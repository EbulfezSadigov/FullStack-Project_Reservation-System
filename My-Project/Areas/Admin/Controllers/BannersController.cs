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

namespace My_Project.Areas.Admin
{
    [Area("Admin")]
    public class BannersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public BannersController(AppDbContext context, IWebHostEnvironment env)
        {
            _env = env;
            _context = context;
        }

        // GET: Admin/Banners
        public async Task<IActionResult> Index()
        {
            return View(await _context.Banners.ToListAsync());
        }

        // GET: Admin/Banners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banner = await _context.Banners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (banner == null)
            {
                return NotFound();
            }

            return View(banner);
        }

        // GET: Admin/Banners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Banners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Banner banner)
        {
            if (!banner.Img.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("", "Please upload image");
            }

            if (banner.Img.Length / 1024 > 1000)
            {
                ModelState.AddModelError("", "Image is too large");
            }


            string path = _env.WebRootPath + @"\images";
            string filename = Guid.NewGuid().ToString() + banner.Img.FileName;
            string final = Path.Combine(path, filename);

            using (FileStream fs = new FileStream(final, FileMode.Create))
            {
                await banner.Img.CopyToAsync(fs);
            }

            banner.Image = filename;


            if (ModelState.IsValid)
            {
                _context.Add(banner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(banner);
        }

        // GET: Admin/Banners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banner = await _context.Banners.FindAsync(id);
            if (banner == null)
            {
                return NotFound();
            }
            return View(banner);
        }

        // POST: Admin/Banners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Banner banner)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (id != banner.Id)
            {
                return NotFound();
            }

            if (!banner.Img.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("", "Please upload image");
            }

            if (banner.Img.Length / 1024 > 1000)
            {
                ModelState.AddModelError("", "Image is too large");
            }

            string path = _env.WebRootPath + @"\images";
            string filename = Guid.NewGuid().ToString() + banner.Img.FileName;
            string final = Path.Combine(path, filename);

            if (System.IO.File.Exists(final))
            {
                System.IO.File.Delete(final);
            }

            using (FileStream fs = new FileStream(final, FileMode.Create))
            {
                await banner.Img.CopyToAsync(fs);
            }

            banner.Image = filename;

            _context.Update(banner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Banners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banner = await _context.Banners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (banner == null)
            {
                return NotFound();
            }

            return View(banner);
        }

        // POST: Admin/Banners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var banner = await _context.Banners.FindAsync(id);

            if (System.IO.File.Exists(Path.Combine(_env.WebRootPath + @"\images", banner.Image)))
            {
                System.IO.File.Delete(Path.Combine(_env.WebRootPath + @"\images", banner.Image));
            }
            _context.Banners.Remove(banner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BannerExists(int id)
        {
            return _context.Banners.Any(e => e.Id == id);
        }
    }
}
