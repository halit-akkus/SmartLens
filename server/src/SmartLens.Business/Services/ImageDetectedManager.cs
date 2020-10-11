using SmartLens.Business.Validator;
using SmartLens.DataAccess.Services.Api;
using SmartLens.Entities.Models;
using SmartLens.Entities.Results;
using SmartLens.Listener.Abstract;
using System.Text;
using System.Threading.Tasks;

namespace SmartLens.Business.Services
{
    public class ImageDetectedManager : IImageDetectedManager
    {
        private IImageDetectedService _imageDetectedService;
        public ImageDetectedManager(IImageDetectedService imageDetectedService)
        {
            _imageDetectedService = imageDetectedService;
        }

        public IImageResult ResultValidator(Stream result)
        {
            if (result==null)
            {
                var error = new ErrorResult();
                error.AddMessage("notNull","Veri boş veya geçersiz.");
                return new ErrorResult();
            }

            return new SuccessResult();
        }
        public Task SendResult(Stream stream)
        {
            var getStreamToString = ResultParse<Stream>.jsonSerialize(stream);

            var getBytes = Encoding.ASCII.GetBytes(getStreamToString);
            return _imageDetectedService.SendResult(getBytes);
        }

        public async Task<IDataResult<ResponseStream>> ReceiveResult(IListener listen,int port)
        {
            
              var checkReceive = await _imageDetectedService.ReceiveResult(listen, port);

             var errorDataResult = new ErrorDataResult<ResponseStream>();
             if (listen == null)
             {
                 errorDataResult.AddMessage("InvalidParameters", "Nesnenin örneği oluşturulmamış.");
                 return errorDataResult;
             }
            if (checkReceive.Length==0)
            {
                errorDataResult.AddMessage("InvalidLength","Geçersiz veri.");
                return errorDataResult;
            }

            var stream = ResultParse<ResponseStream>.jsonDeserialize(checkReceive);
            
             return new SuccessDataResult<ResponseStream>(stream);
             
        }
    }
}
