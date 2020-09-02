using SmartLens.Entities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLens.Business.Validator
{
    public interface IDataResult<T>:IImageResult
    {
        T Data { get; set; }
    }
}
