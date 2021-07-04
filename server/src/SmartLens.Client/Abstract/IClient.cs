using SmartLens.Entities.Results;
using System.Net;
using System.Threading.Tasks;

namespace SmartLens.Client
{
   public interface IClient
    {
        /// <summary>
        /// Byte dizisi türündeki görüntü verisini karşı tarafa yollar.
        /// </summary>
        /// <param name="ipEndPoint"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        Task SendData(IPEndPoint ipEndPoint, byte[] data);
     
        /// <summary>
        /// StringBase64 tipindeki görüntü veririsini karşı tarafa yollar.
        /// </summary>
        /// <param name="ipEndPoint"></param>
        /// <param name="imageByBase64"></param>
        /// <returns></returns>
        Task<byte[]> SendData(IPEndPoint ipEndPoint, string imageByBase64);
    }
}
