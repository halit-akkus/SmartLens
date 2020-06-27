using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartLens.Client;
using static System.Net.Mime.MediaTypeNames;

namespace SmartLens.UICOREMVCClient.Controllers
{
    public class HomeController : Controller
    {
        IClient _Client { get; set; }
        public HomeController(IClient client)
        {
            _Client = client;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SetFrame()
        {
            return View();
        }

        public void CaptureImg(byte[] buffer)
        {
            _Client.SendBuffer(buffer);
        }
    }
}
