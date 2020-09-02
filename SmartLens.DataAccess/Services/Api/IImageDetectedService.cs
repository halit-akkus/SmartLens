using SmartLens.Entities.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace SmartLens.DataAccess.Services.Api
{
    public interface IImageDetectedService
    {
        Task SendResult(IResult result);
    }
}
