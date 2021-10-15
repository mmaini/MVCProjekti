using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Models
{
    public class Employee
    {

        [Required(ErrorMessage = "ID je obavezan")]
        [Display(Name = "Employee ID")]
        public int Id { get; set; }

        [Display(Name = "Ime")]
        [Required(ErrorMessage = "Ime je obavezan podatak")]
        [StringLength(10, ErrorMessage = "Ime ne smije imati više od 10 znakova")]
        public string FirstName { get; set; }

        [Display(Name = "Prezime")]
        [Required(ErrorMessage = "Prezime je obavezan podatak")]
        [StringLength(20, ErrorMessage = "Prezime ne smije imati više od 10 znakova")]
        public string LastName { get; set; }

        [StringLength(30, ErrorMessage = "Radno mjesto ne smije imati više od 30 znakova")]
        [Display(Name = "Radno mjesto")]
        public string Title { get; set; }

        [Display(Name = "Datum rođenja")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Datum zaposlenja")]
        public DateTime? HireDate { get; set; }

        [Display(Name = "Napomena")]
        public string Notes { get; set; }

        //strani ključevi
        [Display(Name = "Država")]
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        [Display(Name = "Država")]
        public virtual Country Country { get; set; }

        [Display(Name = "Odjel")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        [Display(Name = "Odjel")]
        public virtual Department Department { get; set; }
    }
}
