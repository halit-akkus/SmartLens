using SmartLens.Entities.Results;
using SmartLens.Listener.Abstract;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SmartLens.Listener.Concrate
{
    public class AsyncUdpListener : IListener, IDisposable
    {
        private static UdpClient _listener { get; set; }
        private static IPEndPoint _groupEP { get; set; }
        private static AsyncUdpListener _asyncUdpServer;
        private static int _port;

        private static object _lockObject = new object();
        public static AsyncUdpListener CurrentUdpServer(object obj)
        {
            if (_asyncUdpServer == null)
            {
                lock (_lockObject)
                {
                    if (_asyncUdpServer == null)
                    {
                        _asyncUdpServer = new AsyncUdpListener();
                    }
                }
            }
            _port = (int)obj;
            _groupEP = new IPEndPoint(IPAddress.Any, _port);
            return _asyncUdpServer;
        }

        public async Task<IResult> Listen()
        {
            try
            {
                _listener = new UdpClient(_port);
                var receiveResult = await _listener.ReceiveAsync();
                
                _listener.Close();
                var result = new Result
                {
                    receiveData = receiveResult.Buffer,
                };

                return result;
            }
            catch (SocketException e)  { return null;  }
        }

        public async Task<IResult> Listen(int port)
        {
            try
            {
                _listener = new UdpClient(port);
                var receiveResult = await _listener.ReceiveAsync();

                _listener.Close();
                var result = new Result
                {
                    receiveData = receiveResult.Buffer,
                };

                return result;
            }
            catch (SocketException e) { return null; }
        }

        public void Dispose()
        {
            _listener = null;
        }

        public string Message()
        {
            return "For UDP";
        }
    }
}