using SmartLens.Client;
using SmartLens.Entities.Results;
using SmartLens.Listener.Abstract;
using System.Threading.Tasks;


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

        public async Task<IResult> ReceiveResult(IListener listener)
        {
            var checkResult = await listener.Listen();

            return checkResult;
        }
    }
}
