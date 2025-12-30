namespace VStock
{
    partial class VStockSPage
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
            Title = new Label();
            Info = new Label();
            canvas = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)canvas).BeginInit();
            SuspendLayout();
            // 
            // Title
            // 
            Title.AutoSize = true;
            Title.Location = new Point(57, 40);
            Title.Name = "Title";
            Title.Size = new Size(81, 30);
            Title.TabIndex = 1;
            Title.Text = "label1";
            // 
            // Info
            // 
            Info.AutoSize = true;
            Info.Location = new Point(57, 102);
            Info.Name = "Info";
            Info.Size = new Size(81, 30);
            Info.TabIndex = 2;
            Info.Text = "label1";
            // 
            // canvas
            // 
            canvas.BorderStyle = BorderStyle.FixedSingle;
            canvas.Location = new Point(957, 50);
            canvas.Name = "canvas";
            canvas.Size = new Size(1000, 1000);
            canvas.TabIndex = 3;
            canvas.TabStop = false;
            canvas.Paint += canvas_Paint;
            // 
            // VStockSPage
            // 
            AutoScaleDimensions = new SizeF(14F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2020, 1104);
            Controls.Add(canvas);
            Controls.Add(Info);
            Controls.Add(Title);
            Name = "VStockSPage";
            Text = "VStockSPage";
            ((System.ComponentModel.ISupportInitialize)canvas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label Title;
        private Label Info;
        private PictureBox canvas;
    }
}