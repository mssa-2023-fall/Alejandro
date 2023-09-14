using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomerLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginLib;

namespace LoginTest
{
    [TestClass()]
    public class CustomersDBTests
    {
        private CustomerDictionary _customers = new();

        [TestMethod()]
        public void LoginSuccessTest()
        {
            Assert.IsTrue(_customers.Login("CorvusNidum@Outlook.com", "password"));
        }
        [TestMethod()]
        public void LoginFailsWithWrongPasswordTest()
        {
            Assert.IsFalse(_customers.Login("alice@live.com", "badpassword"));
        }
        [TestMethod()]
        public void LoginFailsWithWrongUserNameTest()
        {
            Assert.IsFalse(_customers.Login("noone@live.com", "password"));
        }
        [TestMethod()]
        public void TestExistingCustomersCountEquals3()
        {
            Assert.AreEqual(3, _customers.customerInformation.Count());
        }
        [TestMethod()]
        public void PasswordHashShouldBeDifferent()
        {
            Assert.AreNotEqual(_customers.customerInformation["GermanFox@RedHat.com"].PassHash, _customers.customerInformation["SilverFox@RedHat.com"].PassHash);
            Assert.AreNotEqual(_customers.customerInformation["GermanFox@RedHat.com"].PassHash, _customers.customerInformation["CorvusNidum@Outlook.com"].PassHash);

        }
    }
}