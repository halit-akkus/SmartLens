using SmartLens.Business.Abstract.Listener;
using SuperWebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartLens.Business.Concrete.Listener
{
   public class WebSocketListener : IListener
    {
        private  WebSocketServer _WsServer;
        private int _Port;
        private byte[] _Data;
        private bool signal = false;
        public WebSocketListener(int Port)
        {
            _WsServer = new WebSocketServer();
            _Port = Port;
            _WsServer.Setup(_Port);
            _WsServer.NewSessionConnected += _WsServer_NewSessionConnected;
            _WsServer.SessionClosed += _WsServer_SessionClosed;
            _WsServer.NewDataReceived += _WsServer_NewDataReceived;
            _WsServer.NewMessageReceived += _WsServer_NewMessageReceived;
            _WsServer.Start();
        }

        private void _WsServer_NewMessageReceived(WebSocketSession session, string value)
        {
            session.Send("aaa");
        }

        private  void _WsServer_NewDataReceived(WebSocketSession session, byte[] value)
        {
            _Data = value;
            signal = true;
            session.Send("aaa");
        }
        private void _WsServer_SessionClosed(WebSocketSession session, SuperSocket.SocketBase.CloseReason value)
        {
        }
        private void _WsServer_NewSessionConnected(WebSocketSession session)
        {
        }
        public async Task<byte[]> StartListener()
        {
            while (!signal)
                await Task.Delay(1);
            
            signal = false;
            return _Data;
        }

        public string Message()
        {
            throw new NotImplementedException();
        }
    }
}
