using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Project.DAL;
using My_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using My_Project.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace My_Project.Controllers
{
    [Authorize]
    public class ReservationController : Controller
    {
        private readonly AppDbContext db;

        private readonly UserManager<AppUser> userManager;


        public ReservationController(AppDbContext _db, UserManager<AppUser> _userManager)
        {
            db = _db;
            userManager = _userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Profile()
        {
            AppUser user = await userManager.FindByNameAsync(User.Identity.Name);

            BookingViewModel model = new BookingViewModel
            {
                bookingModels = db.Bookings.Where(x=>x.AppUserId == user.Id).ToList()
            };
            return View(model);
        }

        public IActionResult Booking()
        {
            return View();
        }

        public async Task<IActionResult> BookingMessage(BookingModel model)
        {
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.yandex.ru", 25, false);
                client.Authenticate("hotel.luxe@yandex.com", "hotel20222022");

                var bodyBuilder = new BodyBuilder
                {
                    HtmlBody = $"<h1>Contact Info</h1><p>Name:{model.CustomerName}</p> <p>Phone:{model.CustomerPhone}</p> <p>Address:{model.CustomerAddress}</p> <p>Email:{model.CustomerEmail}</p> <p>Check In:{model.BookingTo}</p> <p>Check Out:{model.BookingFrom}</p> <p>Number Of Members:{model.NumberOfMembers}</p> <h3><i>We contact with your in Recent Days</i></h3>",
                    TextBody = "{model.CustomerName} \r\n {model.CustomerPhone} \r\n {model.CustomerAddress}"
                };

                var message = new MimeMessage
                {
                    Body = bodyBuilder.ToMessageBody()
                };
                message.From.Add(new MailboxAddress("Luxe Hotel", "hotel.luxe@yandex.com"));
                message.To.Add(new MailboxAddress("Testing01", model.CustomerEmail));
                message.Subject = "Thank you for booking the room with us.";
                await client.SendAsync(message);

                await client.DisconnectAsync(true);
            }
            AppUser user = await userManager.FindByNameAsync(User.Identity.Name);

            model.AppUserId = user.Id;
            if (ModelState.IsValid)
            {
                await db.Bookings.AddAsync(model);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
