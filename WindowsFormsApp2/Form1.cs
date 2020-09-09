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
    public partial class Form1 : Form
    {

        private List<ConvolutionFilter> container;

        private ConvolutionFilter activeFilter { get; set; }
        private OrderedDitheringFilter ActiveDitheringFilter { get; set; }

        private bool _ycbcrflag = false;

        private int K { get; set; }
        public Form1()
        {
            InitializeComponent();
            GetFilters();
            K = 8;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.png;)|*.jpg; *.jpeg; *.png;";
            if(open.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(open.FileName);
                pictureBox2.Image = new Bitmap(open.FileName);
            }

            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(pictureBox1);
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.Controls.Add(pictureBox2);
            _ycbcrflag = false;
        }

        private void Inversion_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image == null)
                return;
            Bitmap copy = new Bitmap((Bitmap)pictureBox2.Image);
            Processing.Filtering(copy,"invertion");
            pictureBox2.Image = copy;
        }

        private void BrightnessUP_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image == null)
                return;
            Bitmap copy = new Bitmap((Bitmap)pictureBox2.Image);
            Processing.Filtering(copy, "brighter");
            pictureBox2.Image = copy;
        }

        private void BrighnessDown_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image == null)
                return;
            Bitmap copy = new Bitmap((Bitmap)pictureBox2.Image);
            Processing.Filtering(copy, "darker");
            pictureBox2.Image = copy;
        }

        private void Default_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = pictureBox1.Image;
            _ycbcrflag = false;
        }

        private void Contrast_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image == null)
                return;
            Bitmap copy = new Bitmap((Bitmap)pictureBox2.Image);
            Processing.Filtering(copy, "contrast");
            pictureBox2.Image = copy;
        }

       
        private void Gamma_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image == null)
                return;
            Bitmap copy = new Bitmap((Bitmap)pictureBox2.Image);
            Processing.Filtering(copy, "gamma");
            pictureBox2.Image = copy;
        }

        private void Blur_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image == null)
                return;
            Bitmap copy = new Bitmap((Bitmap)pictureBox2.Image);
            pictureBox2.Image = Processing.ApplyConvolutionFilter(copy, CreateBlur());
        }

        private void Embos_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image == null)
                return;
            Bitmap copy = new Bitmap((Bitmap)pictureBox2.Image);
            pictureBox2.Image = Processing.ApplyConvolutionFilter(copy, CreateEmbos());
        }

        private void EdgeDetection_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image == null)
                return;
            Bitmap copy = new Bitmap((Bitmap)pictureBox2.Image);
            pictureBox2.Image = Processing.ApplyConvolutionFilter(copy, CreateEdgeDetection());
        }

        private void SharpenFilter_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image == null)
                return;
            Bitmap copy = new Bitmap((Bitmap)pictureBox2.Image);
            pictureBox2.Image = Processing.ApplyConvolutionFilter(copy, CreateSharpen());
        }

        private void GaussianBlur_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image == null)
                return;
            Bitmap copy = new Bitmap((Bitmap)pictureBox2.Image);
            pictureBox2.Image = Processing.ApplyConvolutionFilter(copy, CreateGaussian());
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image == null)
                return;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Image Files(*.jpg; *.jpeg;)|*.jpg; *.jpeg;";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image.Save(saveFileDialog.FileName);
            }
        }

        private void CustomFilter_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();

            if (f2.ShowDialog() == DialogResult.Cancel)
            {
                GetFilters();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                ApplyButton.Enabled = true;

                string currentItem = listBox1.SelectedItem.ToString();

                foreach (var filter in container)
                {
                    if (filter.Name == currentItem)
                    {
                        activeFilter = filter;
                    }
                }
            }
        }

        private void GetFilters()
        {
            listBox1.Items.Clear();
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
                listBox1.Items.Add(convolutionFilter.Name);
                container.Add(convolutionFilter);
            }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image == null)
                return;

            Bitmap copy = new Bitmap((Bitmap)pictureBox2.Image);
            pictureBox2.Image = Processing.ApplyConvolutionFilter(copy, activeFilter);
        }

        private ConvolutionFilter CreateBlur()
        {
            foreach (var file in container)
            {
                if (file.Name == "Default_Blur")
                {
                    return file;
                }
            }
            return new ConvolutionFilter();
        }

        private ConvolutionFilter CreateEmbos()
        {
            foreach (var file in container)
            {
                if (file.Name == "Default_Embos")
                {
                    return file;
                }
            }
            return new ConvolutionFilter();
        }

        private ConvolutionFilter CreateGaussian()
        {
            foreach (var file in container)
            {
                if (file.Name == "Default_GaussianBlur")
                {
                    return file;
                }
            }
            return new ConvolutionFilter();
        }

        private ConvolutionFilter CreateSharpen()
        {
            foreach (var file in container)
            {
                if (file.Name == "Default_Sharpen")
                {
                    return file;
                }
            }
            return new ConvolutionFilter();
        }

        private ConvolutionFilter CreateEdgeDetection()
        {
            foreach (var file in container)
            {
                if (file.Name == "Default_EdgeDetection")
                {
                    return file;
                }
            }
            return new ConvolutionFilter();
        }

        private void OrderedDithering_Click(object sender, EventArgs e)
        { 
            if (pictureBox2.Image == null || ActiveDitheringFilter == null)
                return;

            Bitmap copy = new Bitmap((Bitmap)pictureBox2.Image);
            pictureBox2.Image = Processing.ApplyOrderedDithering(copy, ActiveDitheringFilter);

        }

        private void GreyScale_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image == null)
                return;
            Bitmap copy = new Bitmap((Bitmap)pictureBox2.Image);
            Processing.Filtering(copy, "grey");
            pictureBox2.Image = copy;
            _ycbcrflag = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f2 = new Form3();

            if (f2.ShowDialog() == DialogResult.Cancel)
            {
                ActiveDitheringFilter = f2.FormFilter;
            }
        }
            

        private Image Zoom(Image img, int size)
        {
            Bitmap bmp = new Bitmap(img, img.Width + (img.Width * size / 100), img.Height + (img.Height * size / 100));
            Graphics g = Graphics.FromImage(bmp);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            return bmp;
        }


        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            switch(e.Button)
            {
                case MouseButtons.Left:
                    pictureBox1.Image = Zoom(pictureBox1.Image, 30);
                    break;
                case MouseButtons.Right:
                    pictureBox1.Image = Zoom(pictureBox1.Image, -30);
                    break;
            }
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    pictureBox2.Image = Zoom(pictureBox1.Image, 30);
                    break;
                case MouseButtons.Right:
                    pictureBox2.Image = Zoom(pictureBox1.Image, -30);
                    break;
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

        private void PopularityAlgorythm_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image == null)
                return;
            Bitmap copy = new Bitmap((Bitmap)pictureBox2.Image);
            Processing.PolularityAlgorithm(copy, K);
            pictureBox2.Image = copy;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image == null)
                return;

            Bitmap copy = new Bitmap((Bitmap)pictureBox2.Image);
            pictureBox2.Image = Processing.LabTask2(copy, ActiveDitheringFilter , _ycbcrflag);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image == null)
                return;
            _ycbcrflag = true;
            Bitmap copy = new Bitmap((Bitmap)pictureBox2.Image);
            Processing.Filtering(copy, "lab2");
            pictureBox2.Image = copy;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image == null)
                return;
            _ycbcrflag = false;
            Bitmap copy = new Bitmap((Bitmap)pictureBox2.Image);
            Processing.Filtering(copy, "lab2back");
            pictureBox2.Image = copy;
        }
    }
}
