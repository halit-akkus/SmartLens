using SmartLens.Business.Abstract;
using SmartLens.Business.Concrete;
using SmartLens.Client;
using SmartLens.Listener.Abstract;
using SmartLens.Transmission.Concrate;
using SmartLens.Transmission.Services;
using SmartLens.WinFormUI;
using System;
using System.Runtime.InteropServices;
using System.Threading;
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
        private static ResponseClient _client;
        static void Main(string[] args)
        {
            
            int port = args.Length > 0 && args.Length<65536? int.Parse(args[0]) : 11000;
            string protocol = args.Length > 1 ? args[1] : "Udp";

            Console.WriteLine("Server => Running :)");
            Console.WriteLine("-------------------");
            Console.WriteLine($"Protochol =>{protocol} ");
            Console.WriteLine("-------------------");
            Console.WriteLine($"Port Number =>{port}");

            IListener listener = new ServerFactory(port).CreateListener(protocol);
            IClient client = new ClientFactory(port).CreateClient(protocol);

            var startListener = new Thread(delegate ()
            {
                _server = new Server(_detectedManager);
                _server.ServerStarted(listener);
            });

            var startClient = new Thread(delegate ()
            {
                _client = new ResponseClient(_detectedManager, client);
                _client.ServerStarted(listener);
            });

            startListener.Start();
            startClient.Start();
           
            AllocConsole();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Intervall._form1 = new Form1());
        }
    }
}
