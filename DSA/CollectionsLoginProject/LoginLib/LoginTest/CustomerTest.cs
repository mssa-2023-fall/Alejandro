using CustomerLogin;
using LoginLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginTest
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void TestCustomerConstructor()
        {
            Customer testCustomer = new Customer("Alex", "Corvus", "password", "corvusnidum@outlook.com");
            Assert.AreEqual("Alex", testCustomer.FirstName);
            Assert.AreEqual("corvusnidum@outlook.com", testCustomer.Email);
            Assert.AreEqual(64, testCustomer.PassHash.Length);
            
        }

    }
}
