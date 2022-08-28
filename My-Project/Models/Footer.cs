using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Project.Models
{
    public class Footer:BaseEntity
    {
        public string Title { get; set; }
        public string Location { get; set; }
        public string Gmail { get; set; }
        public string AboutText { get; set; }
    }
}
