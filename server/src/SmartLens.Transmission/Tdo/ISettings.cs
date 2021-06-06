using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartLens.Transmission.Tdo
{
    public interface ISettings
    {
        /// <summary>
        /// Görüntü tespiti için, bağlantı kurulacak port numarası.
        /// </summary>
        public int frontServerPort { get; set; }

        /// <summary>
        /// Dağıtık sunucuda işlenen görüntülerin geri dönüş 
        /// yapacağı ve sunucu üzerinde açılmış olan port numarası.
        /// </summary>
        public int serviceServerPort { get; set; }

        /// <summary>
        /// Varsayılan port protokol(UDP/TCP VS.).
        /// </summary>
        public string defaultProtocol { get; set; }

        /// <summary>
        /// Ayarlar dosyasını okumak için belirtilmiş yordam.
        /// </summary>
        /// <returns></returns>
        public  Task<string> getJson();
    }
}
