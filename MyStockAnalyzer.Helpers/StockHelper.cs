using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MyStockAnalyzer.Classes;
using Newtonsoft.Json;

namespace MyStockAnalyzer.Helpers
{
    public class StockHelper
    {
        public DateTime LastGetStockDate { get { return DateTime.Now; } set { } }

        /// <summary>
        /// 下載股價資訊
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="bgnDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<MyStockAnalyzer.Classes.StockPrice> GetStockPriceDataList(MyStockAnalyzer.Classes.StockData stock, DateTime bgnDate, DateTime endDate)
        {
            List<MyStockAnalyzer.Classes.StockPrice> result = new List<MyStockAnalyzer.Classes.StockPrice>();
            // 列舉每個月分出來
            for (DateTime fetchDate = bgnDate; fetchDate <= endDate; fetchDate = fetchDate.AddMonths(1))
            {
                // 抓取股票價格
                List<MyStockAnalyzer.Classes.StockPrice> stockPrices = downloadStockPriceData(stock, fetchDate, stock.Class == "上市" ? "1" : "2");
                result.AddRange(stockPrices.Where(s => s.Date >= bgnDate && s.Date <= endDate));
            }

            return result;
        }

        /// <summary>
        /// 取得股票清單
        /// </summary>
        /// <returns></returns>
        public List<StockData> GetStockDataList()
        {
            List<StockData> result = new List<StockData>();
            // 下載上市股票代碼
            result.AddRange(downloadStockDataList(ConfigHelper.StockListUrl1));
            // 下載上櫃股票代碼
            result.AddRange(downloadStockDataList(ConfigHelper.StockListUrl2));

            // 下載權證標的股票
            List<string> warrantTargetIds = downloadWarrantTargetStockAndETFIds();
            foreach (string id in warrantTargetIds)
            {
                var dat = result.Where(x => x.StockId == id);
                if (dat.Count() > 0)
                {
                    dat.Single().WarrantTarget = "Y";
                }
            }
            return result;
        }

        public List<StockPrice> GetStockRealTimePrice(List<StockData> stockList, DateTime date)
        {
            List<StockPrice> result = new List<StockPrice>();

            // 先處理要查詢的字串
            List<string> queryStocks = new List<string>();
            foreach (StockData stock in stockList)
            {
                if (stock.Class == "上櫃")
                {
                    queryStocks.Add(String.Format("otc_{0}.tw_{1}", stock.StockId, date.ToString("yyyyMMdd")));
                }
                else
                {
                    queryStocks.Add(String.Format("tse_{0}.tw_{1}", stock.StockId, date.ToString("yyyyMMdd")));
                }
            }

            // 下載json
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            string json = wc.DownloadString(String.Format(ConfigHelper.StockRealDataUrl, String.Join("|", queryStocks.ToArray()), date.ToString("yyyyMMdd")));

            // 分析json資料
            StockRealData realData = JsonConvert.DeserializeObject<StockRealData>(json);
            if (realData.msgArray.Count() > 0)
            {
                foreach (Msgarray msg in realData.msgArray)
                {
                    StockPrice price = new StockPrice();
                    price.StockId = msg.c.Trim();
                    price.Date = date;// Convert.ToDateTime(String.Format("{0} {1}", date.ToString("yyyy/MM/dd"), realData.queryTime.sysTime));
                    price.Open = Convert.ToDecimal(msg.o);
                    price.High = Convert.ToDecimal(msg.h);
                    price.Low = Convert.ToDecimal(msg.l);
                    price.Close = Convert.ToDecimal(msg.z);
                    price.Amount = Convert.ToInt32(msg.v);

                    result.Add(price);
                }
            }
            return result;
        }

        /// <summary>
        /// 下載股票名稱資訊
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private List<StockData> downloadStockDataList(string url)
        {
            List<StockData> result = new List<StockData>();

            WebClient wc = new WebClient();
            string text = wc.DownloadString(url);
            string[] data = text.Split(new string[] { "</table>" }, StringSplitOptions.RemoveEmptyEntries);

            string dataListText = HtmlRemovalHelper.StripTagsCharArray(data[1].Replace("</tr>", "[NR]</tr>").Replace("</td>", "[TAB]"));
            string[] dataList = dataListText.Split(new string[] { "[NR]" }, StringSplitOptions.RemoveEmptyEntries);

            string currentType = "";
            foreach (string line in dataList.Skip(1))
            {
                string[] fields = line.Split(new string[] { "[TAB]" }, StringSplitOptions.RemoveEmptyEntries);
                if (fields.Count() == 1)
                {
                    if (line.Contains("股票") || line.Contains("ETF"))
                    {
                        currentType = fields[0].Trim();
                    }
                    else
                    {
                        currentType = "";
                    }
                }
                else if(!String.IsNullOrEmpty(currentType))
                {
                    string[] fields2 = line.Split(new string[] { "[TAB]" }, StringSplitOptions.None);
                    StockData stockData = new StockData();
                    stockData.StockId = fields2[0].Split(new string[] { " ", "\t", "　" }, StringSplitOptions.None).First();
                    stockData.StockName = fields2[0].Split(new string[] { " ", "\t", "　" }, StringSplitOptions.None).Last();
                    stockData.Class = fields2[3];
                    stockData.Industry = String.IsNullOrEmpty(fields2[4]) ? currentType : fields2[4];
                    result.Add(stockData);
                }
            }
            return result;
        }

        /// <summary>
        /// 下載股票與ETF可為權證標的
        /// </summary>
        /// <returns></returns>
        private List<string> downloadWarrantTargetStockAndETFIds()
        {
            List<string> result = new List<string>();
            // 上市ETF權證標的
            result.AddRange(downloadWarrantTargetETFStockIds(ConfigHelper.WarrantTargetETFUrl1));
            // 上櫃ETF權證標的
            result.AddRange(downloadWarrantTargetETFStockIds(ConfigHelper.WarrantTargetETFUrl2));
            // 上市股票權證標的
            result.AddRange(downloadWarrantTargetStockIds(ConfigHelper.WarrantTargetStockUrl1));
            // 上櫃股票權證標的
            result.AddRange(downloadWarrantTargetStockIds(ConfigHelper.WarrantTargetStockUrl2));
            return result;
        }

        /// <summary>
        /// 下載上市櫃ETF可為權證標的
        /// </summary>
        /// <param name="warrantTargetETFUrl"></param>
        /// <returns></returns>
        private List<string> downloadWarrantTargetETFStockIds(string warrantTargetETFUrl)
        {
            List<string> result = new List<string>();
            WebClient wc = new WebClient();
            string htmlEtf = wc.DownloadString(warrantTargetETFUrl);
            string[] tmp = htmlEtf.Split(new string[] { "<TR class='even'>", "<TR class='odd'>" }, StringSplitOptions.None);
            foreach (string row in tmp.Skip(1))
            {
                string[] fields = row.Split(new string[] { "<TD style='text-align:left !important;'>", "<TD>", "</TD>", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
                if (fields.Count() > 0)
                {
                    string etfId = fields[0].Replace("&nbsp;", "").Trim();
                    if (!result.Contains(etfId))
                    {
                        result.Add(etfId);
                    }
                }
            }
            return result;
        }
        
        /// <summary>
        /// 下載上市櫃股票可為權證標的
        /// </summary>
        /// <param name="warrantTargetUrl"></param>
        /// <returns></returns>
        private List<string> downloadWarrantTargetStockIds(string warrantTargetUrl)
        {
            List<string> result = new List<string>();
            WebClient wc = new WebClient();
            // 找到最近更新的權證標的路徑
            string html = wc.DownloadString(warrantTargetUrl);
            string path = html.Split(new string[] { "<select id='t111sb01' name='t111sb01' onChange='window.open(t111sb01.value);'>" }, StringSplitOptions.None)[1]
                .Split(new string[] { "<option value='", "'>" }, StringSplitOptions.None)[1];

            string html2 = wc.DownloadString(String.Format(ConfigHelper.WarrantTargetUrlBase, path));
            string [] sections = html2.Split(new string[] {"<table ", "</table>"}, StringSplitOptions.None);
            foreach (string section in sections)
            {
                if (section.Contains("<colgroup>"))
                {
                    string[] fields = section.Split(new string[] { "<tr><td>&nbsp;", "</td><td>&nbsp;", "</td></tr>", "\r", "\n" }, StringSplitOptions.None).Skip(3).Where(x => !String.IsNullOrEmpty(x)).ToArray();
                    int idx = 0;
                    foreach (string field in fields)
                    {
                        ++idx;
                        if (idx % 2 == 1)
                        {
                            if (!result.Contains(field))
                            {
                                result.Add(field);
                            }
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 從網路直接下載上市櫃股票價格檔並解析
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="fetchDate"></param>
        /// <param name="type">1: 上市, 2: 上櫃</param>
        /// <returns></returns>
        private List<MyStockAnalyzer.Classes.StockPrice> downloadStockPriceData(MyStockAnalyzer.Classes.StockData stock, DateTime fetchDate, string type)
        {
            List<MyStockAnalyzer.Classes.StockPrice> result = new List<MyStockAnalyzer.Classes.StockPrice>();
            string downloadUrl = String.Format(type == "1" ? ConfigHelper.StockPriceUrl1 : ConfigHelper.StockPriceUrl2,
                type == "1" ? fetchDate.Year.ToString() : (fetchDate.Year - 1911).ToString("000"), fetchDate.Month.ToString("00"), stock.StockId);

            WebClient wc = new WebClient();
            string csvText = wc.DownloadString(downloadUrl);
            string[] lines = csvText.Split(new string[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines.Skip(type == "1" ? 2 : 5))
            {
                // 上櫃檔案最後一行跳過
                if (type == "2" && line.Equals(lines.Last())) continue;

                string[] fields = CSVHelper.ParseCSVLine(line, ",");
                if (fields.Length == 9)
                {
                    if (fields[3].Equals("--") || fields[4].Equals("--") || fields[5].Equals("--") || fields[6].Equals("--"))
                    {
                        continue;
                    }

                    string[] strDate = (fields[0].Trim().StartsWith("1") ? fields[0].Trim().Substring(0, 9) : fields[0].Trim().Substring(0, 8)).Split(new string[] {"/"}, StringSplitOptions.None);
                    int year = Convert.ToInt32(strDate[0]);
                    if(year < 1000) year += 1911;
                    DateTime date = new DateTime(year, Convert.ToInt32(strDate[1]), Convert.ToInt32(strDate[2]));
                    // date = date.AddYears(1911);

                    StockPrice priceData = new StockPrice();
                    priceData.StockId = stock.StockId;
                    priceData.Date = date;

                    int amount = Convert.ToInt32(fields[1].Replace(",", ""));

                    if (amount != 0)
                    {
                        if (type == "1")
                        {
                            priceData.Amount = amount / 1000;
                        }
                        else if (type == "2") // 上櫃欄位直接是千股
                        {
                            priceData.Amount = amount;
                        }

                        priceData.Open = Convert.ToDecimal(fields[3].Replace(",", ""));
                        priceData.High = Convert.ToDecimal(fields[4].Replace(",", ""));
                        priceData.Low = Convert.ToDecimal(fields[5].Replace(",", ""));
                        priceData.Close = Convert.ToDecimal(fields[6].Replace(",", ""));

                        result.Add(priceData);
                    }
                }
            }

            return result;
        }
    }
}
