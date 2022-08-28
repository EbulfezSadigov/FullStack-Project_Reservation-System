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
    public class BlogsController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly AppDbContext _context;

        public BlogsController(AppDbContext context, IWebHostEnvironment env)
        {
            _env = env;
            _context = context;
        }

        // GET: Admin/Blogs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Blogs.ToListAsync());
        }

        // GET: Admin/Blogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // GET: Admin/Blogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Blogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Blog blog)
        {
            if (!blog.Img.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("", "Please upload image");
            }

            if (blog.Img.Length / 1024 > 1000)
            {
                ModelState.AddModelError("", "Image is too large");
            }


            string path = _env.WebRootPath + @"\images\blog";
            string filename = Guid.NewGuid().ToString() + blog.Img.FileName;
            string final = Path.Combine(path, filename);

            using (FileStream fs = new FileStream(final, FileMode.Create))
            {
                await blog.Img.CopyToAsync(fs);
            }

            blog.Image = filename;


            if (ModelState.IsValid)
            {
                _context.Add(blog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        // GET: Admin/Blogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blogs.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        // POST: Admin/Blogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (id != blog.Id)
            {
                return NotFound();
            }

            if (!blog.Img.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("", "Please upload image");
            }

            if (blog.Img.Length / 1024 > 1000)
            {
                ModelState.AddModelError("", "Image is too large");
            }

            string path = _env.WebRootPath + @"\images\blog";
            string filename = Guid.NewGuid().ToString() + blog.Img.FileName;
            string final = Path.Combine(path, filename);

            if (System.IO.File.Exists(final))
            {
                System.IO.File.Delete(final);
            }

            using (FileStream fs = new FileStream(final, FileMode.Create))
            {
                await blog.Img.CopyToAsync(fs);
            }

            blog.Image = filename;

            _context.Update(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Blogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // POST: Admin/Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);

            if (System.IO.File.Exists(Path.Combine(_env.WebRootPath + @"\images\blog", blog.Image)))
            {
                System.IO.File.Delete(Path.Combine(_env.WebRootPath + @"\images\blog", blog.Image));
            }
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogExists(int id)
        {
            return _context.Blogs.Any(e => e.Id == id);
        }
    }
}
