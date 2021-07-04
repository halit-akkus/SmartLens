using SmartLens.Business.Services;
using SmartLens.Entities.Results;
using SmartLens.Listener.Abstract;
using SmartLens.Transmission.Abstract;
using SmartLens.Transmission.ClientEndPoint;
using SmartLens.Transmission.Tdo;
using System;
using System.Threading;

namespace SmartLens.Transmission.Concrate
{
    public  class Server:IServer
    {
        private IImageDetectedManager _detectedManager;

        private IClientEp _clientEp;
        
        public Server(IImageDetectedManager imageDetectedManager, IClientEp clientEp)
        {
            _detectedManager = imageDetectedManager;
            _clientEp = clientEp;
        }

        public  async void ServerStarted(IListener listener)
        {
            var intervall = Intervall.Get();

            var consoleEffect = new Thread(new ParameterizedThreadStart(ConsoleEffect.Effect));
            
            consoleEffect.Start(listener.Message().Length);

            while (true)
            {
                Console.WriteLine();
                Console.Write($"{ listener.Message()} =>");

                var result = await listener.Listen();

                var stream = ResultParse<Stream>.jsonDeserialize(result.ReceiveData);
                
                var checkResult = _detectedManager.ResultValidator(stream);

                if (!checkResult.IsSuccess)
                {
                    foreach (var error in checkResult.Messages)
                    {
                        Console.WriteLine($"Server Error=>{error.Key} / Desc:{error.Message} ");
                    }
                    continue;
                }
                
                _clientEp.AddClient(stream.UserId,result.IPEndPoint);

                var statistics = new StatisticsModel
                {
                    Stream = stream,
                    IPEndPoint = result.IPEndPoint
                };

                intervall.SetIntervall(statistics);

                await _detectedManager.SendResult(stream);
            }
        }
    }
}
