using SmartLens.Business.Abstract.Listener;
using SmartLens.Business.Concrete.Listener;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartLens.Transmission.Concrate
{
   public static class Server
    {
        
        [STAThread]
        public static async Task<Image> GetImageAsync(IListener Listener)
        {
            byte[] bytes = await Listener.StartListener();

            return Image.FromStream(new MemoryStream(bytes));
        }

       public static async void ServerStarted(int _port,IListener listener)
        {
            
            Console.WriteLine("Started Server[PORT NO:{0}]", _port);
            Console.WriteLine("-----------------------------");

            
            var intervall = Intervall.Get();

            new Thread(new ParameterizedThreadStart(ConsoleEffect.Effect)).Start(listener.Message().Length);
           
            while (true)
            {
                Console.WriteLine();
                ConsoleEffect.SetColor();
                Console.Write($"{ listener.Message()} =>");
                /*------------------------------------------*/
                var checkImg = await GetImageAsync(listener);
                /*------------------------------------------*/
                var size = ((int)2048 / 1024).ToString();
                intervall.SetIntervall(checkImg, size, int.Parse(size));
            }
        }
    }
}
