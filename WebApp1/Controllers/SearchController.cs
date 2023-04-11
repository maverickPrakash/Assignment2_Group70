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



   
        
      

       
        [HttpPost]
        public async Task<IActionResult> IncrementCost(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            double Cost = Convert.ToDouble(product.Cost);
            Cost = Math.Round(Cost +Cost * 0.01,2);
            product.Cost = Cost.ToString();
            _context.Update(product);
            await _context.SaveChangesAsync();

            Bid bid = new Bid();
            bid.ProductId = product.Id;
            bid.Bidder = User.Identity.Name;
            bid.Cost =Cost;
            bid.Bidstatus = "Pending";
            _context.Add(bid);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "Search", new { id = product.Id });

        }


    }


}
