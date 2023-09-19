using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

namespace MSSAExtension
{
    public enum StringFormat
    {
        Base64,
        Hex
    }
    public static class MSSAExtensions
    {
        public static string GetSHAString(this FileInfo fileInfo, StringFormat stringFormat = StringFormat.Hex)
        {
            using (var sha1 = SHA1.Create())
            {
                byte[] fileHash = sha1.ComputeHash(fileInfo.OpenRead());
                return stringFormat switch
                {
                    StringFormat.Base64 => Convert.ToBase64String(fileHash),
                    StringFormat.Hex => Convert.ToHexString(fileHash),
                    _ => Convert.ToBase64String(fileHash)

                };

            }
        }

         public static T FindMedian<T>(IEnumerable<T> values)
        {
            List<T> sortedValues = values.OrderBy(v => v).ToList();

            int count = sortedValues.Count;

            if (count == 0)
            {
                throw new InvalidOperationException("The input collection is empty.");
            }

            if (count % 2 == 0)
            {
                // If there's an even number of elements, return the average of the middle two.
                int middleIndex = count / 2;
                T middleValue1 = sortedValues[middleIndex - 1];
                T middleValue2 = sortedValues[middleIndex];
                dynamic result = (dynamic)middleValue1 + (dynamic)middleValue2;
                return result / 2;
            }
            else
            {
                // If there's an odd number of elements, return the middle element.
                int middleIndex = count / 2;
                return sortedValues[middleIndex];
            }
        }

        public static T Median<T>(IEnumerable<T> values)
        {
            var sorted = values.OrderBy(v => v).ToList();
            var middle = sorted.Count / 2;
            return sorted[middle];


        }

        
    }
}





        

        
    
