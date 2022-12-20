using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZPE
{
    public partial class Form1 : Form
    {
        string filename;
        Filter fil = new Filter();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Clear();
            groupBoxImage.AutoSize = true;
        }
        private void GreyScaleButton_Click(object sender, EventArgs e)
        {
            if (ImagePictureBox != null && ImagePictureBox.Image != null)
            {
                Bitmap p = new Bitmap(ImagePictureBox.Image);
                ImagePictureBox.Image = fil.GreyScaleFilter(p);
            }
        }
        private void MedianButton_Click(object sender, EventArgs e)
        {
            if (ImagePictureBox.Image != null)
            {
                Bitmap p = new Bitmap(ImagePictureBox.Image);
                fil.MedianFilter(p);
                ImagePictureBox.Image = p;
            }
        }
        private void TresholdButton_Click(object sender, EventArgs e)
        {
            if (ImagePictureBox.Image != null)
            {
                Bitmap p = new Bitmap(ImagePictureBox.Image);
                fil.TresholdFilter(p);
                ImagePictureBox.Image = p;
            }
        }
        private void bottLaplacian_Click(object sender, EventArgs e)
        {
            if (ImagePictureBox.Image != null)
            {
                Bitmap p = new Bitmap(ImagePictureBox.Image);
                p = fil.LaplacianFilter(p);
                ImagePictureBox.Image = p;
            }
        }
        private void InvertColourButton_Click(object sender, EventArgs e)
        {
            if (ImagePictureBox.Image != null)
            {
                Bitmap p = new Bitmap(ImagePictureBox.Image);
                fil.InvertColourFilter(p);
                ImagePictureBox.Image = p;
            }
        }
        private void EdgeDetectButton_Click(object sender, EventArgs e)
        {
            if (ImagePictureBox.Image != null)
            {
                Bitmap p = new Bitmap(ImagePictureBox.Image);
                fil.MedianFilter(p);
                fil.GreyScaleFilter(p);
                fil.LaplacianFilter(p);
                fil.TresholdFilter(p);
                ImagePictureBox.Image = p;
            }
        }
        private void MaxButton_Click(object sender, EventArgs e)
        {
            if (ImagePictureBox.Image != null)
            {
                Bitmap p = new Bitmap(ImagePictureBox.Image);
                fil.MaxFilter(p);
                ImagePictureBox.Image = p;
            }
        }
        private void MinButton_Click(object sender, EventArgs e)
        {
            if (ImagePictureBox.Image != null)
            {
                Bitmap p = new Bitmap(ImagePictureBox.Image);
                fil.MinFilter(p);
                ImagePictureBox.Image = p;
            }
        }
        private void trackBarBlur_Scroll(object sender, EventArgs e)
        {
            label9.Text = Convert.ToString(trackBarBlur.Value);
            if (ImagePictureBox.Image != null)
            {
                Bitmap p = new Bitmap(ImagePictureBox.Image);
                for (int i = 0; i < trackBarBlur.Value - 1; i++)
                {
                    fil.BlurFilter(p);
                }
                ImagePictureBox.Image = p;
            }
        }
        private void trackBarSharpness_Scroll(object sender, EventArgs e)
        {
            label10.Text = Convert.ToString(trackBarSharpness.Value);
            if (ImagePictureBox.Image != null)
            {
                Bitmap p = new Bitmap(ImagePictureBox.Image);
                for (int i = 0; i < trackBarSharpness.Value - 1; i++)
                {
                    fil.SharpnessFilter(p);
                }
                ImagePictureBox.Image = p;
            }
        }
        private void trackBarMaxSharpness_Scroll(object sender, EventArgs e)
        {
            label11.Text = Convert.ToString(trackBarMaxSharpness.Value);
            if (ImagePictureBox.Image != null)
            {
                Bitmap p = new Bitmap(ImagePictureBox.Image);
                for (int i = 0; i < trackBarMaxSharpness.Value - 1; i++)
                {
                    fil.MaxSharpnessFilter(p);
                }
                ImagePictureBox.Image = p;
            }
        }
        private void trackBarBrightness_Scroll(object sender, EventArgs e)
        {
            label15.Text = Convert.ToString(trackBarBrightness.Value);
            if (ImagePictureBox.Image != null)
            {
                Bitmap p = new Bitmap(ImagePictureBox.Image);
                fil.BrightnessFilter(trackBarBrightness.Value, p);
                ImagePictureBox.Image = p;
            }
        }
        private void ColourButton_Click(object sender, EventArgs e)
        {
            if (ImagePictureBox.Image != null)
            {
                CreateChart(new Bitmap(ImagePictureBox.Image));
            }
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog f = new SaveFileDialog();
            f.Filter = "Imagine file png (*.png)|*.png|Imagine file jpg (*.jpg)|*.jpg";
            f.Title = "Scegli immagine";
            f.ShowDialog();
            if (f.FileName != "" && f.FileName != null)
            {
                ImagePictureBox.Image.Save(f.FileName);
            }
        }
        private void LoadButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Open a new file?\nAny unsaved work will be lost", "Open new file", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                OpenFileDialog f = new OpenFileDialog();
                f.Filter = "Imagine file png (*.png)|*.png|Imagine file jpg (*.jpg)|*.jpg";
                f.Title = "Salve immagine";
                f.ShowDialog();
                if (f.FileName != null && f.FileName != "")
                {
                    filename = f.FileName;
                    groupBoxImage.Text = f.FileName;
                    ImagePictureBox.Image = new Bitmap(filename);
                    Clear();
                }
            }
        }
        public void CreateChart(Bitmap b)
        {
            int[] ArrRed = new int[256];
            int[] ArrBlue = new int[256];
            int[] ArrGreen = new int[256];
            for (int i = 0; i < 256; i++)
            {
                ArrRed[i] = 0;
            }
            for (int i = 0; i < 256; i++)
            {
                ArrBlue[i] = 0;
            }
            for (int i = 0; i < 256; i++)
            {
                ArrGreen[i] = 0;
            }
            BitmapData bData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, b.PixelFormat);
            int size = bData.Stride * bData.Height;
            byte[] data = new byte[size];
            int k = 4;
            int r = bData.Stride * 4;
            System.Runtime.InteropServices.Marshal.Copy(bData.Scan0, data, 0, size);
            for (int i = r; i < size - r; i += k)
            {
                if ((i >= bData.Stride && i < size - bData.Stride) && !(i % bData.Stride == 0) && !(i % bData.Stride == bData.Stride - 4))
                {
                    ArrBlue[data[i]]++;
                    ArrGreen[data[i + 1]]++;
                    ArrRed[data[i + 2]]++;
                }
            }
            Form2 f = new Form2();
            f.AR = ArrRed;
            f.AG = ArrGreen;
            f.AB = ArrBlue;
            f.Show();
        }
        void Clear()
        {
            label9.Text = "";
            label10.Text = "";
            label11.Text = "";
            label13.Text = "";
            label14.Text = "";
            label15.Text = "";
            trackBarBlur.Value = 0;
            trackBarSharpness.Value = 0;
            trackBarMaxSharpness.Value = 0;
            trackBarBrightness.Value = 0;
        }
        private void ImagePictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            label13.Text = Convert.ToString(e.X);
            label14.Text = Convert.ToString(e.Y);
        }
    }
}
