using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using My_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Project.DAL
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<RestaurantCategory> RestaurantCategories { get; set; }
        public DbSet<RestaurantService> RestaurantServices { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<RoomType> RoomType { get; set; }
        public DbSet<BookingStatus> BookingStatuses { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<BookingModel> Bookings { get; set; }
        public DbSet<Amentity> Amentities { get; set; }
        public DbSet<RoomAmentity> RoomAmentities { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Blog> Blogs { get; set; }
    }
}
