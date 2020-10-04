using SmartLens.Client;
using SmartLens.Listener.Abstract;
using System.Net;
using System.Threading.Tasks;


namespace SmartLens.DataAccess.Services.Api
{
    public class PythonImageDetectedService : IImageDetectedService
    {
        private IClient _client;
        private const int _port = 1254;
        private const string _host = "127.0.0.1";
        public PythonImageDetectedService(IClient client)
        {
            _client = client;
        }
        //business layerden gelen veriler buradan python servisine iletilecek.
        public async Task SendResult(byte[] data)
        {
            var ep = new IPEndPoint(IPAddress.Parse(_host),_port);
            await _client.SendData(ep,data);
        }

        //python tarafından gelen veriler buraya düşecek.
        public async Task<byte[]> ReceiveResult(IListener listener,int port)
        {
            var checkResult = await listener.Listen(port);
            
            return checkResult;
        }
    }
}
