using SmartLens.Business.Services;
using SmartLens.Client;
using SmartLens.Listener.Abstract;
using SmartLens.Transmission.Abstract;
using SmartLens.Transmission.ClientEndPoint;
using System;
using System.Net;
using System.Text;

namespace SmartLens.Transmission.Concrate
{
    public class ResponseClient : IResponseClient
    {
        private IImageDetectedManager _detectedManager;
        private IClient _client;
        private IClientEp _clientEp;
        public ResponseClient(IClientEp clientEp, IImageDetectedManager imageDetectedManager, IClient client)
        {
            _clientEp = clientEp;
            _detectedManager = imageDetectedManager;
            _client = client;
        }

        public async void ServerStarted(IListener listener, int port)
        {

            while (true)
            {
                var result = await _detectedManager.ReceiveResult(listener, port);

                if (!result.IsSuccess)
                {
                    foreach (var error in result.Messages)
                    {
                        Console.WriteLine($"Client Error=>:{error.Key} / Desc:{error.Message} ");
                    }
                    continue;
                }

                
                var sb = new StringBuilder();
                foreach (var item in result.Data.DetectionList)
                {
                    sb.Append($" {item}");
                }
                var getBytes = Encoding.ASCII.GetBytes(sb.ToString());

                var getClient = _clientEp.GetClientByUserId(result.Data.UserId);
                if (getClient != null)
                {
                    await _client.SendData(getClient.IpEndPoint, getBytes);

                    _clientEp.RemoveClientByUserId(result.Data.UserId);
                }

            }

        }

    }
}
