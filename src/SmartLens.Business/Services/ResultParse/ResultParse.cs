using Newtonsoft.Json;
using System.Text;

namespace SmartLens.Business.Services
{
    public static class ResultParse<T>
    {
        public static T jsonDeserialize(byte[] streamData)
        {
            var streamDataString = Encoding.ASCII.GetString(streamData);
            var StreamData = JsonConvert.DeserializeObject<T>(streamDataString);
            return StreamData;
        }

        public static string jsonSerialize(T obj)
        {
            var StreamData = JsonConvert.SerializeObject(obj);
            return StreamData;
        }
    }
}
