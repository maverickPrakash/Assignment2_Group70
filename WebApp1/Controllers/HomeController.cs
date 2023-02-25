using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BidSiteContext _BidSiteContext { get; set; }
        public HomeController(ILogger<HomeController> logger, BidSiteContext cont)
        {
            _logger = logger;
            _BidSiteContext = cont;
        }

        
        
        public IActionResult Index()
        {

            return View(_BidSiteContext.Products.OrderByDescending(c=> c.Id).Take(8).ToList());
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