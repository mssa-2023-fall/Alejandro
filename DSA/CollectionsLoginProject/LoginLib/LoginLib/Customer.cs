using Azure;
using Azure.Data.Tables;
using CustomerLogin;
using System.Security.Cryptography;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginLib 
{
    public class Customer : ITableEntity
    {
        private CryptoHelper _cryptoHelper = new();

        //JSON deserializer will match json property to the public fields below
        public byte[] PassHash;
        public string FirstName;
        public string LastName;
        public string Email;
        public byte[] Salt;
        public Customer(string first, string last, string password, string email)
        {
            Salt = RandomNumberGenerator.GetBytes(64);
            Email = email;
            FirstName = first;
            LastName = last;
            PassHash = _cryptoHelper.ComputeHash(password, Salt);
        }
        //JSON deserializer will match json property to the public fields below
        public Customer()
        {
            //this is intentionally empty
        }
        //Properties required to implement ITableEntity
        public string PartitionKey { get =>Email ; set => this.Email = value; }
        public string RowKey { get => LastName; set => this.LastName = value; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

        
    }
}