using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using My_Project.DAL;
using My_Project.Models;

namespace My_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RestaurantServicesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public RestaurantServicesController(AppDbContext context, IWebHostEnvironment env)
        {
            _env = env;
            _context = context;
        }

        // GET: Admin/RestaurantServices
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.RestaurantServices.Include(r => r.RestaurantCategory);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Admin/RestaurantServices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurantService = await _context.RestaurantServices
                .Include(r => r.RestaurantCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restaurantService == null)
            {
                return NotFound();
            }

            return View(restaurantService);
        }

        // GET: Admin/RestaurantServices/Create
        public IActionResult Create()
        {
            ViewData["RestaurantCategoryId"] = new SelectList(_context.RestaurantCategories, "Id", "Name");
            return View();
        }

        // POST: Admin/RestaurantServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RestaurantService restaurantService)
        {
            if (!restaurantService.Img.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("", "Please upload image");
            }

            if (restaurantService.Img.Length / 1024 > 1000)
            {
                ModelState.AddModelError("", "Image is too large");
            }


            string path = _env.WebRootPath + @"\images\meal";
            string filename = Guid.NewGuid().ToString() + restaurantService.Img.FileName;
            string final = Path.Combine(path, filename);

            using (FileStream fs = new FileStream(final, FileMode.Create))
            {
                await restaurantService.Img.CopyToAsync(fs);
            }

            restaurantService.Image = filename;

            if (ModelState.IsValid)
            {
                _context.Add(restaurantService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RestaurantCategoryId"] = new SelectList(_context.RestaurantCategories, "Id", "Name", restaurantService.RestaurantCategoryId);
            return View(restaurantService);
        }

        // GET: Admin/RestaurantServices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurantService = await _context.RestaurantServices.FindAsync(id);
            if (restaurantService == null)
            {
                return NotFound();
            }
            ViewData["RestaurantCategoryId"] = new SelectList(_context.RestaurantCategories, "Id", "Name", restaurantService.RestaurantCategoryId);
            return View(restaurantService);
        }

        // POST: Admin/RestaurantServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RestaurantService restaurantService)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (id != restaurantService.Id)
            {
                return NotFound();
            }

            if (!restaurantService.Img.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("", "Please upload image");
            }

            if (restaurantService.Img.Length / 1024 > 1000)
            {
                ModelState.AddModelError("", "Image is too large");
            }

            string path = _env.WebRootPath + @"\images\meal";
            string filename = Guid.NewGuid().ToString() + restaurantService.Img.FileName;
            string final = Path.Combine(path, filename);

            if (System.IO.File.Exists(final))
            {
                System.IO.File.Delete(final);
            }

            using (FileStream fs = new FileStream(final, FileMode.Create))
            {
                await restaurantService.Img.CopyToAsync(fs);
            }

            restaurantService.Image = filename;


            _context.Update(restaurantService);
            await _context.SaveChangesAsync();
            ViewData["RestaurantCategoryId"] = new SelectList(_context.RestaurantCategories, "Id", "Name", restaurantService.RestaurantCategoryId);
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/RestaurantServices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurantService = await _context.RestaurantServices
                .Include(r => r.RestaurantCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restaurantService == null)
            {
                return NotFound();
            }

            return View(restaurantService);
        }

        // POST: Admin/RestaurantServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var service = await _context.RestaurantServices.FindAsync(id);

            if (System.IO.File.Exists(Path.Combine(_env.WebRootPath + @"\images\meal", service.Image)))
            {
                System.IO.File.Delete(Path.Combine(_env.WebRootPath + @"\images\meal", service.Image));
            }
            _context.RestaurantServices.Remove(service);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RestaurantServiceExists(int id)
        {
            return _context.RestaurantServices.Any(e => e.Id == id);
        }
    }
}
