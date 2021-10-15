using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FormsTagHelperDemo.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        [DisplayFormat(DataFormatString = "{0:c2}", ApplyFormatInEditMode = true)]
        public decimal Cost { get; set; }
        public decimal? BillAmount { get; set; }
        public decimal? Discount { get; set; }
        public decimal? NetBillAmount { get; set; }
        public bool IsPartOfDeal { get; set; }
        //veza na kategoriju
        public int CategoryId { get; set; }
        public  Category Category { get; set; }
        public string PaymentType { get; set; }

    }
}
