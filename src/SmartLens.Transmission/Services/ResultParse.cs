using Newtonsoft.Json;
using SmartLens.Entities.Concrate;
using SmartLens.Entities.Results;
using System;
using System.Text;

namespace SmartLens.Transmission.Services
{
    public static class ResultParse
    {
        static StreamData  jsonDeserialize(byte[] streamData)
        {
            var streamDataString = Encoding.ASCII.GetString(streamData);
            var StreamData = JsonConvert.DeserializeObject<StreamData>(streamDataString);
            return StreamData;
        }

        [STAThread]
        public static StreamData GetImage(IResult result)
        {
            var streamData = jsonDeserialize(result.receiveData);
            return streamData;
        }
        [STAThread]
        public static Guid GetUserId(IResult result)
        {
            var streamData = jsonDeserialize(result.receiveData);
            return streamData.UserId;
        }
    }
}
