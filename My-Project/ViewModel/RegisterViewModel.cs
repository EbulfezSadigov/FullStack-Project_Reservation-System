using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace My_Project.ViewModel
{
    public class RegisterViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        [Required, EmailAddress, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [MinLength(8), DataType(DataType.Password)]
        public string Password { get; set; }
        [MinLength(8), DataType(DataType.Password), Compare(nameof(Password))]
        public string PasswordConfirm { get; set; }
    }
}
