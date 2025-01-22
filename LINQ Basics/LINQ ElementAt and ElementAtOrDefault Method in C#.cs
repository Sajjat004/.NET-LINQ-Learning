using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class Test
    {
        public static void Main()
        {
            // ElementAt Method
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            int element = numbers.ElementAt(2);
            Console.WriteLine(element); // Output: 3

            // ElementAtOrDefault Method
            List<int> numbers1 = new List<int> { 1, 2, 3, 4, 5 };
            int element1 = numbers1.ElementAtOrDefault(10);
            Console.WriteLine(element1); // Output: 0

            // Note: ElementAt Method throws an ArgumentOutOfRangeException if the index is out of range. 
            // ElementAtOrDefault Method returns the default value of the type if the index is out of range.

        }
    }
}