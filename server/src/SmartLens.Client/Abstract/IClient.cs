using SmartLens.Entities.Results;
using System.Net;
using System.Threading.Tasks;

namespace SmartLens.Client
{
   public interface IClient
    {
        Task SendData
            (IPEndPoint ipEndPoint, byte[] data);
    }
}
