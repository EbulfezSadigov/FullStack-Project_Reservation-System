using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Project.Models
{
    public class Service:BaseEntity
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Subtext { get; set; }
        public string Icon { get; set; }
        public Category Category { get; set; }
    }
}
