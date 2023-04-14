using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp1.Data;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class SearchController : Controller
    {
        private readonly BidSiteContext _context;

        public SearchController(BidSiteContext context)
        {
            _context = context;
        }

        // GET: Search
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        // GET: Search/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.Include(c => c.Category).Include(c=>c.AspNetUsers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
             
            }
           

            return View(product);
        }

        // GET: Search/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: Search/Queue
        public IActionResult Queue()
        {
            return View();
        }


        //POST : Search QueueResult
        public async Task<IActionResult> QueueResult(String item)
        {
            if (item != null)
            {
                ViewBag.Item = item;
                return View("Index", await _context.Products.Where(j => j.Name.Contains(item) || j.Description.Contains(item) || j.Category.CategoryName.Contains(item)).OrderBy(e => e.Name).ToListAsync());
            }
            else
            {
                ViewBag.Item = item;
                return View("Index", await _context.Products.ToListAsync());
            }

        }


        //SORTING TABLE IN QUEUERESULT
        public async Task<IActionResult> QueueResultSort(String item, String field, String order)
        {
            ViewBag.Item = item;
            ViewBag.Order = order;

            if (item == "" || item == null)
            {
                switch (order)
                {
                    case "DESC":
                        switch (field)
                        {
                            case "Name":
                                return View("Index", await _context.Products.OrderBy(e => e.Name).ToListAsync());

                            case "Cost":
                                return View("Index", await _context.Products.OrderBy(e => e.Cost).ToListAsync());

                            case "Category":
                                return View("Index", await _context.Products.OrderBy(e => e.Category.CategoryName).ToListAsync());

                            default:
                                return View("Index", await _context.Products.ToListAsync());
                        }
                    case "ASC":
                        switch (field)
                        {
                            case "Name":
                                return View("Index", await _context.Products.OrderBy(e => e.Name).ToListAsync());

                            case "Cost":
                                return View("Index", await _context.Products.OrderByDescending(e => e.Cost).ToListAsync());

                            default:
                                return View("Index", await _context.Products.ToListAsync());
                        }

                }

            }

            switch (order)
            {
                case "DESC":
                    switch (field)
                    {
                        case "Name":
                            return View("Index", await _context.Products.Where(j => j.Name.Contains(item) || j.Description.Contains(item) || j.Category.CategoryName.Contains(item)).OrderBy(e => e.Name).ToListAsync());

                        case "Cost":
                            return View("Index", await _context.Products.Where(j => j.Name.Contains(item) || j.Description.Contains(item) || j.Category.CategoryName.Contains(item)).OrderBy(e => e.Cost).ToListAsync());

                        case "Category":
                            return View("Index", await _context.Products.Where(j => j.Name.Contains(item) || j.Description.Contains(item) || j.Category.CategoryName.Contains(item)).OrderBy(e => e.Category).ToListAsync());
                        default:
                            return View("Index", await _context.Products.ToListAsync());

                    }
                case "ASC":
                    switch (field)
                    {
                        case "Name":
                            return View("Index", await _context.Products.Where(j => j.Name.Contains(item) || j.Description.Contains(item) || j.Category.CategoryName.Contains(item)).OrderByDescending(e => e.Name).ToListAsync());

                        case "Cost":
                            return View("Index", await _context.Products.Where(j => j.Name.Contains(item) || j.Description.Contains(item) || j.Category.CategoryName.Contains(item)).OrderByDescending(e => e.Cost).ToListAsync());

                        case "Category":
                            return View("Index", await _context.Products.Where(j => j.Name.Contains(item) || j.Description.Contains(item) || j.Category.CategoryName.Contains(item)).OrderByDescending(e => e.Category).ToListAsync());
                        default:
                            return View("Index", await _context.Products.ToListAsync());

                    }
                default:
                    return View("Index", await _context.Products.ToListAsync());

            }





        }

        public IActionResult Search(string? value)
        {

            ViewBag.category = _context.Categories;

            var item = _context.Products.Include(x => x.Category).Where(c => c.Name.Contains(value) || c.Description.Contains(value));
            return View("index",item);
        }
        [HttpPost]
        public IActionResult Search(string? value, string? costNameSort, int? categorySort, int? Status)
        {
            ViewBag.cate = Status;
            ViewBag.category = _context.Categories;
            if (Status == 0)
            {
                if (categorySort == 0)
                {

                    if (costNameSort == "1")
                    {
                        var item = _context.Products.Include(x => x.Category).Where(c => c.Name.Contains(value) || c.Description.Contains(value)).OrderBy(c => c.Name).ToList();
                        return View("index", item);
                    }
                    else if (costNameSort == "2")
                    {
                        var item = _context.Products.Include(x => x.Category).Where(c => c.Name.Contains(value) || c.Description.Contains(value)).OrderByDescending(c => c.Cost).ToList();
                        return View("index", item);
                    }
                    else if (costNameSort == "3")
                    {
                        var item = _context.Products.Include(x => x.Category).Where(c => c.Name.Contains(value) || c.Description.Contains(value)).OrderBy(c => c.Cost).ToList();

                        return View("index", item);
                    }

                }
                else
                {
                    if (costNameSort == "1")
                    {
                        var item = _context.Products.Include(x => x.Category).Where(c => c.CategoryId == categorySort).OrderBy(c => c.Name).ToList();
                        return View("index", item);
                    }
                    else if (costNameSort == "2")
                    {
                        var item = _context.Products.Include(x => x.Category).Where(c => c.CategoryId == categorySort).OrderByDescending(c => c.Cost).ToList();
                        return View("index", item);
                    }
                    else if (costNameSort == "3")
                    {
                        var item = _context.Products.Include(x => x.Category).Where(c => c.CategoryId == categorySort).OrderBy(c => c.Cost).ToList();

                        return View("index", item);
                    }


                }


            }else if (Status == 1)
            {
                if (categorySort == 0)
                {

                    if (costNameSort == "1")
                    {
                        var item = _context.Products.Include(x => x.Category).Where(c => c.Name.Contains(value) && c.status.Contains("open") || c.Description.Contains(value) && c.status.Contains("open")).OrderBy(c => c.Name).ToList();
                        return View("index", item);
                    }
                    else if (costNameSort == "2")
                    {
                        var item = _context.Products.Include(x => x.Category).Where(c => c.Name.Contains(value) && c.status.Contains("open") || c.Description.Contains(value) && c.status.Contains("open")).OrderByDescending(c => c.Cost).ToList();
                        return View("index", item);
                    }
                    else if (costNameSort == "3")
                    {
                        var item = _context.Products.Include(x => x.Category).Where(c => c.Name.Contains(value) && c.status.Contains("open") || c.Description.Contains(value) && c.status.Contains("open")).OrderBy(c => c.Cost).ToList();

                        return View("index", item);
                    }

                }
                else
                {
                    if (costNameSort == "1")
                    {
                        var item = _context.Products.Include(x => x.Category).Where(c => c.CategoryId == categorySort && c.status.Contains("open")).OrderBy(c => c.Name).ToList();
                        return View("index", item);
                    }
                    else if (costNameSort == "2")
                    {
                        var item = _context.Products.Include(x => x.Category).Where(c => c.CategoryId == categorySort && c.status.Contains("open")).OrderByDescending(c => c.Cost).ToList();
                        return View("index", item);
                    }
                    else if (costNameSort == "3")
                    {
                        var item = _context.Products.Include(x => x.Category).Where(c => c.CategoryId == categorySort && c.status.Contains("open")).OrderBy(c => c.Cost).ToList();

                        return View("index", item);
                    }


                }

            }else if (Status == 2)
            {
                if (categorySort == 0)
                {

                    if (costNameSort == "1")
                    {
                        var item = _context.Products.Include(x => x.Category).Where(c => c.Name.Contains(value) && c.status.Contains("sold") || c.Description.Contains(value) && c.status.Contains("sold")).OrderBy(c => c.Name).ToList();
                        return View("index", item);
                    }
                    else if (costNameSort == "2")
                    {
                        var item = _context.Products.Include(x => x.Category).Where(c => c.Name.Contains(value) && c.status.Contains("sold") || c.Description.Contains(value) && c.status.Contains("sold")).OrderByDescending(c => c.Cost).ToList();
                        return View("index", item);
                    }
                    else if (costNameSort == "3")
                    {
                        var item = _context.Products.Include(x => x.Category).Where(c => c.Name.Contains(value) && c.status.Contains("sold") || c.Description.Contains(value) && c.status.Contains("sold")).OrderBy(c => c.Cost).ToList();

                        return View("index", item);
                    }

                }
                else
                {
                    if (costNameSort == "1")
                    {
                        var item = _context.Products.Include(x => x.Category).Where(c => c.CategoryId == categorySort && c.status.Contains("sold")).OrderBy(c => c.Name).ToList();
                        return View("index", item);
                    }
                    else if (costNameSort == "2")
                    {
                        var item = _context.Products.Include(x => x.Category).Where(c => c.CategoryId == categorySort && c.status.Contains("sold")).OrderByDescending(c => c.Cost).ToList();
                        return View("index", item);
                    }
                    else if (costNameSort == "3")
                    {
                        var item = _context.Products.Include(x => x.Category).Where(c => c.CategoryId == categorySort && c.status.Contains("sold")).OrderBy(c => c.Cost).ToList();

                        return View("index", item);
                    }


                }

            }else if (Status == 3)
            {
                if (categorySort == 0)
                {

                    if (costNameSort == "1")
                    {
                        var item = _context.Products.Include(x => x.Category).Where(c => c.Name.Contains(value) && c.status.Contains("close") || c.Description.Contains(value) && c.status.Contains("close")).OrderBy(c => c.Name).ToList();
                        return View("index", item);
                    }
                    else if (costNameSort == "2")
                    {
                        var item = _context.Products.Include(x => x.Category).Where(c => c.Name.Contains(value) && c.status.Contains("close") || c.Description.Contains(value) && c.status.Contains("close")).OrderByDescending(c => c.Cost).ToList();
                        return View("index", item);
                    }
                    else if (costNameSort == "3")
                    {
                        var item = _context.Products.Include(x => x.Category).Where(c => c.Name.Contains(value) && c.status.Contains("close") || c.Description.Contains(value) && c.status.Contains("close")).OrderBy(c => c.Cost).ToList();

                        return View("index", item);
                    }

                }
                else
                {
                    if (costNameSort == "1")
                    {
                        var item = _context.Products.Include(x => x.Category).Where(c => c.CategoryId == categorySort && c.status.Contains("close")).OrderBy(c => c.Name).ToList();
                        return View("index", item);
                    }
                    else if (costNameSort == "2")
                    {
                        var item = _context.Products.Include(x => x.Category).Where(c => c.CategoryId == categorySort && c.status.Contains("close")).OrderByDescending(c => c.Cost).ToList();
                        return View("index", item);
                    }
                    else if (costNameSort == "3")
                    {
                        var item = _context.Products.Include(x => x.Category).Where(c => c.CategoryId == categorySort && c.status.Contains("close")).OrderBy(c => c.Cost).ToList();

                        return View("index", item);
                    }


                }

            }



            return View("index");

        }








        [HttpPost]
        public async Task<IActionResult> IncrementCost(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            double Cost = Convert.ToDouble(product.Cost);
            Bid bid = new Bid();
            bid.Cost = Cost.ToString();
            Cost = Math.Round(Cost +Cost * 0.01,2);
            product.Cost = Cost.ToString();
            _context.Update(product);
            await _context.SaveChangesAsync();

            
            bid.ProductId = product.Id;
            bid.Bidder = User.Identity.Name;
            
            bid.Bidstatus = "Pending";
            _context.Add(bid);
            await _context.SaveChangesAsync();
            TempData["AlertMessage"] = "Bid is added.";

            return RedirectToAction("Details", "Search", new { id = product.Id });

        }


    }


}
