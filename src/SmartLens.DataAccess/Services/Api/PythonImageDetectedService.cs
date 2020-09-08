using SmartLens.Client;
using SmartLens.Entities.Results;
using SmartLens.Listener.Abstract;
using System.Threading.Tasks;


namespace SmartLens.DataAccess.Services.Api
{
    public class PythonImageDetectedService : IImageDetectedService
    {
        private IClient _client;
        private const int _port = 1254;
         PythonImageDetectedService(IClient client)
        {
            _client = client;
        }
        //business layerden gelen veriler buradan python servisine iletilecek.
        public Task SendResult(IResult result)
        {
            return Task.Run(()=> {
                _client.SendData(result);
            });
        }

        //python tarafından gelen veriler buraya düşecek.
        public async Task<IResult> ReceiveResult(IListener listener)
        {
            var checkResult = await listener.Listen(_port);

            return checkResult;
        }
    }
}
