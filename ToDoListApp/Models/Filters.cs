using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListApp.Models
{
    public class Filters
    {
        //u filterStringu proslijeđujemo parametre za filtriranje
        //filtriramo po 3 stvari: kategorija, da li je rok prekoračen ili ne, status
        public Filters(string filterString)
        {
            //all-all-all => sve kategorije, prekoračeni i ne prekoračeni, svi statusi
            FilterString = filterString ?? "all-all-all";
            //razlomimo string 
            string[] filters = FilterString.Split('-');
            //dodijelimo svaku stavku odgovarajućem svojstvu
            CategoryId = filters[0];
            Due= filters[1];
            StatusId = filters[2];
        }

        public string FilterString { get; set; }
        public string CategoryId { get; set; }
        public string Due { get; set; }
        public string StatusId { get; set; }

        //provjeravamo da li nam je stiglo all ili nešto specifično
        public bool HasCategory => CategoryId.ToLower() != "all";
        public bool HasDue => Due.ToLower() != "all";
        public bool HasStatus => StatusId.ToLower() != "all";


        //vrijednosti za dropdown s rokovima
        public static Dictionary<string, string> DueFilterValues => new Dictionary<string, string>
        {
            {"future", "Future" },
            {"past" , "Past"},
            {"today", "Today" }
        };

        public bool IsPast => Due.ToLower() == "past";
        public bool IsFuture => Due.ToLower() == "future";
        public bool IsToday => Due.ToLower() == "today";
    }
}
