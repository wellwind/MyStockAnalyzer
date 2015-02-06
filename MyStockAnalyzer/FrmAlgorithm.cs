using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyStockAnalyzer.Attributes;
using MyStockAnalyzer.Helpers;
using MyStockAnalyzer.StockSelectionAlgorithms;
using MyStockAnalyzer.StockSelectionAlgorithms.Interfaces;

namespace MyStockAnalyzer
{
    public partial class FrmAlgorithm : Form
    {
        private class AlgorithmItem
        {
            public IStockSelectionAlgorithm Algorithm { get; set; }

            public override string ToString()
            {
                return Algorithm.Name;
            }
        }

        /// <summary>
        /// 回傳選中的演算法
        /// </summary>
        public List<IStockSelectionAlgorithm> ReturnedAlgorithms = new List<IStockSelectionAlgorithm>();

        /// <summary>
        /// 從之前表單傳來目前選中的演算法
        /// </summary>
        public List<IStockSelectionAlgorithm> CurrentAlgorithms { get; set; }

        public FrmAlgorithm()
        {
            InitializeComponent();
        }

        private void FrmAlgorithm_Load(object sender, EventArgs e)
        {
            var queryAlgorithms = from t in Assembly.GetExecutingAssembly().GetTypes()
                                  where t.IsClass && t.Namespace == "MyStockAnalyzer.StockSelectionAlgorithms"
                                  select t;
            foreach (IStockSelectionAlgorithm algorithm in StockSelectionAlgorithmHelper.GetAllAlgorithms())
            {
                cbAlgorithmList.Items.Add(new AlgorithmItem() { Algorithm = algorithm });

                if (CurrentAlgorithms.Where(x => x.Name.Equals(algorithm.Name)).Count() != 0)
                {
                    cbAlgorithmList.SetItemChecked(cbAlgorithmList.Items.Count - 1, true);
                }
            }
        }

        private void cbAlgorithmList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAlgorithmDescription.Clear();
            AlgorithmItem item = cbAlgorithmList.SelectedItem as AlgorithmItem;
            if (item != null)
            {
                txtAlgorithmDescription.Text = StockSelectionAlgorithmHelper.GetAlgorithmDescription(item.Algorithm);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            foreach (object item in cbAlgorithmList.CheckedItems)
            {
                if (item is AlgorithmItem)
                {
                    ReturnedAlgorithms.Add((item as AlgorithmItem).Algorithm);
                }
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
