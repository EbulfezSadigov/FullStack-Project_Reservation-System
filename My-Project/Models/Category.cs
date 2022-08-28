using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Project.Models
{
    public class Category:BaseEntity
    {
        public string Icon { get; set; }
        public string Name { get; set; }
        public Service Service { get; set; }
    }
}
