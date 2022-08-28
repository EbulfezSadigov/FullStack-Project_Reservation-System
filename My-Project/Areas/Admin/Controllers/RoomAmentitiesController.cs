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
    public class RoomAmentitiesController : Controller
    {
        private readonly AppDbContext _context;

        public RoomAmentitiesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/RoomAmentities
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.RoomAmentities.Include(r => r.Amentity).Include(r => r.Room);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Admin/RoomAmentities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomAmentity = await _context.RoomAmentities
                .Include(r => r.Amentity)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomAmentity == null)
            {
                return NotFound();
            }

            return View(roomAmentity);
        }

        // GET: Admin/RoomAmentities/Create
        public IActionResult Create()
        {
            ViewData["AmentityId"] = new SelectList(_context.Amentities, "Id", "Name");
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "RoomNumber");
            return View();
        }

        // POST: Admin/RoomAmentities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomId,AmentityId,Id")] RoomAmentity roomAmentity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomAmentity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AmentityId"] = new SelectList(_context.Amentities, "Id", "Name", roomAmentity.AmentityId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "RoomNumber", roomAmentity.RoomId);
            return View(roomAmentity);
        }

        // GET: Admin/RoomAmentities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomAmentity = await _context.RoomAmentities.FindAsync(id);
            if (roomAmentity == null)
            {
                return NotFound();
            }
            ViewData["AmentityId"] = new SelectList(_context.Amentities, "Id", "Name", roomAmentity.AmentityId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "RoomNumber", roomAmentity.RoomId);
            return View(roomAmentity);
        }

        // POST: Admin/RoomAmentities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomId,AmentityId,Id")] RoomAmentity roomAmentity)
        {
            if (id != roomAmentity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomAmentity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomAmentityExists(roomAmentity.Id))
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
            ViewData["AmentityId"] = new SelectList(_context.Amentities, "Id", "Name", roomAmentity.AmentityId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "RoomNumber", roomAmentity.RoomId);
            return View(roomAmentity);
        }

        // GET: Admin/RoomAmentities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomAmentity = await _context.RoomAmentities
                .Include(r => r.Amentity)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomAmentity == null)
            {
                return NotFound();
            }

            return View(roomAmentity);
        }

        // POST: Admin/RoomAmentities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomAmentity = await _context.RoomAmentities.FindAsync(id);
            _context.RoomAmentities.Remove(roomAmentity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomAmentityExists(int id)
        {
            return _context.RoomAmentities.Any(e => e.Id == id);
        }
    }
}
