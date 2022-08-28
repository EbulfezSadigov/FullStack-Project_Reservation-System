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
    public class AboutsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public AboutsController(AppDbContext context, IWebHostEnvironment env)
        {
            _env = env;
            _context = context;
        }

        // GET: Admin/Abouts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Abouts.ToListAsync());
        }

        // GET: Admin/Abouts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var about = await _context.Abouts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (about == null)
            {
                return NotFound();
            }

            return View(about);
        }

        // GET: Admin/Abouts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Abouts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(About about)
        {
            if (!about.Img.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("", "Please upload image");
            }

            if (about.Img.Length / 1024 > 1000)
            {
                ModelState.AddModelError("", "Image is too large");
            }


            string path = _env.WebRootPath + @"\images";
            string filename = Guid.NewGuid().ToString() + about.Img.FileName;
            string final = Path.Combine(path, filename);

            using (FileStream fs = new FileStream(final, FileMode.Create))
            {
                await about.Img.CopyToAsync(fs);
            }

            about.Image = filename;

            if (ModelState.IsValid)
            {
                _context.Add(about);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(about);
        }

        // GET: Admin/Abouts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var about = await _context.Abouts.FindAsync(id);
            if (about == null)
            {
                return NotFound();
            }
            return View(about);
        }

        // POST: Admin/Abouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, About about)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (id != about.Id)
            {
                return NotFound();
            }

            if (!about.Img.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("", "Please upload image");
            }

            if (about.Img.Length / 1024 > 1000)
            {
                ModelState.AddModelError("", "Image is too large");
            }

            string path = _env.WebRootPath + @"\images";
            string filename = Guid.NewGuid().ToString() + about.Img.FileName;
            string final = Path.Combine(path, filename);

            if (System.IO.File.Exists(final))
            {
                System.IO.File.Delete(final);
            }

            using (FileStream fs = new FileStream(final, FileMode.Create))
            {
                await about.Img.CopyToAsync(fs);
            }

            about.Image = filename;


            _context.Update(about);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Abouts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var about = await _context.Abouts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (about == null)
            {
                return NotFound();
            }

            return View(about);
        }

        // POST: Admin/Abouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var about = await _context.Abouts.FindAsync(id);

            if (System.IO.File.Exists(Path.Combine(_env.WebRootPath + @"\images", about.Image)))
            {
                System.IO.File.Delete(Path.Combine(_env.WebRootPath + @"\images", about.Image));
            }
            _context.Abouts.Remove(about);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AboutExists(int id)
        {
            return _context.Abouts.Any(e => e.Id == id);
        }
    }
}
