using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SmartLens.Transmission
{
   public static class ImageConvert
    {
        public static Image byteToImage(byte[] byteArrayIn)
        {
            using (var fileStream = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(fileStream);
            }
        }
        private static Image ImageToGray(Bitmap bmp)
        {
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color old = bmp.GetPixel(x, y);
                    int avg = (old.R + old.G + old.B) / 3;
                    Color yeni = Color.FromArgb(old.A, avg, avg, avg);
                    bmp.SetPixel(x, y, yeni);
                }
            }
            return bmp;
        }

       
    }
}
