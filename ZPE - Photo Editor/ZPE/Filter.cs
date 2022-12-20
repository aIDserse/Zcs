using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace ZPE
{
    class Filter
    {
        public unsafe Bitmap GreyScaleFilter(Bitmap image)
        {
            Bitmap returnMap = new Bitmap(image.Width, image.Height,
                                   PixelFormat.Format32bppArgb);
            BitmapData bitmapData1 = image.LockBits(new Rectangle(0, 0,
                                     image.Width, image.Height),
                                     ImageLockMode.ReadOnly,
                                     PixelFormat.Format32bppArgb);
            BitmapData bitmapData2 = returnMap.LockBits(new Rectangle(0, 0,
                                     returnMap.Width, returnMap.Height),
                                     ImageLockMode.ReadOnly,
                                     PixelFormat.Format32bppArgb);
            int a = 0;
            byte* imagePointer1 = (byte*)bitmapData1.Scan0;
            byte* imagePointer2 = (byte*)bitmapData2.Scan0;
            for (int i = 0; i < bitmapData1.Height; i++)
            {
                for (int j = 0; j < bitmapData1.Width; j++)
                {
                    a = (imagePointer1[0] + imagePointer1[1] + imagePointer1[2]) / 3;
                    imagePointer2[0] = (byte)a;
                    imagePointer2[1] = (byte)a;
                    imagePointer2[2] = (byte)a;
                    imagePointer2[3] = imagePointer1[3];
                    imagePointer1 += 4;
                    imagePointer2 += 4;
                }
                imagePointer1 += bitmapData1.Stride -
                                (bitmapData1.Width * 4);
                imagePointer2 += bitmapData1.Stride -
                                (bitmapData1.Width * 4);
            }
            returnMap.UnlockBits(bitmapData2);
            image.UnlockBits(bitmapData1);
            return returnMap;
        }
        public Image MedianFilter(Bitmap b)
        {
            BitmapData bData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, b.PixelFormat);
            int size = bData.Stride * bData.Height;
            byte[] data = new byte[size];
            byte[] data2 = new byte[size];
            int k = 4;
            int r = bData.Stride * 4;
            System.Runtime.InteropServices.Marshal.Copy(bData.Scan0, data, 0, size);
            for (int i = r; i < size - r; i += k)
            {
                if (i % bData.Stride * 4 > 1 && i % bData.Stride * 4 < bData.Stride * 4 - 2)
                {
                    int[] Arr1 = { data[i], data[i + k], data[i + k * 2], data[i - k], data[i - k * 2], data[i - bData.Stride], data[i - bData.Stride * 2], data[i + bData.Stride], data[i + bData.Stride * 2] };
                    Array.Sort(Arr1);
                    data2[i] = Convert.ToByte(Arr1[4]);
                    int[] Arr2 = { data[i + 1], data[i + 1 + k], data[i + 1 + k * 2], data[i + 1 - k], data[i + 1 - k * 2], data[i + 1 - bData.Stride], data[i + 1 - bData.Stride * 2], data[i + 1 + bData.Stride], data[i + 1 + bData.Stride * 2] };
                    Array.Sort(Arr2);
                    data2[i + 1] = Convert.ToByte(Arr2[4]);
                    int[] Arr3 = { data[i + 2], data[i + 2 + k], data[i + 2 + k * 2], data[i + 2 - k], data[i + 2 - k * 2], data[i + 2 - bData.Stride], data[i + 2 - bData.Stride * 2], data[i + 2 + bData.Stride], data[i + 2 + bData.Stride * 2] };
                    Array.Sort(Arr3);
                    data2[i + 2] = Convert.ToByte(Arr3[4]);
                    data2[i + 3] = data[i + 3];
                }
            }
            data = data2;
            System.Runtime.InteropServices.Marshal.Copy(data, 0, bData.Scan0, data.Length);
            b.UnlockBits(bData);
            return b;
        }
        public Image TresholdFilter(Bitmap b)
        {
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetThreshold((float)0.5);
            Point[] points =
            {
              new Point(0, 0),
              new Point(b.Width, 0),
              new Point(0, b.Height),
            };
            Rectangle rect =
                new Rectangle(0, 0, b.Width, b.Height);
            using (Graphics gr = Graphics.FromImage(b))
            {
                gr.DrawImage(b, points, rect,
                GraphicsUnit.Pixel, attributes);
            }
            return b;
        }
        public Image InvertColourFilter(Bitmap b)
        {
            BitmapData bData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, b.PixelFormat);
            int size = bData.Stride * bData.Height;
            byte[] data = new byte[size];
            byte[] data2 = new byte[size];
            int k = 4;
            int r = bData.Stride * 4;
            System.Runtime.InteropServices.Marshal.Copy(bData.Scan0, data, 0, size);
            for (int i = r; i < size - r; i += k)
            {
                data2[i] = Convert.ToByte(255 - data[i]);
                data2[i + 1] = Convert.ToByte(255 - data[i + 1]);
                data2[i + 2] = Convert.ToByte(255 - data[i + 2]);
                data2[i + 3] = data[i + 3];
            }
            data = data2;
            System.Runtime.InteropServices.Marshal.Copy(data, 0, bData.Scan0, data.Length);
            b.UnlockBits(bData);
            return b;
        }
        public Bitmap LaplacianFilter(Bitmap b)
        {
            BitmapData bData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, b.PixelFormat);
            int size = bData.Stride * bData.Height;
            byte[] data = new byte[size];
            byte[] data2 = new byte[size];
            int k = 4;
            System.Runtime.InteropServices.Marshal.Copy(bData.Scan0, data, 0, size);
            for (int i = 0; i < size - k; i += k)
            {
                if ((i >= bData.Stride && i < size - bData.Stride) && !(i % bData.Stride == 0) && !(i % bData.Stride == bData.Stride - 4))
                {
                    data2[i] = Convert.ToByte(Math.Max(Math.Min((data[i] * 4 + data[i + k] * -1 + data[i - k] * -1 + data[i + bData.Stride] * -1 + data[i - bData.Stride] * -1), 255), 0));
                    data2[i + 1] = Convert.ToByte(Math.Max(Math.Min((data[i + 1] * 4 + data[i + 1 + k] * -1 + data[i + 1 - k] * -1 + data[i + 1 + bData.Stride] * -1 + data[i + 1 - bData.Stride] * -1), 255), 0));
                    data2[i + 2] = Convert.ToByte(Math.Max(Math.Min((data[i + 2] * 4 + data[i + 2 + k] * -1 + data[i + 2 - k] * -1 + data[i + 2 + bData.Stride] * -1 + data[i + 2 - bData.Stride] * -1), 255), 0));
                    data2[i + 3] = data[i + 3];
                }
            }
            data = data2;
            System.Runtime.InteropServices.Marshal.Copy(data, 0, bData.Scan0, data.Length);
            b.UnlockBits(bData);
            return b;
        }
        public Image MaxFilter(Bitmap b)
        {
            BitmapData bData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, b.PixelFormat);
            int size = bData.Stride * bData.Height;
            byte[] data = new byte[size];
            byte[] data2 = new byte[size];
            int k = 4;
            int r = bData.Stride * 4;
            System.Runtime.InteropServices.Marshal.Copy(bData.Scan0, data, 0, size);
            for (int i = r; i < size - r; i += k)
            {
                if ((i >= bData.Stride && i < size - bData.Stride) && !(i % bData.Stride == 0) && !(i % bData.Stride == bData.Stride - 4))
                {
                    int[] Arr1 = { data[i], data[i + k], data[i + k * 2], data[i - k], data[i - k * 2], data[i - bData.Stride], data[i - bData.Stride * 2], data[i + bData.Stride], data[i + bData.Stride * 2] };
                    Array.Sort(Arr1);
                    data2[i] = Convert.ToByte(Arr1.Max());
                    int[] Arr2 = { data[i + 1], data[i + 1 + k], data[i + 1 + k * 2], data[i + 1 - k], data[i + 1 - k * 2], data[i + 1 - bData.Stride], data[i + 1 - bData.Stride * 2], data[i + 1 + bData.Stride], data[i + 1 + bData.Stride * 2] };
                    Array.Sort(Arr2);
                    data2[i + 1] = Convert.ToByte(Arr2.Max());
                    int[] Arr3 = { data[i + 2], data[i + 2 + k], data[i + 2 + k * 2], data[i + 2 - k], data[i + 2 - k * 2], data[i + 2 - bData.Stride], data[i + 2 - bData.Stride * 2], data[i + 2 + bData.Stride], data[i + 2 + bData.Stride * 2] };
                    Array.Sort(Arr3);
                    data2[i + 2] = Convert.ToByte(Arr3.Max());
                    data2[i + 3] = data[i + 3];
                }
            }
            data = data2;
            System.Runtime.InteropServices.Marshal.Copy(data, 0, bData.Scan0, data.Length);
            b.UnlockBits(bData);
            return b;
        }
        public Image MinFilter(Bitmap b)
        {
            BitmapData bData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, b.PixelFormat);
            int size = bData.Stride * bData.Height;
            byte[] data = new byte[size];
            byte[] data2 = new byte[size];
            int k = 4;
            int r = bData.Stride * 4;
            System.Runtime.InteropServices.Marshal.Copy(bData.Scan0, data, 0, size);
            for (int i = r; i < size - r; i += k)
            {
                if ((i >= bData.Stride && i < size - bData.Stride) && !(i % bData.Stride == 0) && !(i % bData.Stride == bData.Stride - 4))
                {
                    int[] Arr1 = { data[i], data[i + k], data[i + k * 2], data[i - k], data[i - k * 2], data[i - bData.Stride], data[i - bData.Stride * 2], data[i + bData.Stride], data[i + bData.Stride * 2] };
                    Array.Sort(Arr1);
                    data2[i] = Convert.ToByte(Arr1.Min());
                    int[] Arr2 = { data[i + 1], data[i + 1 + k], data[i + 1 + k * 2], data[i + 1 - k], data[i + 1 - k * 2], data[i + 1 - bData.Stride], data[i + 1 - bData.Stride * 2], data[i + 1 + bData.Stride], data[i + 1 + bData.Stride * 2] };
                    Array.Sort(Arr2);
                    data2[i + 1] = Convert.ToByte(Arr2.Min());
                    int[] Arr3 = { data[i + 2], data[i + 2 + k], data[i + 2 + k * 2], data[i + 2 - k], data[i + 2 - k * 2], data[i + 2 - bData.Stride], data[i + 2 - bData.Stride * 2], data[i + 2 + bData.Stride], data[i + 2 + bData.Stride * 2] };
                    Array.Sort(Arr3);
                    data2[i + 2] = Convert.ToByte(Arr3.Min());
                    data2[i + 3] = data[i + 3];
                }
            }
            data = data2;
            System.Runtime.InteropServices.Marshal.Copy(data, 0, bData.Scan0, data.Length);
            b.UnlockBits(bData);
            return b;
        }
        public void AttenuationFIlter(Bitmap b)
        {
            BitmapData bData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, b.PixelFormat);
            int size = bData.Stride * bData.Height;
            byte[] data = new byte[size];
            byte[] data2 = new byte[size];
            int k = 2;
            int r = bData.Stride;
            System.Runtime.InteropServices.Marshal.Copy(bData.Scan0, data, 0, size);
            for (int i = r; i < size - r; i += k)
            {
                if (!(i % r == 0) && !(i % r == r - 4))
                {
                    data2[i] = Convert.ToByte((data[i] * 4 + data[i + k] * 2 + data[i - k] * 2 + data[i - r] * 2 + data[i - r - k] + data[i - r + k] + data[i + r - k] + data[i + r] * 2 + data[i + r + k]) / 16);
                    data2[i + 1] = Convert.ToByte((data[i + 1] * 4 + data[i + 1 + k] * 2 + data[i + 1 - k] * 2 + data[i + 1 - r] * 2 + data[i + 1 - r - k] + data[i + 1 - r + k] + data[i + 1 + r - k] + data[i + 1 + r] * 2 + data[i + 1 + r + k]) / 16);
                    data2[i + 2] = Convert.ToByte((data[i + 2] * 4 + data[i + 2 + k] * 2 + data[i + 2 - k] * 2 + data[i + 2 - r] * 2 + data[i + 2 - r - k] + data[i + 2 - r + k] + data[i + 2 + r - k] + data[i + 2 + r] * 2 + data[i + 2 + r + k]) / 16);
                    data2[i + 3] = data[i + 3];
                }
            }
            data = data2;
            System.Runtime.InteropServices.Marshal.Copy(data, 0, bData.Scan0, data.Length);
            b.UnlockBits(bData);
        }
        public void BlurFilter(Bitmap b)
        {
            BitmapData bData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, b.PixelFormat);
            int size = bData.Stride * bData.Height;
            byte[] data = new byte[size];
            byte[] data2 = new byte[size];
            int k = 4;
            int r = bData.Stride * 4;
            System.Runtime.InteropServices.Marshal.Copy(bData.Scan0, data, 0, size);
            for (int i = r; i < size - r; i += k)
            {
                if (i % bData.Stride * 4 > 1 && i % bData.Stride * 4 < bData.Stride * 4 - 2)
                {
                    data2[i] = Convert.ToByte((data[i] + data[i + k] + data[i - k] + data[i - bData.Stride] + data[i - bData.Stride - k] + data[i - bData.Stride + k] + data[i + bData.Stride - k] + data[i + bData.Stride] + data[i + bData.Stride + k]) / 9);
                    data2[i + 1] = Convert.ToByte((data[i + 1] + data[i + 1 + k] + data[i + 1 - k] + data[i + 1 - bData.Stride - k] + data[i + 1 - bData.Stride] + data[i + 1 - bData.Stride + k] + data[i + 1 + bData.Stride - k] + data[i + 1 + bData.Stride] + data[i + 1 + bData.Stride + k]) / 9);
                    data2[i + 2] = Convert.ToByte((data[i + 2] + data[i + 2 + k] + data[i + 2 - k] + data[i + 2 - bData.Stride - k] + data[i + 2 - bData.Stride] + data[i + 2 - bData.Stride + k] + data[i + 2 + bData.Stride - k] + data[i + 2 + bData.Stride] + data[i + 2 + bData.Stride + k]) / 9);
                    data2[i + 3] = data[i + 3];
                }
            }
            System.Runtime.InteropServices.Marshal.Copy(data2, 0, bData.Scan0, data2.Length);
            b.UnlockBits(bData);
        }
        public void SharpnessFilter(Bitmap b)
        {
            BitmapData bData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, b.PixelFormat);
            int size = bData.Stride * bData.Height;
            byte[] data = new byte[size];
            byte[] data2 = new byte[size];
            int k = 4;
            int r = bData.Stride * 4;
            System.Runtime.InteropServices.Marshal.Copy(bData.Scan0, data, 0, size);
            for (int i = 0; i < size; i += k)
            {
                if ((i >= bData.Stride && i < size - bData.Stride) && !(i % bData.Stride == 0) && !(i % bData.Stride == bData.Stride - 4))
                {
                    data2[i] = Convert.ToByte(Math.Max(Math.Min((data[i] * 5 + data[i + k] * -1 + data[i - k] * -1 + data[i + bData.Stride] * -1 + data[i - bData.Stride] * -1), 255), 0));
                    data2[i + 1] = Convert.ToByte(Math.Max(Math.Min((data[i + 1] * 5 + data[i + 1 + k] * -1 + data[i + 1 - k] * -1 + data[i + 1 + bData.Stride] * -1 + data[i + 1 - bData.Stride] * -1), 255), 0));
                    data2[i + 2] = Convert.ToByte(Math.Max(Math.Min((data[i + 2] * 5 + data[i + 2 + k] * -1 + data[i + 2 - k] * -1 + data[i + 2 + bData.Stride] * -1 + data[i + 2 - bData.Stride] * -1), 255), 0));
                    data2[i + 3] = data[i + 3];
                }
            }
            data = data2;
            System.Runtime.InteropServices.Marshal.Copy(data, 0, bData.Scan0, data.Length);
            b.UnlockBits(bData);
        }
        public void MaxSharpnessFilter(Bitmap b)
        {
            BitmapData bData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, b.PixelFormat);
            int size = bData.Stride * bData.Height;
            byte[] data = new byte[size];
            byte[] data2 = new byte[size];
            int k = 4;
            System.Runtime.InteropServices.Marshal.Copy(bData.Scan0, data, 0, size);
            for (int i = 0; i < size - k; i += k)
            {
                if ((i >= bData.Stride && i < size - bData.Stride) && !(i % bData.Stride == 0) && !(i % bData.Stride == bData.Stride - 4))
                {
                    data2[i] = Convert.ToByte(Math.Max(Math.Min((data[i] * 9 + data[i + k] * -1 + data[i - k] * -1 + data[i + bData.Stride] * -1 + data[i - bData.Stride] * -1 + data[i - bData.Stride + k] * -1 + data[i - bData.Stride - k] * -1 + data[i + bData.Stride + k] * -1 + data[i + bData.Stride - k] * -1), 255), 0));
                    data2[i + 1] = Convert.ToByte(Math.Max(Math.Min((data[i + 1] * 9 + data[i + 1 + k] * -1 + data[i + 1 - k] * -1 + data[i + 1 + bData.Stride] * -1 + data[i + 1 - bData.Stride] * -1 + data[i + 1 - bData.Stride + k] * -1 + data[i + 1 - bData.Stride - k] * -1 + data[i + 1 + bData.Stride + k] * -1 + data[i + 1 + bData.Stride - k] * -1), 255), 0));
                    data2[i + 2] = Convert.ToByte(Math.Max(Math.Min((data[i + 2] * 9 + data[i + 2 + k] * -1 + data[i + 2 - k] * -1 + data[i + 2 + bData.Stride] * -1 + data[i + 2 - bData.Stride] * -1 + data[i + 2 - bData.Stride + k] * -1 + data[i + 2 - bData.Stride - k] * -1 + data[i + 2 + bData.Stride + k] * -1 + data[i + 2 + bData.Stride - k] * -1), 255), 0));
                    data2[i + 3] = data[i + 3];
                }
            }
            data = data2;
            System.Runtime.InteropServices.Marshal.Copy(data, 0, bData.Scan0, data.Length);
            b.UnlockBits(bData);
        }
        public Image BrightnessFilter(int livello, Bitmap b) //Ok
        {
            BitmapData bData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, b.PixelFormat);
            int size = bData.Stride * bData.Height;
            byte[] data = new byte[size];
            byte[] data2 = new byte[size];
            int k = 2;
            int r = bData.Stride * 4;
            data2 = data;
            System.Runtime.InteropServices.Marshal.Copy(bData.Scan0, data, 0, size);
            for (int i = 0; i < size - k; i += k)
            {
                if (i % bData.Stride * 4 > 1 && i % bData.Stride * 4 < bData.Stride * 4 - 2)
                {
                    data2[i] = Convert.ToByte(Math.Max(Math.Min(data[i] + livello, 255), 0));
                    data2[i + 1] = Convert.ToByte(Math.Max(Math.Min(data[i + 1] + livello, 255), 0));
                    data2[i + 2] = Convert.ToByte(Math.Max(Math.Min(data[i + 2] + livello, 255), 0));
                }
            }
            data = data2;
            System.Runtime.InteropServices.Marshal.Copy(data, 0, bData.Scan0, data.Length);
            b.UnlockBits(bData);
            return b;
        }
    }
}
