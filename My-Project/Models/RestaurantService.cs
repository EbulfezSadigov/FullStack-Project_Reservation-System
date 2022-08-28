using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace My_Project.Models
{
    public class RestaurantService:BaseEntity
    {
        public int RestaurantCategoryId { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Money { get; set; }
        [NotMapped]
        public IFormFile Img { get; set; }
        public RestaurantCategory RestaurantCategory { get; set; }
    }
}
