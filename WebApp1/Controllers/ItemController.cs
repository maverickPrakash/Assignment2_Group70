using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class ItemController
    {
        private BidSiteContext _BidSiteContext { get; set; }
        public ItemController(BidSiteContext cont)
        {
            _BidSiteContext = cont;
        }
    }
}
