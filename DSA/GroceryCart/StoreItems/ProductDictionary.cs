using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GroceryLib
{
    class ProductDictionary
    {
        public Dictionary<int, Product> products;
        public int nextProductId = 1;
        
        public ProductDictionary()
        {
            products = new Dictionary<int, Product>
            {
                { 1, Product1 },
                { 2, Product2 },
                { 3, Product3 },
                { 4, Product4 },
                { 5, Product5 },
                { 6, Product6 }
            };

        }

        Product Product1 = new Product(1, "Apple", 1.99M);
        Product Product2 = new Product(2, "WaterMelon", 2.99M);
        Product Product3 = new Product(3, "Milk", 8.99M);
        Product Product4 = new Product(4, "Watermelon", 2.99M);
        Product Product5 = new Product(5, "Chips", 3.99M);
        Product Product6 = new Product(6, "Water", 0.99M);

        public void AddProduct(string name, decimal price)
        {
            Product product = new Product(nextProductId, name, price);
            products.TryAdd(nextProductId, product);
            nextProductId++;
        }

        public bool RemoveProduct(int productId)
        {
            return products.Remove(productId);
        }

        public Product GetProduct(int productId)
        {
            if (products.ContainsKey(productId))
            {
                return products[productId];
            }
            else
            {
                return null;
            }
        }
        


        public void PrintAllProducts()
        {
            Console.WriteLine("Product List:");
            foreach (var kvp in products)
            {
                Console.WriteLine(kvp.Value);
            }
        }
    }
}

