

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
       
        
        static  void Main(string[] args)
        {
            new Thread(new ParameterizedThreadStart(Server.ServerStarted)).Start(args);

            AllocConsole();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Intervall._form1=new Form1());
        }
    }
}
