using SequentialPatternMining;
using SequentialPatternMining.GSP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        List<SortedSet<string>>[] datasetGsp;
        AssociationRule[] assocRules;
        Apriori apriori;

        public Form1()
        {
            InitializeComponent();
            retailDatas = new List<RetailData>();
        }

        private List<SortedSet<string>>[] GetFrequentTransactions(List<RetailData> input)
        {
            //==================
            int minimum = Convert.ToInt32(numericUpDown2.Value);
            //==================

            if (input.Count == 0)
                return null;
            List<List<SortedSet<string>>> result = new List<List<SortedSet<string>>>();
            SortedSet<string> items = new SortedSet<string>();
            List<SortedSet<string>> transac = new List<SortedSet<string>>();
            IEnumerable<string> customerIdsTemp = retailDatas.Select(rd => rd.CustomerID).Distinct();
            List<string> customers = new List<string>();



            var invoicePerCustomer = retailDatas.Select(rd => new { rd.CustomerID, rd.InvoiceNo }).Distinct().ToList();
            foreach (var cid in customerIdsTemp)
            {
                var z = invoicePerCustomer.Where(x => x.CustomerID.Equals(cid)).Count();
                if (z >= minimum)
                {
                    customers.Add(cid);
                }
            }

            customerIdsTemp = null;
            Invoke((Action)(() => { toolStripProgressBar1.Maximum = customers.Count(); }));
            Invoke((Action)(() => { toolStripProgressBar1.Value = 0; }));

            foreach (var c in customers)
            {
                Invoke((Action)(() => { toolStripProgressBar1.PerformStep(); }));
                transac = new List<SortedSet<string>>();
                var z = invoicePerCustomer.Where(ipc => ipc.CustomerID.Equals(c)).Select(ipc1 => ipc1.InvoiceNo);
                foreach (var ivn in z)
                {
                    var x = retailDatas.Where(rd => rd.InvoiceNo.Equals(ivn)).Select(rd1 => rd1.StockCode);
                    transac.Add(new SortedSet<string>(x));
                }
                result.Add(transac);
            }
            Invoke((Action)(() => { label8.Text = $" -  0/{result.Count}"; }));

            Invoke((Action)(() => { toolStripProgressBar1.Value = 0; }));

            return result.ToArray();
        }

        private async Task<List<SortedSet<string>>[]> GetFrequentTransactionsAsync(List<RetailData> input)
        {
            return await Task.Run(() => GetFrequentTransactions(input));
        }

        private SortedSet<string>[] GetTransactions(List<RetailData> input)
        {
            //====================
            int minimum = Convert.ToInt32(numericUpDown1.Value);
            //====================

            IEnumerable<string> tmp;
            if (input.Count == 0)
                return null;
            List<SortedSet<string>> result = new List<SortedSet<string>>();
            var transactionIds = retailDatas.Select(rt => rt.InvoiceNo).Distinct();
            Invoke((Action)(() => { toolStripProgressBar1.Value = 0; }));
            Invoke((Action)(() => { toolStripProgressBar1.Maximum = transactionIds.Count(); }));
            foreach (var item in transactionIds)
            {
                Invoke((Action)(() => { toolStripProgressBar1.PerformStep(); }));
                tmp = retailDatas.Where(rd => rd.InvoiceNo.Equals(item)).Select(i => i.StockCode);
                if (tmp.Count() >= minimum)
                {
                    result.Add(new SortedSet<string>(tmp));
                }
            }
            Invoke((Action)(() => { toolStripProgressBar1.Value = 0; }));
            return result.ToArray();
        }

        private async Task<SortedSet<string>[]> GetTransactionsAsync(List<RetailData> input)
        {
            return await Task.Run(() => GetTransactions(input));
        }

        void PopuateData(List<RetailData> input)
        {
            propertiesDgv.Rows.Add("InvoiceNo", retailDatas.Select(rd => rd.InvoiceNo).Distinct().Count(), "hóa đơn");
            propertiesDgv.Rows.Add("StockCode", retailDatas.Select(rd => rd.StockCode).Distinct().Count(), "mã hàng");
            propertiesDgv.Rows.Add("Description", retailDatas.Select(rd => rd.Description).Distinct().Count(), "tên hàng");
            propertiesDgv.Rows.Add("Quantity", retailDatas.Select(rd => rd.Quantity).Distinct().Count(), "");
            propertiesDgv.Rows.Add("InvoiceDate", retailDatas.Select(rd => rd.InvoiceDate).Distinct().Count(), "lượt mua");
            propertiesDgv.Rows.Add("UnitPrice", retailDatas.Select(rd => rd.UnitPrice).Distinct().Count(), "");
            propertiesDgv.Rows.Add("CustomerID", retailDatas.Select(rd => rd.CustomerID).Distinct().Count(), "khách hàng");
            propertiesDgv.Rows.Add("Country", retailDatas.Select(rd => rd.Country).Distinct().Count(), "quốc gia");
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
                    while (reader.Read() && count <= 500000)
                    {
                        count++;
                        retailDatas.Add(reader.GetRecord<RetailData>());
                    }
                }
                PopuateData(retailDatas);
                tabControl1.Visible = true;
                tabControl1.Enabled = true;
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
            int stt = 1;
            List<double> counts = new List<double>();
            List<string> labels = new List<string>();
            try
            {
                int a = propertiesDgv.CurrentCell.RowIndex;
                switch (a)
                {
                    case 0:
                        {
                            propDetailsDgv.Columns[1].HeaderText = "Hóa đơn";
                            x = retailDatas.Select(rd => rd.InvoiceNo).Distinct();
                            foreach (var y in x)
                            {
                                z = retailDatas.Where(rd => rd.InvoiceNo.Equals(y)).Count();
                                counts.Add(z);
                                labels.Add(y);
                                propDetailsDgv.Rows.Add(stt++, y, z);
                            }
                            DrawGraph("InvoiceNo", counts, labels);
                            break;
                        }
                    case 1:
                        {
                            propDetailsDgv.Columns[1].HeaderText = "Mã hàng";
                            propDetailsDgv.Columns[2].HeaderText = "Số lượt mua";
                            x = retailDatas.Select(rd => rd.StockCode).Distinct();
                            var x1 = retailDatas.Select(rd => new { rd.StockCode, rd.InvoiceNo }).Distinct();
                            foreach (var y in x)
                            {
                                z = retailDatas.Where(rd => rd.StockCode.Equals(y)).Count();
                                counts.Add(z);
                                labels.Add(y);
                                propDetailsDgv.Rows.Add(stt++, y, z);
                            }
                            DrawGraph("StockCode", counts, labels);
                            break;
                        }
                    case 2:
                        {
                            propDetailsDgv.Columns[1].HeaderText = "Tên hàng";
                            propDetailsDgv.Columns[2].HeaderText = "Số lượt mua";
                            x = retailDatas.Select(rd => rd.Description).Distinct();
                            var x1 = retailDatas.Select(rd => new { rd.Description, rd.InvoiceNo }).Distinct().ToList();
                            foreach (var y in x)
                            {
                                z = x1.Where(rd => rd.Description.Equals(y)).Count();
                                counts.Add(z);
                                labels.Add(y);
                                propDetailsDgv.Rows.Add(stt++, y, z);
                            }
                            DrawGraph("Description", counts, labels);
                            break;
                        }
                    case 3:
                        {
                            propDetailsDgv.Columns[1].HeaderText = "Hạng mục";
                            propDetailsDgv.Columns[2].HeaderText = "Số lươngj";
                            x = retailDatas.Select(rd => rd.Quantity).Distinct();
                            foreach (var y in x)
                            {
                                z = retailDatas.Where(rd => rd.Quantity.Equals(y)).Count();
                                counts.Add(z);
                                labels.Add(y);
                                propDetailsDgv.Rows.Add(stt++, y, z);
                            }
                            DrawGraph("Quantity", counts, labels);
                            break;
                        }
                    case 4:
                        {
                            propDetailsDgv.Columns[1].HeaderText = "Tháng";
                            propDetailsDgv.Columns[2].HeaderText = "Số lượt mua";
                            x = retailDatas.Select(rd => rd.InvoiceDate).Distinct();
                            var x1 = retailDatas.Select(rd => new { rd.InvoiceDate, rd.InvoiceNo }).Distinct();
                            int m = 0;
                            foreach (var y in x)
                            {
                                DateTime tmp = new DateTime();
                                var check = DateTime.TryParseExact(y, @"dd/MM/yyyy HH\:mm",
                                    CultureInfo.InvariantCulture, DateTimeStyles.None, out tmp);
                                if (check == false)
                                    continue;
                                if (m != tmp.Month)
                                {
                                    z = x1.Where(rd =>
                                    DateTime.ParseExact(rd.InvoiceDate, @"dd/MM/yyyy HH\:mm",
                                        CultureInfo.InvariantCulture).Month == tmp.Month).Count();
                                    m = tmp.Month;
                                    counts.Add(z);
                                    labels.Add(tmp.Month.ToString());
                                    propDetailsDgv.Rows.Add(stt++, tmp.Month.ToString(), z);
                                }
                            }
                            DrawGraph("InvoiceDate", counts, labels);
                            break;
                        }
                    case 5:
                        {
                            propDetailsDgv.Columns[1].HeaderText = "Giá sản phẩm";
                            propDetailsDgv.Columns[2].HeaderText = "Số sản phẩm";
                            x = retailDatas.Select(rd => rd.UnitPrice).Distinct();
                            var x1 = retailDatas.Select(rd => new { rd.UnitPrice, rd.StockCode }).Distinct();
                            foreach (var y in x)
                            {
                                z = retailDatas.Where(rd => rd.UnitPrice.Equals(y)).Count();
                                counts.Add(z);
                                labels.Add(y);
                                propDetailsDgv.Rows.Add(stt++, y, z);
                            }
                            DrawGraph("UnitPrice", counts, labels);
                            break;
                        }
                    case 6:
                        {
                            propDetailsDgv.Columns[1].HeaderText = "Khách hàng";
                            propDetailsDgv.Columns[2].HeaderText = "Số lượt mua";
                            x = retailDatas.Select(rd => rd.CustomerID).Distinct();
                            var x1 = retailDatas.Select(rd => new { rd.CustomerID, rd.InvoiceNo }).Distinct().ToList();
                            foreach (var y in x)
                            {
                                z = x1.Where(rd => rd.CustomerID.Equals(y)).Count();
                                counts.Add(z);
                                labels.Add(y);
                                propDetailsDgv.Rows.Add(stt++, y, z);
                            }
                            DrawGraph("CustomerID", counts, labels);
                            break;
                        }
                    case 7:
                        {
                            propDetailsDgv.Columns[1].HeaderText = "Quốc gia";
                            propDetailsDgv.Columns[2].HeaderText = "Số lượt mua";
                            x = retailDatas.Select(rd => rd.Country).Distinct();
                            var x1 = retailDatas.Select(rd => new { rd.Country, rd.InvoiceNo }).Distinct();
                            foreach (var y in x)
                            {
                                z = x1.Where(rd => rd.Country.Equals(y)).Count();
                                counts.Add(z);
                                labels.Add(y);
                                propDetailsDgv.Rows.Add(stt++, y, z);
                            }
                            DrawGraph("Country", counts, labels);
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DrawGraph(string property, List<double> graphDatas, List<string> labels)
        {
            GraphPane graphPane = zedGraphControl1.GraphPane;
            graphPane.GraphObjList.Clear();
            graphPane.CurveList.Clear();
            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();

            graphPane.XAxis.Title.Text = "Hạng mục";
            graphPane.YAxis.Title.Text = "Số lượng";
            BarItem barItem = graphPane.AddBar(property, null, graphDatas.ToArray(), Color.LightBlue);
            if (labels.Count <= 10)
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

        private async void FindAllBtn_Click(object sender, EventArgs e)
        {
            try
            {
                assocRuleRtb.Clear();
                assocRuleDgv.Rows.Clear();
                double percent = double.Parse(suppTxtb.Text);
                if (percent < 1)
                {
                    MessageBox.Show("Value to low");
                    return;
                }
                double supp = ((double)((double)dataset.Count() / (double)100)) * percent;
                int support = (int)Math.Round(supp);
                double conf = double.Parse(confTxtb.Text);
                apriori = new Apriori(support, conf, toolStripProgressBar1);

                toolStripStatusLabel1.Text = "Đang xử lí";
                toolStripStatusLabel1.Visible = true;

                assocRules = await apriori.LearnAsync(dataset);

                if (assocRules.Count() <= 500)
                {
                    foreach (var rule in assocRules)
                    {
                        assocRuleDgv.Rows.Add(rule.GetAssocRule(), rule.Support, rule.Confidence.ToString("N"));
                        assocRuleRtb.Text += rule.ToString() + "\n";
                    }
                }
                else
                {
                    MessageBox.Show("Quá nhiều dữ liệu" + "\nKết quả sẽ được lưu vào file");
                    CsvHelper.CsvWriter csvWriter = new CsvHelper.CsvWriter(new StreamWriter(".\\Output.csv"));
                    foreach (var rule in assocRules)
                    {
                        csvWriter.WriteField(rule.GetAssocRule());
                        csvWriter.WriteField(rule.Support);
                        csvWriter.WriteField(rule.Confidence.ToString("N"));
                        csvWriter.NextRecord();
                    }
                }

                toolStripProgressBar1.Visible = false;
                toolStripStatusLabel1.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void OpenFinderBtn_Click(object sender, EventArgs e)
        {
            ItemsFinderForm form = new ItemsFinderForm(retailDatas);
            form.Show();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            string[] inputStr = searchTxtb.Text.Split(',');
            string[][] decision = null;
            double[] scores = apriori.Classifier.Scores(inputStr, ref decision);
            string tmp;
            StringBuilder sb = new StringBuilder();
            sb.Append("Các mặt hàng được mua tiếp theo:\n");
            if (scores.Count() != 0)
            {
                assocRuleRtb.Clear();
                for (int i = 0; i < scores.Count(); i++)
                {
                    tmp = "";
                    foreach (var j in decision[i])
                    {
                        tmp += $"{j}, ";
                    }
                    sb.Append($"{i + 1}. {tmp}  ->  {scores[i].ToString("P", CultureInfo.InvariantCulture)}\n");
                }
                //MessageBox.Show(sb.ToString());
                assocRuleRtb.Text = sb.ToString();
            }
        }

        private async void FinAllGSPBtn_Click(object sender, EventArgs e)
        {
            frequentDgv.Rows.Clear();
            try
            {
                double percent = double.Parse(suppGspTxtb.Text);
                if (percent < 1)
                {
                    MessageBox.Show("Value to low");
                    return;
                }
                double supp = ((double)((double)datasetGsp.Count() / (double)100)) * percent;
                int support = (int)Math.Round(supp);
                GSP gSP = new GSP(support, toolStripProgressBar1);
                Sequence[] x = await gSP.LearnAsync(datasetGsp);

                StringBuilder sb = new StringBuilder();

                foreach (var seq in x)
                {
                    frequentDgv.Rows.Add(seq.GetSequence(), seq.Support);
                    sb.Append($"{seq.GetSequence()}  -  {seq.Support}/{datasetGsp.Count()} - " +
                        $"{(seq.Support / datasetGsp.Count()).ToString("N")}\n");
                }
                richTextBox1.Clear();
                richTextBox1.Text = sb.ToString();
                toolStripProgressBar1.Visible = false;
            }
            catch (Exception ex)
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private async void AnalysistC_Btn_Click(object sender, EventArgs e)
        {
            toolStripProgressBar1.Visible = true;
            toolStripStatusLabel1.Visible = true;
            datasetGsp = await GetFrequentTransactionsAsync(retailDatas);
            finAllGSPBtn.Enabled = true;
            searchGspBtn.Enabled = true;
            toolStripProgressBar1.Visible = false;
            toolStripStatusLabel1.Visible = false;
        }

        private void AnalysistT_Btn_Click(object sender, EventArgs e)
        {

        }

        private void SuppGspTxtb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double percent = double.Parse(suppGspTxtb.Text);
                double supp = ((double)((double)datasetGsp.Count() / (double)100)) * percent;
                int support = (int)Math.Round(supp);
                label8.Text = $"  -  {support}/{datasetGsp.Count()}";
            }
            catch (Exception)
            {

            }
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            toolStripProgressBar1.Visible = true;
            toolStripStatusLabel1.Visible = true;
            dataset = await GetTransactionsAsync(retailDatas);
            findAllBtn.Enabled = true;
            toolStripProgressBar1.Visible = false;
            toolStripStatusLabel1.Visible = false;
            toolStripProgressBar1.Value = 0;
            label9.Text = $"% - 0/{dataset.Count()}";
        }

        private void SuppTxtb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double percent = double.Parse(suppTxtb.Text);
                double supp = ((double)((double)dataset.Count() / (double)100)) * percent;
                int support = (int)Math.Round(supp);
                label9.Text = $"% - {support}/{dataset.Count()}";
            }
            catch (Exception)
            {

            }
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            DateTime tempDT = new DateTime();
            List<double> graphDatas = new List<double>();
            List<string> graphLabels = new List<string>();
            List<RetailData> correctedSet = new List<RetailData>();
            foreach(var rd in retailDatas)
            {
                if(DateTime.TryParseExact(rd.InvoiceDate, @"dd/MM/yyyy HH\:mm",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out tempDT))
                {
                    correctedSet.Add(rd);
                }
            }
            List<RetailData> filteredSet = new List<RetailData>();
            foreach(var rd in correctedSet)
            {
                if(DateTime.ParseExact(rd.InvoiceDate, @"dd/MM/yyyy HH\:mm", CultureInfo.InvariantCulture).Date >= fromDtp.Value.Date &&
                   DateTime.ParseExact(rd.InvoiceDate, @"dd/MM/yyyy HH\:mm", CultureInfo.InvariantCulture).Date <= toDtp.Value.Date)
                {
                    filteredSet.Add(rd);
                }
            }

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("cl1", "Khách hàng");
            dataGridView1.Columns.Add("cl2", "Số lượt mua");
            dataGridView1.Columns.Add("cl3", "Chi tiêu");

            var customerList = filteredSet.Select(x => x.CustomerID).Distinct();
            var buyingCount = filteredSet.Select(x => new { x.CustomerID, x.InvoiceNo }).Distinct();
            foreach(var customer in customerList)
            {
                var cbuyingCount = buyingCount.Where(x => x.CustomerID.Equals(customer)).Count();
                var totalSpend = filteredSet.Where(x => x.CustomerID.Equals(customer))
                    .Select(y => new { Total = Double.Parse(y.UnitPrice) * Double.Parse(y.Quantity) })
                    .Sum(z=>z.Total);

                dataGridView1.Rows.Add(customer, cbuyingCount, totalSpend);
                graphDatas.Add(totalSpend);
                graphLabels.Add(customer);
            }

            DrawGraph2("Chi tiêu khách hàng", graphDatas, graphLabels);
        }

        private void DrawGraph2(string property, List<double> graphDatas, List<string> labels)
        {
            GraphPane graphPane = zedGraphControl2.GraphPane;
            graphPane.GraphObjList.Clear();
            graphPane.CurveList.Clear();
            zedGraphControl2.AxisChange();
            zedGraphControl2.Refresh();

            graphPane.XAxis.Title.Text = "Hạng mục";
            graphPane.YAxis.Title.Text = "Số lượng";
            BarItem barItem = graphPane.AddBar(property, null, graphDatas.ToArray(), Color.LightBlue);
            //if (labels.Count <= 10)
            //{
                graphPane.XAxis.Scale.TextLabels = labels.ToArray();
                graphPane.XAxis.Type = AxisType.Text;
                graphPane.XAxis.MajorTic.IsBetweenLabels = true;
            //}
            //else
            //{
            //    graphPane.XAxis.Scale.TextLabels = null;
            //    graphPane.XAxis.Type = AxisType.Linear;
            //    graphPane.XAxis.MajorTic.IsBetweenLabels = false;
            //}
            zedGraphControl2.AxisChange();
            zedGraphControl2.Refresh();
        }
    }
}
