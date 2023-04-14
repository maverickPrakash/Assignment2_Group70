using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
       

        private BidSiteContext _BidSiteContext { get; set; }
        private readonly IWebHostEnvironment _hostingEnvironment;
        public AdminController(BidSiteContext cont, IWebHostEnvironment hostEnvironment)
        {

            _BidSiteContext = cont;
            this._hostingEnvironment = hostEnvironment;
        }
        
        public ActionResult Index()
        {
            return View(_BidSiteContext.Products.Include(c => c.Category).ToList());
        }
        public IActionResult bidder()
        {
            return View(_BidSiteContext.Bids.Include(c => c.Product));
        }


        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var item = _BidSiteContext.Products.Find(id);
            return View(item);
        }
        [HttpPost]
        public IActionResult Delete(Product p)
        {

            _BidSiteContext.Products.Remove(p);
            _BidSiteContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult SiteUsers() {
            ViewBag.users = _BidSiteContext.Users.Select(c=> new { c.UserName, c.Email });
            
            return View();
        }

        public IActionResult Review()
        {
            return View(_BidSiteContext.Reviews.ToList());
        }





    }
}
