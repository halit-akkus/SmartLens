
using SmartLens.Client;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;


namespace SmartLens.UITransmissionTestClient
{
    class Program
    {
      static  private Image Screenshot()
        {
            var Screenshot = new Bitmap(500,500);
            Graphics GFX = Graphics.FromImage(Screenshot);
            GFX.CopyFromScreen(0, 0, 0, 0,new Size(500, 500));

            return Screenshot;
        }
      static  public byte[] ImageToByte(Image imageIn)
        {
          using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
       
        static void Main(string[] args)
        {
            
            var client = new UDP_CLIENT("127.0.0.1", 11000);

            Console.ReadLine();
            Console.WriteLine("Started");
            while (true)
            {
                client.SendBuffer(ImageToByte(Screenshot()));
                Thread.Sleep(5);
            }
        }
    }
}
