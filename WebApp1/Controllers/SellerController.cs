using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp1.Models;
using System.IO;
using System.Web;
using Microsoft.IdentityModel;
using Microsoft.AspNetCore.Server;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNet.Identity;

namespace WebApp1.Controllers
{
    [Authorize(Roles = "Seller")]
    public class SellerController : Controller
    {


        private readonly IWebHostEnvironment _hostingEnvironment;


        private BidSiteContext _BidSiteContext { get; set; }
        public SellerController(BidSiteContext cont, IWebHostEnvironment hostEnvironment)
        {
            _BidSiteContext = cont;
            this._hostingEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View(_BidSiteContext.Products.Include(c => c.Category).ToList().Where(c => c.Username.Contains(User.Identity.GetUserId())));
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            ViewBag.userId = User.Identity.GetUserId();

           
                
                //Save image to wwwroot/image
                string wwwRootPath = _hostingEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                string extension = Path.GetExtension(product.ImageFile.FileName);
                product.Username = User.Identity.GetUserId();
                product.Image = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Images/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await product.ImageFile.CopyToAsync(fileStream);
                }
                //Insert record
                _BidSiteContext.Add(product);
                await _BidSiteContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            
        }

        public IActionResult AddItem()
        {
            var product = new Product();
            ViewBag.Categories = _BidSiteContext.Categories.ToList();
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

        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _BidSiteContext.Categories.ToList();
            var item = _BidSiteContext.Products.Find(id);
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> editData(Product product)
        {
            //Save image to wwwroot/image
            string wwwRootPath = _hostingEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
            string extension = Path.GetExtension(product.ImageFile.FileName);
            product.Username = User.Identity.GetUserId();
            product.Image = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/Images/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await product.ImageFile.CopyToAsync(fileStream);
            }
            //Update record
            _BidSiteContext.Products.Update(product);
             _BidSiteContext.SaveChanges();
            return RedirectToAction(nameof(Index));

           
        }

    }
}
