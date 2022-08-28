using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Project.Models
{
    public class Amentity:BaseEntity
    {
        public string Name { get; set; }
        public List<RoomAmentity> RoomAmentities { get; set; }
    }
}
