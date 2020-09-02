using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLens.Entities.Results
{
    public class Result:IResult
    {
      public  byte[] receiveData { get; set; }
      public Client client { get; set; }
    }
}
