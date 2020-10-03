
using Newtonsoft.Json;
using SmartLens.Client;
using SmartLens.Entities.Concrate;
using SmartLens.Entities.Results;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;



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
            var _client = new Udp();
            var  nrd = new Random();
            int x = nrd.Next(100,800);
            int y = nrd.Next(100, 500);
              while (true)
            {
                var stream = new StreamData
                {
                    Image = ImageToByte(Screenshot(x, y)),
                    UserId = Guid.NewGuid()
                };
                IResult result = new Result();
                
                var serialize = JsonConvert.SerializeObject(stream);
                byte[] bytes = Encoding.ASCII.GetBytes(serialize);

                result.receiveData = bytes;
                _client.SetPort(11000);
                _client.SendData(result);
            }
        }
    }
}
