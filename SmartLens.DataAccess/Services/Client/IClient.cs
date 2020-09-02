using SmartLens.Entities.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartLens.DataAccess.Services.Client
{
    interface IClient
    {
        Task SendData(IResult result);
    }
}
