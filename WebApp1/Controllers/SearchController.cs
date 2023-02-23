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

            var product = await _context.Products
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
                                return View("Index", await _context.Products.OrderBy(e => e.Category).ToListAsync());

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


        // POST: Search/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Cost,Asset_condition,Category,Image")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Search/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Search/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Cost,Asset_condition,Category,Image")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Search/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Search/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Product'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        [HttpPost]
        public async Task<IActionResult> IncrementCost(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            int price = Convert.ToInt32(product.Cost);
            price = price + 1;
            product.Cost = price.ToString();
            _context.Update(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


    }


}
