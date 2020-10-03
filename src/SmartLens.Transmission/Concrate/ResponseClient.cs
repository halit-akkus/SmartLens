using SmartLens.Business.Services;
using SmartLens.Client;
using SmartLens.Listener.Abstract;
using SmartLens.Transmission.Abstract;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;

namespace SmartLens.Transmission.Concrate
{
     public class ResponseClient:IResponseClient
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

                  Console.WriteLine($"gelen veri=> X");

                var ep = new IPEndPoint(IPAddress.Parse(""),1111);


                var getBytes = Encoding.ASCII.GetBytes(result.Data.ImageIndexNumber.ToString());

                  await  _client.SendData(ep,getBytes);
              }
             
        }

    }
}
