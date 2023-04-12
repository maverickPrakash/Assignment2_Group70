using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class BuyerController : Controller
    {
        private BidSiteContext _BidSiteContext { get; set; }
        public BuyerController(BidSiteContext cont)
        {
            _BidSiteContext = cont;

        }
        public IActionResult Index()

        {
           
            return View(_BidSiteContext.Bids.Include(c=>c.Product).Where(c=>c.Bidder.Contains(User.Identity.Name)));

        }
    }
}
