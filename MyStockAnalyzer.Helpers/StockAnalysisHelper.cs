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
                StockChartData chartData = new StockChartData();
                chartData.PriceToday = priceData;
                if (idx > 1)
                {
                    chartData.PriceYesterday = priceYesterday;
                }
                chartData.ChartIdx = idx;

                result.Add(chartData);

                #region 計算MA & VMA
                if (idx >= 5)
                {
                    chartData.MA5 = GetNDaysChart(result, idx, 5).Select(x => x.PriceToday.Close).Average();
                    chartData.VMA5 = GetNDaysChart(result, idx, 5).Select(x => Convert.ToDecimal(x.PriceToday.Amount)).Average();
                }
                if (idx >= 10)
                {
                    chartData.MA10 = GetNDaysChart(result, idx, 10).Select(x => x.PriceToday.Close).Average();
                    chartData.VMA10 = GetNDaysChart(result, idx, 10).Select(x => Convert.ToDecimal(x.PriceToday.Amount)).Average();
                }
                if (idx >= 20)
                {
                    chartData.MA20 = GetNDaysChart(result, idx, 20).Select(x => x.PriceToday.Close).Average();
                    chartData.VMA20 = GetNDaysChart(result, idx, 20).Select(x => Convert.ToDecimal(x.PriceToday.Amount)).Average();
                }
                if (idx >= 60)
                {
                    chartData.MA60 = GetNDaysChart(result, idx, 60).Select(x => x.PriceToday.Close).Average();
                }
                if (idx >= 120)
                {
                    chartData.MA120 = GetNDaysChart(result, idx, 120).Select(x => x.PriceToday.Close).Average();
                }
                #endregion

                #region 計算RSV, K, D
                if (idx >= 9)
                {
                    List<StockChartData> charts = GetNDaysChart(result, idx, 9).ToList();
                    decimal max = charts.Select(x => x.PriceToday.High).Max();
                    decimal min = charts.Select(x => x.PriceToday.Low).Min();
                    if (max == min)
                    {
                        chartData.RSV = 50;
                    }
                    else
                    {
                        chartData.RSV = ((chartData.PriceToday.Close - min) / (max - min)) * 100;
                    }

                    chartData.KValue = (result.Where(x => x.ChartIdx == idx - 1).Single().KValue * 2 / 3) + (chartData.RSV / 3);
                    chartData.DValue = (result.Where(x => x.ChartIdx == idx - 1).Single().DValue * 2 / 3) + (chartData.KValue / 3);
                }
                else
                {
                    chartData.RSV = 50;
                    chartData.KValue = 50;
                    chartData.DValue = 50;
                }
                #endregion

                #region 計算布林通道
                if (idx >= 20)
                {
                    decimal stdavg = MathHelper.CaculateStdAvg(GetNDaysChart(result, idx, 20).Select(x => x.PriceToday.Close).ToArray());
                    chartData.BBUB = chartData.MA20 + stdavg * 2;
                    chartData.BBLB = chartData.MA20 - stdavg * 2;
                }
                #endregion
                priceYesterday = chartData.PriceToday;
            }

            return result;
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
