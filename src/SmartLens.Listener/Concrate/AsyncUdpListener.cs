using SmartLens.Entities.Models.Result;
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
        private static UdpClient _frontlistener;
        private static UdpClient _serviceListener;

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

            return _asyncUdpServer;
        }

        public async Task<Result> Listen()
        {
            try
            {
                _frontlistener = new UdpClient(_port);
                var receiveResult = await _frontlistener.ReceiveAsync();

                _frontlistener.Close();
                var result = new Result
                {
                    ReceiveData = receiveResult.Buffer,
                    IPEndPoint = receiveResult.RemoteEndPoint
                };

                return result;
            }
            catch (SocketException e)  { return null;  }
        }

        public async Task<byte[]> Listen(int port)
        {
            try
            {
                _serviceListener = new UdpClient(port);
                var receiveResult = await _serviceListener.ReceiveAsync();

                _serviceListener.Close();
             
                return receiveResult.Buffer;
            }
            catch (SocketException e) { return null; }
        }

        public void Dispose()
        {
            _serviceListener = null;
            _frontlistener = null;
        }

        public string Message()
        {
            return "For UDP";
        }
    }
}