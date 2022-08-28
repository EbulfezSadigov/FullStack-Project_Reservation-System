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
    public class FootersController : Controller
    {
        private readonly AppDbContext _context;

        public FootersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Footers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Footers.ToListAsync());
        }

        // GET: Admin/Footers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var footer = await _context.Footers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (footer == null)
            {
                return NotFound();
            }

            return View(footer);
        }

        // GET: Admin/Footers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Footers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Location,Gmail,AboutText,Id")] Footer footer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(footer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(footer);
        }

        // GET: Admin/Footers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var footer = await _context.Footers.FindAsync(id);
            if (footer == null)
            {
                return NotFound();
            }
            return View(footer);
        }

        // POST: Admin/Footers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Location,Gmail,AboutText,Id")] Footer footer)
        {
            if (id != footer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(footer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FooterExists(footer.Id))
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
            return View(footer);
        }

        // GET: Admin/Footers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var footer = await _context.Footers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (footer == null)
            {
                return NotFound();
            }

            return View(footer);
        }

        // POST: Admin/Footers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var footer = await _context.Footers.FindAsync(id);
            _context.Footers.Remove(footer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FooterExists(int id)
        {
            return _context.Footers.Any(e => e.Id == id);
        }
    }
}
