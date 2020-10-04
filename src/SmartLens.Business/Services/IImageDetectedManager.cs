using SmartLens.Business.Validator;
using SmartLens.Entities.Models;
using SmartLens.Entities.Models.Result;
using SmartLens.Entities.Results;
using SmartLens.Listener.Abstract;
using System.Threading.Tasks;

namespace SmartLens.Business.Services
{
    public interface IImageDetectedManager
    {
        IImageResult ResultValidator(Stream stream);
        Task SendResult(Stream stream);
        Task<IDataResult<ResponseStream>> ReceiveResult(IListener listen,int port);
    }
}
