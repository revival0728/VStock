namespace VStock
{
    partial class TradSPage
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
            stockPlot = new ScottPlot.WinForms.FormsPlot();
            Title = new Label();
            Info = new Label();
            plotFn = new CheckedListBox();
            SuspendLayout();
            // 
            // stockPlot
            // 
            stockPlot.DisplayScale = 2F;
            stockPlot.Location = new Point(11, 83);
            stockPlot.Margin = new Padding(2, 2, 2, 2);
            stockPlot.Name = "stockPlot";
            stockPlot.Size = new Size(1049, 479);
            stockPlot.TabIndex = 0;
            // 
            // Title
            // 
            Title.AutoSize = true;
            Title.Location = new Point(24, 11);
            Title.Margin = new Padding(2, 0, 2, 0);
            Title.Name = "Title";
            Title.Size = new Size(42, 15);
            Title.TabIndex = 1;
            Title.Text = "label1";
            // 
            // Info
            // 
            Info.AutoSize = true;
            Info.Location = new Point(24, 41);
            Info.Margin = new Padding(2, 0, 2, 0);
            Info.Name = "Info";
            Info.Size = new Size(42, 15);
            Info.TabIndex = 2;
            Info.Text = "label1";
            // 
            // plotFn
            // 
            plotFn.Enabled = false;
            plotFn.FormattingEnabled = true;
            plotFn.Items.AddRange(new object[] { "SMA", "BolingerB", "RSI", "MACD" });
            plotFn.Location = new Point(827, 11);
            plotFn.Margin = new Padding(2, 2, 2, 2);
            plotFn.MultiColumn = true;
            plotFn.Name = "plotFn";
            plotFn.Size = new Size(233, 58);
            plotFn.TabIndex = 3;
            plotFn.ItemCheck += plotFn_ItemCheck;
            // 
            // TradSPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1083, 585);
            Controls.Add(plotFn);
            Controls.Add(Info);
            Controls.Add(Title);
            Controls.Add(stockPlot);
            Margin = new Padding(2, 2, 2, 2);
            Name = "TradSPage";
            Text = "TradSPage";
            FormClosing += TradSPage_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ScottPlot.WinForms.FormsPlot stockPlot;
        private Label Title;
        private Label Info;
        private CheckedListBox plotFn;
    }
}