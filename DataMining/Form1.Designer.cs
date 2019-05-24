namespace DataMining
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fileDirectoryTxtB = new System.Windows.Forms.TextBox();
            this.openFileBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.propDetailsDgv = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.propertiesDgv = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.assocRuleDgv = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assocRuleRtb = new System.Windows.Forms.RichTextBox();
            this.openFinderBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.findAllBtn = new System.Windows.Forms.Button();
            this.searchBtn = new System.Windows.Forms.Button();
            this.confTxtb = new System.Windows.Forms.TextBox();
            this.suppTxtb = new System.Windows.Forms.TextBox();
            this.searchTxtb = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.analysistT_Btn = new System.Windows.Forms.Button();
            this.analysistC_Btn = new System.Windows.Forms.Button();
            this.searchGspBtn = new System.Windows.Forms.Button();
            this.finAllGSPBtn = new System.Windows.Forms.Button();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.frequentDgv = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.suppGspTxtb = new System.Windows.Forms.TextBox();
            this.searchGspTxtb = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.propDetailsDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.propertiesDgv)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.assocRuleDgv)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frequentDgv)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // fileDirectoryTxtB
            // 
            this.fileDirectoryTxtB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileDirectoryTxtB.Enabled = false;
            this.fileDirectoryTxtB.Location = new System.Drawing.Point(40, 4);
            this.fileDirectoryTxtB.Name = "fileDirectoryTxtB";
            this.fileDirectoryTxtB.Size = new System.Drawing.Size(719, 27);
            this.fileDirectoryTxtB.TabIndex = 0;
            // 
            // openFileBtn
            // 
            this.openFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openFileBtn.Location = new System.Drawing.Point(765, 4);
            this.openFileBtn.Name = "openFileBtn";
            this.openFileBtn.Size = new System.Drawing.Size(74, 27);
            this.openFileBtn.TabIndex = 1;
            this.openFileBtn.Text = "Mở file";
            this.openFileBtn.UseVisualStyleBackColor = true;
            this.openFileBtn.Click += new System.EventHandler(this.OpenFileBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "File";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Enabled = false;
            this.tabControl1.Location = new System.Drawing.Point(12, 37);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(827, 397);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(819, 364);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tổng quan";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.propDetailsDgv);
            this.splitContainer1.Panel1.Controls.Add(this.propertiesDgv);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.zedGraphControl1);
            this.splitContainer1.Size = new System.Drawing.Size(813, 358);
            this.splitContainer1.SplitterDistance = 385;
            this.splitContainer1.TabIndex = 0;
            // 
            // propDetailsDgv
            // 
            this.propDetailsDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propDetailsDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.propDetailsDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.propDetailsDgv.Location = new System.Drawing.Point(3, 177);
            this.propDetailsDgv.Name = "propDetailsDgv";
            this.propDetailsDgv.Size = new System.Drawing.Size(379, 178);
            this.propDetailsDgv.TabIndex = 2;
            this.propDetailsDgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PropDetailsDgv_CellContentClick);
            // 
            // Column8
            // 
            this.Column8.HeaderText = "STT";
            this.Column8.Name = "Column8";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Hạng mục";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Số lượng";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // propertiesDgv
            // 
            this.propertiesDgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertiesDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.propertiesDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.dataGridViewTextBoxColumn3});
            this.propertiesDgv.Location = new System.Drawing.Point(3, 3);
            this.propertiesDgv.Name = "propertiesDgv";
            this.propertiesDgv.Size = new System.Drawing.Size(379, 168);
            this.propertiesDgv.TabIndex = 2;
            this.propertiesDgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PropertiesDgv_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Thuộc tính";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Số lượng";
            this.Column2.Name = "Column2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Đơn vị";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraphControl1.Location = new System.Drawing.Point(4, 5);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(416, 348);
            this.zedGraphControl1.TabIndex = 0;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer2);
            this.tabPage2.Controls.Add(this.openFinderBtn);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.findAllBtn);
            this.tabPage2.Controls.Add(this.searchBtn);
            this.tabPage2.Controls.Add(this.confTxtb);
            this.tabPage2.Controls.Add(this.suppTxtb);
            this.tabPage2.Controls.Add(this.searchTxtb);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(819, 364);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Qui luật mua hàng";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(6, 78);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.assocRuleDgv);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.assocRuleRtb);
            this.splitContainer2.Size = new System.Drawing.Size(810, 280);
            this.splitContainer2.SplitterDistance = 558;
            this.splitContainer2.TabIndex = 5;
            // 
            // assocRuleDgv
            // 
            this.assocRuleDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.assocRuleDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.assocRuleDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4,
            this.Column5});
            this.assocRuleDgv.Location = new System.Drawing.Point(9, 7);
            this.assocRuleDgv.Name = "assocRuleDgv";
            this.assocRuleDgv.Size = new System.Drawing.Size(546, 270);
            this.assocRuleDgv.TabIndex = 1;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "QL mua hàng";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Mức phổ biến";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Mức tin cậy";
            this.Column5.Name = "Column5";
            // 
            // assocRuleRtb
            // 
            this.assocRuleRtb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.assocRuleRtb.Location = new System.Drawing.Point(3, 7);
            this.assocRuleRtb.Name = "assocRuleRtb";
            this.assocRuleRtb.Size = new System.Drawing.Size(242, 270);
            this.assocRuleRtb.TabIndex = 0;
            this.assocRuleRtb.Text = "";
            // 
            // openFinderBtn
            // 
            this.openFinderBtn.Location = new System.Drawing.Point(440, 13);
            this.openFinderBtn.Name = "openFinderBtn";
            this.openFinderBtn.Size = new System.Drawing.Size(149, 29);
            this.openFinderBtn.TabIndex = 4;
            this.openFinderBtn.Text = "Tra cứu sản phẩm";
            this.openFinderBtn.UseVisualStyleBackColor = true;
            this.openFinderBtn.Click += new System.EventHandler(this.OpenFinderBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(227, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Độ tin cậy";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tìm kiếm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Độ phổ biến";
            // 
            // findAllBtn
            // 
            this.findAllBtn.Enabled = false;
            this.findAllBtn.Location = new System.Drawing.Point(316, 45);
            this.findAllBtn.Name = "findAllBtn";
            this.findAllBtn.Size = new System.Drawing.Size(124, 27);
            this.findAllBtn.TabIndex = 2;
            this.findAllBtn.Text = "Phân tích";
            this.findAllBtn.UseVisualStyleBackColor = true;
            this.findAllBtn.Click += new System.EventHandler(this.FindAllBtn_Click);
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(227, 45);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(83, 27);
            this.searchBtn.TabIndex = 2;
            this.searchBtn.Text = "Tìm";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // confTxtb
            // 
            this.confTxtb.Location = new System.Drawing.Point(309, 14);
            this.confTxtb.Name = "confTxtb";
            this.confTxtb.Size = new System.Drawing.Size(118, 27);
            this.confTxtb.TabIndex = 1;
            // 
            // suppTxtb
            // 
            this.suppTxtb.Location = new System.Drawing.Point(103, 14);
            this.suppTxtb.Name = "suppTxtb";
            this.suppTxtb.Size = new System.Drawing.Size(118, 27);
            this.suppTxtb.TabIndex = 1;
            // 
            // searchTxtb
            // 
            this.searchTxtb.Location = new System.Drawing.Point(103, 45);
            this.searchTxtb.Name = "searchTxtb";
            this.searchTxtb.Size = new System.Drawing.Size(118, 27);
            this.searchTxtb.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.analysistT_Btn);
            this.tabPage3.Controls.Add(this.analysistC_Btn);
            this.tabPage3.Controls.Add(this.searchGspBtn);
            this.tabPage3.Controls.Add(this.finAllGSPBtn);
            this.tabPage3.Controls.Add(this.splitContainer3);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.suppGspTxtb);
            this.tabPage3.Controls.Add(this.searchGspTxtb);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(819, 364);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Thói quen mua hàng";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(46, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(216, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "Thói quen mua chuỗi sản phẩm";
            // 
            // analysistT_Btn
            // 
            this.analysistT_Btn.Location = new System.Drawing.Point(268, 40);
            this.analysistT_Btn.Name = "analysistT_Btn";
            this.analysistT_Btn.Size = new System.Drawing.Size(151, 32);
            this.analysistT_Btn.TabIndex = 10;
            this.analysistT_Btn.Text = "Theo thời gian";
            this.analysistT_Btn.UseVisualStyleBackColor = true;
            this.analysistT_Btn.Click += new System.EventHandler(this.AnalysistT_Btn_Click);
            // 
            // analysistC_Btn
            // 
            this.analysistC_Btn.Location = new System.Drawing.Point(268, 6);
            this.analysistC_Btn.Name = "analysistC_Btn";
            this.analysistC_Btn.Size = new System.Drawing.Size(151, 32);
            this.analysistC_Btn.TabIndex = 10;
            this.analysistC_Btn.Text = "Theo khách hàng";
            this.analysistC_Btn.UseVisualStyleBackColor = true;
            this.analysistC_Btn.Click += new System.EventHandler(this.AnalysistC_Btn_Click);
            // 
            // searchGspBtn
            // 
            this.searchGspBtn.Enabled = false;
            this.searchGspBtn.Location = new System.Drawing.Point(691, 42);
            this.searchGspBtn.Name = "searchGspBtn";
            this.searchGspBtn.Size = new System.Drawing.Size(112, 27);
            this.searchGspBtn.TabIndex = 9;
            this.searchGspBtn.Text = "Tìm kiếm";
            this.searchGspBtn.UseVisualStyleBackColor = true;
            // 
            // finAllGSPBtn
            // 
            this.finAllGSPBtn.Enabled = false;
            this.finAllGSPBtn.Location = new System.Drawing.Point(691, 11);
            this.finAllGSPBtn.Name = "finAllGSPBtn";
            this.finAllGSPBtn.Size = new System.Drawing.Size(112, 27);
            this.finAllGSPBtn.TabIndex = 9;
            this.finAllGSPBtn.Text = "Phân tích";
            this.finAllGSPBtn.UseVisualStyleBackColor = true;
            this.finAllGSPBtn.Click += new System.EventHandler(this.FinAllGSPBtn_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer3.Location = new System.Drawing.Point(3, 76);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.frequentDgv);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.richTextBox1);
            this.splitContainer3.Size = new System.Drawing.Size(813, 285);
            this.splitContainer3.SplitterDistance = 581;
            this.splitContainer3.TabIndex = 8;
            // 
            // frequentDgv
            // 
            this.frequentDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.frequentDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.frequentDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column7});
            this.frequentDgv.Location = new System.Drawing.Point(3, 3);
            this.frequentDgv.Name = "frequentDgv";
            this.frequentDgv.Size = new System.Drawing.Size(575, 279);
            this.frequentDgv.TabIndex = 0;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Hạng mục";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Support";
            this.Column7.Name = "Column7";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(222, 279);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(424, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Tìm kiếm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(425, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Support";
            // 
            // suppGspTxtb
            // 
            this.suppGspTxtb.Location = new System.Drawing.Point(500, 11);
            this.suppGspTxtb.Name = "suppGspTxtb";
            this.suppGspTxtb.Size = new System.Drawing.Size(185, 27);
            this.suppGspTxtb.TabIndex = 4;
            // 
            // searchGspTxtb
            // 
            this.searchGspTxtb.Location = new System.Drawing.Point(500, 42);
            this.searchGspTxtb.Name = "searchGspTxtb";
            this.searchGspTxtb.Size = new System.Drawing.Size(185, 27);
            this.searchGspTxtb.TabIndex = 5;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(819, 364);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Thống kê";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 424);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(848, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(99, 17);
            this.toolStripStatusLabel1.Text = "Đang xử lí dữ liệu";
            this.toolStripStatusLabel1.Visible = false;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(500, 16);
            this.toolStripProgressBar1.Step = 1;
            this.toolStripProgressBar1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 446);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.openFileBtn);
            this.Controls.Add(this.fileDirectoryTxtB);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.propDetailsDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.propertiesDgv)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.assocRuleDgv)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.frequentDgv)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox fileDirectoryTxtB;
        private System.Windows.Forms.Button openFileBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView propDetailsDgv;
        private System.Windows.Forms.DataGridView propertiesDgv;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button findAllBtn;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.TextBox confTxtb;
        private System.Windows.Forms.TextBox suppTxtb;
        private System.Windows.Forms.TextBox searchTxtb;
        private System.Windows.Forms.Button openFinderBtn;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView assocRuleDgv;
        private System.Windows.Forms.RichTextBox assocRuleRtb;
        private System.Windows.Forms.Button searchGspBtn;
        private System.Windows.Forms.Button finAllGSPBtn;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DataGridView frequentDgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox suppGspTxtb;
        private System.Windows.Forms.TextBox searchGspTxtb;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button analysistT_Btn;
        private System.Windows.Forms.Button analysistC_Btn;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}

