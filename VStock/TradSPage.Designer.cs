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
            SuspendLayout();
            // 
            // stockPlot
            // 
            stockPlot.DisplayScale = 2F;
            stockPlot.Location = new Point(25, 94);
            stockPlot.Name = "stockPlot";
            stockPlot.Size = new Size(2111, 958);
            stockPlot.TabIndex = 0;
            // 
            // Title
            // 
            Title.AutoSize = true;
            Title.Location = new Point(49, 18);
            Title.Name = "Title";
            Title.Size = new Size(81, 30);
            Title.TabIndex = 1;
            Title.Text = "label1";
            // 
            // Info
            // 
            Info.AutoSize = true;
            Info.Location = new Point(49, 61);
            Info.Name = "Info";
            Info.Size = new Size(81, 30);
            Info.TabIndex = 2;
            Info.Text = "label1";
            // 
            // TradSPage
            // 
            AutoScaleDimensions = new SizeF(14F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2148, 1064);
            Controls.Add(Info);
            Controls.Add(Title);
            Controls.Add(stockPlot);
            Name = "TradSPage";
            Text = "TradSPage";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ScottPlot.WinForms.FormsPlot stockPlot;
        private Label Title;
        private Label Info;
    }
}