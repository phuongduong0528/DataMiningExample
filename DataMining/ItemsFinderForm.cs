using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataMining
{
    public partial class ItemsFinderForm : Form
    {
        List<RetailData> retailDatas;
        List<(string StockCode, string Description)> stockData;
        public ItemsFinderForm(List<RetailData> retailDatas)
        {
            InitializeComponent();
            this.retailDatas = retailDatas;
            stockData = new List<(string StockCode, string Description)>();
        }

        private void ItemsFinder_Load(object sender, EventArgs e)
        {
            PopulateTable();
        }

        private void PopulateTable()
        {
            listDgv.Rows.Clear();
            stockData = retailDatas.Select(rd => (rd.StockCode, rd.Description)).Distinct().ToList();
            foreach ((string StockCode, string Description) i in stockData)
            {
                listDgv.Rows.Add(i.StockCode, i.Description);
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            listDgv.Rows.Clear();
            string searchString = searchTxtb.Text.Trim();
            IEnumerable<(string StockCode, string Description)> searchResults = 
                stockData.Where(sd => sd.StockCode.Equals(searchString));
            foreach((string StockCode, string Description) i in searchResults)
            {
                listDgv.Rows.Add(i.StockCode, i.Description);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            PopulateTable();
        }
    }
}
