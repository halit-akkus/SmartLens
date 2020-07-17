

using SmartLens.Business.Abstract.Listener;
using SmartLens.Business.Concrete.Listener;
using SmartLens.Transmission.Concrate;
using SmartLens.WinFormUI;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace SmartLens.Transmission
{
 public static  class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        private static int _port;
        
        static  void Main(string[] args)
        {
            string[] obj = (string[])args;
            _port = args.Length > 0 ? int.Parse(args[0]) : 11000;
            /*--------------------------------------------------------*/
            var serverFact = new ServerFactory();
            IListener listener = serverFact.CreateListener(Standart.ListenerType.Udp,_port);
           
            var startListener = new Thread(delegate() {
                Server.ServerStarted(_port, listener);
            });
            startListener.Start();

            AllocConsole();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Intervall._form1=new Form1());
        }
    }
}
