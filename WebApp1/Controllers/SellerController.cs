using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            
            return View(_BidSiteContext.Products.Include(c => c.Category).ToList());
        }
        public IActionResult AddProduct(Product product) {
        _BidSiteContext.Products.Add(product);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult AddItem()
        {
            var product = new Product();
            ViewBag.Categories= _BidSiteContext.Categories.ToList();
            return View(product);
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
    }
}
