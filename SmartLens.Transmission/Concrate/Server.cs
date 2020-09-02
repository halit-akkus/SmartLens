using Newtonsoft.Json;
using SmartLens.Business.Abstract;
using SmartLens.Entities.Concrate;
using SmartLens.Entities.Results;
using SmartLens.Listener.Abstract;
using SmartLens.Transmission.Services;
using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartLens.Transmission.Concrate
{
    public  class Server
    {
        private IImageDetectedManager _detectedManager;
        public Server(IImageDetectedManager imageDetectedManager)
        {
            _detectedManager = imageDetectedManager;
        }
       
        public  async void ServerStarted(IListener listener)
        {
            var intervall = Intervall.Get();

            new Thread(new ParameterizedThreadStart(ConsoleEffect.Effect)).Start(listener.Message().Length);

            while (true)
            {
                Console.WriteLine();
               
                Console.Write($"{ listener.Message()} =>");
                /*------------------------------------------*/
                var result = await listener.Listen();
                /*------------------------------------------*/
               
                var checkResult = _detectedManager.ResultValidator(result);
            
                if (checkResult.IsSuccess)
                {
                    intervall.SetIntervall(result);

                    await  _detectedManager.SendResult(result);
                }
            }
        }
    }
}
