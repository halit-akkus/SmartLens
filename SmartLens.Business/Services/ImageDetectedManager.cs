using SmartLens.Business.Abstract;
using SmartLens.Business.Validator;
using SmartLens.DataAccess.Services.Api;
using SmartLens.Entities.Results;
using System;
using System.Collections.Generic;
using System.Text;
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
            if (result==null||result.client == null)
            {
                var error = new ErrorResult();
                error.AddMessage("notNull","Veri boş.");
                return new ErrorResult();
            }

            return new SuccessResult();
        }
        public Task SendResult(IResult result)
        {
            return _imageDetectedService.SendResult(result);
        }
    }
}
