using SmartLens.Entities.Results;
using SmartLens.Listener.Abstract;
using System;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SmartLens.Listener.Concrate
{
    public class AsyncTcpIpListener : IDisposable, IListener
    {
        private static TcpListener _listener;
        private static AsyncTcpIpListener _asyncTcpServer;
        public static AsyncTcpIpListener CurrentTcpServer(int port)
        {
            if (_asyncTcpServer == null)
            {
                _asyncTcpServer = new AsyncTcpIpListener();
                _listener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
                _listener.Start();
            }
            return _asyncTcpServer;
        }
        public void Dispose()
        {
            _listener = null;
        }
        public string Message()
        {
            return "For TCP";
        }

        public async Task<IResult> Listen()
        {
            try
            {
                var receiveResult = await _listener.AcceptTcpClientAsync();
                
                var myNetworkStream = receiveResult.GetStream();
                
                if (myNetworkStream.CanRead)
                {
                    byte[] myReadBuffer = new byte[1024];
                    myNetworkStream.Read(myReadBuffer, 0, myReadBuffer.Length);
                    var result = new Result
                    {
                        receiveData = myReadBuffer,
                        client = new Client
                        {
                            IPAddress = IPAddress.Parse("127.0.0.1")
                        }
                    };
                    return result;
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
            }
            return null;
        }
    }
}
