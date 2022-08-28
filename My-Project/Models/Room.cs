using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace My_Project.Models
{
    public class Room:BaseEntity
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string RoomNumber { get; set; }
        public decimal RoomPrice { get; set; }
        [NotMapped]
        public IFormFile Img { get; set; }
        public int BookingStatusId { get; set; }
        public int RoomTypeId { get; set; }
        public int RoomCapacity { get; set; }
        public RoomType RoomType { get; set; }
        public List<BookingModel> Booking { get; set; }
        public BookingStatus BookingStatus { get; set; }
        public List<RoomAmentity> RoomAmentities { get; set; }
        public int PeopleCount { get; set; }
        public int Area { get; set; }
        public string DetailText1 { get; set; }
        public string DetailText2 { get; set; }
    }
}
