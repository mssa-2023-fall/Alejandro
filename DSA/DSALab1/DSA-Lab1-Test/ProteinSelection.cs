using DSA_Lab_1;
using System.Runtime.CompilerServices;

namespace DSA_Lab1_Test
{
    [TestClass]
    public class ProteinSelection

    {
        RestaurantMenu menu;
        [TestInitialize]
        public void TestSetup()
        {
            menu = new RestaurantMenu();
        }

        [TestMethod]
        [DataRow("Beef", "hamburger")]
        [DataRow("Pepperoni", "pizza")]
        [DataRow("Tofu", "Tofu Fried Rice")]
        [DataRow("BEEF", "hamburger")]
        [DataRow("PEPPERoni", "pizza")]
        [DataRow("tofu", "Tofu Fried Rice")]
        public void TestWithExpectedProteinTypeShouldReturnCorrespondingDishes(string proteinChoices, string menuItem)
        {
            string dish = menu.GetDishRecommendation(proteinChoices);
            Assert.AreEqual(menuItem, dish, true);
        }

        [TestMethod]
        public void TestWith_UNExpected_ProteinTypeShouldReturnMessageProteinNotAvailable()
        {
            string dish = menu.GetDishRecommendation("fish");
            Assert.AreEqual("That protein is not available.", dish, true);
            
        }

        [TestMethod]
        
            
            
            
    }
}