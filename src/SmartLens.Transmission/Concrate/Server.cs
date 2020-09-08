using SmartLens.Business.Abstract;
using SmartLens.Listener.Abstract;
using SmartLens.Transmission.Abstract;
using System;
using System.Threading;

namespace SmartLens.Transmission.Concrate
{
    public  class Server:IServer
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
              
                var result = await listener.Listen();
               
                var checkResult = _detectedManager.ResultValidator(result);
                if (!checkResult.IsSuccess)
                {
                    foreach (var error in checkResult.Messages)
                    {
                        Console.WriteLine($"Server Error=>{error.Key} / Desc:{error.Message} ");
                    }
                    continue;
                }
                intervall.SetIntervall(result);

                await _detectedManager.SendResult(result);
            }
        }
    }
}
