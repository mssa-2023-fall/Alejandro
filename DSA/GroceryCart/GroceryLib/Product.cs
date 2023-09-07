using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryLib
{


    //Error Handling and Testing still required.
    public class Product
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








