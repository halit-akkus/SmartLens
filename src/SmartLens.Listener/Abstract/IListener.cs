using SmartLens.Entities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLens.Listener.Abstract
{
    public interface IListener
    {
        Task<IResult> Listen();
        string Message();
    }
}
