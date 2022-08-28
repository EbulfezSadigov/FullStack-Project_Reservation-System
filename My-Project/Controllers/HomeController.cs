using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using My_Project.DAL;
using My_Project.Models;
using My_Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace My_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext db;

        public HomeController(AppDbContext _db)
        {
            db = _db;
        }
        public async Task<IActionResult> Index()
        {
            HomeViewModel hvm = new HomeViewModel()
            {
                guests = await db.Guests.ToListAsync(),
                about = db.Abouts.FirstOrDefault(),
                restaurantServices = await db.RestaurantServices.ToListAsync(),
                restaurantCategories = await db.RestaurantCategories.ToListAsync(),
                rooms = await db.Rooms.Include(x=>x.RoomAmentities).ThenInclude(x=>x.Amentity).ToListAsync(),
                banners = await db.Banners.ToListAsync(),
                footer = await db.Footers.FirstOrDefaultAsync(),
                categories = await db.Categories.ToListAsync(),
                services = await db.Services.ToListAsync(),
                roomTypes = await db.RoomType.ToListAsync(),
                bookingStatuses = await db.BookingStatuses.ToListAsync(),
                bookings = await db.Bookings.ToListAsync(),
                amentities = await db.Amentities.ToListAsync(),
                roomAmentities = await db.RoomAmentities.ToListAsync()
            };

            return View(hvm);
        }

        public async Task<IActionResult> About()
        {
            HomeViewModel hvm = new HomeViewModel()
            {
                guests = await db.Guests.ToListAsync(),
                about = db.Abouts.FirstOrDefault(),
                categories = await db.Categories.ToListAsync(),
                footer = await db.Footers.FirstOrDefaultAsync(),
                services = await db.Services.ToListAsync()
            };
            return View(hvm);
        }

        public async Task<IActionResult> Room()
        {
            HomeViewModel hvm = new HomeViewModel()
            {
                guests = await db.Guests.ToListAsync(),
                rooms = await db.Rooms.Include(x => x.RoomAmentities).ThenInclude(x => x.Amentity).ToListAsync(),
                categories = await db.Categories.ToListAsync(),
                footer = await db.Footers.FirstOrDefaultAsync(),
                amentities = await db.Amentities.ToListAsync(),
                services = await db.Services.ToListAsync()
            };
            return View(hvm);
        }

        public async Task<IActionResult> Restaurant()
        {
            HomeViewModel hvm = new HomeViewModel()
            {
                restaurantServices = await db.RestaurantServices.ToListAsync(),
                restaurantCategories = await db.RestaurantCategories.ToListAsync(),
                guests = await db.Guests.ToListAsync(),
                categories = await db.Categories.ToListAsync(),
                footer = await db.Footers.FirstOrDefaultAsync(),
                services = await db.Services.ToListAsync()
            };
            return View(hvm);
        }

        public async Task<IActionResult> Blog()
        {
            HomeViewModel hvm = new HomeViewModel()
            {
                footer = await db.Footers.FirstOrDefaultAsync(),
                blogs = await db.Blogs.ToListAsync()
            };
            return View(hvm);
        }


        public IActionResult Contact()
        {
            HomeViewModel hvm = new HomeViewModel()
            {
                footer = db.Footers.FirstOrDefault(),
            };
            return View(hvm);
        }

        public async Task<IActionResult> Message(Message msg)
        {
            if (ModelState.IsValid)
            {
                msg.Date = DateTime.Now;
                await db.Messages.AddAsync(msg);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
