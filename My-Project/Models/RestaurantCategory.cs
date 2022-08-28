using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Project.Models
{
    public class RestaurantCategory:BaseEntity
    {
        public List<RestaurantService> RestaurantService { get; set; }
        public string Name { get; set; }
    }
}
