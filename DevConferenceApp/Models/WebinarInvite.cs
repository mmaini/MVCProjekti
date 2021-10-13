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
        public string Name { get; set; }

        [Required(ErrorMessage = "Molimo unesite email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Molimo unesite telefon")]
        [Phone]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Molimo navedite da li ćete učestvovati")]
        public bool? WillJoin { get; set; }

    }
}
