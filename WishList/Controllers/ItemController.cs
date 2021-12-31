using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Item> items = new List<Item>();

            foreach (var item in _context.Items)
            {    
                items.Add(item);
            }
            

            return View("Index",items);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Item toBeDeleted = null;
            
            foreach (var item in _context.Items)
            {
                if(item.Id == id)
                {
                    toBeDeleted = item;
                }
            }
            _context.Items.Remove(toBeDeleted);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
