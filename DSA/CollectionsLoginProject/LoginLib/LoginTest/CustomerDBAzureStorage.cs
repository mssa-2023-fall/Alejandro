using Azure;
using Azure.Data.Tables;
using Azure.Identity;
using Azure.Security.KeyVault.Keys;
using Azure.Security.KeyVault.Keys.Cryptography;
using LoginLib;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LoginTest
{
    [TestClass]
    public class CustomersDBAzureStorageTest
    {
        private string _tenantID;
        private string _clientID;
        private string _ClientSecret;
        private string _tableConnStr;
        private string _tableName;
        private string _keyVaultUri;
        private TableServiceClient _tableServiceClient;
        private KeyClient _keyClient;
        private CryptographyClient _key;


        [TestInitialize]
        public void init()                                                                
        {                                                                                 
            var config = new ConfigurationBuilder()                                       
                .AddUserSecrets(Assembly.GetExecutingAssembly(), true)                    
                .Build();                                                                 
            _tenantID = config["Azure:TenantID"];                                         
            _clientID = config["Azure:ClientID"];
            _ClientSecret = config["Azure:ClientSecret"];
            _tableConnStr = config["Azure:TableConnStr"];
            _tableName = config["Azure:TableName"] + Guid.NewGuid().ToString().Substring(0, 4);//append guid to avoid delay in deleting the table
            _keyVaultUri = config["Azure:KeyVaultUri"];
            //code to create a table: _tableName
            _tableServiceClient = new TableServiceClient(_tableConnStr);
            _tableServiceClient.CreateTableIfNotExists(_tableName);
            //create Key Client
            _keyClient = new KeyClient(new Uri(_keyVaultUri), new ClientSecretCredential(_tenantID, _clientID, _ClientSecret));
            _key = _keyClient.GetCryptographyClient("mssa");
        }

        [TestMethod]
        public void EncryptDecryptWithKeyVault()
        {
            
            var plaintText = "Hello World";
            byte[] encryptedKeyResult = _key.Encrypt(EncryptionAlgorithm.RsaOaep,Encoding.UTF8.GetBytes(plaintText)).Ciphertext;
            byte[] decyptedKeyResult = _key.Decrypt(EncryptionAlgorithm.RsaOaep, encryptedKeyResult).Plaintext;
            string decryptedText = Encoding.UTF8.GetString(decyptedKeyResult);

            Assert.AreEqual(plaintText, decryptedText);
            

        }

        [TestMethod]
        public void ConfirmTenantIDAndOtherVariables()
        {
            Assert.AreEqual("75202359-8ca2-4185-af85-e8d288e60729", _tenantID);
            Assert.AreEqual("595c2c90-3888-428a-9b28-4574aeb9b706", _clientID);
        }
        [TestMethod]
        public void EntityInsertAndRetreiveTest()
        {
            TableClient _testTable = _tableServiceClient.GetTableClient(_tableName);
            var tableEntity = new TableEntity("x", "y")
                {
                    { "Product", "Marker Set" },
                    { "Price", 5.00 },
                    { "Quantity", 21 }
                };
            _testTable.AddEntity(tableEntity);
            var result = _testTable.GetEntity<TableEntity>("x", "y").Value;

            Assert.AreEqual("Marker Set", result.GetString("Product"));
            Assert.AreEqual(5.00d, result.GetDouble("Price"));
            Assert.AreEqual(21, result.GetInt32("Quantity"));

        }

        [TestMethod]
        public void CustomerInsertAndRetrieveTest()
        {
            TableClient _testTable = _tableServiceClient.GetTableClient(_tableName);
            Customer testCustomer = new Customer("Frank","Gambino", "password","FrankTheTank@RedHat.com", "11112222");
            _testTable.AddEntity(testCustomer);
            
        }

        [TestMethod]
        public void CustomerInsterAndQueryTest()
        {
            TableClient _testTable = _tableServiceClient.GetTableClient(_tableName);
            Customer testCustomer = new Customer("Mike", "West", "password", "TheRealMike@RedHat.com", "11112222");
            Customer testCustomer1 = new Customer("Adam", "Christensen", "password", "Spades@RedHat.com", "11112222");
            Customer testCustomer2 = new Customer("David", "Williams", "password", "Diamonds@RedHat.com", "11112222");

            _testTable.AddEntity(testCustomer);
            _testTable.AddEntity(testCustomer1);
            _testTable.AddEntity(testCustomer2);
            var result = testCustomer.FirstName;

            Assert.AreEqual(testCustomer.FirstName, "Mike");
            Assert.AreEqual(testCustomer1.FirstName, "Adam");
            Assert.AreEqual(result.Count(), 4);

        }

        //Insert a test record and confirm we can read it back
        [TestCleanup]
        public void Cleanup()
        {
            //code to delete a table: _tableName
            _tableServiceClient.DeleteTable(_tableName);
        }

        // install storage explorer from here: https://go.microsoft.com/fwlink/?linkid=2216182&clcid=0x409
    }
}
