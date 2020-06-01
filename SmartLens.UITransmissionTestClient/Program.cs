
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

            var Screenshot = new Bitmap(1920,1080);
            Graphics GFX = Graphics.FromImage(Screenshot);
            GFX.CopyFromScreen(0, 0, 0, 0,new Size(1920,1080));

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
            while (true)
            {
               byte[] sendbuf = ImageToByte(Screenshot());
                IPEndPoint ep = new IPEndPoint(broadcast, 11000);

                s.SendTo(sendbuf,65507,SocketFlags.None,ep);

                Console.WriteLine("Message sent to the broadcast address");
               
            }
           
        }
    }
}
