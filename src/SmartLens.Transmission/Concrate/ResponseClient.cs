using SmartLens.Business.Abstract;
using SmartLens.Client;
using SmartLens.Listener.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SmartLens.Transmission.Concrate
{
     public class ResponseClient
    {
        private IImageDetectedManager _detectedManager;
        private IClient _client;
        public ResponseClient(IImageDetectedManager imageDetectedManager, IClient client)
        {
            _detectedManager = imageDetectedManager;
            _client = client;
        }

        public async void ServerStarted(IListener listener)
        {
            while (true)
            {
                var result = await _detectedManager.ReceiveResult(listener);

                if (!result.IsSuccess)
                {
                    foreach (var error in result.Messages)
                    {
                        Console.WriteLine($"Client Error=>:{error.Key} / Desc:{error.Message} ");
                    }
                    continue;
                }
                Console.WriteLine($"Sended=> X ");
                //TODO : daha sonra burada aşağıdaki gibi yapılandırılacak.
                //Console.WriteLine($"Sended=> { result.Data.client.IPAddress } ");
                await  _client.SendData(result.Data);
            }
        }

    }
}
