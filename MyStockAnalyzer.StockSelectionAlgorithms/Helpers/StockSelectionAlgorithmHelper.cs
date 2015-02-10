using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MyStockAnalyzer.StockSelectionAlgorithms.Attributes;
using MyStockAnalyzer.StockSelectionAlgorithms.Interfaces;

namespace MyStockAnalyzer.StockSelectionAlgorithms.Helpers
{
    public class StockSelectionAlgorithmHelper
    {
        /// <summary>
        /// 取得所有的演算法
        /// </summary>
        /// <returns></returns>
        public static List<IStockSelectionAlgorithm> GetAllAlgorithms()
        {
            var queryAlgorithms = from t in Assembly.GetExecutingAssembly().GetTypes()
                                  where t.IsClass && t.Namespace == "MyStockAnalyzer.StockSelectionAlgorithms" && t.GetInterface("IStockSelectionAlgorithm") != null
                                  select Activator.CreateInstance(t) as IStockSelectionAlgorithm;
            return queryAlgorithms.ToList();
        }

        /// <summary>
        /// 取得預設選取的演算法
        /// </summary>
        /// <returns></returns>
        public static List<IStockSelectionAlgorithm> GetDefaultAlgorithms()
        {
            return GetAllAlgorithms().Where(x => x is IStockSelectionConditionDefault).ToList();
        }

        /// <summary>
        /// 取得演算法說明
        /// </summary>
        /// <param name="algorithm"></param>
        /// <returns></returns>
        public static string GetAlgorithmDescription(IStockSelectionAlgorithm algorithm)
        {
            string desc = String.Empty;

            AlgorithmDescriptionAttribute attr = algorithm.GetType().GetCustomAttribute(typeof(AlgorithmDescriptionAttribute)) as AlgorithmDescriptionAttribute;
            if (attr != null)
            {
                desc = attr.GetDescription();
                if (algorithm is IStockSelectionConditionWarrantOnly)
                {
                    desc += "\r\n\r\n※ 只篩選權證標的股";
                }
            }
            return desc;
        }
    }
}
