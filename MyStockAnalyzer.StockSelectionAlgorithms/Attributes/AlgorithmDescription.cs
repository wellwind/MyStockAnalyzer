using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStockAnalyzer.StockSelectionAlgorithms.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class AlgorithmDescriptionAttribute : System.Attribute
    {
        private string Description;

        /// <summary>
        /// 選股演算法說明
        /// </summary>
        /// <param name="Description"></param>
        public AlgorithmDescriptionAttribute(string Description)
        {
            this.Description = Description;
        }

        public string GetDescription()
        {
            return this.Description;
        }
    }
}