using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Project.Models
{
    public class BookingStatus:BaseEntity
    {
        public string Name { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
