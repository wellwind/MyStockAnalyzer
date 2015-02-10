using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStockAnalyzer.StockSelectionAlgorithms
{
    public class StockSelectionResult
    {
        public DateTime Date { get; set; }
        public string Memo { get; set; }

        public StockSelectionResult()
        {
            Memo = String.Empty;
        }
    }
}
