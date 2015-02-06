using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStockAnalyzer.Models
{
    public class StockModel
    {
        StockEntities _db;
        public StockModel()
        {
            _db = new StockEntities();
        }

        /// <summary>
        /// 取得所有股票名稱資訊
        /// </summary>
        /// <returns></returns>
        public List<StockData> GetAllStockData()
        {
            return GetAllStockData(false);
        }

        /// <summary>
        /// 取得所有股票名稱資訊
        /// </summary>
        /// <param name="warrantOnly">只取出有權證的股票</param>
        /// <returns></returns>
        public List<StockData> GetAllStockData(bool warrantOnly)
        {
            if (warrantOnly)
            {
                return (from s in _db.StockData where s.WarrantTarget == "Y" orderby s.Class, s.StockId select s).ToList();
            }
            else
            {
                return (from s in _db.StockData orderby s.Class, s.StockId select s).ToList();
            }
        }

        public List<StockData> GetStockData(string[] stockIds)
        {
            return (from s in _db.StockData where stockIds.Contains(s.StockId) orderby s.Class, s.StockId select s).ToList();
        }

        public StockData GetStockDataById(string stockId)
        {
            return (from s in _db.StockData where stockId == s.StockId orderby s.Class, s.StockId select s).SingleOrDefault();
        }

        #region 取得股價資訊
        /// <summary>
        /// 取得所有的股票價格資訊
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<StockPrice>> GetStockPriceData()
        {
            IQueryable<StockPrice> data = from s in _db.StockPrice select s;
            return queryStockPriceDataListToDictionary(data);
        }

        /// <summary>
        /// 依日期取得所有的股票價格資訊
        /// </summary>
        /// <param name="dtBgn"></param>
        /// <returns></returns>
        public Dictionary<string, List<StockPrice>> GetStockPriceData(DateTime dtBgn)
        {
            IQueryable<StockPrice> data = from s in _db.StockPrice where s.Date >= dtBgn.Date select s;
            return queryStockPriceDataListToDictionary(data);
        }

        /// <summary>
        /// 依日期起訖取得所有的股票價格資訊
        /// </summary>
        /// <param name="dtBgn"></param>
        /// <param name="dtEnd"></param>
        /// <returns></returns>
        public Dictionary<string, List<StockPrice>> GetStockPriceData(DateTime dtBgn, DateTime dtEnd)
        {
            IQueryable<StockPrice> data = from s in _db.StockPrice where s.Date >= dtBgn.Date && s.Date <= dtEnd.Date select s;
            return queryStockPriceDataListToDictionary(data);
        }

        /// <summary>
        /// 依股票代碼取得股票價格資訊
        /// </summary>
        /// <param name="stockId"></param>
        /// <returns></returns>
        public Dictionary<string, List<StockPrice>> GetStockPriceData(string[] stockId)
        {
            IQueryable<StockPrice> data = from s in _db.StockPrice where stockId.Contains(s.StockId) select s;
            return queryStockPriceDataListToDictionary(data);
        }

        /// <summary>
        /// 依股票代碼及時間取得股票價格資訊
        /// </summary>
        /// <param name="stockId"></param>
        /// <param name="dtBgn"></param>
        /// <returns></returns>
        public Dictionary<string, List<StockPrice>> GetStockPriceData(string[] stockId, DateTime dtBgn)
        {
            IQueryable<StockPrice> data = from s in _db.StockPrice where stockId.Contains(s.StockId) && s.Date >= dtBgn.Date select s;
            return queryStockPriceDataListToDictionary(data);
        }

        /// <summary>
        /// 依股票代碼及時間取得股票價格資訊
        /// </summary>
        /// <param name="stockId"></param>
        /// <param name="dtBgn"></param>
        /// <param name="dtEnd"></param>
        /// <returns></returns>
        public Dictionary<string, List<StockPrice>> GetStockPriceData(string[] stockId, DateTime dtBgn, DateTime dtEnd)
        {
            IQueryable<StockPrice> data = (from s in _db.StockPrice where stockId.Contains(s.StockId) && s.Date >= dtBgn.Date && s.Date <= dtEnd.Date select s);
            return queryStockPriceDataListToDictionary(data);
        }

        private Dictionary<string, List<StockPrice>> queryStockPriceDataListToDictionary(IQueryable<StockPrice> data)
        {
            Dictionary<string, List<StockPrice>> result = new Dictionary<string, List<StockPrice>>();
            foreach (StockPrice price in data)
            {
                if (!result.ContainsKey(price.StockId))
                {
                    result.Add(price.StockId, new List<StockPrice>());
                }

                result[price.StockId].Add(price);
            }

            return result;
        }

        #endregion

        /// <summary>
        /// 取得可為權證標的的股票
        /// </summary>
        /// <returns></returns>
        public List<StockData> GetWarrantTargetStockData()
        {
            return (from s in _db.StockData orderby s.StockId where s.WarrantTarget == "Y" select s).ToList();
        }

        /// <summary>
        /// 更新股票代碼資訊
        /// </summary>
        /// <param name="stockDataList"></param>
        public void UpdateStockList(List<StockData> stockDataList)
        {
            DateTime current = DateTime.Now;
            string[] stockIds = stockDataList.Select(x => x.StockId).ToArray();
            // 1. 先找出包含在資料庫的部分
            var existStockData = from s in _db.StockData where stockIds.Contains(s.StockId) select s;
            foreach (StockData stock in existStockData)
            {
                // 內容不一樣則更新
                StockData compareStock = stockDataList.Where(x => x.StockId == stock.StockId).First();
                if (!compareStock.Equals(stock))
                {
                    stock.StockName = compareStock.StockName;
                    stock.Class = compareStock.Class;
                    stock.Industry = compareStock.Industry;
                    stock.WarrantTarget = compareStock.WarrantTarget;
                    stock.Updated = current;
                    _db.Entry(stock).State = System.Data.Entity.EntityState.Modified;
                }
            }

            // 2. 將不在資料庫的部分新增
            string[] existStockIds = existStockData.Select(x => x.StockId).ToArray();
            var nonExistStockData = from s in stockDataList where !existStockIds.Contains(s.StockId) select s;
            foreach (StockData stock in nonExistStockData)
            {
                stock.Updated = current;
                _db.StockData.Add(stock);
            }

            _db.SaveChanges();
        }

        /// <summary>
        /// 更新股價資訊
        /// </summary>
        /// <param name="stockPriceList"></param>
        public void UpdateStockPriceList(List<StockPrice> stockPriceList)
        {
            if (stockPriceList.Count() == 0) return;

            // 先將要檢查的範圍資料全部撈出來, 以免每筆都要查詢拖累效能
            //DateTime minDate = stockPriceList.Select(x => x.Date).Min();
            //DateTime maxDate = stockPriceList.Select(x => x.Date).Max();
            //string[] stockIds = stockPriceList.Select(x => x.StockId).ToArray();
            //var checkExist = (from s in _db.StockPrice where stockIds.Contains(s.StockId) && s.Date >= minDate && s.Date <= maxDate select s).ToList();

            //foreach (StockPrice stock in stockPriceList)
            //{
            //    //var checkSingleStock = from s in checkExist where s.StockId == stock.StockId && s.Date == stock.Date select s;
            //    //if (!checkSingleStock.Any())
            //    //{
            //    //    _db.StockPrice.Add(stock);
            //    //}
            //}
            _db.StockPrice.AddRange(stockPriceList);
            _db.SaveChanges();
        }

        /// <summary>
        /// 將指定時段內的股價資訊刪除
        /// </summary>
        /// <param name="dtBgn"></param>
        /// <param name="dtEnd"></param>
        public void DeleteStockPriceByDateRange(DateTime dtBgn, DateTime dtEnd)
        {
            var dat = from s in _db.StockPrice where s.Date >= dtBgn && s.Date <= dtEnd select s;
            _db.StockPrice.RemoveRange(dat);
            // _db.Database.ExecuteSqlCommand(String.Format("DELETE FROM StockPrice WHERE [Date] >= '{0}' AND [Date] <= '{1}'", dtBgn.ToString("yyyy-MM-dd"), dtEnd.ToString("yyyy-MM-dd")));
            _db.SaveChanges();
        }
    }
}