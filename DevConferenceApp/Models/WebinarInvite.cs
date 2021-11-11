using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevConferenceApp.Models
{
    //klasa koja predstavlja pozivnicu na konferenciju
    public class WebinarInvite
    {
        [Required(ErrorMessage = "Molimo unesite ime")]
        [Display(Name="Ime")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Molimo unesite email")]
        [EmailAddress]
        [Display(Name = "Email adresa")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Molimo unesite telefon")]
        [Phone]
        [Display(Name = "Broj telefona")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Molimo navedite da li ćete učestvovati")]
        [Display(Name = "Dolazi")]
        public bool? WillJoin { get; set; }

    }
}
