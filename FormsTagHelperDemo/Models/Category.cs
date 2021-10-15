using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FormsTagHelperDemo.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
       
        //jedna kategorija može imati više proizvoda
        public IEnumerable<Product> Products { get; set; }

        //obzirom da se ne spajamo na bazu još, definiramo u kodu listu kategorija
        public List<SelectListItem> Categories { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value="1", Text="Moda"},
            new SelectListItem {Value="2", Text="Elektronika"},
            new SelectListItem {Value="3", Text="Računala"},
            new SelectListItem {Value="4", Text="Sport"}
        };
    }
}
