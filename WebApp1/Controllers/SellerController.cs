using Microsoft.AspNetCore.Mvc;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class SellerController : Controller
    {
        private BidSiteContext _BidSiteContext { get; set; }
        public SellerController(BidSiteContext cont)
        {
            _BidSiteContext=cont;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddItem()
            
        {
            var category = _BidSiteContext.Categories.ToList();
            return View(category);
        }
    }
}
