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
    public class MessageController : Controller
    {

        private readonly AppDbContext db;
        public MessageController(AppDbContext _db)
        {
            db = _db;
        }

        public async Task<IActionResult> Index()
        {
            List<Message> messages = await db.Messages.ToListAsync();
            return View(messages);
        }


        public IActionResult Delete(int id)
        {
            Message message = db.Messages.FirstOrDefault(x => x.Id == id);
            if (message == null) return NotFound();
            return View(message);
        }


        public IActionResult DeleteConfirmed(int id)
        {
            Message message = db.Messages.FirstOrDefault(x => x.Id == id);
            if (message == null) return NotFound();
            db.Messages.Remove(message);
            db.SaveChanges();
            return RedirectToAction("Index", "Message", new { area = "Admin" });
        }
    }
}
