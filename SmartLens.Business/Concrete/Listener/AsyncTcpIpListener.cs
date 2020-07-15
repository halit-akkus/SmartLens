using SmartLens.Business.Abstract.Listener;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

public class AsyncTcpServer : IDisposable,IListener
{
    public class DataReceivedEventArgs : EventArgs
    {
        public NetworkStream Stream { get; private set; }

        public DataReceivedEventArgs(NetworkStream stream)
        {
            Stream = stream;
        }
    }

    public event EventHandler<DataReceivedEventArgs> OnDataReceived;

    public AsyncTcpServer(IPAddress address, int port)
    {
        _listener = new TcpListener(address, port);
    }

    

    public void Stop()
    {
        _isListening = false;
        _listener.Stop();
    }

    public void Dispose()
    {
        Stop();
    }

    private IAsyncResult WaitForClientConnection()
    {
      var checkAsyncResult =   _listener.BeginAcceptTcpClient(HandleClientConnection, _listener);

        return checkAsyncResult;
    }

    private void HandleClientConnection(IAsyncResult result)
    {
        if (!_isListening)
        {
            return;
        }

        var server = result.AsyncState as TcpListener;
        var client = _listener.EndAcceptTcpClient(result);

      var checkAsyncResult =  WaitForClientConnection();

        OnDataReceived?.Invoke(this, new DataReceivedEventArgs(client.GetStream()));
    }

    public Task<byte[]> StartListener()
    {
        throw new NotImplementedException();
    }

    public string Message()
    {
        return "Waiting for broadcast/ UDP";
    }

    //public Task<byte[]> StartListener()
    //{
    //    _listener.Start();
    //    _isListening = true;


    //  Task<IAsyncResult>.Run(()=> {
    //      var checkAsyncResult = WaitForClientConnection();

    //  });


    //}

    private readonly TcpListener _listener;
    private volatile bool _isListening = false;
}