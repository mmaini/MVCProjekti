using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ValidationsDemo.Models
{
    public class UserDetails
    {
        //Required - obavezno polje + definiramo vlastitu poruku o grešci
        [Required(ErrorMessage = "Korisničko ime je obavezno")]
        //StringLength - definiramo maksimalnu duljinu unosa
        [StringLength(15, ErrorMessage = "Korisničko ime ne smije imati više od 15 znakova")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Lozinka je obavezna")]
        //Definiramo maksimalnu i minimalnu duljinu unosa
        [StringLength(11, MinimumLength = 5, ErrorMessage = "Lozinka ima imati od 5 do 11 znakova")]
        //Definiramo tip password da ne bi bio plain text
        [DataType("password")]
        public string Password { get; set; }

        //Definiramo tip na drugačiji način (isto kao [DataType("password")])
        [DataType(DataType.Password)]
        //Definiramo što će se ispisati u formi umjesto ConfirmPassword
        [Display(Name="Ponovljena lozinka")]
        //Definiramo da ovaj unos mora biti isti kao unos u Password
        [Compare("Password", ErrorMessage = "Lozinke se moraju podudarati")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Datum rođenja je obavezan")]
        //Isto kao   [Display(Name="Datum rođenja")]
        [DisplayName("Datum rođenja")]
        [DataType(DataType.Date)]
        //definiramo format prikaza datuma - ApplyFormatInEditMode omogućava da odmah unosimo željeni format
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Email adresa je obavezna")]
        //Regex će nam validirati email adresu
        [EmailAddress(ErrorMessage = "Molimo unesite ispravnu email adresu")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Poštanski broj je obavezan")]
        [DisplayName("Poštanski broj")]
        //Definiramo raspon unosa
        [Range(100, 1000, ErrorMessage = "Poštanski broj mora biti u rasponu 100 - 1000")]
        public int PostalCode { get; set; }

        [Required(ErrorMessage = "Broj telefona je obavezan")]
        [DisplayName("Broj telefona")]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "Bilješke su obavezne")]
        [DisplayName("Bilješka")]
        //Dobit ćemo kontrolu za unos više linija teksta - textarea
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        //Definiramo koje su ekstenzije dopuštene za sliku
        [FileExtensions(Extensions = "png,jpg,jpeg,gif")]
        public string Photo { get; set; }


        [Display(Name = "Dodatne napomene")] 
        public string AdditionalComments { get; set; }

    }
}
