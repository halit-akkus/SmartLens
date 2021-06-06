using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SmartLens.Transmission.Tdo
{
    public class Settings : ISettings
    {

        public int frontServerPort { get; set; }

        public int serviceServerPort { get; set; }

        public string defaultProtocol { get; set; }

        public async Task<string> getJson()
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
