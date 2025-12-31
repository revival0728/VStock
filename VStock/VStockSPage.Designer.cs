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
            Mode = new GroupBox();
            NoiseMode = new RadioButton();
            StairMode = new RadioButton();
            SaveImg = new Button();
            ((System.ComponentModel.ISupportInitialize)canvas).BeginInit();
            Mode.SuspendLayout();
            SuspendLayout();
            // 
            // Title
            // 
            Title.AutoSize = true;
            Title.Location = new Point(28, 20);
            Title.Margin = new Padding(2, 0, 2, 0);
            Title.Name = "Title";
            Title.Size = new Size(42, 15);
            Title.TabIndex = 1;
            Title.Text = "label1";
            // 
            // Info
            // 
            Info.AutoSize = true;
            Info.Location = new Point(28, 51);
            Info.Margin = new Padding(2, 0, 2, 0);
            Info.Name = "Info";
            Info.Size = new Size(42, 15);
            Info.TabIndex = 2;
            Info.Text = "label1";
            // 
            // canvas
            // 
            canvas.BorderStyle = BorderStyle.FixedSingle;
            canvas.Location = new Point(478, 25);
            canvas.Margin = new Padding(2, 2, 2, 2);
            canvas.Name = "canvas";
            canvas.Size = new Size(501, 501);
            canvas.TabIndex = 3;
            canvas.TabStop = false;
            canvas.Paint += canvas_Paint;
            // 
            // Mode
            // 
            Mode.Controls.Add(NoiseMode);
            Mode.Controls.Add(StairMode);
            Mode.Location = new Point(28, 112);
            Mode.Margin = new Padding(2, 2, 2, 2);
            Mode.Name = "Mode";
            Mode.Padding = new Padding(2, 2, 2, 2);
            Mode.Size = new Size(200, 100);
            Mode.TabIndex = 4;
            Mode.TabStop = false;
            Mode.Text = "生成";
            // 
            // NoiseMode
            // 
            NoiseMode.AutoSize = true;
            NoiseMode.Location = new Point(14, 48);
            NoiseMode.Margin = new Padding(2, 2, 2, 2);
            NoiseMode.Name = "NoiseMode";
            NoiseMode.Size = new Size(49, 19);
            NoiseMode.TabIndex = 1;
            NoiseMode.Text = "噪聲";
            NoiseMode.UseVisualStyleBackColor = true;
            // 
            // StairMode
            // 
            StairMode.AutoSize = true;
            StairMode.Checked = true;
            StairMode.Location = new Point(14, 23);
            StairMode.Margin = new Padding(2, 2, 2, 2);
            StairMode.Name = "StairMode";
            StairMode.Size = new Size(49, 19);
            StairMode.TabIndex = 0;
            StairMode.TabStop = true;
            StairMode.Text = "色階";
            StairMode.UseVisualStyleBackColor = true;
            // 
            // SaveImg
            // 
            SaveImg.Location = new Point(28, 247);
            SaveImg.Margin = new Padding(2, 2, 2, 2);
            SaveImg.Name = "SaveImg";
            SaveImg.Size = new Size(200, 58);
            SaveImg.TabIndex = 5;
            SaveImg.Text = "儲存圖片";
            SaveImg.UseVisualStyleBackColor = true;
            SaveImg.Click += SaveImg_Click;
            // 
            // VStockSPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(993, 541);
            Controls.Add(SaveImg);
            Controls.Add(Mode);
            Controls.Add(canvas);
            Controls.Add(Info);
            Controls.Add(Title);
            Margin = new Padding(2, 2, 2, 2);
            Name = "VStockSPage";
            Text = "VStockSPage";
            FormClosing += VStockSPage_FormClosing;
            ((System.ComponentModel.ISupportInitialize)canvas).EndInit();
            Mode.ResumeLayout(false);
            Mode.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label Title;
        private Label Info;
        private PictureBox canvas;
        private GroupBox Mode;
        private RadioButton NoiseMode;
        private RadioButton StairMode;
        private Button SaveImg;
    }
}