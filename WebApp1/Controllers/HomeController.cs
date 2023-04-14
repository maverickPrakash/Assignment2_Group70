using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult sellerReview(string seller)
            
        {
            ViewBag.Seller = seller;
            return View(_BidSiteContext.Reviews.Where(c => c.sellerUsername.Contains(seller)).ToList());
        }

        public IActionResult Search(string? value)
        {

            ViewBag.category = _BidSiteContext.Categories;

            var item = _BidSiteContext.Products.Include(x => x.Category).Where(c => c.Name.Contains(value) || c.Description.Contains(value));
            return View(item);
        }
        [HttpPost]
        public IActionResult Search(string? value, string? costNameSort, int? categorySort)
        {
            ViewBag.cate = categorySort;
            ViewBag.category = _BidSiteContext.Categories;
            if (categorySort == 0)
            {

                if (costNameSort == "1")
                {
                    var item = _BidSiteContext.Products.Include(x => x.Category).Where(c => c.Name.Contains(value) || c.Description.Contains(value)).OrderBy(c => c.Name).ToList();
                    return View(item);
                }
                else if (costNameSort == "2")
                {
                    var item = _BidSiteContext.Products.Include(x => x.Category).Where(c => c.Name.Contains(value) || c.Description.Contains(value)).OrderByDescending(c => c.Cost).ToList();
                    return View(item);
                }
                else if (costNameSort == "3")
                {
                    var item = _BidSiteContext.Products.Include(x => x.Category).Where(c => c.Name.Contains(value) || c.Description.Contains(value)).OrderBy(c => c.Cost).ToList();

                    return View(item);
                }

            }
            else
            {
                if (costNameSort == "1")
                {
                    var item = _BidSiteContext.Products.Include(x => x.Category).Where(c => c.CategoryId == categorySort).OrderBy(c => c.Name).ToList();
                    return View(item);
                }
                else if (costNameSort == "2")
                {
                    var item = _BidSiteContext.Products.Include(x => x.Category).Where(c => c.CategoryId == categorySort).OrderByDescending(c => c.Cost).ToList();
                    return View(item);
                }
                else if (costNameSort == "3")
                {
                    var item = _BidSiteContext.Products.Include(x => x.Category).Where(c => c.CategoryId == categorySort).OrderBy(c => c.Cost).ToList();

                    return View(item);
                }


            }



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