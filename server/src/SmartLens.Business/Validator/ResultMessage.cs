namespace SmartLens.Business.Validator
{
    public class ResultMessage
    {
        public string Key { get; set; }
        public string Message { get; set; }

        public ResultMessage(string key, string message)
        {
            Key = key;
            Message = message;
        }
    }
}