using GroceryLib;

namespace GroceryCartTest
{
    [TestClass]
    public class GroceryCartTest
    {
        [TestMethod]
        public void DefaultCreateShoppingCartIsEmptyCart()
        {
            //Arrange
            ShoppingCart shoppingCart = new ShoppingCart();
            ShoppingCart shoppingCart1 = new ShoppingCart();
            ShoppingCart shoppingCart2 = new ShoppingCart();

            //Action
            shoppingCart1 = shoppingCart2;

            //Assert
            Assert.IsNotNull(shoppingCart);
            Assert.IsNotNull(shoppingCart1);
            Assert.IsNotNull(shoppingCart2);

            Assert.AreNotEqual(shoppingCart, shoppingCart1);
            Assert.AreNotSame(shoppingCart, shoppingCart1);

            Assert.AreNotEqual(shoppingCart, shoppingCart2);
            Assert.AreNotSame(shoppingCart, shoppingCart1);

            Assert.AreEqual(shoppingCart1, shoppingCart2);
            Assert.AreSame(shoppingCart1, shoppingCart2);
        }

        [TestMethod]
        public void AddNewItemToCartFromProductDictionary()
        {   //Arrange
            ShoppingCart shoppingCart = new ShoppingCart();
            ProductDictionary productDictionary = new ProductDictionary();

            //Action
            shoppingCart.AddToCart(1, 3);//Key represents the ItemId and Value represents the number of items added to cart
            shoppingCart.AddToCart(1, 4);//Key represents the ItemId and Value represents the number of items added to cart
            int actualValue = shoppingCart.cartItems[1];
            int expectedValue = 7;

            //Assert
            Assert.AreEqual(1, shoppingCart.cartItems.Keys.Count());
            Assert.AreEqual(actualValue, expectedValue);
            Assert.AreNotEqual(2, shoppingCart.cartItems.Keys.Count());
            Assert.AreNotEqual(6, shoppingCart.cartItems[1]);
        }

        [TestMethod]
        public void AddsKeyItemIdandIncreasesQuantityForSimilarItemIdAdded()
        {

        }
    }
}