using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HelloWorld.Models;
using System.Fabric;

namespace HelloWorld.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            
            var osNameAndVersion = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
            ViewData["osver"] = osNameAndVersion.ToString();
            var nodeName = FabricRuntime.GetNodeContext().NodeName.ToString();
            ViewData["nodeName"] = nodeName.ToString();

            ViewData["timeNow"] = System.DateTime.Now.ToUniversalTime().ToString();
            return View();
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
