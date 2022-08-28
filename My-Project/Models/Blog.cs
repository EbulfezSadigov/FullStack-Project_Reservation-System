using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace My_Project.Models
{
    public class Blog:BaseEntity
    {
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Img { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int CommentCount { get; set; }
        public string BlogTitle { get; set; }
        public string BlogText { get; set; }
        public string BlogTitle2 { get; set; }
        public string BlogText2 { get; set; }
    }
}
