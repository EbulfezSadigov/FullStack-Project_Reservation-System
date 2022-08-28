using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Project.Models
{
    public class RoomAmentity:BaseEntity
    {
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int AmentityId { get; set; }
        public Amentity Amentity { get; set; }
    }
}
