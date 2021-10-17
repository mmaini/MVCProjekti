using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Data.ViewModels
{
    public class RegisterVM
    {

        [Display(Name = "Ime i prezime")]
        [Required(ErrorMessage = "Obavezan unos")]
        public string FullName { get; set; }
       
        [Display(Name = "Email adresa")]
        [Required(ErrorMessage = "Email adresa je obavezna")]
        public string EmailAddress { get; set; }
       
        [Display(Name = "Lozinka")]
        [Required(ErrorMessage = "Lozinka je obavezna")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Potvrda lozinke")]
        [Required(ErrorMessage = "Potrebno je potvrditi lozinku")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Lozinke se ne podudaraju")]
        public string ConfirmPassword { get; set; }
    }
}
