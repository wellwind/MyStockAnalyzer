using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStockAnalyzer.Classes
{
    public class StockPrice
    {
        public string StockId { get; set; }
        public System.DateTime Date { get; set; }
        public decimal Open { get; set; }
        public decimal Close { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public long Amount { get; set; }
    }
}
