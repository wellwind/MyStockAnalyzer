using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStockAnalyzer.Classes
{
    public class StockData
    {
        public string StockId { get; set; }
        public string StockName { get; set; }
        public string Class { get; set; }
        public string Industry { get; set; }
        public Nullable<System.DateTime> Updated { get; set; }
        public string WarrantTarget { get; set; }
    }
}
