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
    public class RoomsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;


        public RoomsController(AppDbContext context, IWebHostEnvironment env)
        {
            _env = env;
            _context = context;
        }

        // GET: Admin/Rooms
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Rooms.Include(r => r.BookingStatus).Include(r => r.RoomType);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Admin/Rooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .Include(r => r.BookingStatus)
                .Include(r => r.RoomType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Admin/Rooms/Create
        public IActionResult Create()
        {
            ViewData["BookingStatusId"] = new SelectList(_context.BookingStatuses, "Id", "Name");
            ViewData["RoomTypeId"] = new SelectList(_context.RoomType, "Id", "Name");
            return View();
        }

        // POST: Admin/Rooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Room room)
        {
            if (!room.Img.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("", "Please upload image");
            }

            if (room.Img.Length / 1024 > 1000)
            {
                ModelState.AddModelError("", "Image is too large");
            }


            string path = _env.WebRootPath + @"\images";
            string filename = Guid.NewGuid().ToString() + room.Img.FileName;
            string final = Path.Combine(path, filename);

            using (FileStream fs = new FileStream(final, FileMode.Create))
            {
                await room.Img.CopyToAsync(fs);
            }

            room.Image = filename;

            if (ModelState.IsValid)
            {
                _context.Add(room);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookingStatusId"] = new SelectList(_context.BookingStatuses, "Id", "Name", room.BookingStatusId);
            ViewData["RoomTypeId"] = new SelectList(_context.RoomType, "Id", "Name", room.RoomTypeId);
            return View(room);
        }

        // GET: Admin/Rooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            ViewData["BookingStatusId"] = new SelectList(_context.BookingStatuses, "Id", "Name", room.BookingStatusId);
            ViewData["RoomTypeId"] = new SelectList(_context.RoomType, "Id", "Name", room.RoomTypeId);
            return View(room);
        }

        // POST: Admin/Rooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Room room)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (id != room.Id)
            {
                return NotFound();
            }

            if (!room.Img.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("", "Please upload image");
            }

            if (room.Img.Length / 1024 > 1000)
            {
                ModelState.AddModelError("", "Image is too large");
            }

            string path = _env.WebRootPath + @"\images";
            string filename = Guid.NewGuid().ToString() + room.Img.FileName;
            string final = Path.Combine(path, filename);

            if (System.IO.File.Exists(final))
            {
                System.IO.File.Delete(final);
            }

            using (FileStream fs = new FileStream(final, FileMode.Create))
            {
                await room.Img.CopyToAsync(fs);
            }

            room.Image = filename;

            _context.Update(room);
            await _context.SaveChangesAsync();
            ViewData["BookingStatusId"] = new SelectList(_context.BookingStatuses, "Id", "Name", room.BookingStatusId);
            ViewData["RoomTypeId"] = new SelectList(_context.RoomType, "Id", "Name", room.RoomTypeId);
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Rooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .Include(r => r.BookingStatus)
                .Include(r => r.RoomType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Admin/Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var room = await _context.Rooms.FindAsync(id);

            if (System.IO.File.Exists(Path.Combine(_env.WebRootPath + @"\images", room.Image)))
            {
                System.IO.File.Delete(Path.Combine(_env.WebRootPath + @"\images", room.Image));
            }
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.Id == id);
        }
    }
}
