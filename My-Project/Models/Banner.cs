using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace My_Project.Models
{
    public class Banner:BaseEntity
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        [NotMapped]
        public IFormFile Img { get; set; }
    }
}
