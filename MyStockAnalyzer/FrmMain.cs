using MyStockAnalyzer.Classes;
using MyStockAnalyzer.Helpers;
using MyStockAnalyzer.Models;
using MyStockAnalyzer.StockSelectionAlgorithms;
using MyStockAnalyzer.StockSelectionAlgorithms.Helpers;
using MyStockAnalyzer.StockSelectionAlgorithms.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using StockDividend = MyStockAnalyzer.Classes.StockDividend;
using ThreadState = System.Threading.ThreadState;

namespace MyStockAnalyzer
{
    public partial class FrmMain : Form
    {
        private StockModel model = new StockModel();
        private MemoModel memoModel = new MemoModel();
        private StockHelper stockHelper = new StockHelper();
        private FrmBrowser frmBrowser;

        private List<IStockSelectionAlgorithm> stockSelectionAlgorithms = new List<IStockSelectionAlgorithm>();

        /// <summary>
        /// 下載股價資訊的執行緒
        /// </summary>
        private Thread[] threadDownloadStockPrice = new Thread[10];

        /// <summary>
        /// 存放要更新的股價資訊
        /// </summary>
        private List<MyStockAnalyzer.Classes.StockPrice> waitedUpdateSotckPrice = new List<MyStockAnalyzer.Classes.StockPrice>();

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            LogHelper.DisplayGridView = this.dgvLog;
            dtStockEnd.Value = DateTime.Now;
            dtStockBgn.Value = DateTimeHelper.GetFirstDayOfMonth(DateTime.Now.Year, DateTime.Now.Month);

            lblAlgorithms.Text = String.Empty;
            stockSelectionAlgorithms = StockSelectionAlgorithmHelper.GetDefaultAlgorithms();
            setStockAlgorithmsLabel();

            refreshWarrant();

            txtMemo.Text = memoModel.GetMemo();

            loadStockChart("0050", true);
        }

        private void loadStockChart(string stockId, bool getRealTimeData)
        {
            List<Classes.StockPrice> stockPriceList = model.GetStockPriceData(new string[] { stockId }).First().Value.OrderByDescending(x => x.Date).Take(100).OrderBy(x => x.Date).ToList();

            // List<MyStockAnalyzer.Classes.StockPrice> result = stockHelper.GetStockRealTimePrice
            if (getRealTimeData)
            {
                List<Classes.StockPrice> realTimePrice = stockHelper.GetStockRealTimePrice(new List<Classes.StockData>() { model.GetStockDataById(stockId) }, DateTime.Now.Date);
                if (realTimePrice.Count > 0)
                {
                    stockPriceList.Add(realTimePrice.First());
                }
            }
            List<StockChartData> chartData = StockAnalysisHelper.StockPriceDataToChart(stockPriceList);

            chartKBar.Series.Clear();
            chartKBar.Series.Add("KChart");
            chartKBar.Series[0].ChartType = SeriesChartType.Candlestick;

            chartKBar.Series[0]["PriceUpColor"] = "Red";
            chartKBar.Series[0]["PriceDownColor"] = "LimeGreen";

            foreach (StockChartData data in chartData)
            {
                chartKBar.Series[0].Points.AddXY(data.PriceToday.Date.ToString("yyyy/MM/dd"), (double)data.PriceToday.High, (double)data.PriceToday.Low, (double)data.PriceToday.Open, (double)data.PriceToday.Close);
                chartKBar.Series[0].Points.Last().Color = Color.Black;
            }

            chartKBar.ChartAreas[0].AxisY.Minimum = Math.Floor((double)(chartData.Select(x => x.PriceToday.Low).Min() * 0.98m));
            chartKBar.ChartAreas[0].AxisY.Maximum = Math.Ceiling((double)(chartData.Select(x => x.PriceToday.High).Max() * 1.02m));
        }

        private void setStockAlgorithmsLabel()
        {
            lblAlgorithms.Text = String.Format("({0})", String.Join(";", stockSelectionAlgorithms.Select(x => x.Name).ToArray()));
            toolTips.SetToolTip(lblAlgorithms, lblAlgorithms.Text);
        }

        private void refreshWarrant()
        {
            dgvWarrantStock.Rows.Clear();
            dgvWarrantList.Rows.Clear();

            List<MyStockAnalyzer.Classes.StockData> warrantTargetList = model.GetAllStockData(true);
            foreach (MyStockAnalyzer.Classes.StockData stock in warrantTargetList)
            {
                dgvWarrantStock.Rows.Add(new string[] { stock.StockId, stock.StockName });
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            MyStockAnalyzer.Classes.StockData data = model.GetStockDataById("3086");
            List<MyStockAnalyzer.Classes.StockPrice> result = stockHelper.GetStockRealTimePrice(new List<MyStockAnalyzer.Classes.StockData>() { data }, DateTime.Now.Date);
        }

        private void showChartDialog(string url, string title)
        {
            frmBrowser = new FrmBrowser();
            frmBrowser.Text = title;
            frmBrowser.SetUrl(url);
            frmBrowser.Show();
        }

        #region 更新股票資訊

        private void btnUpdateStockData_Click(object sender, EventArgs e)
        {
            btnUpdateStockData.Enabled = false;

            LogHelper.SetLogMessage("更新股票資訊中...");

            // 1. 更新股票代碼
            LogHelper.SetLogMessage("下載股票代碼");
            List<MyStockAnalyzer.Classes.StockData> stockDataList = stockHelper.GetStockDataList();

            LogHelper.SetLogMessage("更新股票代碼");
            model.UpdateStockList(stockDataList);

            // 2. 更新大盤資訊
            LogHelper.SetLogMessage("更新大盤資訊");

            // 3. 更新ETF成份股
            LogHelper.SetLogMessage("更新ETF成份股");
            updateEtfStocks();

            // 4. 更新個股資訊
            LogHelper.SetLogMessage("更新股票價格資訊");
            // updateAllStockPrice(stockDataList);

            LogHelper.SetLogMessage("完成");

            btnUpdateStockData.Enabled = true;
        }

        private void updateEtfStocks()
        {
            string[] targetId = { "0050", "0051" };
            foreach (var etfId in targetId)
            {
                updateStocksInEtf(etfId);
            }
        }

        private void updateStocksInEtf(string etfId)
        {
            var etfStocks = stockHelper.GetEtfStocks(etfId);
            model.UpdateEtfStocksData(etfId, etfStocks);
        }

        /// <summary>
        /// 擷取並更新股價資料庫
        /// </summary>
        /// <param name="stockDataList"></param>
        private void updateAllStockPrice(List<MyStockAnalyzer.Classes.StockData> stockDataList)
        {
            model.DeleteStockPriceByDateRange(dtStockBgn.Value, dtStockEnd.Value);

            lock (this)
            {
                waitedUpdateSotckPrice.Clear();
            }

            startDownloadAllstockPrice(stockDataList);

            updateStockPriceWhenAllThreadDone();
        }

        private void updateStockPriceWhenAllThreadDone()
        {
            while (!isAllBackgroundWorkerDone())
            {
                Application.DoEvents();
            }
            model.UpdateStockPriceList(waitedUpdateSotckPrice);
        }

        private void startDownloadAllstockPrice(List<MyStockAnalyzer.Classes.StockData> stockDataList)
        {
            foreach (MyStockAnalyzer.Classes.StockData stock in stockDataList)
            {
                do
                {
                    int workNum = getAvailableBackgroundWorkNum();
                    if (workNum != -1)
                    {
                        LogHelper.SetLogMessage(String.Format("(Thread {6}) 抓取股票 {0} {1} {2}/{3} ~ {4}/{5}資料", stock.StockId, stock.StockName,
                            dtStockBgn.Value.Year, dtStockBgn.Value.Month.ToString("00"),
                            dtStockEnd.Value.Year, dtStockEnd.Value.Month.ToString("00"),
                            (workNum + 1).ToString("00")
                            ));

                        threadDownloadStockPrice[workNum].Start(stock);
                        break;
                    }
                } while (true);
            }
        }

        /// <summary>
        /// 執行下載股價資訊執行緒
        /// </summary>
        /// <param name="obj"></param>
        private void threadDownloadStockPrice_Start(object obj)
        {
            if (obj is MyStockAnalyzer.Classes.StockData)
            {
                MyStockAnalyzer.Classes.StockData stock = obj as MyStockAnalyzer.Classes.StockData;
                List<MyStockAnalyzer.Classes.StockPrice> singleStockPrices = stockHelper.GetStockPriceDataList(stock, dtStockBgn.Value.Date, dtStockEnd.Value.Date);
                lock (this)
                {
                    waitedUpdateSotckPrice.AddRange(singleStockPrices);
                }
            }
        }

        /// <summary>
        /// 取得可欲的執行緒index
        /// </summary>
        /// <returns></returns>
        private int getAvailableBackgroundWorkNum()
        {
            for (int i = 0; i < 10; ++i)
            {
                if (threadDownloadStockPrice[i] == null || threadDownloadStockPrice[i].ThreadState == ThreadState.Unstarted || threadDownloadStockPrice[i].ThreadState == ThreadState.Stopped)
                {
                    threadDownloadStockPrice[i] = new Thread(threadDownloadStockPrice_Start);
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// 確認是否所有執行緒皆已完成
        /// </summary>
        /// <returns></returns>
        private bool isAllBackgroundWorkerDone()
        {
            for (int i = 0; i < 10; ++i)
            {
                if (threadDownloadStockPrice[i].ThreadState == ThreadState.Running)
                {
                    return false;
                }
            }
            return true;
        }

        #endregion 更新股票資訊

        #region 選股Tab

        private void linkLblClearLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dgvLog.Rows.Clear();
        }

        private void btnSelection_Click(object sender, EventArgs e)
        {
            if (this.stockSelectionAlgorithms.Count == 0)
            {
                MessageBox.Show("尚未選擇任何選股演算法");
                return;
            }

            dgvSelectionResult.Rows.Clear();

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            LogHelper.SetLogMessage("開始進行選股動作..");

            // 擷取即時資料
            List<MyStockAnalyzer.Classes.StockData> stockData = model.GetAllStockData();
            List<MyStockAnalyzer.Classes.StockPrice> realTimeData = addRealTimeTostockData(stockData);

            startStockSelection(stockData, realTimeData);

            sw.Stop();
            LogHelper.SetLogMessage(String.Format("完成選股，花費 {0} 秒", (sw.ElapsedMilliseconds / 1000).ToString("0.00")));
        }

        private void startStockSelection(List<MyStockAnalyzer.Classes.StockData> stockData, List<MyStockAnalyzer.Classes.StockPrice> realTimeData)
        {
            // 分析股票資料
            foreach (var data in stockData)
            {
                Dictionary<string, List<MyStockAnalyzer.Classes.StockPrice>> stockPrice = model.GetStockPriceData(new string[] { data.StockId }, dtSelectionBgn.Value.Date.AddMonths(-12), dtSelectionEnd.Value.Date);
                foreach (KeyValuePair<string, List<MyStockAnalyzer.Classes.StockPrice>> kvp in stockPrice)
                {
                    // 如果要分析即時資料，將目前抓到的即時資料加入股價資訊中
                    if (chkRealData.Checked && realTimeData.Any(x => x.StockId == kvp.Key))
                    {
                        kvp.Value.AddRange(realTimeData.Where(x => x.StockId == kvp.Key));
                    }
                    List<MyStockAnalyzer.Classes.StockChartData> chartData = StockAnalysisHelper.StockPriceDataToChart(kvp.Value);

                    selectStockByAlgorithms(data, chartData);
                }
            }
        }

        private void selectStockByAlgorithms(MyStockAnalyzer.Classes.StockData data, List<MyStockAnalyzer.Classes.StockChartData> chartData)
        {
            foreach (IStockSelectionAlgorithm algorithm in this.stockSelectionAlgorithms)
            {
                // 當演算法指定只檢查權證標的時, 忽略非權證標的個股
                if (skipIfAlgorithmWarrantOnlyAndStockWithoutWarrant(algorithm, data))
                {
                    continue;
                }

                List<StockSelectionResult> result = algorithm.GetSelectionResult(chartData, dtSelectionBgn.Value.Date, dtSelectionEnd.Value.Date.AddDays(1).AddSeconds(-1));
                foreach (StockSelectionResult ss in result)
                {
                    dgvSelectionResult.Rows.Add(new string[] { ss.Date.ToString("yyyy/MM/dd"), data.StockId, data.StockName, algorithm.Name, data.WarrantTarget, ss.Memo });
                }
            }
        }

        private bool skipIfAlgorithmWarrantOnlyAndStockWithoutWarrant(IStockSelectionAlgorithm algorithm, MyStockAnalyzer.Classes.StockData stockData)
        {
            if (algorithm is IStockSelectionConditionWarrantOnly)
            {
                if (stockData.WarrantTarget == null || !stockData.WarrantTarget.Equals("Y"))
                {
                    return true;
                }
            }

            return false;
        }

        private List<Classes.StockPrice> addRealTimeTostockData(List<MyStockAnalyzer.Classes.StockData> stockData)
        {
            List<MyStockAnalyzer.Classes.StockPrice> realTimeData = new List<MyStockAnalyzer.Classes.StockPrice>();
            if (chkRealData.Checked)
            {
                LogHelper.SetLogMessage(String.Format("下載即時資料"));
                List<MyStockAnalyzer.Classes.StockData> tmp = new List<MyStockAnalyzer.Classes.StockData>();
                foreach (MyStockAnalyzer.Classes.StockData data in stockData)
                {
                    tmp.Add(data);
                    if (tmp.Count >= 50)
                    {
                        realTimeData.AddRange(stockHelper.GetStockRealTimePrice(tmp, DateTime.Now.Date));
                        tmp.Clear();
                    }
                }
                if (tmp.Count() > 0)
                {
                    realTimeData.AddRange(stockHelper.GetStockRealTimePrice(tmp, DateTime.Now.Date));
                }
                tmp.Clear();
            }
            return realTimeData;
        }

        private void linkLblAlgorithms_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmAlgorithm frmAlgorithm = new FrmAlgorithm();
            frmAlgorithm.CurrentAlgorithms = this.stockSelectionAlgorithms;
            frmAlgorithm.ShowDialog();
            if (frmAlgorithm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                this.stockSelectionAlgorithms.Clear();
                this.stockSelectionAlgorithms.AddRange(frmAlgorithm.ReturnedAlgorithms);
                setStockAlgorithmsLabel();
            }
        }

        private void btnSelectionExport_Click(object sender, EventArgs e)
        {
            if (saveCSVDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("時間,代碼,名稱,篩選方法,權證,備註");

                foreach (DataGridViewRow row in dgvSelectionResult.Rows)
                {
                    sb.AppendLine(String.Format("{0},{1},{2},{3},{4},{5}",
                        row.Cells["colSelectionDate"].Value.ToString(), row.Cells["colSelectionStockId"].Value.ToString(), row.Cells["colSelectionStockName"].Value.ToString(),
                        row.Cells["colSelectionMethod"].Value.ToString(), (row.Cells["colSelectionWarrant"].Value == null ? "" : row.Cells["colSelectionWarrant"].Value.ToString()),
                        String.Join(",", row.Cells["colSelectionMemo"].Value.ToString().Split(new string[] { ";", ":" }, StringSplitOptions.None))));
                }

                System.IO.File.WriteAllText(saveCSVDialog.FileName, sb.ToString(), Encoding.UTF8);
                MessageBox.Show("選股資料已匯出");
            }
        }

        private void dgvSelectionResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colSelectionStockId.Index)
            {
                //showChartDialog(String.Format("http://histock.tw/stock/tchart.aspx?no={0}&m=b#twDayK1_pnlChart", dgvSelectionResult.Rows[e.RowIndex].Cells[colSelectionStockId.Name].Value.ToString()),
                //    dgvSelectionResult.Rows[e.RowIndex].Cells[colSelectionStockId.Name].Value.ToString() + "-" + dgvSelectionResult.Rows[e.RowIndex].Cells[colSelectionStockName.Name].Value.ToString());
                loadStockChart(dgvSelectionResult.Rows[e.RowIndex].Cells[colSelectionStockId.Name].Value.ToString(), chkRealData.Checked);
            }
        }

        #endregion 選股Tab

        #region 權證Tab

        private void linkLblWarrantRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            refreshWarrant();
        }

        #endregion 權證Tab

        #region 備註Tab

        private void btnSaveMemo_Click(object sender, EventArgs e)
        {
            memoModel.SaveMemo(txtMemo.Text);
        }

        #endregion 備註Tab

        private void btnGetDividend_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            List<int> years = new List<int>() { 2014, 2013, 2012, 2010, 2009 };

            txtDividendResult.Clear();
            txtDividendResult.Text += getDividendHeader(years) + "\r\n";

            var etfStocks = model.GetEtfStocksData();

            int cnt = 0;
            foreach (var etfStock in etfStocks)
            {
                var stockPrice = model.GetStockPriceData(new string[] { etfStock.StockId });
                var stockData = model.GetStockData(new string[] { etfStock.StockId });
                Debug.WriteLine("{0}\t{1}", (++cnt).ToString("00"), etfStock.StockId);

                var stockDividendsResult = stockHelper.GetStockDividends(etfStock.StockId);
                string line = "";
                decimal currentPrice = stockPrice[etfStock.StockId].OrderByDescending(stock => stock.Date).First().Close;

                line = String.Format("{0}\t{1}\t{2}\t{3}\t", etfStock.EtfId, etfStock.StockId,
                    stockData.First(stock => stock.StockId == etfStock.StockId).StockName,
                    currentPrice.ToString("0.00"));

                // 股利
                List<decimal> dividends = new List<decimal>();
                foreach (var year in years)
                {
                    if (stockDividendsResult.Any(stock => stock.Year == year))
                    {
                        var stockDividendData = stockDividendsResult.First(stock => stock.Year == year);
                        dividends.Add(stockDividendData.CashDividends);
                        line += stockDividendData.CashDividends.ToString("0.00") + "\t";
                    }
                    else
                    {
                        line += "0.00\t";
                    }
                }

                decimal avgDividend = dividends.Sum() / 5;
                line += String.Format("{0}\t{1}\t{2}\t{3}\t{4}\t",
                    avgDividend.ToString("0.00"),
                    (avgDividend * 20).ToString("0.00"), (currentPrice - avgDividend * 20).ToString("0.00"),
                    (avgDividend * 16).ToString("0.00"), (currentPrice - avgDividend * 16).ToString("0.00"));

                // 現金殖利率
                List<decimal> cashRates = new List<decimal>();
                foreach (var year in years)
                {
                    if (stockDividendsResult.Any(stock => stock.Year == year))
                    {
                        var stockDividendData = stockDividendsResult.First(stock => stock.Year == year);
                        cashRates.Add(stockDividendData.CashDividendsRate);
                        line += stockDividendData.CashDividendsRate.ToString("0.00") + "%\t";
                    }
                    else
                    {
                        line += "0.00%\t";
                    }
                }

                decimal avgCashRate = cashRates.Sum() / 5;
                decimal stdAvgCashRate = cashRates.Count > 0 ? MathHelper.CaculateStdAvg(cashRates.ToArray()) : 0;
                if (stockDividendsResult.Count() == 0) stockDividendsResult.Add(new StockDividend());
                line += String.Format("{0}%\t{1}%\t{2}%\t{3}%\t{4}\t",
                    avgCashRate.ToString("0.00"),
                    stdAvgCashRate.ToString("0.00"),
                    stockDividendsResult.First().GrossMargin.ToString("0.00"),
                    stockDividendsResult.First().ROE.ToString("0.00"),
                    stockDividendsResult.First().EPS.ToString("0.00"));

                txtDividendResult.Text += line + "\r\n";
                txtDividendResult.SelectionStart = txtDividendResult.Text.Length;
                Application.DoEvents();
            }

            txtDividendResult.Text += "Done";
        }

        private static string getDividendHeader(List<int> years)
        {
            string header = years.Aggregate("ETF\tStock Id\tStock Name\tStock Price\t", (current, year) => current + (year + "\t"));
            header += "平均股利\t合理價格\t合理差距\t便宜價格\t便宜差距\t";
            header = years.Aggregate(header, (current, year) => current + (year + "\t"));
            header += "平均現金殖利率\t現金殖利率標準差\t毛利率\tROE\tEPS\t建議";
            return header;
        }
    }
}