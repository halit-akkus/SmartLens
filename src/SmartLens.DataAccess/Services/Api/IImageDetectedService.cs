using SmartLens.Entities.Results;
using SmartLens.Listener.Abstract;
using System.Net;
using System.Threading.Tasks;
namespace SmartLens.DataAccess.Services.Api
{
    public interface IImageDetectedService
    {
        Task SendResult(byte[] data);
        Task<byte[]> ReceiveResult(IListener listener);
    }
}
