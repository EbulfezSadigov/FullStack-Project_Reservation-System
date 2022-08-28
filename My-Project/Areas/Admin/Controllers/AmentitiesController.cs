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
    public class AmentitiesController : Controller
    {
        private readonly AppDbContext _context;

        public AmentitiesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Amentities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Amentities.ToListAsync());
        }

        // GET: Admin/Amentities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amentity = await _context.Amentities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (amentity == null)
            {
                return NotFound();
            }

            return View(amentity);
        }

        // GET: Admin/Amentities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Amentities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id")] Amentity amentity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(amentity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(amentity);
        }

        // GET: Admin/Amentities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amentity = await _context.Amentities.FindAsync(id);
            if (amentity == null)
            {
                return NotFound();
            }
            return View(amentity);
        }

        // POST: Admin/Amentities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id")] Amentity amentity)
        {
            if (id != amentity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(amentity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmentityExists(amentity.Id))
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
            return View(amentity);
        }

        // GET: Admin/Amentities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amentity = await _context.Amentities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (amentity == null)
            {
                return NotFound();
            }

            return View(amentity);
        }

        // POST: Admin/Amentities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var amentity = await _context.Amentities.FindAsync(id);
            _context.Amentities.Remove(amentity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AmentityExists(int id)
        {
            return _context.Amentities.Any(e => e.Id == id);
        }
    }
}
