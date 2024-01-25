using appconfigmvc02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.FeatureManagement.Mvc;
using System.Diagnostics;

namespace appconfigmvc02.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        public Settings Settings { get; set; }
        public HomeController(ILogger<HomeController> logger,IConfiguration configuration, IOptionsSnapshot<Settings> options)
        {
            _logger = logger;
            _configuration = configuration;
            Settings = options.Value;
        }

        public IActionResult Index()
        {
            string configValue = _configuration["test"];
           
            return View(Settings);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [FeatureGate("Beta")]
        public IActionResult BetaPage()
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