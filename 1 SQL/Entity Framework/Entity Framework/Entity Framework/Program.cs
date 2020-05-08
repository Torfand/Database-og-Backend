using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new NorthwindContext();
            var product = db.Products
                .Include(p =>p.Category)
                .First();
            Console.WriteLine("Prod : " + product.ProductName);
            Console.WriteLine("Kategori : " + product.Category.CategoryName);
        }
    }
}
