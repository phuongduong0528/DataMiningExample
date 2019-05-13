using SequentialPatternMining;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace DataMining
{
    public partial class Form1 : Form
    {
        StreamReader fileReader;
        List<RetailData> retailDatas;
        SortedSet<string>[] dataset;

        public Form1()
        {
            InitializeComponent();
            retailDatas = new List<RetailData>();
        }

        private SortedSet<string>[] GetTransactions(List<RetailData> input)
        {
            if (input.Count == 0)
                return null;
            List<SortedSet<string>> result = new List<SortedSet<string>>();
            var transactionIds = retailDatas.Select(rt => rt.InvoiceNo).Distinct();
            List<RetailData> tmp;
            foreach (var item in transactionIds)
            {
                result.Add(new SortedSet<string>(retailDatas.Where(rd => rd.InvoiceNo.Equals(item)).Select(i => i.StockCode)));
            }
            return result.ToArray();
        }

        void PopuateData(List<RetailData> input)
        {
            propertiesDgv.Rows.Add("InvoiceNo",retailDatas.Select(rd=>rd.InvoiceNo).Distinct().Count());
            propertiesDgv.Rows.Add("StockCode", retailDatas.Select(rd => rd.StockCode).Distinct().Count());
            propertiesDgv.Rows.Add("Description", retailDatas.Select(rd => rd.Description).Distinct().Count());
            propertiesDgv.Rows.Add("Quantity", retailDatas.Select(rd => rd.Quantity).Distinct().Count());
            propertiesDgv.Rows.Add("InvoiceDate", retailDatas.Select(rd => rd.InvoiceDate).Distinct().Count());
            propertiesDgv.Rows.Add("UnitPrice", retailDatas.Select(rd => rd.UnitPrice).Distinct().Count());
            propertiesDgv.Rows.Add("CustomerID", retailDatas.Select(rd => rd.CustomerID).Distinct().Count());
            propertiesDgv.Rows.Add("Country", retailDatas.Select(rd => rd.Country).Distinct().Count());
        }

        private void OpenFileBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    fileReader = new StreamReader(openFileDialog1.FileName);
                    fileDirectoryTxtB.Text = openFileDialog1.FileName;
                    CsvHelper.CsvReader reader = new CsvHelper.CsvReader(fileReader);
                    int count = 0;
                    while (reader.Read() && count <= 6000)
                    {
                        count++;
                        retailDatas.Add(reader.GetRecord<RetailData>());
                    }
                    tabControl1.Visible = true;
                    tabControl1.Enabled = true;
                }
                PopuateData(retailDatas);
                dataset =  GetTransactions(retailDatas);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PropertiesDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            propDetailsDgv.Rows.Clear();
            IEnumerable<string> x;
            int z;
            List<double> counts = new List<double>();
            List<string> labels = new List<string>();
            try
            {
                int a = propertiesDgv.CurrentCell.RowIndex;
                switch (a)
                {
                    case 0:
                        {
                            x = retailDatas.Select(rd => rd.InvoiceNo).Distinct();
                            foreach (var y in x)
                            {
                                z = retailDatas.Where(rd => rd.InvoiceNo.Equals(y)).Count();
                                counts.Add(z);
                                labels.Add(y);
                                propDetailsDgv.Rows.Add(y, z);
                            }
                            DrawGraph("InvoiceNo",counts, labels);
                            break;
                        }
                    case 1:
                        {
                            x = retailDatas.Select(rd => rd.StockCode).Distinct();  
                            foreach (var y in x)
                            {
                                z = retailDatas.Where(rd => rd.StockCode.Equals(y)).Count();
                                counts.Add(z);
                                labels.Add(y);
                                propDetailsDgv.Rows.Add(y, z);
                            }
                            DrawGraph("StockCode", counts, labels);
                            break;
                        }
                    case 2:
                        {
                            x = retailDatas.Select(rd => rd.Description).Distinct();
                            foreach (var y in x)
                            {
                                z = retailDatas.Where(rd => rd.Description.Equals(y)).Count();
                                counts.Add(z);
                                labels.Add(y);
                                propDetailsDgv.Rows.Add(y, z);
                            }
                            DrawGraph("Description", counts, labels);
                            break;
                        }
                    case 3:
                        {
                            x = retailDatas.Select(rd => rd.Quantity).Distinct();
                            foreach (var y in x)
                            {
                                z = retailDatas.Where(rd => rd.Quantity.Equals(y)).Count();
                                counts.Add(z);
                                labels.Add(y);
                                propDetailsDgv.Rows.Add(y, z);
                            }
                            DrawGraph("Quantity", counts, labels);
                            break;
                        }
                    case 4:
                        {
                            x = retailDatas.Select(rd => rd.InvoiceDate).Distinct();
                            foreach (var y in x)
                            {
                                z = retailDatas.Where(rd => rd.InvoiceDate.Equals(y)).Count();
                                counts.Add(z);
                                labels.Add(y);
                                propDetailsDgv.Rows.Add(y, z);
                            }
                            DrawGraph("InvoiceDate", counts, labels);
                            break;
                        }
                    case 5:
                        {
                            x = retailDatas.Select(rd => rd.UnitPrice).Distinct();
                            foreach (var y in x)
                            {
                                z = retailDatas.Where(rd => rd.UnitPrice.Equals(y)).Count();
                                counts.Add(z);
                                labels.Add(y);
                                propDetailsDgv.Rows.Add(y, z);
                            }
                            DrawGraph("UnitPrice", counts, labels);
                            break;
                        }
                    case 6:
                        {
                            x = retailDatas.Select(rd => rd.CustomerID).Distinct();
                            foreach (var y in x)
                            {
                                z = retailDatas.Where(rd => rd.CustomerID.Equals(y)).Count();
                                counts.Add(z);
                                labels.Add(y);
                                propDetailsDgv.Rows.Add(y, z);
                            }
                            DrawGraph("CustomerID", counts, labels);
                            break;
                        }
                    case 7:
                        {
                            x = retailDatas.Select(rd => rd.Country).Distinct();
                            foreach (var y in x)
                            {
                                z = retailDatas.Where(rd => rd.Country.Equals(y)).Count();
                                counts.Add(z);
                                labels.Add(y);
                                propDetailsDgv.Rows.Add(y, z);
                            }
                            DrawGraph("Country", counts, labels);
                            break;
                        }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DrawGraph(string property,List<double> graphDatas, List<string> labels)
        {
            GraphPane graphPane = zedGraphControl1.GraphPane;
            graphPane.GraphObjList.Clear();
            graphPane.CurveList.Clear();
            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();

            graphPane.XAxis.Title.Text = "Hạng mục";
            graphPane.YAxis.Title.Text = "Số lượng";
            BarItem barItem = graphPane.AddBar(property, null, graphDatas.ToArray(), Color.LightBlue);
            if(labels.Count <= 10)
            {
                graphPane.XAxis.Scale.TextLabels = labels.ToArray();
                graphPane.XAxis.Type = AxisType.Text;
                graphPane.XAxis.MajorTic.IsBetweenLabels = true;
            }
            else
            {
                graphPane.XAxis.Scale.TextLabels = null;
                graphPane.XAxis.Type = AxisType.Linear;
                graphPane.XAxis.MajorTic.IsBetweenLabels = false;
            }
            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();

        }

        private void PropDetailsDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void FindAllBtn_Click(object sender, EventArgs e)
        {
            try
            {
                assocRuleDgv.Rows.Clear();
                double percent = double.Parse(suppTxtb.Text);
                if(percent < 6)
                {
                    MessageBox.Show("Value to low");
                    return;
                }
                var supp = ((double)((double)dataset.Count() / (double)100)) * percent;
                int support = (int)Math.Round(supp);
                double conf = double.Parse(confTxtb.Text);
                Apriori apriori = new Apriori(support,conf);
                AssociationRule[] assocRule = apriori.Learn(dataset);

                foreach(var rule in assocRule)
                {
                    assocRuleDgv.Rows.Add(rule.GetAssocRule(), rule.Support, rule.Confidence);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void OpenFinderBtn_Click(object sender, EventArgs e)
        {
            ItemsFinderForm form = new ItemsFinderForm(retailDatas);
            form.Show();
        }
    }
}
