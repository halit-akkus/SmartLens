using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SmartLens.UIWebMvc.Models;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace SmartLens.UIWebMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;

        public HomeController()
        {
            _httpClient = new HttpClient();

            _httpClient.BaseAddress = new Uri("https://localhost:44316");
        }

        public IActionResult Index()
        {
            return View();
        }
     
        private string Base64Parse(string base64)
        {
            if (string.IsNullOrEmpty(base64)) return base64;

            int indexNumber = base64.IndexOf(',');

            if (indexNumber > 0)
            {
                ++indexNumber;
                return base64.Substring(indexNumber, base64.Length - indexNumber);
            }
            return base64;
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync([FromBody] ImageDetect imageDetect)
        {
            imageDetect.imageBase64 = Base64Parse(imageDetect.imageBase64);

            var loginDataAsJson = JsonConvert.SerializeObject(imageDetect);

            var stringContent = new StringContent(loginDataAsJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/ImageDetected/Detected", stringContent);

            var responseValueAsString = await response.Content.ReadAsStringAsync();

            return Ok(responseValueAsString);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
