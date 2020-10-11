using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLens.Business.Validator
{
    public interface IImageResult
    {
        bool IsSuccess { get; set; }
        List<ResultMessage> Messages { get; set; }
    }
}
