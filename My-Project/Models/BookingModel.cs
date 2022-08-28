using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace My_Project.Models
{
    public class BookingModel : BaseEntity
    {
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustomerAddress { get; set; }
        [Required, EmailAddress]
        public string CustomerEmail { get; set; }
        [Required]
        public string CustomerPhone { get; set; }
        [Required]
        public DateTime BookingTo { get; set; }
        [Required]
        public DateTime BookingFrom { get; set; }
        [Required]
        public int NumberOfMembers { get; set; }
        public int RoomId { get; set; }
        public string AppUserId { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
