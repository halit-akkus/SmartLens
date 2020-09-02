using SmartLens.Business.Validator;
using SmartLens.Entities.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartLens.Business.Abstract
{
    public interface IImageDetectedManager
    {
        IImageResult ResultValidator(IResult result);
        Task SendResult(IResult result);
    }
}
