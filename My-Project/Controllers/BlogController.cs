using Microsoft.AspNetCore.Mvc;
using My_Project.DAL;
using My_Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Project.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext db;


        public BlogController(AppDbContext _db)
        {
            db = _db;
        }

        public IActionResult Details(int Id)
        {
            HomeViewModel hvm = new HomeViewModel()
            {
                footer = db.Footers.First(),
                detailBlog = db.Blogs.Find(Id)
            };
            return View(hvm);
        }
    }
}
