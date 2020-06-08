
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
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            IPAddress broadcast = IPAddress.Parse("127.0.0.1");
            var rnd = new Random();
            while (true)
            {
               byte[] sendbuf = ImageToByte(Screenshot());
                IPEndPoint ep = new IPEndPoint(broadcast, 11000);

                if (sendbuf.Length > 65505)
                    continue;

                   s.SendTo(sendbuf,ep);

                Console.WriteLine(rnd.Next(0, 99999));
                Thread.Sleep(1);
            }
        }
    }
}
