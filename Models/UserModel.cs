using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmsCatalog.Models
{
    public class UserModel : IUser<UserRegisterModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string FullName { get; set; }
        public string registrationDate { get; private set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        [NotMapped]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Email")]
        [NotMapped]
        public string Email { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [NotMapped]
        public string PasswordConfirm { get; set; }

        public UserModel()
        {
            registrationDate =  DateTime.Now.ToShortDateString();
        }
    }
}
