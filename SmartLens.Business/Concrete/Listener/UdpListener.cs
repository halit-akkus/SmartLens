using SmartLens.Business.Abstract.Listener;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SmartLens.Business.Concrete.Listener
{
    public class UdpListener : IListener
    {
        UdpClient _listener { get; set; }
        IPEndPoint _groupEP { get; set; }
        public UdpListener(UdpClient udpClient, IPEndPoint ıPEndPoint)
        {
            _listener = udpClient;
            _groupEP = ıPEndPoint;
        }
        public async Task<byte[]> StartListener()
        {
            try
            {
                Console.WriteLine("Waiting for broadcast");
                var bytes = await _listener.ReceiveAsync();
                return bytes.Buffer;
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
    }
}