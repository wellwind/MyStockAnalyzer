using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStockAnalyzer.Models
{
    public class StockRealData
    {
        public Msgarray[] msgArray { get; set; }
        public int userDelay { get; set; }
        public string rtmessage { get; set; }
        public string referer { get; set; }
        public Querytime queryTime { get; set; }
        public string rtcode { get; set; }
    }

    public class Querytime
    {
        public string sysTime { get; set; }
        public long sessionLatestTime { get; set; }
        public string sysDate { get; set; }
        public string sessionKey { get; set; }
        public long sessionFromTime { get; set; }
        public int stockInfoItem { get; set; }
        public bool showChart { get; set; }
        public string sessionStr { get; set; }
        public int stockInfo { get; set; }
    }

    public class Msgarray
    {
        public string tk0 { get; set; }
        public string tk1 { get; set; }
        public string tlong { get; set; }
        public string f { get; set; }
        public string ex { get; set; }
        public string g { get; set; }
        public string d { get; set; }
        public string it { get; set; }
        public string b { get; set; }
        public string c { get; set; }
        public string a { get; set; }
        public string n { get; set; }
        public string o { get; set; }
        public string l { get; set; }
        public string h { get; set; }
        public string ip { get; set; }
        public string i { get; set; }
        public string w { get; set; }
        public string v { get; set; }
        public string u { get; set; }
        public string t { get; set; }
        public string tv { get; set; }
        public string p { get; set; }
        public string nf { get; set; }
        public string ch { get; set; }
        public string z { get; set; }
        public string y { get; set; }
    }
}