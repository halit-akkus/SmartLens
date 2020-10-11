using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace SmartLens.UITransmissionTestClient.Client.Concrete
{
    class PaintingProcess : IPaintingProcess
    {
        public byte[] ImageToByte(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        public Image Screenshot(int x, int y)
        {
            var Screenshot = new Bitmap(500, 500);
            Graphics GFX = Graphics.FromImage(Screenshot);
            var nrd = new Random();
            GFX.CopyFromScreen(0, x, y, 0, new Size(500, 500));

            return Screenshot;
        }  
     
    }
}
