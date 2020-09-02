using SmartLens.Business.Abstract;
using SmartLens.Listener.Abstract;
using SmartLens.Transmission.Concrate;
using SmartLens.WinFormUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace SmartLens.Transmission
{
    public static class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        private static IImageDetectedManager _detectedManager;
        private static Server _server;
        static void Main(string[] args)
        {

            int port = args.Length > 0 ? int.Parse(args[0]) : 11000;
            string protocol = args.Length > 1 ? args[1] : "Udp";
            Console.WriteLine("Server => Running :)");
            Console.WriteLine("-------------------");
            Console.WriteLine($"Protochol =>{protocol} ");
            Console.WriteLine("-------------------");
            Console.WriteLine($"Port Number =>{port}");
            IListener listener =new ServerFactory(port).CreateListener(protocol);
            var startListener = new Thread(delegate ()
            {
                _server = new Server(_detectedManager);
                _server.ServerStarted(listener);
            });
            startListener.Start();
            AllocConsole();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Intervall._form1 = new Form1());
        }
    }
}
