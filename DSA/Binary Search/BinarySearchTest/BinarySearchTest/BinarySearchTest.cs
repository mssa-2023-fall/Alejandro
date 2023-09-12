using System.Drawing;
using BinarySearch;
namespace BinarySearchTest
{
    [TestClass]
    public class BinarySearchTest
    {
        

        [TestMethod]
        public void BinarySearchShouldReturnNegativeOneWhenItemIsAboveMaxorBelowMin()
        {
            int[] sorted = GenerateSortedNumber(200);
            int result = AlexBinarySearch.Binaries(sorted, 500);
            Assert.AreEqual(-1, result);
            result = AlexBinarySearch.Binaries(sorted, -10);
            Assert.AreEqual(-1, result);
        }
        
        
        [TestMethod]
        public void BinarySearchShouldWorkWith0ElementArray()
        {
            int[] empty = { };

            Assert.ThrowsException<ArgumentException>(() => AlexBinarySearch.Binaries(empty, 5));

        }

        [TestMethod]
        public void BinarySearchShouldWorkWith256ElementArray()
        {
            int[] sorted = GenerateSortedNumber(256);

            int result = AlexBinarySearch.Binaries(sorted, 0);
            Assert.AreEqual(0, result);
            result = AlexBinarySearch.Binaries(sorted, 255);
            Assert.AreEqual(255, result);

        }
        

        public static int[] GenerateRandomNumber(int size)
        {
            var array = new int[size];
            var rand = new Random();
            var maxNum = 10000;

            for (int i = 0; i < size; i++)
                array[i] = rand.Next(maxNum + 1);

            Array.Sort(array);
            return array;
        }
        public static int[] GenerateSortedNumber(int size)
        {
            var array = new int[size];

            for (int i = 0; i < size; i++)
                array[i] = i;

            return array;
        }

        

    }


}