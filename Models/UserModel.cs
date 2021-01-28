using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmsCatalog.Models
{
    public class UserModel : IUser<UserRegisterModel>
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name must not be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Name must not be empty")]
        public string SurName { get; set; }
        public string FullName { get; private set; }
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
            FullName = $"{Name} {SurName}";
        }
    }
}
