using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MoviesApp.Models
{

    //proširujemo ugrađenu IdentityUser 
    public class ApplicationUser : IdentityUser
    {
        [Display(Name="Ime i prezime")]
        public string FullName { get; set; }

    }
}
