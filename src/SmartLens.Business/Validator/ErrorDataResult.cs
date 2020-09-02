using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLens.Business.Validator
{
    class ErrorDataResult<T>:IDataResult<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public List<ResultMessage> Messages { get; set; }

        public ErrorDataResult()
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
