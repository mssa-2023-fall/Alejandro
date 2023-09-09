// See https://aka.ms/new-console-template for more information

using GroceryLib;
using System.Data.Common;
using System.Diagnostics;
using System.Runtime.CompilerServices;
/*
//Utilized a bool variable for while the customer shops
bool addMoreItems = false;
Console.WriteLine("Welcome to Chancho's SuperMarket! Below are the items: ");
DateTime dateTime = DateTime.Now;
//Grab a shopping Cart
ShoppingCart shoppingCart = new ShoppingCart();
//Grab a store catalog
ProductDictionary productDictionary = new ProductDictionary();

//Countinue to loop through the store items while the customer is not finished shopping.
do
{
    //Prints all Store Items
    productDictionary.PrintAllProducts();


    //The following variable is utilized to pass on to the productId of choice by the customer
    Console.WriteLine("Please select a productId to add to your cart.");
    int itemId = 0;
    itemId = int.Parse(Console.ReadLine());

    //The following variable is utilized to pass on the quantity of the product the user wants
    int qunatityId = 0;
    Console.WriteLine("Please entry the quantity of the productId {0}.", itemId);
    qunatityId = int.Parse(Console.ReadLine());

    //Adding the product to the shopping cart based on the product/ItemId and quantity
    shoppingCart.AddToCart(itemId, qunatityId);

    //Simple prompt to see if the customer would like to continue shopping
    Console.WriteLine("Would you like to add more items? Y for Yes, N for No");
    if(Console.ReadKey(false) == new ConsoleKeyInfo('y', ConsoleKey.Y, false, false, false)) {
        addMoreItems = true;
    } else { addMoreItems = false; }

} while (addMoreItems);

//Receipt prints. Date and Time the transaction was made
Console.WriteLine("******************************");
Console.WriteLine("*****CHANCHO'S SUPERMARKET****");
Console.WriteLine($"******{dateTime}*****");
shoppingCart.ViewCart(productDictionary);
Console.WriteLine("******************************");
Console.WriteLine("******************************");
shoppingCart.CalculateTotal(productDictionary);
Console.WriteLine("******************************");
Console.WriteLine("******************************");


//Capabilities added for store manager to add products to the ProductDictionary
productDictionary.AddProduct("Orange Juice", 5.49M);*/

ShoppingCart cart = new ShoppingCart();
cart.AddToCart(1, 1);
cart.AddToCart(1, 2);

Console.WriteLine(cart.cartItems[1]);
