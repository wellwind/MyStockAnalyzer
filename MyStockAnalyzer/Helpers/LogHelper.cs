using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStockAnalyzer.Helpers
{
    public class LogHelper
    {

        public static DataGridView DisplayGridView { get; set; }

        public static void SetLogMessage(string message)
        {
            DisplayGridView.Rows.Add(new string[] { DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"), message });
            DisplayGridView.Rows[DisplayGridView.Rows.GetLastRow(DataGridViewElementStates.Displayed)].Selected = true;
            DisplayGridView.FirstDisplayedScrollingRowIndex = DisplayGridView.Rows.Count - 1;
            Application.DoEvents();
        }
    }
}
