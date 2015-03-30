using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStockAnalyzer.Helpers
{
    public class DateTimeHelper
    {
        public static DateTime GetLastDayOfMonth(int year, int month)
        {
            DateTime dt = GetFirstDayOfMonth(year, month);
            // 本月1號的下個月的前一天即為本月最後一天
            DateTime result = dt.AddMonths(1).AddDays(-1);
            return result;
        }

        public static DateTime GetFirstDayOfMonth(int year, int month)
        {
            return new DateTime(year, month, 1);
        }
    }
}
