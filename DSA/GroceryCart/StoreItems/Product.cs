using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryLib
{
    using System;
    using System.Collections.Generic;


    class Product
    {
        public int ProductId { get; }
        public string Name { get; }
        public decimal Price { get; }

        public Product(int productId, string name, decimal price)
        {
            ProductId = productId;
            Name = name;
            Price = price;
        }

        
    }



}

    /*class Program
    {
        static void Main()
        {
            ProductDictionary productDictionary = new ProductDictionary();

            productDictionary.AddProduct("Product A", 19.99);
            productDictionary.AddProduct("Product B", 29.99);
            productDictionary.AddProduct("Product C", 9.99);

            productDictionary.PrintAllProducts();

            Console.WriteLine("\nRemoving Product ID 2...");
            productDictionary.RemoveProduct(2);

            productDictionary.PrintAllProducts();

            Console.WriteLine("\nGetting Product ID 1:");
            Product product = productDictionary.GetProduct(1);
            if (product != null)
            {
                Console.WriteLine(product);
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }
    }*/






