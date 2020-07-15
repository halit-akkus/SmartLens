
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
       
        static  private Image Screenshot(int x, int y)
        {
            var Screenshot = new Bitmap(500,500);
            Graphics GFX = Graphics.FromImage(Screenshot);
            var nrd = new Random();
            GFX.CopyFromScreen(0, x, y, 0,new Size(500, 500));

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
            
            var _client = new UDP_CLIENT("127.0.0.1", 11000);

            
            Console.WriteLine("Started");

            var  nrd = new Random();
            int x = nrd.Next(0,800);
            int y = nrd.Next(0, 100);

            while (true)
            {
                _client.SendBuffer(ImageToByte(Screenshot(x,y)));
                Thread.Sleep(1);
            }
        }
    }
}
