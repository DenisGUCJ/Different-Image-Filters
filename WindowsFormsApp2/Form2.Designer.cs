namespace WindowsFormsApp2
{
    partial class Form2
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SaveFilter = new System.Windows.Forms.Button();
            this.DivisorField = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.AutoDivisor = new System.Windows.Forms.Button();
            this.Refresh = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.OffsetField = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.AnchorXFiled = new System.Windows.Forms.TextBox();
            this.AnchorYField = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.listBox = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.BiasField = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.NameField = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 380F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(380, 40);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(398, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(88, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "1";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(492, 32);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(88, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "1";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBox2.Validating += new System.ComponentModel.CancelEventHandler(this.textBox2_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(398, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Rows";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(489, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Columns";
            // 
            // SaveFilter
            // 
            this.SaveFilter.Location = new System.Drawing.Point(492, 376);
            this.SaveFilter.Name = "SaveFilter";
            this.SaveFilter.Size = new System.Drawing.Size(88, 33);
            this.SaveFilter.TabIndex = 6;
            this.SaveFilter.Text = "Save Filter";
            this.SaveFilter.UseVisualStyleBackColor = true;
            this.SaveFilter.Click += new System.EventHandler(this.SaveFilter_Click);
            // 
            // DivisorField
            // 
            this.DivisorField.Location = new System.Drawing.Point(398, 79);
            this.DivisorField.Name = "DivisorField";
            this.DivisorField.Size = new System.Drawing.Size(88, 20);
            this.DivisorField.TabIndex = 7;
            this.DivisorField.Text = "1";
            this.DivisorField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DivisorField.TextChanged += new System.EventHandler(this.DivisorField_TextChanged);
            this.DivisorField.Validating += new System.ComponentModel.CancelEventHandler(this.DivisorField_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(398, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Divisor";
            // 
            // AutoDivisor
            // 
            this.AutoDivisor.Location = new System.Drawing.Point(492, 72);
            this.AutoDivisor.Name = "AutoDivisor";
            this.AutoDivisor.Size = new System.Drawing.Size(88, 32);
            this.AutoDivisor.TabIndex = 9;
            this.AutoDivisor.Text = "Auto";
            this.AutoDivisor.UseVisualStyleBackColor = true;
            this.AutoDivisor.Click += new System.EventHandler(this.AutoDivisor_Click);
            // 
            // Refresh
            // 
            this.Refresh.Location = new System.Drawing.Point(398, 377);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(88, 32);
            this.Refresh.TabIndex = 10;
            this.Refresh.Text = "Refresh";
            this.Refresh.UseVisualStyleBackColor = true;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(398, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Offset";
            // 
            // OffsetField
            // 
            this.OffsetField.Location = new System.Drawing.Point(398, 130);
            this.OffsetField.Name = "OffsetField";
            this.OffsetField.Size = new System.Drawing.Size(88, 20);
            this.OffsetField.TabIndex = 11;
            this.OffsetField.Text = "1";
            this.OffsetField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.OffsetField.TextChanged += new System.EventHandler(this.OffsetField_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(398, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Anchor point";
            // 
            // AnchorXFiled
            // 
            this.AnchorXFiled.Location = new System.Drawing.Point(398, 197);
            this.AnchorXFiled.Name = "AnchorXFiled";
            this.AnchorXFiled.Size = new System.Drawing.Size(88, 20);
            this.AnchorXFiled.TabIndex = 13;
            this.AnchorXFiled.Text = "0";
            this.AnchorXFiled.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AnchorXFiled.TextChanged += new System.EventHandler(this.AnchorXFiled_TextChanged);
            this.AnchorXFiled.Validating += new System.ComponentModel.CancelEventHandler(this.AnchorXFiled_Validating);
            // 
            // AnchorYField
            // 
            this.AnchorYField.Location = new System.Drawing.Point(492, 197);
            this.AnchorYField.Name = "AnchorYField";
            this.AnchorYField.Size = new System.Drawing.Size(88, 20);
            this.AnchorYField.TabIndex = 15;
            this.AnchorYField.Text = "0";
            this.AnchorYField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AnchorYField.TextChanged += new System.EventHandler(this.AnchorYField_TextChanged);
            this.AnchorYField.Validating += new System.ComponentModel.CancelEventHandler(this.AnchorYField_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(398, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "x";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(492, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "y";
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(398, 232);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(182, 82);
            this.listBox.TabIndex = 18;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(495, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Bias";
            // 
            // BiasField
            // 
            this.BiasField.Location = new System.Drawing.Point(492, 130);
            this.BiasField.Name = "BiasField";
            this.BiasField.Size = new System.Drawing.Size(88, 20);
            this.BiasField.TabIndex = 19;
            this.BiasField.Text = "0";
            this.BiasField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BiasField.TextChanged += new System.EventHandler(this.BiasField_TextChanged);
            this.BiasField.Validating += new System.ComponentModel.CancelEventHandler(this.BiasField_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 373);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Name";
            // 
            // NameField
            // 
            this.NameField.Location = new System.Drawing.Point(12, 389);
            this.NameField.Name = "NameField";
            this.NameField.Size = new System.Drawing.Size(367, 20);
            this.NameField.TabIndex = 21;
            this.NameField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NameField.TextChanged += new System.EventHandler(this.NameField_TextChanged);
            this.NameField.Validating += new System.ComponentModel.CancelEventHandler(this.NameField_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 421);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.NameField);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.BiasField);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.AnchorYField);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AnchorXFiled);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.OffsetField);
            this.Controls.Add(this.Refresh);
            this.Controls.Add(this.AutoDivisor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DivisorField);
            this.Controls.Add(this.SaveFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximumSize = new System.Drawing.Size(610, 460);
            this.MinimumSize = new System.Drawing.Size(610, 460);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SaveFilter;
        private System.Windows.Forms.TextBox DivisorField;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button AutoDivisor;
        private System.Windows.Forms.Button Refresh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox OffsetField;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox AnchorXFiled;
        private System.Windows.Forms.TextBox AnchorYField;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox BiasField;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox NameField;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}