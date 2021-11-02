using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductShop.Models
{
    //klasa koja simulira bazu
    public class Database
    {
        //metoda koja simulira dohvat proizvoda iz baze, vraća listu hardkodiranih proizvoda
        public static List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            Product p = new Product();
            p.Id = 1;
            p.Name = "Prizvod 1";
            p.Price = (decimal)499.00;
            products.Add(p);

            p = new Product();
            p.Id = 2;
            p.Name = "Najbolji proizvod ikad";
            p.Price = (decimal)1109.00;
            products.Add(p);

            p = new Product();
            p.Id = 3;
            p.Name = "Treći proizvod";
            p.Price = (decimal)2017.00;
            products.Add(p);

            p = new Product();
            p.Id = 4;
            p.Name = "Najgori proizvod ikad";
            p.Price = (decimal)1480.99;
            products.Add(p);

            p = new Product();
            p.Id = 5;
            p.Name = "Neki drugi proizvod";
            p.Price = (decimal)290.00;
            products.Add(p);

            p = new Product();
            p.Id = 6;
            p.Name = "Šesti proizvod";
            p.Price = (decimal)405.00;
            products.Add(p);

            p = new Product();
            p.Id = 7;
            p.Name = "Još neki proizvod";
            p.Price = (decimal)899.99;
            products.Add(p);

            p = new Product();
            p.Id = 8;
            p.Name = "Proizvod mjeseca";
            p.Price = (decimal)1499.99;
            products.Add(p);

            p = new Product();
            p.Id = 9;
            p.Name = "Deveti proizvod";
            p.Price = (decimal)69.99;
            products.Add(p);

            p = new Product();
            p.Id = 10;
            p.Name = "Zadnji proizvod";
            p.Price = (decimal)99.99;
            products.Add(p);

            return products;
        }

        //metoda koja dohvaća proizvod po slug-u
        public static Product GetProduct(string slug)
        {
            List<Product> products = Database.GetProducts();
            //šetaj po proizvodima
            foreach (Product p in products)
            {
                //ako je slug jednak proslijeđenom, vrati taj proizvod
                if (p.Slug == slug)
                {
                    return p;
                }
            }
            //ako nismo našli podudaranje, vrati null
            return null;
        }
    }
}


