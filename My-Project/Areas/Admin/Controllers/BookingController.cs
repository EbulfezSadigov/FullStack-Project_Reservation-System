using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_Project.DAL;
using My_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Project.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class BookingController : Controller
    {
        private readonly AppDbContext db;
        public BookingController(AppDbContext _db)
        {
            db = _db;
        }

        public async Task<IActionResult> Index()
        {
            List<BookingModel> bookings = await db.Bookings.ToListAsync();
            return View(bookings);
        }


        public IActionResult Delete(int id)
        {
            BookingModel booking = db.Bookings.FirstOrDefault(x => x.Id == id);
            if (booking == null) return NotFound();
            return View(booking);
        }


        public IActionResult DeleteConfirmed(int id)
        {
            BookingModel booking = db.Bookings.FirstOrDefault(x => x.Id == id);
            if (booking == null) return NotFound();
            db.Bookings.Remove(booking);
            db.SaveChanges();
            return RedirectToAction("Index", "Booking", new { area = "Admin" });
        }
    }
}
