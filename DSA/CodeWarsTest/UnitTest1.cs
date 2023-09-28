namespace CodeWarsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod()
        {
            var test = new int[] { 2, 4, 6, 8, 2, 5, 4, 3, 2 };
            Func<int, bool> isEven = (value) => value % 2 == 0;

            var result = DropWhile(test, isEven);
        }
        [TestMethod]
        public static int[] DropWhile(int[] input, Func<int, bool> predicate)
        {
            if (input.Length == 0) { return new int[0]; }
            int index = 0;
            while (predicate(input[index]))
            {
                index++;
                if (index == input.Length) { return new int[0]; }
            }
            return input[index..];
        }


    }
}