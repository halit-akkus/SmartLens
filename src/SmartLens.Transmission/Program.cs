using Autofac;
using Newtonsoft.Json;
using SmartLens.Listener.Abstract;
using SmartLens.Transmission.Abstract;
using SmartLens.Transmission.Concrate;
using SmartLens.Transmission.DependencyModules.Autofac;
using SmartLens.Transmission.Tdo;
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
        private static ISettings _settings;
    
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
       
        static void Main(string[] args)
        {

            var serviceProvider = ContainerConfiguration.Configure();

            _client = serviceProvider.Resolve<IResponseClient>();
            _server = serviceProvider.Resolve<IServer>();
            _settings = serviceProvider.Resolve<ISettings>();

            var getJson = _settings.getJson();
            Console.WriteLine($"Settings: {getJson.Result}");
             _settings = JsonConvert.DeserializeObject<Settings>(getJson.Result);


            int port = args.Length>0 ? int.Parse(args[0]) : _settings.frontServerPort;

            string protocol = args.Length > 1 ? args[1] : _settings.defaultProtocol;

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

            
             
              var startClient = new Thread(delegate ()
             {
                 _client.ServerStarted(listener,_settings.serviceServerPort);
             });
             startClient.Start();
             


            AllocConsole();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Intervall._form1 = new Form1());
        }
    }
}
