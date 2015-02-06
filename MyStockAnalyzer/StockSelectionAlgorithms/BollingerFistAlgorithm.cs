using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyStockAnalyzer.Attributes;
using MyStockAnalyzer.Helpers;
using MyStockAnalyzer.Models;
using MyStockAnalyzer.StockSelectionAlgorithms.Interfaces;

namespace MyStockAnalyzer.StockSelectionAlgorithms
{
    /// <summary>
    /// 布林拳演算法
    /// 邏輯:
    /// 隔日沖戰法，當爆量長紅且布林軌道從收斂轉發散時進場，隔日脫手
    /// 由於隔日沖獲利少，因此只挑選包含權證的個股來增加獲利
    /// 檢查方法:
    /// 前10個交易日布林上下緣再7%以內，今日產生爆量長紅突破20日最高點
    /// </summary>
    [AlgorithmDescription(@"
布林拳演算法
邏輯:
隔日沖戰法，當爆量長紅且布林軌道從收斂轉發散時進場，隔日脫手
由於隔日沖獲利少，因此只挑選包含權證的個股來增加獲利
檢查方法:
前10個交易日布林上下緣再7%以內，今日產生爆量長紅突破20日最高點")]
    public class BollingerFistAlgorithm : IStockSelectionAlgorithm, IStockSelectionConditionDefault, IStockSelectionConditionWarrantOnly
    {
        public string Name
        {
            get { return "布林拳"; }
        }

        public List<StockSelectionResult> GetSelectionResult(List<StockChartData> stockPriceList, DateTime checkBgn, DateTime checkEnd)
        {
            List<StockSelectionResult> result = new List<StockSelectionResult>();
            for (DateTime date = checkBgn; date <= checkEnd; date = date.AddDays(1))
            {
                // 該日期沒股價資訊則跳過
                if (stockPriceList.Where(x => x.PriceToday.Date == date.Date).Count() == 0)
                {
                    continue;
                }

                StockChartData currentDatePrice = stockPriceList.Where(x => x.PriceToday.Date == date).First();

                if (currentDatePrice.ChartIdx < 30)
                {
                    continue;
                }

                // 量必須為5日均量的1.5倍以上為爆量
                if (currentDatePrice.PriceToday.Amount < currentDatePrice.VMA5 * 1.5m) 
                {
                    continue;
                }

                // 漲幅必須大於3%
                if ((currentDatePrice.PriceToday.Close - currentDatePrice.PriceYesterday.Close) / currentDatePrice.PriceYesterday.Close <= 0.03m) 
                {
                    continue;
                }

                // 漲停買不到，跳過
                if (currentDatePrice.IsLimitUp)
                {
                    continue;
                }

                List<StockChartData> stock10Days = StockAnalysisHelper.GetNDaysChart(stockPriceList, currentDatePrice.ChartIdx -1, 10).ToList();

                // 10日內最高點
                if (currentDatePrice.PriceToday.Close > stock10Days.Select(x => x.PriceToday.Close).Max())
                {
                    // 10日內布林上下緣在7%以內
                    bool chk = true;
                    foreach (StockChartData data in stock10Days)
                    {
                        if (((data.BBUB - data.BBLB) / data.BBLB) > 0.07m)
                        {
                            chk = false;
                        }
                    }

                    if (chk)
                    {
                        StockChartData nextDayData = StockAnalysisHelper.GetNextNDaysChart(stockPriceList, currentDatePrice.ChartIdx, 1);
                        result.Add(new StockSelectionResult()
                        {
                            Date = currentDatePrice.PriceToday.Date,
                            Memo = String.Format("布林拳; 布林平均: {0}%;漲幅: {1}%;爆量: {2}倍; 今日收盤: {3}; 明日開盤: {4}", 
                                (stock10Days.Select(x => (x.BBUB - x.BBLB) / x.BBLB).Average()* 100m).ToString("0.00"),
                                (((currentDatePrice.PriceToday.Close - currentDatePrice.PriceYesterday.Close) / currentDatePrice.PriceYesterday.Close) * 100m).ToString("0.00"),
                                (currentDatePrice.PriceToday.Amount / currentDatePrice.VMA5).ToString("0.00"),
                                currentDatePrice.PriceToday.Close.ToString("0.00"),
                                nextDayData == null ? "0.00": nextDayData.PriceToday.Open.ToString("0.00")
                            )
                        });
                    }
                }
                
            }



            return result;
        }
    }
}
