using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp1.Models;
using System.IO;
using System.Web;

using Microsoft.AspNetCore.Server;

namespace WebApp1.Controllers
{
    
    public class SellerController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private BidSiteContext _BidSiteContext { get; set; }
        public SellerController(BidSiteContext cont)
        {
            _BidSiteContext=cont;
        }
        public IActionResult Index()
        {
            
            return View(_BidSiteContext.Products.Include(c => c.Category).ToList());
        }
        [HttpPost]
        public IActionResult AddProduct(Product product) {
            string filename = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
            string extension = Path.GetExtension(product.ImageFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            product.Image = "~/Images/" + filename;
            filename = Path.Combine(Server.MapPath("~/Images/"), filename);
            product.ImageFile.SaveAs(filename);
            ViewBag.Product = product;
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
