namespace WindowsFormsApp2
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Save = new System.Windows.Forms.Button();
            this.Inversion = new System.Windows.Forms.Button();
            this.BrightnessUP = new System.Windows.Forms.Button();
            this.BrighnessDown = new System.Windows.Forms.Button();
            this.Contrast = new System.Windows.Forms.Button();
            this.Default = new System.Windows.Forms.Button();
            this.Gamma = new System.Windows.Forms.Button();
            this.Blur = new System.Windows.Forms.Button();
            this.Embos = new System.Windows.Forms.Button();
            this.EdgeDetection = new System.Windows.Forms.Button();
            this.SharpenFilter = new System.Windows.Forms.Button();
            this.GaussianBlur = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.CustomFilter = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.OrderedDithering = new System.Windows.Forms.Button();
            this.GreyScale = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.PopularityAlgorythm = new System.Windows.Forms.Button();
            this.KValue = new System.Windows.Forms.TextBox();
            this.Lab1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(933, 416);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(954, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 31);
            this.button1.TabIndex = 1;
            this.button1.Text = "Upload image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(933, 412);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseClick);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(1066, 15);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(106, 31);
            this.Save.TabIndex = 3;
            this.Save.Text = "Save result";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Inversion
            // 
            this.Inversion.Location = new System.Drawing.Point(1066, 102);
            this.Inversion.Name = "Inversion";
            this.Inversion.Size = new System.Drawing.Size(106, 31);
            this.Inversion.TabIndex = 4;
            this.Inversion.Text = "Invertion";
            this.Inversion.UseVisualStyleBackColor = true;
            this.Inversion.Click += new System.EventHandler(this.Inversion_Click);
            // 
            // BrightnessUP
            // 
            this.BrightnessUP.Location = new System.Drawing.Point(1066, 139);
            this.BrightnessUP.Name = "BrightnessUP";
            this.BrightnessUP.Size = new System.Drawing.Size(106, 31);
            this.BrightnessUP.TabIndex = 5;
            this.BrightnessUP.Text = "Brightness (Lighter)";
            this.BrightnessUP.UseVisualStyleBackColor = true;
            this.BrightnessUP.Click += new System.EventHandler(this.BrightnessUP_Click);
            // 
            // BrighnessDown
            // 
            this.BrighnessDown.Location = new System.Drawing.Point(1066, 176);
            this.BrighnessDown.Name = "BrighnessDown";
            this.BrighnessDown.Size = new System.Drawing.Size(106, 31);
            this.BrighnessDown.TabIndex = 6;
            this.BrighnessDown.Text = "Brightness (Darker)";
            this.BrighnessDown.UseVisualStyleBackColor = true;
            this.BrighnessDown.Click += new System.EventHandler(this.BrighnessDown_Click);
            // 
            // Contrast
            // 
            this.Contrast.Location = new System.Drawing.Point(1066, 213);
            this.Contrast.Name = "Contrast";
            this.Contrast.Size = new System.Drawing.Size(106, 31);
            this.Contrast.TabIndex = 7;
            this.Contrast.Text = "Contrast enhancement";
            this.Contrast.UseVisualStyleBackColor = true;
            this.Contrast.Click += new System.EventHandler(this.Contrast_Click);
            // 
            // Default
            // 
            this.Default.Location = new System.Drawing.Point(1066, 303);
            this.Default.Name = "Default";
            this.Default.Size = new System.Drawing.Size(106, 31);
            this.Default.TabIndex = 8;
            this.Default.Text = "Default";
            this.Default.UseVisualStyleBackColor = true;
            this.Default.Click += new System.EventHandler(this.Default_Click);
            // 
            // Gamma
            // 
            this.Gamma.Location = new System.Drawing.Point(1066, 250);
            this.Gamma.Name = "Gamma";
            this.Gamma.Size = new System.Drawing.Size(106, 31);
            this.Gamma.TabIndex = 13;
            this.Gamma.Text = "Gamma correction";
            this.Gamma.UseVisualStyleBackColor = true;
            this.Gamma.Click += new System.EventHandler(this.Gamma_Click);
            // 
            // Blur
            // 
            this.Blur.Location = new System.Drawing.Point(954, 102);
            this.Blur.Name = "Blur";
            this.Blur.Size = new System.Drawing.Size(106, 31);
            this.Blur.TabIndex = 14;
            this.Blur.Text = "Blur";
            this.Blur.UseVisualStyleBackColor = true;
            this.Blur.Click += new System.EventHandler(this.Blur_Click);
            // 
            // Embos
            // 
            this.Embos.Location = new System.Drawing.Point(954, 176);
            this.Embos.Name = "Embos";
            this.Embos.Size = new System.Drawing.Size(106, 31);
            this.Embos.TabIndex = 15;
            this.Embos.Text = "Embos";
            this.Embos.UseVisualStyleBackColor = true;
            this.Embos.Click += new System.EventHandler(this.Embos_Click);
            // 
            // EdgeDetection
            // 
            this.EdgeDetection.Location = new System.Drawing.Point(954, 213);
            this.EdgeDetection.Name = "EdgeDetection";
            this.EdgeDetection.Size = new System.Drawing.Size(106, 31);
            this.EdgeDetection.TabIndex = 16;
            this.EdgeDetection.Text = "Edge detection";
            this.EdgeDetection.UseVisualStyleBackColor = true;
            this.EdgeDetection.Click += new System.EventHandler(this.EdgeDetection_Click);
            // 
            // SharpenFilter
            // 
            this.SharpenFilter.Location = new System.Drawing.Point(954, 250);
            this.SharpenFilter.Name = "SharpenFilter";
            this.SharpenFilter.Size = new System.Drawing.Size(106, 31);
            this.SharpenFilter.TabIndex = 17;
            this.SharpenFilter.Text = "Sharpen";
            this.SharpenFilter.UseVisualStyleBackColor = true;
            this.SharpenFilter.Click += new System.EventHandler(this.SharpenFilter_Click);
            // 
            // GaussianBlur
            // 
            this.GaussianBlur.Location = new System.Drawing.Point(954, 139);
            this.GaussianBlur.Name = "GaussianBlur";
            this.GaussianBlur.Size = new System.Drawing.Size(106, 31);
            this.GaussianBlur.TabIndex = 18;
            this.GaussianBlur.Text = "Gaussian blur";
            this.GaussianBlur.UseVisualStyleBackColor = true;
            this.GaussianBlur.Click += new System.EventHandler(this.GaussianBlur_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pictureBox1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(936, 416);
            this.flowLayoutPanel1.TabIndex = 19;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.pictureBox2);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(12, 434);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(936, 415);
            this.flowLayoutPanel2.TabIndex = 20;
            // 
            // CustomFilter
            // 
            this.CustomFilter.Location = new System.Drawing.Point(954, 488);
            this.CustomFilter.Name = "CustomFilter";
            this.CustomFilter.Size = new System.Drawing.Size(106, 31);
            this.CustomFilter.TabIndex = 24;
            this.CustomFilter.Text = "Make custom filter";
            this.CustomFilter.UseVisualStyleBackColor = true;
            this.CustomFilter.Click += new System.EventHandler(this.CustomFilter_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(954, 376);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(218, 95);
            this.listBox1.TabIndex = 25;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // ApplyButton
            // 
            this.ApplyButton.Enabled = false;
            this.ApplyButton.Location = new System.Drawing.Point(1066, 488);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(106, 31);
            this.ApplyButton.TabIndex = 26;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // OrderedDithering
            // 
            this.OrderedDithering.Location = new System.Drawing.Point(954, 620);
            this.OrderedDithering.Name = "OrderedDithering";
            this.OrderedDithering.Size = new System.Drawing.Size(138, 31);
            this.OrderedDithering.TabIndex = 27;
            this.OrderedDithering.Text = "Ordered dithering";
            this.OrderedDithering.UseVisualStyleBackColor = true;
            this.OrderedDithering.Click += new System.EventHandler(this.OrderedDithering_Click);
            // 
            // GreyScale
            // 
            this.GreyScale.Location = new System.Drawing.Point(954, 583);
            this.GreyScale.Name = "GreyScale";
            this.GreyScale.Size = new System.Drawing.Size(138, 31);
            this.GreyScale.TabIndex = 28;
            this.GreyScale.Text = "Grey";
            this.GreyScale.UseVisualStyleBackColor = true;
            this.GreyScale.Click += new System.EventHandler(this.GreyScale_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1098, 620);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 31);
            this.button2.TabIndex = 29;
            this.button2.Text = "Options";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // PopularityAlgorythm
            // 
            this.PopularityAlgorythm.Location = new System.Drawing.Point(954, 657);
            this.PopularityAlgorythm.Name = "PopularityAlgorythm";
            this.PopularityAlgorythm.Size = new System.Drawing.Size(138, 31);
            this.PopularityAlgorythm.TabIndex = 30;
            this.PopularityAlgorythm.Text = "Popularity algo";
            this.PopularityAlgorythm.UseVisualStyleBackColor = true;
            this.PopularityAlgorythm.Click += new System.EventHandler(this.PopularityAlgorythm_Click);
            // 
            // KValue
            // 
            this.KValue.Location = new System.Drawing.Point(1098, 663);
            this.KValue.Name = "KValue";
            this.KValue.Size = new System.Drawing.Size(74, 20);
            this.KValue.TabIndex = 31;
            this.KValue.Text = "8";
            this.KValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.KValue.TextChanged += new System.EventHandler(this.KValue_TextChanged);
            // 
            // Lab1
            // 
            this.Lab1.AutoSize = true;
            this.Lab1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Lab1.Location = new System.Drawing.Point(951, 71);
            this.Lab1.Name = "Lab1";
            this.Lab1.Size = new System.Drawing.Size(53, 20);
            this.Lab1.TabIndex = 32;
            this.Lab1.Text = "LAB 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(954, 552);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 33;
            this.label2.Text = "LAB 2";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(954, 738);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(138, 31);
            this.button3.TabIndex = 34;
            this.button3.Text = "Lab2 Task";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(954, 775);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(138, 27);
            this.button4.TabIndex = 35;
            this.button4.Text = "Lab2ApplyY\'CrCb";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(955, 808);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(138, 27);
            this.button5.TabIndex = 36;
            this.button5.Text = "Lab2ConvertBack";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1184, 861);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Lab1);
            this.Controls.Add(this.KValue);
            this.Controls.Add(this.PopularityAlgorythm);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.GreyScale);
            this.Controls.Add(this.OrderedDithering);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.CustomFilter);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.GaussianBlur);
            this.Controls.Add(this.SharpenFilter);
            this.Controls.Add(this.EdgeDetection);
            this.Controls.Add(this.Embos);
            this.Controls.Add(this.Blur);
            this.Controls.Add(this.Gamma);
            this.Controls.Add(this.Default);
            this.Controls.Add(this.Contrast);
            this.Controls.Add(this.BrighnessDown);
            this.Controls.Add(this.BrightnessUP);
            this.Controls.Add(this.Inversion);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.button1);
            this.MaximumSize = new System.Drawing.Size(1200, 900);
            this.MinimumSize = new System.Drawing.Size(1200, 900);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CG project";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Inversion;
        private System.Windows.Forms.Button BrightnessUP;
        private System.Windows.Forms.Button BrighnessDown;
        private System.Windows.Forms.Button Contrast;
        private System.Windows.Forms.Button Default;
        private System.Windows.Forms.Button Gamma;
        private System.Windows.Forms.Button Blur;
        private System.Windows.Forms.Button Embos;
        private System.Windows.Forms.Button EdgeDetection;
        private System.Windows.Forms.Button SharpenFilter;
        private System.Windows.Forms.Button GaussianBlur;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button CustomFilter;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Button OrderedDithering;
        private System.Windows.Forms.Button GreyScale;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button PopularityAlgorythm;
        private System.Windows.Forms.TextBox KValue;
        private System.Windows.Forms.Label Lab1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

