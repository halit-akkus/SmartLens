using SmartLens.Business.Validator;
using SmartLens.Entities.Results;
using SmartLens.Listener.Abstract;
using System.Threading.Tasks;

namespace SmartLens.Business.Abstract
{
    public interface IImageDetectedManager
    {
        IImageResult ResultValidator(IResult result);
        Task SendResult(IResult result);
        Task<IDataResult<IResult>> ReceiveResult(IListener listen);
    }
}
