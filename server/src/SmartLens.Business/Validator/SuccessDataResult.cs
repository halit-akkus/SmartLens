using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLens.Business.Validator
{
    class SuccessDataResult<T> : IDataResult<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public List<ResultMessage> Messages { get; set; }

        public SuccessDataResult(T data)
        {
            IsSuccess = true;
            Data = data;
        }

        public void AddMessage(string key, string message)
        {
            if (Messages == null)
            {
                Messages = new List<ResultMessage>();
            }

            Messages.Add(new ResultMessage(key, message));
        }
    }
}
