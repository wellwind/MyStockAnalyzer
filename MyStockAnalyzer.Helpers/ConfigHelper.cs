using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStockAnalyzer.Helpers
{
    public class ConfigHelper
    {
        // 股票清單
        public static string StockListUrl1 = "http://isin.twse.com.tw/isin/C_public.jsp?strMode=2";

        public static string StockListUrl2 = "http://isin.twse.com.tw/isin/C_public.jsp?strMode=4";

        // 股價資訊
        public static string StockPriceUrl1 =
            "http://www.twse.com.tw/ch/trading/exchange/STOCK_DAY/STOCK_DAY_print.php?genpage=genpage/Report{0}{1}/{0}{1}_F3_1_8_{2}.php&type=csv";

        public static string StockPriceUrl2 =
            "http://www.gretai.org.tw/web/stock/aftertrading/daily_trading_info/st43_download.php?l=zh-tw&d={0}/{1}&stkno={2}&s=0,asc,0";

        //<input type="hidden" id="html" name="html" value="<table width=590 border=0 align=center cellpadding=0 cellspacing=1 class=board_trad><tr height=25 bgcolor=#F7F0E8><td colspan=5><div align=center class=til_2>104 年01月 發行量加權股價指數歷史資料</div></td></tr><tr bgcolor=#EBDCC9 class=basic2 height=25><td align=center>日期</td><td align=center>開盤指數</td><td align=center>最高指數</td><td align=center>最低指數</td><td align=center>收盤指數</td></tr><tr height=20 bgcolor=#FFFFFF class=gray12><td align=center> 104/01/05</td><td align=center> 9,292.31</td><td align=center> 9,292.31</td><td align=center> 9,182.02</td><td align=center> 9,274.11</td></tr><tr height=20 bgcolor=#FFFFFF class=gray12><td align=center> 104/01/06</td><td align=center> 9,209.93</td><td align=center> 9,209.93</td><td align=center> 9,043.44</td><td align=center> 9,048.34</td></tr><tr height=20 bgcolor=#FFFFFF class=gray12><td align=center> 104/01/07</td><td align=center> 9,051.94</td><td align=center> 9,108.66</td><td align=center> 9,050.54</td><td align=center> 9,080.09</td></tr><tr height=20 bgcolor=#FFFFFF class=gray12><td align=center> 104/01/08</td><td align=center> 9,154.03</td><td align=center> 9,246.62</td><td align=center> 9,154.03</td><td align=center> 9,238.03</td></tr><tr height=20 bgcolor=#FFFFFF class=gray12><td align=center> 104/01/09</td><td align=center> 9,247.40</td><td align=center> 9,284.57</td><td align=center> 9,215.58</td><td align=center> 9,215.58</td></tr><tr height=20 bgcolor=#FFFFFF class=gray12><td align=center> 104/01/12</td><td align=center> 9,198.02</td><td align=center> 9,229.65</td><td align=center> 9,178.30</td><td align=center> 9,178.30</td></tr><tr height=20 bgcolor=#FFFFFF class=gray12><td align=center> 104/01/13</td><td align=center> 9,162.77</td><td align=center> 9,253.82</td><td align=center> 9,161.71</td><td align=center> 9,231.80</td></tr></table>">
        // 大盤資訊
        public static string StockMapUrl1 =
            "http://www.twse.com.tw/ch/trading/indices/MI_5MINS_HIST/MI_5MINS_HIST.php?myear={0}&mmon={1}";

        public static string StockMapVolumeUrl1 =
            "http://www.twse.com.tw/ch/trading/exchange/FMTQIK/FMTQIK2.php?STK_NO=&myear={0}&mmon={1}&type=csv";

        // 即時股價資訊
        public static string StockRealDataUrl =
            "http://mis.twse.com.tw/stock/api/getStockInfo.jsp?ex_ch={0}&json=1&delay=0";

        // public static string StockRealDataUrl2 = "http://mis.twse.com.tw/stock/api/getStockInfo.jsp?ex_ch={0}.tw_{1}&json=1&delay=0";

        // ETF權證標的
        public static string WarrantTargetEtfUrl1 = "http://mops.twse.com.tw/mops/web/ajax_t51sb11";

        public static string WarrantTargetEtfUrl2 = "http://mops.twse.com.tw/mops/web/ajax_t51sb11_otc";

        // 股票權證標的
        public static string WarrantTargetUrlBase = "http://mops.twse.com.tw/{0}";

        public static string WarrantTargetStockUrl1 = "http://mops.twse.com.tw/mops/web/t111sb01";
        public static string WarrantTargetStockUrl2 = "http://mops.twse.com.tw/mops/web/o_t111sb01";

        // 股票相關權證資訊
        // http://mops.twse.com.tw/mops/web/t90sbfa01
        public static string StockWarrantUrl = "http://mops.twse.com.tw/mops/web/ajax_t90sbfa01";

        // ETF成份資訊
        public static Dictionary<string, string> StockEtfUrl = new Dictionary<string, string>()
        {
            {"0050", "http://www.twse.com.tw/ch/trading/indices/twco/tai50i_print.php?language=ch&datafile=twco_c.htm"},
            {"0051", "http://www.twse.com.tw/ch/trading/indices/tmcc/tai100i_print.php?language=ch&datafile=tmcc_c.htm"}
        };

        public static string StockDividendUrl = "http://wantgoo.com/stock/report.aspx?stockno={0}&t=2";
    }
}