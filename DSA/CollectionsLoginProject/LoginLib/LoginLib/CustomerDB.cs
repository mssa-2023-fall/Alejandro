using CustomerLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LoginLib
{
    public class CustomerDictionary
    {
        private CryptoHelper _crypto = new();
        public Dictionary<string, Customer> customerInformation = new Dictionary<string, Customer>();
        public CustomerDictionary() {
            customerInformation = new Dictionary<string, Customer>();
            {
                Customer Andrew = new Customer("Andrew", "Spralix", "password","GermanFox@RedHat.com", "11112222");
                Customer Mike = new Customer("Mike", "Kraus", "password", "SilverFox@RedHat.com", "11112222");
                Customer Alex = new Customer("Alex", "Corvus", "password", "CorvusNidum@Outlook.com", "11112222");
                customerInformation.TryAdd(Andrew.Email, Andrew);
                customerInformation.TryAdd(Mike.Email, Mike);
                customerInformation.TryAdd(Alex.Email, Alex);
            }

        }

        public bool Login(string username, string password)
        {
            if (!customerInformation.ContainsKey(username))
                { return false; }
            else
            {
                return _crypto.VerifyHash(password, customerInformation[username].PassHash, customerInformation[username].Salt);
            }

        }

        public void NewCustomer(string email, string password, string firstName, string lastName, string creditCard)
        {
            Customer customer = new Customer(firstName, lastName, password, email, creditCard);
            CustomerDictionary newCustomer = new CustomerDictionary();

            newCustomer.customerInformation.TryAdd(customer.Email, customer);

        }

        public void DeleteAccount(string account, string password, string email) 
        {
        
        }

        

    }
}
