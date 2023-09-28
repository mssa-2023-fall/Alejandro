using MSSAExtension;

namespace MSSAExtensionTest
{
    [TestClass]
    public class MSSAExtensionsTest
    {
        [TestMethod]
        public void TestGetShaStringExtension()
        {
            var file = new FileInfo(@"b:\oscar_age_male.csv");

            Assert.AreEqual("4r7YHwqBQPs26FCqZI+pKwYoQWQ=", file.GetSHAString(StringFormat.Base64));
            Assert.AreEqual("E2BED81F0A8140FB36E850AA648FA92B06284164", file.GetSHAString(StringFormat.Hex));

        }
        [TestMethod]
        public void CustomLinqMethods()
        {
            IEnumerable<int> inputs = new[] { 1, 2, 3, 4, 5, 6, 7 };
            IEnumerable<float> inputs1 = new[] { 1f, 2.3f, 3.9f, 4.95f, 5.25f, 6.94f, 7.41f, 8.5f };
            IEnumerable<int> inputs2 = new[] { 1, 2, 3, 4, 5, 6, 7 };
            float median = inputs.Median();
            Assert.AreEqual(4, median);
              
        }
        
        [TestMethod]
        public void TestIndexDictionary() 
        {
            Dictionary<FileInfo, Stream> dictionary = new Dictionary<FileInfo, Stream>();
            var file = new FileInfo(@"B:\oscar_age_male.csv");
            dictionary.Add(file, file.OpenRead());
            Assert.AreEqual(dictionary[file].Length, file.Length);
        }



    }
}