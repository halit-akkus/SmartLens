using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SmartLens.Transmission.Tdo
{
    public class Settings : ISettings
    {

        public int FrontServerPort { get; set; }

        public int ServiceServerPort { get; set; }

        public string DefaultProtocol { get; set; }

        public async Task<string> GetJson()
        {
            var filePath = "Settings.json";

            using (StreamReader sr = new StreamReader(filePath, Encoding.UTF7))
            {
                string readText = await sr.ReadToEndAsync();
                return readText;
            }
        }
    }
}
