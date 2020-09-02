using SmartLens.Entities.Results;
using SmartLens.Listener.Abstract;
using System.Threading.Tasks;
namespace SmartLens.DataAccess.Services.Api
{
    public interface IImageDetectedService
    {
        Task SendResult(IResult result);
        Task<IResult> ReceiveResult(IListener listener);
    }
}
