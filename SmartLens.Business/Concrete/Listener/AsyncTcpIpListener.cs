using SmartLens.Business.Abstract.Listener;
using System;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

public class AsyncTcpServer : IDisposable,IListener
{
    private static TcpListener _listener;
    private static AsyncTcpServer _asyncTcpServer;
    public static AsyncTcpServer currentTcpServer(int port)
    {
        if (_asyncTcpServer == null)
        {
            _asyncTcpServer = new AsyncTcpServer();
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
        return "Waiting for TCP";
    }

    public async Task<byte[]> StartListener()
    {
        try
        {
            var receiveResult = await _listener.AcceptTcpClientAsync();
            var myNetworkStream = receiveResult.GetStream();

            if (myNetworkStream.CanRead)
            {
                byte[] myReadBuffer = new byte[2];
                myNetworkStream.Read(myReadBuffer, 0, myReadBuffer.Length);
                return myReadBuffer;
            }
        }
        catch (SocketException e)
        {
            Console.WriteLine(e);
        }
        return new byte[] { };
    }




}