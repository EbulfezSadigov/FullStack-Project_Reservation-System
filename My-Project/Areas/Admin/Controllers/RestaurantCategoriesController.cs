using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using My_Project.DAL;
using My_Project.Models;

namespace My_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RestaurantCategoriesController : Controller
    {
        private readonly AppDbContext _context;

        public RestaurantCategoriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/RestaurantCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.RestaurantCategories.ToListAsync());
        }

        // GET: Admin/RestaurantCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurantCategory = await _context.RestaurantCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restaurantCategory == null)
            {
                return NotFound();
            }

            return View(restaurantCategory);
        }

        // GET: Admin/RestaurantCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/RestaurantCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id")] RestaurantCategory restaurantCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(restaurantCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(restaurantCategory);
        }

        // GET: Admin/RestaurantCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurantCategory = await _context.RestaurantCategories.FindAsync(id);
            if (restaurantCategory == null)
            {
                return NotFound();
            }
            return View(restaurantCategory);
        }

        // POST: Admin/RestaurantCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id")] RestaurantCategory restaurantCategory)
        {
            if (id != restaurantCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(restaurantCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestaurantCategoryExists(restaurantCategory.Id))
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
            return View(restaurantCategory);
        }

        // GET: Admin/RestaurantCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurantCategory = await _context.RestaurantCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restaurantCategory == null)
            {
                return NotFound();
            }

            return View(restaurantCategory);
        }

        // POST: Admin/RestaurantCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var restaurantCategory = await _context.RestaurantCategories.FindAsync(id);
            _context.RestaurantCategories.Remove(restaurantCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RestaurantCategoryExists(int id)
        {
            return _context.RestaurantCategories.Any(e => e.Id == id);
        }
    }
}
