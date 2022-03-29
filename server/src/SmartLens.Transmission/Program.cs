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
using System.Threading.Tasks;
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
            IContainer serviceProvider = ContainerConfiguration.Configure();

            _client = serviceProvider.Resolve<IResponseClient>();
            _server = serviceProvider.Resolve<IServer>();
            _settings = serviceProvider.Resolve<ISettings>();

            Task<string> getJson = _settings.GetJson();

            Console.WriteLine($"Settings: {getJson.Result}");

             _settings = JsonConvert.DeserializeObject<Settings>(getJson.Result);

            int port = args.Length > 0 ? int.Parse(args[0]) : _settings.FrontServerPort;

            string protocol = args.Length > 1 ? args[1] : _settings.DefaultProtocol;

            Console.WriteLine("Server => Running :)");
            Console.WriteLine("-------------------");
            Console.WriteLine($"Protocol =>{protocol} ");
            Console.WriteLine("-------------------");
            Console.WriteLine($"Port Number =>{port}");

            IListener listener = new ServerFactory(port).CreateListener(protocol);

            Thread startListener = new Thread(delegate ()
            {
                _server.ServerStarted(listener);
            });

            startListener.Start();

            Thread startClient = new Thread(delegate ()
             {
                 _client.ServerStarted(listener,_settings.ServiceServerPort);
             });

            startClient.Start();
             
            AllocConsole();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Intervall._form1 = new Form1());
        }
    }
}
