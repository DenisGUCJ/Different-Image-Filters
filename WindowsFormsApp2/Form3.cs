using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form3 : Form
    {
        public  OrderedDitheringFilter FormFilter { get; set; }
        public double[][] Kernel { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int K { get; set; }
        public Form3()
        {
            InitializeComponent();

            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.ColumnCount = 2;
            Rows = tableLayoutPanel1.RowCount;
            Columns = tableLayoutPanel1.ColumnCount;
            K = 2;

            for (int i = 0; i < 6; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40));
            }

            tableLayoutPanel1.Controls.Add(MakeASell(), 0, 0);
            tableLayoutPanel1.Controls.Add(MakeASell(), 0, 0);
            tableLayoutPanel1.Controls.Add(MakeASell(), 0, 0);
            tableLayoutPanel1.Controls.Add(MakeASell(), 0, 0);

            AdaptKernel(2);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int value;
            int prevValue = tableLayoutPanel1.RowCount;

            if (Int32.TryParse(textBox1.Text, out value))
            {
                if (value >= 2 && value <= 6)
                {
                    if (value != 5)
                    {
                        textBox2.Text = value.ToString();

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
                    AdaptKernel(value);
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int value;
            int prevValue = tableLayoutPanel1.ColumnCount;

            if (Int32.TryParse(textBox2.Text, out value))
            {
                if (value >= 2 && value <= 6)
                {
                    if (value != 5)
                    {
                        textBox1.Text = value.ToString();

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

        private TextBox MakeASell()
        {
            TextBox richTextBox = new TextBox();
            richTextBox.Dock = DockStyle.Fill;
            richTextBox.Text = "0";
            richTextBox.ReadOnly = true;
            richTextBox.Validating += new CancelEventHandler(MakeACell_Validating);

            return richTextBox;
        }

        private void MakeACell_Validating(object sender, CancelEventArgs e)
        {
            TextBox cell = (TextBox)sender;
            double value;
            if (double.TryParse(cell.Text, out value))
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

        private void KValue_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (Int32.TryParse(KValue.Text, out value))
            {
                K = value;   
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            //SetKernel();
            SetFilter();
            this.Close();
        }

        private void SetFilter()
        {
            FormFilter = new OrderedDitheringFilter();
            FormFilter.Kernel = Kernel;
            FormFilter.AnchorX = (Rows - 1) / 2;
            FormFilter.AnchorY = (Columns - 1) / 2;
            FormFilter.K = K;
            FormFilter.Dimention = Rows;
        }

        private void PreSetButton_Click(object sender, EventArgs e)
        {
            Kernel = new double[3][] {new double [3] {3, 7, 4} ,
                                    new double [3] {6, 1, 9},
                                    new double [3]  {2, 8, 5}};

            MakeBayerKernel(3);
            textBox1.Text = "3";
            textBox2.Text = "3";
            KValue.Text = "2";
            SetMatrix();
        }

        private void AdaptKernel(int dimension) 
        {
            switch (dimension)  
            {
                case 2:
                    Kernel = new double[2][] {new double [2] {1, 3},
                                    new double [2] {4, 2} };
                    textBox1.Text = "2";
                    textBox2.Text = "2";
                    MakeBayerKernel(2);
                    SetMatrix();
                    break;
                case 3:
                    Kernel = new double[3][] {new double [3] {3, 7, 4} ,
                                    new double [3] {6, 1, 9},
                                    new double [3]  {2, 8, 5}};
                    textBox1.Text = "3";
                    textBox2.Text = "3";
                    MakeBayerKernel(3);
                    SetMatrix();
                    break;
                case 4:
                    MakeComplexBayerKernel(4);
                    textBox1.Text = "4";
                    textBox2.Text = "4";
                    MakeBayerKernel(4);
                    SetMatrix();
                    break;
                case 6:
                    MakeComplexBayerKernel(6);
                    textBox1.Text = "6";
                    textBox2.Text = "6";
                    MakeBayerKernel(6);
                    SetMatrix();
                    break;
                default:
                    break;
            }

                
        }
            
        private void MakeBayerKernel(int dimension)
        {
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    Kernel[i][j] = Kernel[i][j] * (1.0 / (dimension * dimension + 1));
                }
            }
        }

        private void MakeComplexBayerKernel(int dimension)
        {
           if (dimension == 4)
            {
                Kernel = new double[2][] {new double [2] {1, 3},
                                    new double [2] {4, 2} };
            }
            else
            {
                Kernel = new double[3][] {new double [3] {3, 7, 4} ,
                                    new double [3] {6, 1, 9},
                                    new double [3]  {2, 8, 5}};
            }

            double[][] temp = new double[dimension][];
            for (int i = 0; i < dimension; i++)
            {
                temp[i] = new double[dimension];
            }
            //uppel left part
            for (int i = 0; i < dimension/2; i++)
            {
                for (int j = 0; j < dimension / 2; j++)
                    temp[i][j] = 4.0 * (Kernel[i][j] - 1) + 1.0;
            }

            //upper right part
            for (int i = 0; i < dimension / 2; i++)
            {
                for (int j = dimension/2; j < dimension; j++)
                    temp[i][j] = 4.0 * (Kernel[i][j - dimension / 2] - 1) + 3.0;
            }

            for (int i = dimension / 2; i < dimension; i++)
            {
                for (int j = 0; j < dimension / 2; j++)
                    temp[i][j] = 4.0 * (Kernel[i - dimension / 2][j] - 1) + 4.0;
            }

            //lower right part
            for (int i = dimension / 2; i < dimension; i++)
            {
                for (int j = dimension / 2; j < dimension; j++)
                    temp[i][j] = 4.0 * (Kernel[i - dimension / 2][j - dimension / 2] - 1) + 2.0;
            }

            Kernel = temp;
        }
    }
}
