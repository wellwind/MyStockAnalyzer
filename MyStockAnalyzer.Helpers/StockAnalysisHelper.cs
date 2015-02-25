using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyStockAnalyzer.Classes;

namespace MyStockAnalyzer.Helpers
{
    public class StockAnalysisHelper
    {
        /// <summary>
        /// 取得基本分析指標資料
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static List<StockChartData> StockPriceDataToChart(List<StockPrice> source)
        {
            List<StockChartData> result = new List<StockChartData>();
            int idx = 0;
            StockPrice priceYesterday = new StockPrice();
            foreach (StockPrice priceData in source.OrderBy(s => s.Date))
            {
                ++idx;
                StockChartData chartDataToday = new StockChartData();
                chartDataToday.PriceToday = priceData;
                if (idx > 1)
                {
                    chartDataToday.PriceYesterday = priceYesterday;
                }
                chartDataToday.ChartIdx = idx;

                result.Add(chartDataToday);

                processTechnicalAnalysisIndicators(result, idx, chartDataToday);

                priceYesterday = chartDataToday.PriceToday;
            }

            return result;
        }

        private static void processTechnicalAnalysisIndicators(List<StockChartData> result, int idx, StockChartData chartDataToday)
        {
            calculateMovingAverage(result, idx, chartDataToday);

            calculateKDValue(result, idx, chartDataToday);

            calculateBBand(result, idx, chartDataToday);
        }

        private static void calculateBBand(List<StockChartData> result, int idx, StockChartData chartDataToday)
        {
            if (idx >= 20)
            {
                decimal stdavg = MathHelper.CaculateStdAvg(GetNDaysChart(result, idx, 20).Select(x => x.PriceToday.Close).ToArray());
                chartDataToday.BBUB = chartDataToday.MA20 + stdavg * 2;
                chartDataToday.BBLB = chartDataToday.MA20 - stdavg * 2;
            }
        }

        private static void calculateKDValue(List<StockChartData> result, int idx, StockChartData chartDataToday)
        {
            if (idx >= 9)
            {
                List<StockChartData> charts = GetNDaysChart(result, idx, 9).ToList();
                decimal max = charts.Select(x => x.PriceToday.High).Max();
                decimal min = charts.Select(x => x.PriceToday.Low).Min();
                if (max == min)
                {
                    chartDataToday.RSV = 50;
                }
                else
                {
                    chartDataToday.RSV = ((chartDataToday.PriceToday.Close - min) / (max - min)) * 100;
                }

                chartDataToday.KValue = (result.Where(x => x.ChartIdx == idx - 1).Single().KValue * 2 / 3) + (chartDataToday.RSV / 3);
                chartDataToday.DValue = (result.Where(x => x.ChartIdx == idx - 1).Single().DValue * 2 / 3) + (chartDataToday.KValue / 3);
            }
            else
            {
                chartDataToday.RSV = 50;
                chartDataToday.KValue = 50;
                chartDataToday.DValue = 50;
            }
        }

        private static void calculateMovingAverage(List<StockChartData> result, int idx, StockChartData chartDataToday)
        {
            if (idx >= 5)
            {
                chartDataToday.MA5 = GetNDaysChart(result, idx, 5).Select(x => x.PriceToday.Close).Average();
                chartDataToday.VMA5 = GetNDaysChart(result, idx, 5).Select(x => Convert.ToDecimal(x.PriceToday.Amount)).Average();
            }
            if (idx >= 10)
            {
                chartDataToday.MA10 = GetNDaysChart(result, idx, 10).Select(x => x.PriceToday.Close).Average();
                chartDataToday.VMA10 = GetNDaysChart(result, idx, 10).Select(x => Convert.ToDecimal(x.PriceToday.Amount)).Average();
            }
            if (idx >= 20)
            {
                chartDataToday.MA20 = GetNDaysChart(result, idx, 20).Select(x => x.PriceToday.Close).Average();
                chartDataToday.VMA20 = GetNDaysChart(result, idx, 20).Select(x => Convert.ToDecimal(x.PriceToday.Amount)).Average();
            }
            if (idx >= 60)
            {
                chartDataToday.MA60 = GetNDaysChart(result, idx, 60).Select(x => x.PriceToday.Close).Average();
            }
            if (idx >= 120)
            {
                chartDataToday.MA120 = GetNDaysChart(result, idx, 120).Select(x => x.PriceToday.Close).Average();
            }
        }

        public static IEnumerable<StockChartData> GetNDaysChart(List<StockChartData> list, int currentChartIdx, int range)
        {
            return list.Where(x => x.ChartIdx <= currentChartIdx && x.ChartIdx >= currentChartIdx - range +1);
        }

        public static StockChartData GetNextNDaysChart(List<StockChartData> list, int currentChartIdx, int range)
        {
            return list.Where(x => x.ChartIdx == currentChartIdx + range).FirstOrDefault();
        }


    }
}
