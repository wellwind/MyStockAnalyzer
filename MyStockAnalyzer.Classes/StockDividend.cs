using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStockAnalyzer.Classes
{
    public class StockDividend
    {
        public string StockId { get; set; }

        public int Year { get; set; }

        public decimal CashDividends { get; set; }

        public decimal StockDividends { get; set; }

        public decimal CashDividendsRate { get; set; }

        public decimal Price { get; set; }

        public decimal EPS { get; set; }

        public decimal ROE { get; set; }

        public decimal GrossMargin { get; set; }
    }
}