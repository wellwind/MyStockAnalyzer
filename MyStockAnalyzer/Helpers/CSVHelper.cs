using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStockAnalyzer.Helpers
{
    public class CSVHelper
    {
        /// <summary>
        /// 免強堪用的CSV parser
        /// </summary>
        /// <param name="line"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static string[] ParseCSVLine(string line, string delimiter)
        {
            List<string> fields = new List<string>();

            bool openQuote = false;
            bool closeQuote = false;

            string singleField = "";
            foreach (char c in line.ToCharArray())
            {
                if (c.Equals(delimiter[0]))
                {
                    if (!(openQuote ^ closeQuote))
                    {
                        openQuote = false;
                        closeQuote = false;
                        fields.Add(singleField);
                        singleField = String.Empty;
                        continue;
                    }
                }
                
                if (c.Equals('"'))
                {
                    if (!openQuote)
                    {
                        openQuote = true;
                    }
                    else
                    {
                        closeQuote = true;
                    }
                    continue;
                }

                if (!c.Equals("\""))
                {
                    singleField += c.ToString();
                }
            }

            if (!String.IsNullOrEmpty(singleField))
            {
                fields.Add(singleField);
            }

            return fields.ToArray();
        }
    }
}
