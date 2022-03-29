using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using SmartLens.Client;
using SmartLens.WebApi.Models.CustomModels.Request;

namespace SmartLens.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageDetectedController : ControllerBase
    {

        private readonly IClient _client;

        private readonly 

        private const int Port = 11000;

        private const string Ip = "127.0.0.1";

        public ImageDetectedController(IClient client)
        {
            _client = client;
        }

        [HttpPost]
        [Route("Detected")]
        public async Task<IActionResult> Detected([FromBody] ImageDetect imageDetect)
        {
            var ipEndPoint = new IPEndPoint(IPAddress.Parse(Ip), Port);

            var result = await _client.SendData(ipEndPoint, imageDetect.imageBase64);

            var encodingToString = Encoding.UTF7.GetString(result);

            return Ok(encodingToString);
        }
    }
}
