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
    public class BookingStatusController : Controller
    {
        private readonly AppDbContext _context;

        public BookingStatusController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/BookingStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.BookingStatuses.ToListAsync());
        }

        // GET: Admin/BookingStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingStatus = await _context.BookingStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookingStatus == null)
            {
                return NotFound();
            }

            return View(bookingStatus);
        }

        // GET: Admin/BookingStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/BookingStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id")] BookingStatus bookingStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookingStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookingStatus);
        }

        // GET: Admin/BookingStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingStatus = await _context.BookingStatuses.FindAsync(id);
            if (bookingStatus == null)
            {
                return NotFound();
            }
            return View(bookingStatus);
        }

        // POST: Admin/BookingStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id")] BookingStatus bookingStatus)
        {
            if (id != bookingStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookingStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingStatusExists(bookingStatus.Id))
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
            return View(bookingStatus);
        }

        // GET: Admin/BookingStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingStatus = await _context.BookingStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookingStatus == null)
            {
                return NotFound();
            }

            return View(bookingStatus);
        }

        // POST: Admin/BookingStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookingStatus = await _context.BookingStatuses.FindAsync(id);
            _context.BookingStatuses.Remove(bookingStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingStatusExists(int id)
        {
            return _context.BookingStatuses.Any(e => e.Id == id);
        }
    }
}
