using Azure;
using Azure.Data.Tables;
using CustomerLogin;
using System.Security.Cryptography;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Security.KeyVault.Keys.Cryptography;

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
        public byte[] CreditCardHash { get; }
        public Customer(string first, string last, string password, string email, string creditCard, CryptographyClient? _cryptographicClient=null)
        {
            Salt = RandomNumberGenerator.GetBytes(64);
            Email = email;
            FirstName = first;
            LastName = last;
            PassHash = _cryptoHelper.ComputeHash(password, Salt);
            if (_cryptographicClient != null)
            { CreditCardHash = _cryptographicClient.Encrypt(EncryptionAlgorithm.RsaOaep, Encoding.UTF8.GetBytes(creditCard)).Ciphertext; }
            else {CreditCardHash = _cryptoHelper.EncryptCreditCard(password, creditCard).Result; }
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