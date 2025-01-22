using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class Test
    {
        public static void Main()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            var result = numbers.Take(3);
            foreach (var num in result)
            {
                Console.WriteLine(num);
            }

            var result1 = numbers.Take(10);
            foreach (var num in result1)
            {
                Console.WriteLine(num);
            }

            // Note: Take Method returns the specified number of elements from the start of the sequence. If the sequence contains less number of elements, it returns all the elements. If the reference sequence is null, it throws a NullReferenceException.
        }
    }
}