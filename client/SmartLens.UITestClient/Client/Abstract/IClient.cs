using System.Threading.Tasks;

namespace SmartLens.UITransmissionTestClient
{
   public interface IClient
    {
        Task<byte[]> SendData  (IStream result);
    }
}
