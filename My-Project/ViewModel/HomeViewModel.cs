using My_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Project.ViewModel
{
    public class HomeViewModel
    {
        public About about { get; set; }
        public List<Guest> guests { get; set; }
        public List<RestaurantCategory> restaurantCategories { get; set; }
        public List<RestaurantService> restaurantServices { get; set; }
        public List<Banner> banners { get; set; }
        public Footer footer { get; set; }
        public List<Category> categories { get; set; }
        public List<Service> services { get; set; }
        public List<RoomType> roomTypes { get; set; }
        public List<BookingStatus> bookingStatuses { get; set; }
        public List<Room> rooms { get; set; }
        public List<BookingModel> bookings { get; set; }
        public List<Amentity> amentities { get; set; }
        public List<RoomAmentity> roomAmentities { get; set; }
        public List<Blog> blogs { get; set; }
        public Blog detailBlog { get; set; }
        public Room detailRoom { get; set; }
    }
}
