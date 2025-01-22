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
            var result = numbers.SkipWhile(n => n < 3);
            foreach (var num in result)
            {
                Console.WriteLine(num);
            }

            var result1 = numbers.SkipWhile(n => n < 10);
            foreach (var num in result1)
            {
                Console.WriteLine(num);
            }

            // Note: SkipWhile Method skips elements from the start of the sequence until the condition is false and returns the rest of the elements. If the reference sequence is null, it throws a NullReferenceException.
        }
    }
}