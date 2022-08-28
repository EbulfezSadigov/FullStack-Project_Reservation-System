using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace My_Project.ViewModel
{
    public class LoginViewModel
    {
        [Required, EmailAddress, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [MinLength(8), DataType(DataType.Password)]
        public string Password { get; set; }
        public bool StayLogged { get; set; }
    }
}
