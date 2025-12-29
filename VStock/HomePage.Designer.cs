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
            HistoryView.Location = new Point(37, 81);
            HistoryView.Margin = new Padding(5, 5, 5, 5);
            HistoryView.Name = "HistoryView";
            HistoryView.Size = new Size(709, 658);
            HistoryView.TabIndex = 0;
            HistoryView.UseCompatibleStateImageBehavior = false;
            HistoryView.View = View.Details;
            // 
            // TimeStamp
            // 
            TimeStamp.Text = "時間";
            TimeStamp.Width = 350;
            // 
            // StockId
            // 
            StockId.Text = "股票代碼";
            StockId.Width = 150;
            // 
            // SearchType
            // 
            SearchType.Text = "查詢分析分法";
            SearchType.Width = 160;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(37, 36);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(146, 41);
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
            SearchArea.Location = new Point(790, 81);
            SearchArea.Margin = new Padding(5, 5, 5, 5);
            SearchArea.Name = "SearchArea";
            SearchArea.Padding = new Padding(5, 5, 5, 5);
            SearchArea.Size = new Size(558, 357);
            SearchArea.TabIndex = 2;
            SearchArea.TabStop = false;
            SearchArea.Text = "查詢股票";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(84, 294);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(37, 30);
            label4.TabIndex = 7;
            label4.Text = "到";
            // 
            // DateTo
            // 
            DateTo.Enabled = false;
            DateTo.Location = new Point(126, 284);
            DateTo.Margin = new Padding(5, 5, 5, 5);
            DateTo.Name = "DateTo";
            DateTo.Size = new Size(387, 38);
            DateTo.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(84, 242);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(37, 30);
            label3.TabIndex = 5;
            label3.Text = "從";
            // 
            // DateFrom
            // 
            DateFrom.Enabled = false;
            DateFrom.Location = new Point(126, 232);
            DateFrom.Margin = new Padding(5, 5, 5, 5);
            DateFrom.Name = "DateFrom";
            DateFrom.Size = new Size(387, 38);
            DateFrom.TabIndex = 4;
            // 
            // SHistory
            // 
            SHistory.AutoSize = true;
            SHistory.Location = new Point(25, 186);
            SHistory.Margin = new Padding(5, 5, 5, 5);
            SHistory.Name = "SHistory";
            SHistory.Size = new Size(140, 34);
            SHistory.TabIndex = 3;
            SHistory.Text = "歷史資料";
            SHistory.UseVisualStyleBackColor = true;
            SHistory.CheckedChanged += SHistory_CheckedChanged;
            // 
            // SRealTime
            // 
            SRealTime.AutoSize = true;
            SRealTime.Checked = true;
            SRealTime.Location = new Point(25, 141);
            SRealTime.Margin = new Padding(5, 5, 5, 5);
            SRealTime.Name = "SRealTime";
            SRealTime.Size = new Size(140, 34);
            SRealTime.TabIndex = 2;
            SRealTime.TabStop = true;
            SRealTime.Text = "即時資料";
            SRealTime.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 71);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(115, 30);
            label2.TabIndex = 1;
            label2.Text = "股票代碼:";
            // 
            // StockIdInput
            // 
            StockIdInput.BorderStyle = BorderStyle.FixedSingle;
            StockIdInput.Location = new Point(126, 68);
            StockIdInput.Margin = new Padding(5, 5, 5, 5);
            StockIdInput.Name = "StockIdInput";
            StockIdInput.Size = new Size(416, 38);
            StockIdInput.TabIndex = 0;
            // 
            // SearchList
            // 
            SearchList.Location = new Point(790, 447);
            SearchList.Margin = new Padding(5, 5, 5, 5);
            SearchList.Name = "SearchList";
            SearchList.Size = new Size(556, 92);
            SearchList.TabIndex = 3;
            SearchList.UseCompatibleStateImageBehavior = false;
            SearchList.View = View.SmallIcon;
            // 
            // SListAdd
            // 
            SListAdd.Location = new Point(800, 567);
            SListAdd.Margin = new Padding(5, 5, 5, 5);
            SListAdd.Name = "SListAdd";
            SListAdd.Size = new Size(252, 73);
            SListAdd.TabIndex = 4;
            SListAdd.Text = "加入查詢列表";
            SListAdd.UseVisualStyleBackColor = true;
            SListAdd.Click += SListAdd_Click;
            // 
            // SListDel
            // 
            SListDel.Location = new Point(1087, 567);
            SListDel.Margin = new Padding(5, 5, 5, 5);
            SListDel.Name = "SListDel";
            SListDel.Size = new Size(246, 73);
            SListDel.TabIndex = 5;
            SListDel.Text = "從列表刪除";
            SListDel.UseVisualStyleBackColor = true;
            SListDel.Click += SListDel_Click;
            // 
            // SearchVStock
            // 
            SearchVStock.Location = new Point(1087, 666);
            SearchVStock.Margin = new Padding(5, 5, 5, 5);
            SearchVStock.Name = "SearchVStock";
            SearchVStock.Size = new Size(246, 74);
            SearchVStock.TabIndex = 7;
            SearchVStock.Text = "VStock 查詢分析";
            SearchVStock.UseVisualStyleBackColor = true;
            SearchVStock.Click += SearchVStock_Click;
            // 
            // SearchTrad
            // 
            SearchTrad.Location = new Point(800, 666);
            SearchTrad.Margin = new Padding(5, 5, 5, 5);
            SearchTrad.Name = "SearchTrad";
            SearchTrad.Size = new Size(252, 74);
            SearchTrad.TabIndex = 6;
            SearchTrad.Text = "傳統查詢分析";
            SearchTrad.UseVisualStyleBackColor = true;
            SearchTrad.Click += SearchTrad_Click;
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(14F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1397, 780);
            Controls.Add(SearchVStock);
            Controls.Add(SearchTrad);
            Controls.Add(SListDel);
            Controls.Add(SListAdd);
            Controls.Add(SearchList);
            Controls.Add(SearchArea);
            Controls.Add(label1);
            Controls.Add(HistoryView);
            Margin = new Padding(5, 5, 5, 5);
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
