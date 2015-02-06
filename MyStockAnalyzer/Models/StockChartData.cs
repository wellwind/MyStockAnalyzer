using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStockAnalyzer.Models
{
    public class StockChartData
    {
        /// <summary>
        /// 第幾根K線
        /// </summary>
        public int ChartIdx { get; set; }

        public StockPrice PriceYesterday { get; set; }
        public StockPrice PriceToday { get; set; }

        #region 技術分析屬性
        public decimal MA5 { get; set; }
        public decimal MA10 { get; set; }
        public decimal MA20 { get; set; }
        public decimal MA60 { get; set; }
        public decimal MA120 { get; set; }

        public decimal VMA5 { get; set; }
        public decimal VMA10 { get; set; }
        public decimal VMA20 { get; set; }

        public decimal RSV { get; set; }
        public decimal KValue { get; set; }
        public decimal DValue { get; set; }

        /// <summary>
        /// 20日收盤標準差
        /// </summary>
        public decimal StdAvg20 { get; set; }
        /// <summary>
        /// 布林通道上緣
        /// </summary>
        public decimal BBUB { get; set; }
        /// <summary>
        /// 布林通道下緣
        /// </summary>
        public decimal BBLB { get; set; }
        #endregion

        #region 線圖分析屬性
    
        /// <summary>
        /// 取得漲停板的價位
        /// </summary>
        public decimal LimitUpPrice
        {
            get
            {
                return getPriceLimitUpOrDown("Up");
            }
        }

        /// <summary>
        /// 取得跌停板的價位
        /// </summary>
        public decimal LimitDownPrice
        {
            get
            {
                return getPriceLimitUpOrDown("Down");
            }
        }

        /// <summary>
        /// 是否漲停板
        /// </summary>
        public bool IsLimitUp
        {
            get
            {
                return PriceToday.Close == LimitUpPrice;
            }
        }

        /// <summary>
        /// 是否跌停板
        /// </summary>
        public bool IsLimitDown
        {
            get
            {
                return PriceToday.Close == LimitDownPrice;
            }
        }

        /// <summary>
        /// 是否漲停or跌停
        /// </summary>
        public bool IsLimitUpOrDown
        {
            get { return IsLimitUp || IsLimitDown; }
        }

        #endregion

        private decimal getPriceLimitUpOrDown(string limitType)
        {
            // reference: http://stock7.0123456789.tw/

            double price = PriceYesterday == null ? Convert.ToDouble(PriceToday.Close) : Convert.ToDouble(PriceYesterday.Close);
            double limitUp = price * 1.07;
            double limitDown = price * 0.93;
            double STOCKUP = 0, STOCKDW = 0;
            if (limitUp < 10 && limitDown < 10)
            {
                STOCKUP = ((Math.Floor((Math.Floor(limitUp * 100) * 100))) / 100) / 100;
                STOCKDW = ((Math.Floor((Math.Ceiling(limitDown * 100) * 100))) / 100) / 100;
            }
            else if (limitUp > 10 && limitDown < 10)
            {
                STOCKUP = ((Math.Floor(((Math.Floor(limitUp / 0.05) * 0.05) * 100) * 100)) / 100) / 100;
                STOCKDW = ((Math.Floor((Math.Ceiling(limitDown * 100) * 100))) / 100) / 100;
            }
            else if (limitUp >= 10 && limitDown >= 10 && limitUp <= 50 && limitDown < 50)
            {
                STOCKUP = ((Math.Floor(((Math.Floor(limitUp / 0.05) * 0.05) * 100) * 100)) / 100) / 100;
                STOCKDW = ((Math.Floor(((Math.Ceiling(limitDown / 0.05) * 0.05) * 100) * 100)) / 100) / 100;
            }
            else if (limitUp >= 50 && limitDown >= 50 && limitUp < 100 && limitDown < 100)
            {
                STOCKUP = ((Math.Floor(((Math.Floor(limitUp / 0.1) * 0.1) * 100) * 100)) / 100) / 100;
                STOCKDW = ((Math.Floor(((Math.Ceiling(limitDown / 0.1) * 0.1) * 100) * 100)) / 100) / 100;
            }
            else if (limitUp >= 50 && limitDown < 50)
            {
                STOCKUP = ((Math.Floor(((Math.Floor(limitUp / 0.1) * 0.1) * 100) * 100)) / 100) / 100;
                STOCKDW = (Math.Floor((Math.Ceiling(limitDown / 0.05) * 0.05) * 100)) / 100;
            }
            else if (limitUp >= 100 && limitDown >= 100 && limitUp < 1000 && limitDown < 1000)
            {
                STOCKUP = ((Math.Floor(((Math.Floor(limitUp / 0.5) * 0.5) * 100) * 100)) / 100) / 100;
                STOCKDW = ((Math.Floor(((Math.Ceiling(limitDown / 0.5) * 0.5) * 100) * 100)) / 100) / 100;
            }
            else if (limitUp >= 100 && limitDown < 100)
            {
                STOCKUP = ((Math.Floor(((Math.Floor(limitUp / 0.5) * 0.5) * 100) * 100)) / 100) / 100;
                STOCKDW = ((Math.Floor(((Math.Ceiling(limitDown / 0.1) * 0.1) * 100) * 100)) / 100) / 100;
            }
            else if (limitUp >= 1000 && limitDown <= 1000)
            {
                STOCKUP = ((Math.Floor(((Math.Floor(limitUp / 5) * 5) * 100) * 100)) / 100) / 100;
                STOCKDW = ((Math.Floor(((Math.Ceiling(limitDown / 5) * 5) * 100) * 100)) / 100) / 100;
            }
            else if (limitUp >= 1000 && limitDown >= 1000)
            {
                STOCKUP = ((Math.Floor(((Math.Floor(limitUp / 5) * 5) * 100) * 100)) / 100) / 100;
                STOCKDW = ((Math.Floor(((Math.Ceiling(limitDown / 5) * 5) * 100) * 100)) / 100) / 100;
            }

            if (limitType.ToUpper() == "UP")
            {
                return Convert.ToDecimal(STOCKUP);
            }
            else
            {
                return Convert.ToDecimal(STOCKDW);
            }
        }

    }
}
