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
            var result = numbers.TakeWhile(n => n < 4);
            foreach (var num in result)
            {
                Console.WriteLine(num);
            }

            var result1 = numbers.TakeWhile(n => n < 10);
            foreach (var num in result1)
            {
                Console.WriteLine(num);
            }

            // Note: TakeWhile Method returns elements from the start of the sequence until the condition is false. If the reference sequence is null, it throws a NullReferenceException.
        }
    }
}