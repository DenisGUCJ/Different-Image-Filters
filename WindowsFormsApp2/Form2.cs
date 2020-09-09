using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        public double[][] Kernel { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }

        public double Divisor { get; set; }
        public double Bias { get; set; }
        public int AnchorX { get; set; }
        public int AnchorY { get; set; }
        public int Offset { get; set; }

        private List<ConvolutionFilter> container;
        public Form2()
        {
            InitializeComponent();

            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.ColumnCount = 1;
            Rows = tableLayoutPanel1.RowCount;
            Columns = tableLayoutPanel1.ColumnCount;

            for (int i = 0; i < 9; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40));
            }

            tableLayoutPanel1.Controls.Add(MakeASell(), 0, 0);

            SetName();
            SetDivisor();
            SetBias();
            SetOffset();
            SetAnchorX();
            SetAnchorY();

            GetFilters();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int value;
            int prevValue = tableLayoutPanel1.RowCount;

            if (Int32.TryParse(textBox1.Text, out value))
            {
                if (value >= 1 && value <= 9)
                {
                    if (value % 2 == 1)
                    {
                        if (value > prevValue)
                        {
                            tableLayoutPanel1.RowCount = value;
                            Rows = tableLayoutPanel1.RowCount;

                            for (int i = prevValue; i < value; i++)
                            {
                                for (int j = 0; j < Columns; j++)
                                {
                                    tableLayoutPanel1.Controls.Add(MakeASell(), j, i);
                                    tableLayoutPanel1.Show();
                                }
                            }
                        }

                        else if (value < prevValue)
                        {
                            for (int i = prevValue - 1; i >= value; i--)
                            {
                                for (int j = Columns - 1; j >= 0; j--)
                                {
                                    var controlCol = tableLayoutPanel1.GetControlFromPosition(j, i);
                                    tableLayoutPanel1.Controls.Remove(controlCol);
                                }
                                tableLayoutPanel1.RowCount--;
                                Rows = tableLayoutPanel1.RowCount;
                            }
                        }
                    }  
                }
            }

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int value;
            int prevValue = tableLayoutPanel1.ColumnCount;

            if (Int32.TryParse(textBox2.Text, out value))
            {
                if (value >= 1 && value <= 9)
                {
                    if (value % 2 == 1)
                    {
                        if (value > prevValue)
                        {
                            tableLayoutPanel1.ColumnCount = value;
                            Columns = tableLayoutPanel1.ColumnCount;

                            for (int i = prevValue; i < value; i++)
                            {
                                for (int j = 0; j < Rows; j++)
                                {
                                    tableLayoutPanel1.Controls.Add(MakeASell(), i, j);
                                }

                            }
                        }
                        else if (value < prevValue)
                        {
                            for (int i = prevValue - 1; i >= value; i--)
                            {
                                for (int j = Rows - 1; j >= 0; j--)
                                {
                                    var controlCol = tableLayoutPanel1.GetControlFromPosition(i, j);
                                    tableLayoutPanel1.Controls.Remove(controlCol);
                                }
                                tableLayoutPanel1.ColumnCount--;
                                Columns = tableLayoutPanel1.ColumnCount;
                            }
                        }
                    }
                    
                }
            }
        }

        private RichTextBox MakeASell()
        {
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Dock = DockStyle.Fill;
            richTextBox.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox.Text = "0";
            richTextBox.Validating += new CancelEventHandler(MakeACell_Validating);

            return richTextBox;
        }

        private void MakeACell_Validating(object sender, CancelEventArgs e)
        {
            RichTextBox cell = (RichTextBox)sender;
            int value;
            if (Int32.TryParse(cell.Text, out value))
            {
                e.Cancel = false;
                errorProvider1.SetError(cell, null);
            }
            else
            {
                e.Cancel = true;
                errorProvider1.SetError(cell, "Value is not numeric!");
            }
        }

        private void SetKernel()
        {
            Kernel = new double[Rows][];

            for (int i = 0; i < Rows; i++)
            {
                Kernel[i] = new double[Columns];

                for (int j = 0; j < Columns; j++)
                {
                    
                    int value;
                    var control = tableLayoutPanel1.GetControlFromPosition(j, i);
                    if (Int32.TryParse(control.Text, out value))
                    {
                        Kernel[i][j] = value;
                    }
    
                }
            }
        }

        private void SetMatrix()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    tableLayoutPanel1.GetControlFromPosition(j, i).Text = Kernel[i][j].ToString();
                }
            }
        }

        private void SetName()
        {
            Name = NameField.Text;
        }
        private void SetDivisor()
        {
            int value;
            if (Int32.TryParse(DivisorField.Text, out value))
                Divisor = value;
        }
        private void SetBias()
        {
            int value;
            if (Int32.TryParse(BiasField.Text, out value))
                Bias = value;
        }

        private void SetOffset()
        {
            int value;
            if (Int32.TryParse(OffsetField.Text, out value))
                Offset = value;
        }

        private void SetAnchorX()
        {
            int value;
            if (Int32.TryParse(AnchorXFiled.Text, out value))
                AnchorX = value;
        }

        private void SetAnchorY()
        {
            int value;
            if (Int32.TryParse(AnchorYField.Text, out value))
                AnchorY = value;
        }

        private double ComputeKernelSum()
        {
            double SUM = 0;
            for (int i = 0; i < Rows; i++)
            {
                for(int j = 0; j <Columns; j++ )
                SUM += Kernel[i][j];
            }
            if (SUM == 0)
                SUM = 1;

            return SUM;
        }

        private void SaveFilter_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                var files = Directory.GetFiles(@".", "*.xml", SearchOption.TopDirectoryOnly);
                foreach (var file in files)
                {
                    if (file.ToString() == @".\" + Name + ".xml")
                    {
                        if (MessageBox.Show("Same filter name exists. Rewrite?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            XmlSerialization();
                        }
                    }
                    else
                    {
                        XmlSerialization();
                    }
                }
                GetFilters();
            }
        }

        private void XmlSerialization()
        {
            SetKernel();
            ConvolutionFilter convolutionFilter = CreateFilterClass(Name);
            XmlSerializer xs = new XmlSerializer(typeof(ConvolutionFilter));
            TextWriter tw = new StreamWriter(@".\" + Name + ".xml");
            xs.Serialize(tw, convolutionFilter);
            tw.Close();
        }

        private void GetFilters()
        {
            listBox.Items.Clear();
            container = new List<ConvolutionFilter> { };

            var files = Directory.GetFiles(@".", "*.xml", SearchOption.TopDirectoryOnly);
            XmlSerializer xs = new XmlSerializer(typeof(ConvolutionFilter));

            foreach (var file in files)
            {

                ConvolutionFilter convolutionFilter;
                using (var sr = new StreamReader(file))
                {
                    convolutionFilter = (ConvolutionFilter)xs.Deserialize(sr);
                }
                listBox.Items.Add(convolutionFilter.Name);
                container.Add(convolutionFilter);
            }          
        }

        private void AutoDivisor_Click(object sender, EventArgs e)
        {
            SetKernel();

            Divisor = ComputeKernelSum();

            DivisorField.Text = Divisor.ToString();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    var control = tableLayoutPanel1.GetControlFromPosition(j, i);
                    control.Text = "0";
                }
            }
        }

        private ConvolutionFilter CreateFilterClass(string name)
        {
            ConvolutionFilter convolutionFilter = new ConvolutionFilter();
            convolutionFilter.Name = name;
            convolutionFilter.Factor = 1 / Divisor;
            convolutionFilter.Bias = Bias;
            convolutionFilter.Kernel = Kernel;
            convolutionFilter.Offset = Offset;
            convolutionFilter.AnchorX = AnchorX;
            convolutionFilter.AnchorY = AnchorY;

            return convolutionFilter;
        }

        private void DivisorField_TextChanged(object sender, EventArgs e)
        {
            SetDivisor();
        }

        private void OffsetField_TextChanged(object sender, EventArgs e)
        {
            SetOffset();
        }

        private void BiasField_TextChanged(object sender, EventArgs e)
        {
            SetBias();
        }

        private void AnchorXFiled_TextChanged(object sender, EventArgs e)
        {
            SetAnchorX();
        }

        private void AnchorYField_TextChanged(object sender, EventArgs e)
        {
            SetAnchorY();
        }

        private void NameField_TextChanged(object sender, EventArgs e)
        {
            SetName();
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                string currentItem = listBox.SelectedItem.ToString();

                foreach (var filter in container)
                {
                    if (filter.Name == currentItem)
                    {
                        NameField.Text = filter.Name;
                        OffsetField.Text = filter.Offset.ToString();
                        BiasField.Text = filter.Bias.ToString();
                        AnchorXFiled.Text = filter.AnchorX.ToString();
                        AnchorYField.Text = filter.AnchorY.ToString();
                        DivisorField.Text = (1 / filter.Factor).ToString();
                        textBox1.Text = filter.Kernel.Length.ToString();
                        textBox2.Text = filter.Kernel[0].Length.ToString();
                        Kernel = filter.Kernel;
                        SetMatrix();
                    }
                }
            }         
        }

        private void AnchorXFiled_Validating(object sender, CancelEventArgs e)
        {
            int value;
            if (Int32.TryParse(AnchorXFiled.Text, out value))
            {
                if ((value < 0) || (value > Columns - 1))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(AnchorXFiled, "X index is out of range");
                }
                else
                {
                    errorProvider1.SetError(AnchorXFiled, null);
                }
                
            }
            else
            {
                e.Cancel = true;
                errorProvider1.SetError(AnchorXFiled,"Value is not numeric!");
            }
        }

        private void AnchorYField_Validating(object sender, CancelEventArgs e)
        {
            int value;
            if (Int32.TryParse(AnchorYField.Text, out value))
            {
                if ((value < 0) || (value > Rows - 1))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(AnchorYField, "Y index is out of range");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(AnchorYField, null);
                }

            }
            else
            {
                e.Cancel = true;
                errorProvider1.SetError(AnchorYField, "Value is not numeric!");
            }
        }

        private void NameField_Validating(object sender, CancelEventArgs e)
        {
            if (NameField.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(NameField,"Name must not be empty!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(NameField, null);
            }
        }

        private void BiasField_Validating(object sender, CancelEventArgs e)
        {
            int value;
            if (Int32.TryParse(BiasField.Text, out value))
            {
                e.Cancel = false;
                errorProvider1.SetError(BiasField, null);
            }
            else
            {
                e.Cancel = true;
                errorProvider1.SetError(BiasField, "Value is not numeric!");
            }
        }

        private void DivisorField_Validating(object sender, CancelEventArgs e)
        {
            int value;
            if (Int32.TryParse(DivisorField.Text, out value))
            {
                e.Cancel = false;
                errorProvider1.SetError(DivisorField, null);
            }
            else
            { 
                e.Cancel = true;
                errorProvider1.SetError(DivisorField, "Value is not numeric!");
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            int value;
            if (Int32.TryParse(textBox1.Text, out value))
            {
                if (value < 1 || value > 9 || value % 2 == 0)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(textBox1, "Odd values from range [1,9]!");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(textBox1, null);
                }
            }
            else
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "Value is not numeric!");
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            int value;
            if (Int32.TryParse(textBox2.Text, out value))
            {
                if (value < 1 || value > 9 || value % 2 == 0)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(textBox2, "Odd values from range [1,9]!");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(textBox2, null);
                }
            }
            else
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox2, "Value is not numeric!");  
            }
        }
    }
}
