using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLens.Listener.Abstract.Result
{
   public interface IResult
    {
        byte[] receiveData { get; set; }
        Client client { get; set; }
    }
}
