using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    static class Processing
    {
      

        public static void Filtering(Bitmap processedBitmap, string filter)
        {
          
            BitmapData bitmapData = processedBitmap.LockBits(new Rectangle(0, 0, processedBitmap.Width, processedBitmap.Height), ImageLockMode.ReadWrite, processedBitmap.PixelFormat);

            int bytesPerPixel = Bitmap.GetPixelFormatSize(processedBitmap.PixelFormat) / 8;
            int byteCount = bitmapData.Stride * processedBitmap.Height;
            byte[] pixels = new byte[byteCount];
            IntPtr ptrFirstPixel = bitmapData.Scan0;
            Marshal.Copy(ptrFirstPixel, pixels, 0, pixels.Length);
            int heightInPixels = bitmapData.Height;
            int widthInBytes = bitmapData.Width * bytesPerPixel;

            switch (filter) 
            {
                case "invertion":

                    for (int y = 0; y < heightInPixels; y++)
                    {
                        int currentLine = y * bitmapData.Stride;
                        for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                        {
                            int oldBlue = 255 - pixels[currentLine + x];
                            int oldGreen = 255 - pixels[currentLine + x + 1];
                            int oldRed = 255 - pixels[currentLine + x + 2];

                            pixels[currentLine + x] = (byte)oldBlue;
                            pixels[currentLine + x + 1] = (byte)oldGreen;
                            pixels[currentLine + x + 2] = (byte)oldRed;
                        }
                    }

                    Marshal.Copy(pixels, 0, ptrFirstPixel, pixels.Length);
                    processedBitmap.UnlockBits(bitmapData);

                    break;

                case "brighter":

                    for (int y = 0; y < heightInPixels; y++)
                    {
                        int currentLine = y * bitmapData.Stride;
                        for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                        {
                            int oldBlue = 50 + pixels[currentLine + x]; if (oldBlue > 255) oldBlue = 255;
                            int oldGreen = 50 + pixels[currentLine + x + 1]; if (oldGreen > 255) oldGreen = 255;
                            int oldRed = 50 + pixels[currentLine + x + 2]; if (oldRed > 255) oldRed = 255;

                            pixels[currentLine + x] = (byte)oldBlue;
                            pixels[currentLine + x + 1] = (byte)oldGreen;
                            pixels[currentLine + x + 2] = (byte)oldRed;
                        }
                    }

                    Marshal.Copy(pixels, 0, ptrFirstPixel, pixels.Length);
                    processedBitmap.UnlockBits(bitmapData);

                    break;



                case "darker":

                    for (int y = 0; y < heightInPixels; y++)
                    {
                        int currentLine = y * bitmapData.Stride;
                        for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                        {
                            int oldBlue = pixels[currentLine + x] - 50; if (oldBlue < 0) oldBlue = 0;
                            int oldGreen = pixels[currentLine + x + 1] - 50; if (oldGreen < 0) oldGreen = 0;
                            int oldRed = pixels[currentLine + x + 2] - 50; if (oldRed < 0) oldRed = 0;

                            pixels[currentLine + x] = (byte)oldBlue;
                            pixels[currentLine + x + 1] = (byte)oldGreen;
                            pixels[currentLine + x + 2] = (byte)oldRed;
                        }
                    }

                    Marshal.Copy(pixels, 0, ptrFirstPixel, pixels.Length);
                    processedBitmap.UnlockBits(bitmapData);

                    break;

                case "contrast":
                      
                    int threshold = 50;
                    var contrastLevel = Math.Pow((100.0 + threshold) / 100.0, 2);

                    for (int y = 0; y < heightInPixels; y++)
                    {
                        int currentLine = y * bitmapData.Stride;
                        for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                        {
                            int oldBlue = (int)(((((pixels[currentLine + x] / 255.0) - 0.5) * contrastLevel) + 0.5) * 255.0);
                            if (oldBlue < 0) oldBlue = 0; else if (oldBlue > 255) oldBlue = 255;

                            int oldGreen = (int)(((((pixels[currentLine + x + 1] / 255.0) - 0.5) * contrastLevel) + 0.5) * 255.0);
                            if (oldGreen < 0) oldGreen = 0; else if (oldGreen > 255) oldGreen = 255;

                            int oldRed = (int)(((((pixels[currentLine + x + 2] / 255.0) - 0.5) * contrastLevel) + 0.5) * 255.0);
                            if (oldRed < 0) oldRed = 0; else if (oldRed > 255) oldRed = 255;

                            pixels[currentLine + x] = (byte)oldBlue;
                            pixels[currentLine + x + 1] = (byte)oldGreen;
                            pixels[currentLine + x + 2] = (byte)oldRed;
                        }
                    }

                    Marshal.Copy(pixels, 0, ptrFirstPixel, pixels.Length);
                    processedBitmap.UnlockBits(bitmapData);

                    break;

                case "gamma":

                    for (int y = 0; y < heightInPixels; y++)
                    {
                        int currentLine = y * bitmapData.Stride;
                        for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                        {
                            // gamma = 1.5

                            int oldBlue = (int)(255 * Math.Pow((pixels[currentLine + x] / 255.0), 1.5));
                            if (oldBlue < 0) oldBlue = 0; else if (oldBlue > 255) oldBlue = 255;

                            int oldGreen = (int)(255 * Math.Pow((pixels[currentLine+x + 1] / 255.0), 1.5));
                            if (oldGreen < 0) oldGreen = 0; else if (oldGreen > 255) oldGreen = 255;

                            int oldRed = (int)(255 * Math.Pow((pixels[currentLine + x + 2] / 255.0), 1.5));
                            if (oldRed < 0) oldRed = 0; else if (oldRed > 255) oldRed = 255;

                            pixels[currentLine + x] = (byte)oldBlue;
                            pixels[currentLine + x + 1] = (byte)oldGreen;
                            pixels[currentLine + x + 2] = (byte)oldRed;
                        }
                    }

                    Marshal.Copy(pixels, 0, ptrFirstPixel, pixels.Length);
                    processedBitmap.UnlockBits(bitmapData);

                    break;
                case "grey":

                    for (int y = 0; y < heightInPixels; y++)
                    {
                        int currentLine = y * bitmapData.Stride;
                        for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                        {

                            //average  method 
                            double grey = (pixels[currentLine + x] + pixels[currentLine + x + 1] + pixels[currentLine + x + 2]) / 3;

                            //luminosity method
                            //double grey = 0.21 * pixels[currentLine + x] + 0.72 * pixels[currentLine + x + 1] + 0.07 * pixels[currentLine + x + 2];
                         
                            pixels[currentLine + x] = (byte)grey;
                            pixels[currentLine + x + 1] = (byte)grey;
                            pixels[currentLine + x + 2] = (byte)grey;
                        }
                    }

                    Marshal.Copy(pixels, 0, ptrFirstPixel, pixels.Length);
                    processedBitmap.UnlockBits(bitmapData);

                    break;

                case "lab2":

                    for (int y = 0; y < heightInPixels; y++)
                    {
                        int currentLine = y * bitmapData.Stride;
                        for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                        {

                            double blue = pixels[currentLine + x];
                            double green = pixels[currentLine + x + 1];
                            double red = pixels[currentLine + x + 2];


                            double Y = 16.0 + 1.0 / 256.0 * (65.738 * red + 129.057 * green + 25.064 * blue);
                            double Cb = 128.0 + 1.0 / 256.0 * (-37.945 * red - 74.494 * green + 112.439 * blue);
                            double Cr = 128.0 + 1.0 / 256.0 * (112.439 * red - 94.154 * green - 18.285 * blue);

                            pixels[currentLine + x] = (byte)Cr;
                            pixels[currentLine + x + 1] = (byte)Cb;
                            pixels[currentLine + x + 2] = (byte)Y;
                        }
                    }

                    Marshal.Copy(pixels, 0, ptrFirstPixel, pixels.Length);
                    processedBitmap.UnlockBits(bitmapData);

                    break;

                case "lab2back":

                    for (int y = 0; y < heightInPixels; y++)
                    {
                        int currentLine = y * bitmapData.Stride;
                        for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                        {

                            double newCr = pixels[currentLine + x];
                            double newCb = pixels[currentLine + x + 1];
                            double newY = pixels[currentLine + x + 2];


                            double red = (298.082 * newY + 408.583 * newCr) / 256.0 - 222.921;
                            double green = (298.082 * newY - 100.291 * newCb - 208.120 * newCr) / 256.0 + 135.576;
                            double blue = (298.082 * newY + 516.412 * newCb) / 256.0 - 276.836;

                            pixels[currentLine + x] = (byte)blue;
                            pixels[currentLine + x + 1] = (byte)green;
                            pixels[currentLine + x + 2] = (byte)red;
                        }
                    }

                    Marshal.Copy(pixels, 0, ptrFirstPixel, pixels.Length);
                    processedBitmap.UnlockBits(bitmapData);

                    break;

                default:
                    break;
            }
            
        }

        public static Bitmap ApplyConvolutionFilter(this Bitmap sourceBitmap, ConvolutionFilter filter)
        {

            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];


            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);


            sourceBitmap.UnlockBits(sourceData);

            int filterHeight = filter.Kernel.Length;
            int filterWidth = filter.Kernel[0].Length;
            int filterAnchorX = filter.AnchorX;
            int filterAnchorY = filter.AnchorY;

            int indexLowerBoundX = -filterAnchorX;
            int indexUpperBoundX = (filterWidth - filterAnchorX) - 1;
            int indexLowerBoundY = -filterAnchorY;
            int indexUpperBoundY = (filterHeight - filterAnchorY) - 1;


            for (int offsetY = 0; offsetY < sourceBitmap.Height; offsetY++) 
            {
                for (int offsetX = 0; offsetX < sourceBitmap.Width; offsetX++)
                {
                    double blue = 0;
                    double green = 0;
                    double red = 0;

                    int byteOffset = offsetY * sourceData.Stride + offsetX * 4;

                    for (int filterY = indexLowerBoundY; filterY <= indexUpperBoundY; filterY++)
                    {
                        int computeY = (filterY) * sourceData.Stride;

                        if ((offsetY + filterY < 0) || (offsetY + filterY) > (sourceBitmap.Height - 1))
                        {
                            computeY = (-filterY) * sourceData.Stride;
                        }

                        for (int filterX = indexLowerBoundX; filterX <= indexUpperBoundX; filterX++)
                        {
                            int computeX = filterX * 4;

                            if((offsetX + filterX) < 0 || (offsetX + filterX) > (sourceBitmap.Width - 1))
                            {
                                computeX = (- filterX) * 4;
                            }

                            int calcOffset = byteOffset + computeY + computeX;

                     
                            blue += (pixelBuffer[calcOffset]) * filter.Kernel[filterY + filterAnchorY] [filterX + filterAnchorX];

                            green += (pixelBuffer[calcOffset + 1]) * filter.Kernel[filterY + filterAnchorY][filterX + filterAnchorX];

                            red += (pixelBuffer[calcOffset + 2]) * filter.Kernel[filterY + filterAnchorY][filterX + filterAnchorX];

                        }
                    }


                    blue = filter.Factor * blue + filter.Bias;
                    green = filter.Factor * green + filter.Bias;
                    red = filter.Factor * red + filter.Bias;


                    if (blue > 255) blue = 255;
                    else if (blue < 0) blue = 0;

                    if (green > 255) green = 255;
                    else if (green < 0) green = 0;


                    if (red > 255) red = 255;
                    else if (red < 0) red = 0;


                    resultBuffer[byteOffset] = (byte)(blue);
                    resultBuffer[byteOffset + 1] = (byte)(green);
                    resultBuffer[byteOffset + 2] = (byte)(red);
                    resultBuffer[byteOffset + 3] = 255;
                }
            }

            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);


            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);


            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);


            return resultBitmap;
        }


        public static Bitmap ApplyOrderedDithering(this Bitmap sourceBitmap, OrderedDitheringFilter filter)
        {
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];


            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);


            sourceBitmap.UnlockBits(sourceData);

           
            
            int filterAnchorX = filter.AnchorX;
            int filterAnchorY = filter.AnchorY;
            int filterDimension = filter.Dimention;
            int indexLowerBoundX = -filterAnchorX;
            int indexUpperBoundX = (filterDimension - filterAnchorX) - 1;
            int indexLowerBoundY = -filterAnchorY;
            int indexUpperBoundY = (filterDimension - filterAnchorY) - 1;
            int K = filter.K;

            double[] levels = new double[K]; 

            for (int i = 0; i < levels.Length; i++)
            {
                double interval = (float)i / (K - 1);
                levels[i] = interval * 255;
            }

            for (int offsetY = 0; offsetY < sourceBitmap.Height; offsetY += filter.Dimention)
            {
                for (int offsetX = 0; offsetX < sourceBitmap.Width; offsetX += filter.Dimention)
                {

                    int byteOffset = offsetY * sourceData.Stride + offsetX * 4;

                    for (int filterY = indexLowerBoundY; filterY <= indexUpperBoundY; filterY++)
                    {
                        int computeY = (filterY) * sourceData.Stride;

                        if ((offsetY + filterY < 0) || (offsetY + filterY) > (sourceBitmap.Height - 1))
                        {
                            continue;
                        }

                        for (int filterX = indexLowerBoundX; filterX <= indexUpperBoundX; filterX++)
                        {
                            int computeX = filterX * 4;

                            if ((offsetX + filterX) < 0 || (offsetX + filterX) > (sourceBitmap.Width - 1))
                            {
                                continue;
                            }

                            int calcOffset = byteOffset + computeY + computeX;

                            double kernelValue = filter.Kernel[filterY + filterAnchorY][filterX + filterAnchorX];
                            double blue = (pixelBuffer[calcOffset]);
                            double green = (pixelBuffer[calcOffset + 1]);
                            double red = (pixelBuffer[calcOffset + 2]);

                            resultBuffer[calcOffset] = (byte)levels[TakeLevelIndex(blue, kernelValue, K)];
                            resultBuffer[calcOffset + 1] = (byte)levels[TakeLevelIndex(green, kernelValue, K)];
                            resultBuffer[calcOffset + 2] = (byte)levels[TakeLevelIndex(red, kernelValue, K)];

                            resultBuffer[calcOffset + 3] = 255;

                        }
                    }
                }
            }


            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }


        private static int TakeLevelIndex(double channel, double kernel, int K)
        {
            double kernel_intensity = kernel;
            double channel_intensity = channel / 255;
           
            double col = Math.Floor((K - 1) * channel_intensity);

            double re = (K - 1) * channel_intensity - col;

            if (re >= kernel_intensity)
            {
                col++;
            }

            return (int)col;
        }

        public static void PolularityAlgorithm(Bitmap processedBitmap, int K)
        {
            BitmapData bitmapData = processedBitmap.LockBits(new Rectangle(0, 0, processedBitmap.Width, processedBitmap.Height), ImageLockMode.ReadWrite, processedBitmap.PixelFormat);

            int bytesPerPixel = Bitmap.GetPixelFormatSize(processedBitmap.PixelFormat) / 8;
            int byteCount = bitmapData.Stride * processedBitmap.Height;
            byte[] pixels = new byte[byteCount];
            IntPtr ptrFirstPixel = bitmapData.Scan0;
            Marshal.Copy(ptrFirstPixel, pixels, 0, pixels.Length);
            int heightInPixels = bitmapData.Height;
            int widthInBytes = bitmapData.Width * bytesPerPixel;


            Dictionary<Color, int> container = new Dictionary<Color, int>();


            for (int y = 0; y < heightInPixels; y++)
            {
                int currentLine = y * bitmapData.Stride;
                for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                {
                    int blue = pixels[currentLine + x];
                    int green = pixels[currentLine + x + 1];
                    int red = pixels[currentLine + x + 2];

                    Color color = Color.FromArgb(red, green, blue);


                    if (container.ContainsKey(color))
                    {
                        container[color]++;

                    }
                    else
                    {
                        container.Add(color, 1);
                    }
                }
            }

            var sortedList = container.ToList();
            sortedList.Sort((a, b) => b.Value.CompareTo(a.Value));


            List<Color> pallete = new List<Color>() { };

            for(int i = 0; i < K; i++) 
            {
                if (sortedList.Count == 0 || sortedList.First().Key == null)
                {
                    break;
                }
                pallete.Add(sortedList.First().Key);
                sortedList.Remove(sortedList.First());
                //var maxKey = container.FirstOrDefault(x => x.Value == container.Values.Max()).Key;
                //pallete.Add(maxKey);
                //container.Remove(maxKey); 
            }



            //for (int y = 0; y < heightInPixels; y++)
            Parallel.For(0,heightInPixels,y=>
            {
                int currentLine = y * bitmapData.Stride;
                for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                {
                    //Color min = Color.FromArgb(255, 255, 255);
                    int red = pixels[currentLine + x + 2];
                    int green = pixels[currentLine + x + 1];
                    int blue = pixels[currentLine + x];

                    var temp_pallete = pallete;
                    //int actualIntencity = pixels[currentLine + x] + pixels[currentLine + x + 1]
                    //        + pixels[currentLine + x + 2];

                    var closestColor = GetClosestColor(pallete, Color.FromArgb(red, green, blue));

                    //foreach (var value in pallete)
                    //{  
                    //    double palleteIntencity = value.R + value.G + value.B;

                    //    double diff = Math.Abs(palleteIntencity - actualIntencity);
                    //    if (diff < min)
                    //    {
                    //        min = diff;
                    //        red = value.R;
                    //        green = value.G;
                    //        blue = value.B;
                    //    }
                    //}
                    pixels[currentLine + x] = (byte)closestColor.B;
                    pixels[currentLine + x + 1] = (byte)closestColor.G;
                    pixels[currentLine + x + 2] = (byte)closestColor.R;
                }
            });


            Marshal.Copy(pixels, 0, ptrFirstPixel, pixels.Length);
            processedBitmap.UnlockBits(bitmapData);
        }

        private static Color GetClosestColor(List<Color> colorList, Color baseColor)
        {
            var colors = colorList.Select(x => new { Value = x, Diff = GetDiff(x, baseColor) }).ToList();
            var min = colors.Min(x => x.Diff);
            return colors.Find(x => x.Diff == min).Value;
        }

        private static int GetDiff(Color color, Color baseColor)
        {
            int a = color.A - baseColor.A,
                r = color.R - baseColor.R,
                g = color.G - baseColor.G,
                b = color.B - baseColor.B;
            return a * a + r * r + g * g + b * b; //Euclid distance
        }

     
        public static Bitmap LabTask2(this Bitmap sourceBitmap, OrderedDitheringFilter filter,bool _flag)
        {
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];


            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);


            sourceBitmap.UnlockBits(sourceData);



            int filterAnchorX = filter.AnchorX;
            int filterAnchorY = filter.AnchorY;
            int filterDimension = filter.Dimention;
            int indexLowerBoundX = -filterAnchorX;
            int indexUpperBoundX = (filterDimension - filterAnchorX) - 1;
            int indexLowerBoundY = -filterAnchorY;
            int indexUpperBoundY = (filterDimension - filterAnchorY) - 1;
            int K = filter.K;

            double[] levels = new double[K];

            for (int i = 0; i < levels.Length; i++)
            {
                double interval = (float)i / (K - 1);
                levels[i] = interval * 255;
            }

            double[] levelsY = new double[K];
            double[] levelsCr = new double[K];
            double[] levelsCb = new double[K];

            for (int i = 0; i < levelsY.Length; i++)
            {
                double interval = (float)i / (K - 1);
                levelsY[i] = 17 + interval * (235 - 17);
            }

            for (int i = 0; i < levelsCr.Length; i++)
            {
                double interval = (float)i / (K - 1);
                levelsCr[i] = 16 + interval * (240 - 16);
            }

            for (int i = 0; i < levelsCb.Length; i++)
            {
                double interval = (float)i / (K - 1);
                levelsCb[i] = 16 + interval * (240 - 16);
            }

            for (int offsetY = 0; offsetY < sourceBitmap.Height; offsetY += filter.Dimention)
            {
                for (int offsetX = 0; offsetX < sourceBitmap.Width; offsetX += filter.Dimention)
                {

                    int byteOffset = offsetY * sourceData.Stride + offsetX * 4;

                    for (int filterY = indexLowerBoundY; filterY <= indexUpperBoundY; filterY++)
                    {
                        int computeY = (filterY) * sourceData.Stride;

                        if ((offsetY + filterY < 0) || (offsetY + filterY) > (sourceBitmap.Height - 1))
                        {
                            continue;
                        }

                        for (int filterX = indexLowerBoundX; filterX <= indexUpperBoundX; filterX++)
                        {
                            int computeX = filterX * 4;

                            if ((offsetX + filterX) < 0 || (offsetX + filterX) > (sourceBitmap.Width - 1))
                            {
                                continue;
                            }

                            int calcOffset = byteOffset + computeY + computeX;

                            double kernelValue = filter.Kernel[filterY + filterAnchorY][filterX + filterAnchorX];


                            double blue = (pixelBuffer[calcOffset]);
                            double green = (pixelBuffer[calcOffset + 1]);
                            double red = (pixelBuffer[calcOffset + 2]);

                            double Y;
                            double Cb;
                            double Cr;

                            if (_flag)
                            {
                                Y = red;
                                Cb = green;
                                Cr = blue;
                            }
                            else
                            {
                                Y = 16.0 + 1.0 / 256.0 * (65.738 * red + 129.057 * green + 25.064 * blue);
                                Cb = 128.0 + 1.0 / 256.0 * (-37.945 * red - 74.494 * green + 112.439 * blue);
                                Cr = 128.0 + 1.0 / 256.0 * (112.439 * red - 94.154 * green - 18.285 * blue);
                            }

                            double newY = levelsY[TakeLevelIndex(Y, kernelValue, K)];
                            double newCr = levelsCr[TakeLevelIndex(Cr, kernelValue, K)];
                            double newCb = levelsCb[TakeLevelIndex(Cb, kernelValue, K)];

                            double newRed = (298.082 * newY + 408.583 * newCr) / 256.0 - 222.921;
                            if (newRed < 0) newRed = 0;
                            if (newRed > 255) newRed = 255;

                            double newGreen = (298.082 * newY - 100.291 * newCb - 208.120 * newCr) / 256.0 + 135.576;
                            if (newGreen < 0) newGreen = 0;
                            if (newGreen > 255) newGreen = 255;

                            double newBlue = (298.082 * newY + 516.412 * newCb) / 256.0 - 276.836;
                            if (newBlue < 0) newBlue = 0;
                            if (newBlue > 255) newBlue = 255;
                            
                            if (newGreen < 0) newGreen = 0;

                            resultBuffer[calcOffset] = (byte)newBlue;
                            resultBuffer[calcOffset + 1] = (byte)newGreen;
                            resultBuffer[calcOffset + 2] = (byte)newRed;


                            resultBuffer[calcOffset + 3] = 255;

                        }
                    }
                }
            }


            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }


    }
}
