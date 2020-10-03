using Autofac;
using Microsoft.Extensions.DependencyInjection;
using SmartLens.Business.Abstract;
using SmartLens.Business.Concrete;
using SmartLens.Client;
using SmartLens.Listener.Abstract;
using SmartLens.Transmission.Abstract;
using SmartLens.Transmission.Concrate;
using SmartLens.Transmission.DependencyModules.Autofac;
using SmartLens.Transmission.Services;
using SmartLens.WinFormUI;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace SmartLens.Transmission
{
    public  class Program
    {
        private static IServer _server;
        private static IResponseClient _client;
    
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
       
        static void Main(string[] args)
        {
            var serviceProvider = ContainerConfiguration.Configure();
            _client = serviceProvider.Resolve<IResponseClient>();
            _server = serviceProvider.Resolve<IServer>();

            int port = args.Length > 0 && args.Length<65536? int.Parse(args[0]) : 11000;
            string protocol = args.Length > 1 ? args[1] : "Udp";

            Console.WriteLine("Server => Running :)");
            Console.WriteLine("-------------------");
            Console.WriteLine($"Protochol =>{protocol} ");
            Console.WriteLine("-------------------");
            Console.WriteLine($"Port Number =>{port}");

            IListener listener = new ServerFactory(port).CreateListener(protocol);


            var startListener = new Thread(delegate ()
            {
                _server.ServerStarted(listener);
            });
            startListener.Start();

            
            IClient client = new ClientFactory(port).CreateClient(protocol);
             
              var startClient = new Thread(delegate ()
             {
                 _client.ServerStarted(listener);
             });
             //startClient.Start();
             


            AllocConsole();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Intervall._form1 = new Form1());
        }
    }
}
