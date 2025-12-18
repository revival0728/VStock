namespace VStock
{
    partial class HomePage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            HistoryView = new ListView();
            TimeStamp = new ColumnHeader();
            StockId = new ColumnHeader();
            SearchType = new ColumnHeader();
            label1 = new Label();
            SearchArea = new GroupBox();
            label4 = new Label();
            DateTo = new DateTimePicker();
            label3 = new Label();
            DateFrom = new DateTimePicker();
            SHistory = new RadioButton();
            SRealTime = new RadioButton();
            label2 = new Label();
            StockIdInput = new TextBox();
            SearchList = new ListView();
            SListAdd = new Button();
            SListDel = new Button();
            SearchVStock = new Button();
            SearchTrad = new Button();
            SearchArea.SuspendLayout();
            SuspendLayout();
            // 
            // HistoryView
            // 
            HistoryView.Columns.AddRange(new ColumnHeader[] { TimeStamp, StockId, SearchType });
            HistoryView.Location = new Point(24, 51);
            HistoryView.Name = "HistoryView";
            HistoryView.Size = new Size(457, 418);
            HistoryView.TabIndex = 0;
            HistoryView.UseCompatibleStateImageBehavior = false;
            HistoryView.View = View.Details;
            // 
            // TimeStamp
            // 
            TimeStamp.Text = "時間";
            TimeStamp.Width = 200;
            // 
            // StockId
            // 
            StockId.Text = "股票代碼";
            StockId.Width = 120;
            // 
            // SearchType
            // 
            SearchType.Text = "查詢分析分法";
            SearchType.Width = 120;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(24, 23);
            label1.Name = "label1";
            label1.Size = new Size(92, 25);
            label1.TabIndex = 1;
            label1.Text = "查詢歷史";
            // 
            // SearchArea
            // 
            SearchArea.Controls.Add(label4);
            SearchArea.Controls.Add(DateTo);
            SearchArea.Controls.Add(label3);
            SearchArea.Controls.Add(DateFrom);
            SearchArea.Controls.Add(SHistory);
            SearchArea.Controls.Add(SRealTime);
            SearchArea.Controls.Add(label2);
            SearchArea.Controls.Add(StockIdInput);
            SearchArea.Location = new Point(508, 51);
            SearchArea.Name = "SearchArea";
            SearchArea.Size = new Size(359, 226);
            SearchArea.TabIndex = 2;
            SearchArea.TabStop = false;
            SearchArea.Text = "查詢股票";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(54, 186);
            label4.Name = "label4";
            label4.Size = new Size(24, 19);
            label4.TabIndex = 7;
            label4.Text = "到";
            // 
            // DateTo
            // 
            DateTo.Enabled = false;
            DateTo.Location = new Point(81, 180);
            DateTo.Name = "DateTo";
            DateTo.Size = new Size(250, 27);
            DateTo.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(54, 153);
            label3.Name = "label3";
            label3.Size = new Size(24, 19);
            label3.TabIndex = 5;
            label3.Text = "從";
            // 
            // DateFrom
            // 
            DateFrom.Enabled = false;
            DateFrom.Location = new Point(81, 147);
            DateFrom.Name = "DateFrom";
            DateFrom.Size = new Size(250, 27);
            DateFrom.TabIndex = 4;
            // 
            // SHistory
            // 
            SHistory.AutoSize = true;
            SHistory.Location = new Point(16, 118);
            SHistory.Name = "SHistory";
            SHistory.Size = new Size(90, 23);
            SHistory.TabIndex = 3;
            SHistory.Text = "歷史資料";
            SHistory.UseVisualStyleBackColor = true;
            SHistory.CheckedChanged += SHistory_CheckedChanged;
            // 
            // SRealTime
            // 
            SRealTime.AutoSize = true;
            SRealTime.Checked = true;
            SRealTime.Location = new Point(16, 89);
            SRealTime.Name = "SRealTime";
            SRealTime.Size = new Size(90, 23);
            SRealTime.TabIndex = 2;
            SRealTime.TabStop = true;
            SRealTime.Text = "即時資料";
            SRealTime.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 45);
            label2.Name = "label2";
            label2.Size = new Size(72, 19);
            label2.TabIndex = 1;
            label2.Text = "股票代碼:";
            // 
            // StockIdInput
            // 
            StockIdInput.BorderStyle = BorderStyle.FixedSingle;
            StockIdInput.Location = new Point(81, 43);
            StockIdInput.Name = "StockIdInput";
            StockIdInput.Size = new Size(268, 27);
            StockIdInput.TabIndex = 0;
            // 
            // SearchList
            // 
            SearchList.Location = new Point(508, 283);
            SearchList.Name = "SearchList";
            SearchList.Size = new Size(359, 60);
            SearchList.TabIndex = 3;
            SearchList.UseCompatibleStateImageBehavior = false;
            SearchList.View = View.SmallIcon;
            // 
            // SListAdd
            // 
            SListAdd.Location = new Point(514, 359);
            SListAdd.Name = "SListAdd";
            SListAdd.Size = new Size(162, 46);
            SListAdd.TabIndex = 4;
            SListAdd.Text = "加入查詢列表";
            SListAdd.UseVisualStyleBackColor = true;
            SListAdd.Click += SListAdd_Click;
            // 
            // SListDel
            // 
            SListDel.Location = new Point(699, 359);
            SListDel.Name = "SListDel";
            SListDel.Size = new Size(158, 46);
            SListDel.TabIndex = 5;
            SListDel.Text = "從列表刪除";
            SListDel.UseVisualStyleBackColor = true;
            SListDel.Click += SListDel_Click;
            // 
            // SearchVStock
            // 
            SearchVStock.Location = new Point(699, 422);
            SearchVStock.Name = "SearchVStock";
            SearchVStock.Size = new Size(158, 47);
            SearchVStock.TabIndex = 7;
            SearchVStock.Text = "VStock 查詢分析";
            SearchVStock.UseVisualStyleBackColor = true;
            SearchVStock.Click += SearchVStock_Click;
            // 
            // SearchTrad
            // 
            SearchTrad.Location = new Point(514, 422);
            SearchTrad.Name = "SearchTrad";
            SearchTrad.Size = new Size(162, 47);
            SearchTrad.TabIndex = 6;
            SearchTrad.Text = "傳統查詢分析";
            SearchTrad.UseVisualStyleBackColor = true;
            SearchTrad.Click += SearchTrad_Click;
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(898, 494);
            Controls.Add(SearchVStock);
            Controls.Add(SearchTrad);
            Controls.Add(SListDel);
            Controls.Add(SListAdd);
            Controls.Add(SearchList);
            Controls.Add(SearchArea);
            Controls.Add(label1);
            Controls.Add(HistoryView);
            Name = "HomePage";
            Text = "VStock";
            SearchArea.ResumeLayout(false);
            SearchArea.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView HistoryView;
        private Label label1;
        private GroupBox SearchArea;
        private Label label2;
        private TextBox StockIdInput;
        private RadioButton SHistory;
        private RadioButton SRealTime;
        private Label label4;
        private DateTimePicker DateTo;
        private Label label3;
        private DateTimePicker DateFrom;
        private ListView SearchList;
        private Button SListAdd;
        private Button SListDel;
        private Button SearchVStock;
        private Button SearchTrad;
        private ColumnHeader TimeStamp;
        private ColumnHeader StockId;
        private ColumnHeader SearchType;
    }
}
