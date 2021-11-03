using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListApp.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Opis je obavezan")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Datum je obavezan")]
        public DateTime? DueDate { get; set; }
        [Required(ErrorMessage = "Kategorija je obavezna")]
        public string CategoryId { get; set; }
        [Required(ErrorMessage = "Status je obavezan")]
        public string StatusId { get; set; }
        public Category Category { get; set; }
        public Status Status { get; set; }

        //ako je još otvoren, a datum mu je prošao onda smo prekoračili rok
        public bool OverDue => StatusId == "open" && DueDate < DateTime.Today;

  
    }
}
