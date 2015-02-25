namespace MyStockAnalyzer
{
    partial class FrmMain
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1111D, "1,2,3,4");
            this.btnUpdateStockData = new System.Windows.Forms.Button();
            this.dtStockBgn = new System.Windows.Forms.DateTimePicker();
            this.dtStockEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLog = new System.Windows.Forms.DataGridView();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRecord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linkLblClearLog = new System.Windows.Forms.LinkLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpSelection = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblAlgorithms = new System.Windows.Forms.Label();
            this.dtSelectionBgn = new System.Windows.Forms.DateTimePicker();
            this.linkLblAlgorithms = new System.Windows.Forms.LinkLabel();
            this.btnSelection = new System.Windows.Forms.Button();
            this.chkRealData = new System.Windows.Forms.CheckBox();
            this.dtSelectionEnd = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvSelectionResult = new System.Windows.Forms.DataGridView();
            this.colSelectionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSelectionStockId = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colSelectionStockName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSelectionMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSelectionWarrant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSelectionMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbSelectionWaitCollect = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSelectionExport = new System.Windows.Forms.Button();
            this.tpWarrant = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLblWarrantRefresh = new System.Windows.Forms.LinkLabel();
            this.dgvWarrantList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvWarrantStock = new System.Windows.Forms.DataGridView();
            this.colWarrantStockId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWarrantStockName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpWaitCollect = new System.Windows.Forms.TabPage();
            this.cmbWaitCollect = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tpHistoryCollect = new System.Windows.Forms.TabPage();
            this.cmbHistoryCollect = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tpMemo = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSaveMemo = new System.Windows.Forms.Button();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.saveCSVDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.chartKBar = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tpSelection.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectionResult)).BeginInit();
            this.panel2.SuspendLayout();
            this.tpWarrant.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarrantList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarrantStock)).BeginInit();
            this.tpWaitCollect.SuspendLayout();
            this.tpHistoryCollect.SuspendLayout();
            this.tpMemo.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartKBar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdateStockData
            // 
            this.btnUpdateStockData.Location = new System.Drawing.Point(340, 7);
            this.btnUpdateStockData.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateStockData.Name = "btnUpdateStockData";
            this.btnUpdateStockData.Size = new System.Drawing.Size(112, 31);
            this.btnUpdateStockData.TabIndex = 0;
            this.btnUpdateStockData.Text = "更新股票資訊";
            this.btnUpdateStockData.UseVisualStyleBackColor = true;
            this.btnUpdateStockData.Click += new System.EventHandler(this.btnUpdateStockData_Click);
            // 
            // dtStockBgn
            // 
            this.dtStockBgn.CustomFormat = "yyyy/MM/dd";
            this.dtStockBgn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStockBgn.Location = new System.Drawing.Point(22, 9);
            this.dtStockBgn.Margin = new System.Windows.Forms.Padding(4);
            this.dtStockBgn.Name = "dtStockBgn";
            this.dtStockBgn.Size = new System.Drawing.Size(139, 27);
            this.dtStockBgn.TabIndex = 1;
            // 
            // dtStockEnd
            // 
            this.dtStockEnd.CustomFormat = "yyyy/MM/dd";
            this.dtStockEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStockEnd.Location = new System.Drawing.Point(193, 9);
            this.dtStockEnd.Margin = new System.Windows.Forms.Padding(4);
            this.dtStockEnd.Name = "dtStockEnd";
            this.dtStockEnd.Size = new System.Drawing.Size(139, 27);
            this.dtStockEnd.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(169, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "~";
            // 
            // dgvLog
            // 
            this.dgvLog.AllowUserToAddRows = false;
            this.dgvLog.AllowUserToDeleteRows = false;
            this.dgvLog.AllowUserToOrderColumns = true;
            this.dgvLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTime,
            this.colRecord});
            this.dgvLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLog.Location = new System.Drawing.Point(3, 565);
            this.dgvLog.MultiSelect = false;
            this.dgvLog.Name = "dgvLog";
            this.dgvLog.RowHeadersVisible = false;
            this.dgvLog.RowTemplate.Height = 24;
            this.dgvLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLog.Size = new System.Drawing.Size(1178, 194);
            this.dgvLog.TabIndex = 4;
            // 
            // colTime
            // 
            this.colTime.FillWeight = 15F;
            this.colTime.HeaderText = "時間";
            this.colTime.Name = "colTime";
            this.colTime.ReadOnly = true;
            // 
            // colRecord
            // 
            this.colRecord.FillWeight = 85F;
            this.colRecord.HeaderText = "紀錄";
            this.colRecord.Name = "colRecord";
            this.colRecord.ReadOnly = true;
            // 
            // linkLblClearLog
            // 
            this.linkLblClearLog.AutoSize = true;
            this.linkLblClearLog.Location = new System.Drawing.Point(3, 546);
            this.linkLblClearLog.Name = "linkLblClearLog";
            this.linkLblClearLog.Size = new System.Drawing.Size(72, 16);
            this.linkLblClearLog.TabIndex = 5;
            this.linkLblClearLog.TabStop = true;
            this.linkLblClearLog.Text = "清除紀錄";
            this.linkLblClearLog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblClearLog_LinkClicked);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpSelection);
            this.tabControl1.Controls.Add(this.tpWarrant);
            this.tabControl1.Controls.Add(this.tpWaitCollect);
            this.tabControl1.Controls.Add(this.tpHistoryCollect);
            this.tabControl1.Controls.Add(this.tpMemo);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 253);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1178, 290);
            this.tabControl1.TabIndex = 6;
            // 
            // tpSelection
            // 
            this.tpSelection.Controls.Add(this.tableLayoutPanel2);
            this.tpSelection.Location = new System.Drawing.Point(4, 26);
            this.tpSelection.Name = "tpSelection";
            this.tpSelection.Padding = new System.Windows.Forms.Padding(3);
            this.tpSelection.Size = new System.Drawing.Size(1170, 260);
            this.tpSelection.TabIndex = 1;
            this.tpSelection.Text = "選股";
            this.tpSelection.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.dgvSelectionResult, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnSelectionExport, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1164, 254);
            this.tableLayoutPanel2.TabIndex = 18;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblAlgorithms);
            this.panel3.Controls.Add(this.dtSelectionBgn);
            this.panel3.Controls.Add(this.linkLblAlgorithms);
            this.panel3.Controls.Add(this.btnSelection);
            this.panel3.Controls.Add(this.chkRealData);
            this.panel3.Controls.Add(this.dtSelectionEnd);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1058, 34);
            this.panel3.TabIndex = 1;
            // 
            // lblAlgorithms
            // 
            this.lblAlgorithms.AutoSize = true;
            this.lblAlgorithms.ForeColor = System.Drawing.Color.DarkRed;
            this.lblAlgorithms.Location = new System.Drawing.Point(644, 9);
            this.lblAlgorithms.Name = "lblAlgorithms";
            this.lblAlgorithms.Size = new System.Drawing.Size(130, 16);
            this.lblAlgorithms.TabIndex = 15;
            this.lblAlgorithms.Text = "(尚未選擇演算法)";
            // 
            // dtSelectionBgn
            // 
            this.dtSelectionBgn.CustomFormat = "yyyy/MM/dd";
            this.dtSelectionBgn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtSelectionBgn.Location = new System.Drawing.Point(14, 4);
            this.dtSelectionBgn.Margin = new System.Windows.Forms.Padding(4);
            this.dtSelectionBgn.Name = "dtSelectionBgn";
            this.dtSelectionBgn.Size = new System.Drawing.Size(139, 27);
            this.dtSelectionBgn.TabIndex = 9;
            // 
            // linkLblAlgorithms
            // 
            this.linkLblAlgorithms.AutoSize = true;
            this.linkLblAlgorithms.Location = new System.Drawing.Point(549, 9);
            this.linkLblAlgorithms.Name = "linkLblAlgorithms";
            this.linkLblAlgorithms.Size = new System.Drawing.Size(88, 16);
            this.linkLblAlgorithms.TabIndex = 14;
            this.linkLblAlgorithms.TabStop = true;
            this.linkLblAlgorithms.Text = "選擇演算法";
            this.linkLblAlgorithms.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblAlgorithms_LinkClicked);
            // 
            // btnSelection
            // 
            this.btnSelection.Location = new System.Drawing.Point(332, 2);
            this.btnSelection.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelection.Name = "btnSelection";
            this.btnSelection.Size = new System.Drawing.Size(112, 31);
            this.btnSelection.TabIndex = 8;
            this.btnSelection.Text = "執行篩選";
            this.btnSelection.UseVisualStyleBackColor = true;
            this.btnSelection.Click += new System.EventHandler(this.btnSelection_Click);
            // 
            // chkRealData
            // 
            this.chkRealData.AutoSize = true;
            this.chkRealData.Location = new System.Drawing.Point(452, 7);
            this.chkRealData.Name = "chkRealData";
            this.chkRealData.Size = new System.Drawing.Size(91, 20);
            this.chkRealData.TabIndex = 13;
            this.chkRealData.Text = "即時股價";
            this.chkRealData.UseVisualStyleBackColor = true;
            // 
            // dtSelectionEnd
            // 
            this.dtSelectionEnd.CustomFormat = "yyyy/MM/dd";
            this.dtSelectionEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtSelectionEnd.Location = new System.Drawing.Point(185, 4);
            this.dtSelectionEnd.Margin = new System.Windows.Forms.Padding(4);
            this.dtSelectionEnd.Name = "dtSelectionEnd";
            this.dtSelectionEnd.Size = new System.Drawing.Size(139, 27);
            this.dtSelectionEnd.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(161, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "~";
            // 
            // dgvSelectionResult
            // 
            this.dgvSelectionResult.AllowUserToAddRows = false;
            this.dgvSelectionResult.AllowUserToDeleteRows = false;
            this.dgvSelectionResult.AllowUserToOrderColumns = true;
            this.dgvSelectionResult.AllowUserToResizeColumns = false;
            this.dgvSelectionResult.AllowUserToResizeRows = false;
            this.dgvSelectionResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSelectionResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelectionResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelectionDate,
            this.colSelectionStockId,
            this.colSelectionStockName,
            this.colSelectionMethod,
            this.colSelectionWarrant,
            this.colSelectionMemo});
            this.tableLayoutPanel2.SetColumnSpan(this.dgvSelectionResult, 2);
            this.dgvSelectionResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSelectionResult.Location = new System.Drawing.Point(3, 83);
            this.dgvSelectionResult.Name = "dgvSelectionResult";
            this.dgvSelectionResult.RowHeadersVisible = false;
            this.dgvSelectionResult.RowTemplate.Height = 24;
            this.dgvSelectionResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSelectionResult.Size = new System.Drawing.Size(1158, 168);
            this.dgvSelectionResult.TabIndex = 12;
            this.dgvSelectionResult.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSelectionResult_CellContentClick);
            // 
            // colSelectionDate
            // 
            this.colSelectionDate.FillWeight = 13F;
            this.colSelectionDate.HeaderText = "時間";
            this.colSelectionDate.Name = "colSelectionDate";
            this.colSelectionDate.ReadOnly = true;
            // 
            // colSelectionStockId
            // 
            this.colSelectionStockId.FillWeight = 9F;
            this.colSelectionStockId.HeaderText = "代碼";
            this.colSelectionStockId.Name = "colSelectionStockId";
            this.colSelectionStockId.ReadOnly = true;
            this.colSelectionStockId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSelectionStockId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colSelectionStockName
            // 
            this.colSelectionStockName.FillWeight = 13F;
            this.colSelectionStockName.HeaderText = "名稱";
            this.colSelectionStockName.Name = "colSelectionStockName";
            this.colSelectionStockName.ReadOnly = true;
            // 
            // colSelectionMethod
            // 
            this.colSelectionMethod.FillWeight = 15F;
            this.colSelectionMethod.HeaderText = "篩選方法";
            this.colSelectionMethod.Name = "colSelectionMethod";
            this.colSelectionMethod.ReadOnly = true;
            // 
            // colSelectionWarrant
            // 
            this.colSelectionWarrant.FillWeight = 8F;
            this.colSelectionWarrant.HeaderText = "權證";
            this.colSelectionWarrant.Name = "colSelectionWarrant";
            this.colSelectionWarrant.ReadOnly = true;
            // 
            // colSelectionMemo
            // 
            this.colSelectionMemo.FillWeight = 52.53807F;
            this.colSelectionMemo.HeaderText = "備註";
            this.colSelectionMemo.Name = "colSelectionMemo";
            this.colSelectionMemo.ReadOnly = true;
            // 
            // panel2
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.panel2, 2);
            this.panel2.Controls.Add(this.cmbSelectionWaitCollect);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1158, 34);
            this.panel2.TabIndex = 0;
            // 
            // cmbSelectionWaitCollect
            // 
            this.cmbSelectionWaitCollect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectionWaitCollect.FormattingEnabled = true;
            this.cmbSelectionWaitCollect.Location = new System.Drawing.Point(89, 5);
            this.cmbSelectionWaitCollect.Name = "cmbSelectionWaitCollect";
            this.cmbSelectionWaitCollect.Size = new System.Drawing.Size(449, 24);
            this.cmbSelectionWaitCollect.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "候選清單";
            // 
            // btnSelectionExport
            // 
            this.btnSelectionExport.Location = new System.Drawing.Point(1068, 4);
            this.btnSelectionExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectionExport.Name = "btnSelectionExport";
            this.btnSelectionExport.Size = new System.Drawing.Size(92, 31);
            this.btnSelectionExport.TabIndex = 17;
            this.btnSelectionExport.Text = "匯出結果";
            this.btnSelectionExport.UseVisualStyleBackColor = true;
            this.btnSelectionExport.Click += new System.EventHandler(this.btnSelectionExport_Click);
            // 
            // tpWarrant
            // 
            this.tpWarrant.Controls.Add(this.tableLayoutPanel3);
            this.tpWarrant.Location = new System.Drawing.Point(4, 26);
            this.tpWarrant.Name = "tpWarrant";
            this.tpWarrant.Padding = new System.Windows.Forms.Padding(3);
            this.tpWarrant.Size = new System.Drawing.Size(1181, 392);
            this.tpWarrant.TabIndex = 0;
            this.tpWarrant.Text = "權證";
            this.tpWarrant.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 305F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 305F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.dgvWarrantList, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.dgvWarrantStock, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1175, 386);
            this.tableLayoutPanel3.TabIndex = 9;
            // 
            // panel4
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.panel4, 3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.linkLblWarrantRefresh);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1169, 24);
            this.panel4.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-6, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "可發行權證標的";
            // 
            // linkLblWarrantRefresh
            // 
            this.linkLblWarrantRefresh.AutoSize = true;
            this.linkLblWarrantRefresh.Location = new System.Drawing.Point(121, 7);
            this.linkLblWarrantRefresh.Name = "linkLblWarrantRefresh";
            this.linkLblWarrantRefresh.Size = new System.Drawing.Size(72, 16);
            this.linkLblWarrantRefresh.TabIndex = 8;
            this.linkLblWarrantRefresh.TabStop = true;
            this.linkLblWarrantRefresh.Text = "重新整理";
            this.linkLblWarrantRefresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblWarrantRefresh_LinkClicked);
            // 
            // dgvWarrantList
            // 
            this.dgvWarrantList.AllowUserToAddRows = false;
            this.dgvWarrantList.AllowUserToDeleteRows = false;
            this.dgvWarrantList.AllowUserToOrderColumns = true;
            this.dgvWarrantList.AllowUserToResizeColumns = false;
            this.dgvWarrantList.AllowUserToResizeRows = false;
            this.dgvWarrantList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvWarrantList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWarrantList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvWarrantList.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvWarrantList.Location = new System.Drawing.Point(308, 33);
            this.dgvWarrantList.MultiSelect = false;
            this.dgvWarrantList.Name = "dgvWarrantList";
            this.dgvWarrantList.RowHeadersVisible = false;
            this.dgvWarrantList.RowTemplate.Height = 24;
            this.dgvWarrantList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWarrantList.Size = new System.Drawing.Size(299, 350);
            this.dgvWarrantList.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 50F;
            this.dataGridViewTextBoxColumn1.HeaderText = "權證代碼";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 70F;
            this.dataGridViewTextBoxColumn2.HeaderText = "權證名稱";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dgvWarrantStock
            // 
            this.dgvWarrantStock.AllowUserToAddRows = false;
            this.dgvWarrantStock.AllowUserToDeleteRows = false;
            this.dgvWarrantStock.AllowUserToOrderColumns = true;
            this.dgvWarrantStock.AllowUserToResizeColumns = false;
            this.dgvWarrantStock.AllowUserToResizeRows = false;
            this.dgvWarrantStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvWarrantStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWarrantStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colWarrantStockId,
            this.colWarrantStockName});
            this.dgvWarrantStock.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvWarrantStock.Location = new System.Drawing.Point(3, 33);
            this.dgvWarrantStock.MultiSelect = false;
            this.dgvWarrantStock.Name = "dgvWarrantStock";
            this.dgvWarrantStock.RowHeadersVisible = false;
            this.dgvWarrantStock.RowTemplate.Height = 24;
            this.dgvWarrantStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWarrantStock.Size = new System.Drawing.Size(299, 350);
            this.dgvWarrantStock.TabIndex = 5;
            // 
            // colWarrantStockId
            // 
            this.colWarrantStockId.FillWeight = 50F;
            this.colWarrantStockId.HeaderText = "股票代碼";
            this.colWarrantStockId.Name = "colWarrantStockId";
            this.colWarrantStockId.ReadOnly = true;
            // 
            // colWarrantStockName
            // 
            this.colWarrantStockName.FillWeight = 70F;
            this.colWarrantStockName.HeaderText = "股票名稱";
            this.colWarrantStockName.Name = "colWarrantStockName";
            this.colWarrantStockName.ReadOnly = true;
            // 
            // tpWaitCollect
            // 
            this.tpWaitCollect.Controls.Add(this.cmbWaitCollect);
            this.tpWaitCollect.Controls.Add(this.label5);
            this.tpWaitCollect.Location = new System.Drawing.Point(4, 26);
            this.tpWaitCollect.Name = "tpWaitCollect";
            this.tpWaitCollect.Padding = new System.Windows.Forms.Padding(3);
            this.tpWaitCollect.Size = new System.Drawing.Size(1181, 392);
            this.tpWaitCollect.TabIndex = 2;
            this.tpWaitCollect.Text = "候選";
            this.tpWaitCollect.UseVisualStyleBackColor = true;
            // 
            // cmbWaitCollect
            // 
            this.cmbWaitCollect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWaitCollect.FormattingEnabled = true;
            this.cmbWaitCollect.Location = new System.Drawing.Point(84, 10);
            this.cmbWaitCollect.Name = "cmbWaitCollect";
            this.cmbWaitCollect.Size = new System.Drawing.Size(449, 24);
            this.cmbWaitCollect.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "候選清單";
            // 
            // tpHistoryCollect
            // 
            this.tpHistoryCollect.Controls.Add(this.cmbHistoryCollect);
            this.tpHistoryCollect.Controls.Add(this.label6);
            this.tpHistoryCollect.Location = new System.Drawing.Point(4, 26);
            this.tpHistoryCollect.Name = "tpHistoryCollect";
            this.tpHistoryCollect.Padding = new System.Windows.Forms.Padding(3);
            this.tpHistoryCollect.Size = new System.Drawing.Size(1181, 392);
            this.tpHistoryCollect.TabIndex = 3;
            this.tpHistoryCollect.Text = "歷史候選";
            this.tpHistoryCollect.UseVisualStyleBackColor = true;
            // 
            // cmbHistoryCollect
            // 
            this.cmbHistoryCollect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHistoryCollect.FormattingEnabled = true;
            this.cmbHistoryCollect.Location = new System.Drawing.Point(84, 10);
            this.cmbHistoryCollect.Name = "cmbHistoryCollect";
            this.cmbHistoryCollect.Size = new System.Drawing.Size(449, 24);
            this.cmbHistoryCollect.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "候選清單";
            // 
            // tpMemo
            // 
            this.tpMemo.Controls.Add(this.tableLayoutPanel4);
            this.tpMemo.Location = new System.Drawing.Point(4, 26);
            this.tpMemo.Name = "tpMemo";
            this.tpMemo.Padding = new System.Windows.Forms.Padding(3);
            this.tpMemo.Size = new System.Drawing.Size(1181, 392);
            this.tpMemo.TabIndex = 4;
            this.tpMemo.Text = "備註";
            this.tpMemo.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.btnSaveMemo, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtMemo, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1175, 386);
            this.tableLayoutPanel4.TabIndex = 9;
            // 
            // btnSaveMemo
            // 
            this.btnSaveMemo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSaveMemo.Location = new System.Drawing.Point(1059, 4);
            this.btnSaveMemo.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveMemo.Name = "btnSaveMemo";
            this.btnSaveMemo.Size = new System.Drawing.Size(112, 27);
            this.btnSaveMemo.TabIndex = 8;
            this.btnSaveMemo.Text = "儲存備註";
            this.btnSaveMemo.UseVisualStyleBackColor = true;
            this.btnSaveMemo.Click += new System.EventHandler(this.btnSaveMemo_Click);
            // 
            // txtMemo
            // 
            this.txtMemo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMemo.Location = new System.Drawing.Point(3, 38);
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(1169, 345);
            this.txtMemo.TabIndex = 0;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(460, 7);
            this.btnTest.Margin = new System.Windows.Forms.Padding(4);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(112, 31);
            this.btnTest.TabIndex = 7;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnUpdateStockData);
            this.panel1.Controls.Add(this.dtStockBgn);
            this.panel1.Controls.Add(this.btnTest);
            this.panel1.Controls.Add(this.dtStockEnd);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1178, 44);
            this.panel1.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.linkLblClearLog, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dgvLog, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.chartKBar, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1184, 762);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // saveCSVDialog
            // 
            this.saveCSVDialog.Filter = "CSV檔案|*.csv";
            // 
            // chartKBar
            // 
            chartArea1.Name = "ChartArea1";
            this.chartKBar.ChartAreas.Add(chartArea1);
            this.chartKBar.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartKBar.Legends.Add(legend1);
            this.chartKBar.Location = new System.Drawing.Point(3, 53);
            this.chartKBar.Name = "chartKBar";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Stock;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.Points.Add(dataPoint1);
            series1.YValuesPerPoint = 4;
            this.chartKBar.Series.Add(series1);
            this.chartKBar.Size = new System.Drawing.Size(1178, 194);
            this.chartKBar.TabIndex = 9;
            this.chartKBar.Text = "chart1";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 762);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("新細明體", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMain";
            this.Text = "我的股票分析軟體";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tpSelection.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectionResult)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tpWarrant.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarrantList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarrantStock)).EndInit();
            this.tpWaitCollect.ResumeLayout(false);
            this.tpWaitCollect.PerformLayout();
            this.tpHistoryCollect.ResumeLayout(false);
            this.tpHistoryCollect.PerformLayout();
            this.tpMemo.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartKBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUpdateStockData;
        private System.Windows.Forms.DateTimePicker dtStockBgn;
        private System.Windows.Forms.DateTimePicker dtStockEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecord;
        private System.Windows.Forms.LinkLabel linkLblClearLog;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpWarrant;
        private System.Windows.Forms.TabPage tpSelection;
        private System.Windows.Forms.DataGridView dgvWarrantList;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvWarrantStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWarrantStockId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWarrantStockName;
        private System.Windows.Forms.LinkLabel linkLblWarrantRefresh;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.DataGridView dgvSelectionResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtSelectionBgn;
        private System.Windows.Forms.DateTimePicker dtSelectionEnd;
        private System.Windows.Forms.Button btnSelection;
        private System.Windows.Forms.CheckBox chkRealData;
        private System.Windows.Forms.LinkLabel linkLblAlgorithms;
        private System.Windows.Forms.TabPage tpWaitCollect;
        private System.Windows.Forms.TabPage tpHistoryCollect;
        private System.Windows.Forms.ComboBox cmbSelectionWaitCollect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbWaitCollect;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbHistoryCollect;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tpMemo;
        private System.Windows.Forms.Button btnSaveMemo;
        private System.Windows.Forms.TextBox txtMemo;
        private System.Windows.Forms.Button btnSelectionExport;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.SaveFileDialog saveCSVDialog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSelectionDate;
        private System.Windows.Forms.DataGridViewLinkColumn colSelectionStockId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSelectionStockName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSelectionMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSelectionWarrant;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSelectionMemo;
        private System.Windows.Forms.Label lblAlgorithms;
        private System.Windows.Forms.ToolTip toolTips;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartKBar;
    }
}

