using SmartLens.DataAccess.Services.Client;
using SmartLens.Entities.Results;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SmartLens.DataAccess.Services.Api
{
    public class PythonImageDetectedService : IImageDetectedService
    {
        private IClient _client;
         PythonImageDetectedService(IClient client)
        {
            _client = client;
        }
        public Task SendResult(IResult result)
        {
            return Task.Run(()=> {
                _client.SendData(result);
            });
        }
    }
}
