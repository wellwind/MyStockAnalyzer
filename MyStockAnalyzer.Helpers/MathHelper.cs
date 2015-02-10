using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStockAnalyzer.Helpers
{
    public class MathHelper
    {
        public static decimal CaculateStdAvg(decimal[] input)
        {
            decimal avg = input.Average();
            double sumSquare = 0.0;

            foreach (decimal value in input)
            {
                sumSquare += Math.Pow(Convert.ToDouble(value - avg), 2);
            }

            return Convert.ToDecimal(Math.Sqrt(sumSquare / input.Count()));
        }

        public static decimal GetHighLowPercent(decimal high, decimal low)
        {
            return ((high - low) / low) * 100m;
        }
    }
}
