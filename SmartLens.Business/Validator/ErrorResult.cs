using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLens.Business.Validator
{
    public class ErrorResult:IImageResult
    {
        public bool IsSuccess { get; set; }
        public List<ResultMessage> Messages { get; set; }

        public ErrorResult()
        {
            IsSuccess = false;
            Messages = new List<ResultMessage>();
        }
            
        public void AddMessage(string key, string message)
        {
            Messages.Add(new ResultMessage(key, message));
        }
    }
}
