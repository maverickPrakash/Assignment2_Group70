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

        public IActionResult payment(int Cost, int productID, int bid )
        {
            Payment pay = new Payment();
            ViewBag.Products = _BidSiteContext.Products.Where(c=>c.Id.Equals(productID)).ToList();
            ViewBag.Cost = Cost;
            ViewBag.bid = bid;
            return View(pay);
        }
        public IActionResult comPay(Payment pay)
        {
            
            var bid = _BidSiteContext.Bids.Find(pay.BidId);
            bid.Bidstatus = "Completed";
            _BidSiteContext.Update(bid);
            _BidSiteContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult review(int product, string Seller, int bid)
        {
            Review review = new Review();
            ViewBag.Products = _BidSiteContext.Products.Where(c => c.Id.Equals(product)).ToList();
            ViewBag.ProductId = product;
            ViewBag.SellerName = _BidSiteContext.Products.Where(c => c.Id.Equals(product)).Select(c=>c.AspNetUsers.UserName).FirstOrDefault();
            ViewBag.bid = bid;
            ViewBag.Seller = Seller;
            return View(review);
        }

        public IActionResult addReview(Review review)
        {
            var bid = _BidSiteContext.Bids.Find(review.BidId);
            bid.Bidstatus = "Reviewed";
            _BidSiteContext.Update(bid);
            _BidSiteContext.Add(review);
            _BidSiteContext.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
