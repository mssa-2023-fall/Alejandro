using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryLib
{

    //Error Handling and Testing still required.
    public class ShoppingCart
    {
        public Dictionary<int, int> cartItems; // Dictionary to store product ID and quantity

        public ShoppingCart()
        {
            cartItems = new Dictionary<int, int>();


        }



        public void AddToCart(int productId, int quantity)
        {
            if (quantity > 0)
            {
                if (cartItems.ContainsKey(productId))
                {
                    cartItems[productId] += quantity; // If product already in cart, add to quantity
                }
                else
                {
                    cartItems.TryAdd(productId, quantity); // Otherwise, add as a new item in the cart
                }
            }
        }

        public void RemoveFromCart(int productId, int quantity)
        {
            if (cartItems.ContainsKey(productId))
            {
                if (quantity >= cartItems[productId])
                {
                    cartItems.Remove(productId); // If quantity is equal or more, remove the item
                }
                else
                {
                    cartItems[productId] -= quantity; // Otherwise, reduce the quantity
                }
            }
        }

        public void ViewCart(ProductDictionary productDictionary)
        {
            Console.WriteLine("Shopping Cart Contents:");
            foreach (var kvp in cartItems)
            {
                int productId = kvp.Key;
                int quantity = kvp.Value;
                Product product = productDictionary.GetProduct(productId);

                if (product != null)
                {
                    Console.WriteLine($"{product.Name} (Product ID: {productId}) - Quantity: {quantity}");
                }
                else
                {
                    Console.WriteLine($"Product ID {productId} not found.");
                }
            }
        }

        public void CalculateTotal(ProductDictionary productDictionary)
        {
            decimal total = 0;

            foreach (var kvp in cartItems)
            {
                int productId = kvp.Key;
                int quantity = kvp.Value;
                Product product = productDictionary.GetProduct(productId);

                if (product != null)
                {
                    total += product.Price * quantity;
                }
            }

            Console.WriteLine($"Total amount in shopping cart is: {total}");
        }
    }

    

}
