using SmartLens.Business.Abstract.Listener;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SmartLens.Business.Concrete.Listener
{
    public class AsyncUdpListener : IListener,IDisposable
    {
        private static UdpClient _listener { get; set; }
        private static IPEndPoint _groupEP { get; set; }
        private static AsyncUdpListener _asyncUdpServer;
     
        public static AsyncUdpListener currentUdpServer(UdpClient udpClient, IPEndPoint ıPEndPoint)
        {
            if (_asyncUdpServer ==null)
            {
                _asyncUdpServer = new AsyncUdpListener();
            }
            _listener = udpClient;
            _groupEP = ıPEndPoint;
            return _asyncUdpServer;
        }
        public static void newUdpClient(UdpClient udpClient)
        {
            _listener = udpClient;
        }
        public async Task<byte[]> StartListener()
        {
            try
            {
                var receiveResult = await _listener.ReceiveAsync();
                _listener.Close();
                return receiveResult.Buffer;
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                _listener.Close();
            }
            return new byte[] { };
        }

        public string Message()
        {
            return "Waiting for broadcast/ UDP";
        }

        public void Dispose()
        {
            _listener = null;
        }
    }
}