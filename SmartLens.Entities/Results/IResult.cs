using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLens.Entities.Results
{
    public interface IResult
    {
        byte[] receiveData { get; set; }
        Client client { get; set; }
    }
}
