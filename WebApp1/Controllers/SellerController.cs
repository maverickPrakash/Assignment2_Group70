using Microsoft.AspNetCore.Mvc;

namespace WebApp1.Controllers
{
    public class SellerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddItem()
        {
            return View();
        }
    }
}
