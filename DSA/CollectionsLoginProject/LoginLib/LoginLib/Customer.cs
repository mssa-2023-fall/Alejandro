using CustomerLogin;
using System.Security.Cryptography;
using System.Text;

namespace LoginLib
{
    public class Customer
    {
        private CryptoHelper _cryptoHelper = new();
        
        public byte[] PassHash { get;  }
        public string FirstName { get;  }
        public string LastName { get;  }
        public string Email { get;  }
        public byte[] Salt;
        public Customer(string first, string last, string password, string email)
        {
           
            Email = email;
            FirstName = first;
            LastName = last;
            Salt = RandomNumberGenerator.GetBytes(64);
            PassHash = _cryptoHelper.ComputeHash(password, Salt);
        }
    }
}