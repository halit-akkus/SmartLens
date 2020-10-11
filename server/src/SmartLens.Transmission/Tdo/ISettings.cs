using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartLens.Transmission.Tdo
{
    public interface ISettings
    {
        public int frontServerPort { get; set; }
        public int serviceServerPort { get; set; }
        public string defaultProtocol { get; set; }
        public  Task<string> getJson();
    }
}
