using SmartLens.Business.Abstract;
using SmartLens.Business.Validator;
using SmartLens.DataAccess.Services.Api;
using SmartLens.Entities.Results;
using SmartLens.Listener.Abstract;
using System.Threading.Tasks;

namespace SmartLens.Business.Concrete
{
    public class ImageDetectedManager : IImageDetectedManager
    {
        private IImageDetectedService _imageDetectedService;
        public ImageDetectedManager(IImageDetectedService imageDetectedService)
        {
            _imageDetectedService = imageDetectedService;
        }

        public IImageResult ResultValidator(IResult result)
        {
            if (result==null)
            {
                var error = new ErrorResult();
                error.AddMessage("notNull","Veri boş veya geçersiz.");
                return new ErrorResult();
            }

            return new SuccessResult();
        }
        public Task SendResult(IResult result)
        {
            return _imageDetectedService.SendResult(result);
        }

        public async Task<IDataResult<IResult>> ReceiveResult(IListener listen)
        {
            var checkReceive = await _imageDetectedService.ReceiveResult(listen);
            if (listen == null)
            {
                var errorDataResult = new ErrorDataResult<IResult>();
                errorDataResult.AddMessage("InvalidParameters", "Nesnenin örneği oluşturulmamış.");
                return errorDataResult;
            }

            return new SuccessDataResult<IResult>(checkReceive);
        }
    }
}
