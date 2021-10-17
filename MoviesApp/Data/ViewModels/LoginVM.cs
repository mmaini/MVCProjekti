using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name="Email adresa")]
        [Required(ErrorMessage = "Email adresa je obavezna")]
        public string EmailAddress { get; set; }
        [Display(Name = "Lozinka")]
        [Required(ErrorMessage = "Lozinka je obavezna")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
