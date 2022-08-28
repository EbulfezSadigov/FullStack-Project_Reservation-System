using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace My_Project.Models
{
    public class Guest:BaseEntity
    {
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Img { get; set; }
        public string Title { get; set; }
        public int startCount { get; set; }
        public string Name { get; set; }
        public string Where { get; set; }
    }
}
