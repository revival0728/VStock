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
            // Mode
            // 
            Mode.Controls.Add(NoiseMode);
            Mode.Controls.Add(StairMode);
            Mode.Location = new Point(57, 224);
            Mode.Name = "Mode";
            Mode.Size = new Size(400, 200);
            Mode.TabIndex = 4;
            Mode.TabStop = false;
            Mode.Text = "生成";
            // 
            // NoiseMode
            // 
            NoiseMode.AutoSize = true;
            NoiseMode.Location = new Point(28, 95);
            NoiseMode.Name = "NoiseMode";
            NoiseMode.Size = new Size(92, 34);
            NoiseMode.TabIndex = 1;
            NoiseMode.Text = "噪聲";
            NoiseMode.UseVisualStyleBackColor = true;
            // 
            // StairMode
            // 
            StairMode.AutoSize = true;
            StairMode.Checked = true;
            StairMode.Location = new Point(28, 46);
            StairMode.Name = "StairMode";
            StairMode.Size = new Size(92, 34);
            StairMode.TabIndex = 0;
            StairMode.TabStop = true;
            StairMode.Text = "色階";
            StairMode.UseVisualStyleBackColor = true;
            // 
            // SaveImg
            // 
            SaveImg.Location = new Point(57, 494);
            SaveImg.Name = "SaveImg";
            SaveImg.Size = new Size(400, 116);
            SaveImg.TabIndex = 5;
            SaveImg.Text = "儲存圖片";
            SaveImg.UseVisualStyleBackColor = true;
            SaveImg.Click += SaveImg_Click;
            // 
            // VStockSPage
            // 
            AutoScaleDimensions = new SizeF(14F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2020, 1104);
            Controls.Add(SaveImg);
            Controls.Add(Mode);
            Controls.Add(canvas);
            Controls.Add(Info);
            Controls.Add(Title);
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