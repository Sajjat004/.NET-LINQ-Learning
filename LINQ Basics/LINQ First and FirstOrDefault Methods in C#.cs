using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class Test
    {
        public static void Main()
        {
            // First Method
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            int firstElement = numbers.First();
            Console.WriteLine(firstElement); // Output: 1

            // FirstOrDefault Method
            List<int> numbers1 = new List<int>();
            int firstElement1 = numbers1.FirstOrDefault();
            Console.WriteLine(firstElement1); // Output: 0

            // First Method with Predicate
            List<int> numbers2 = new List<int> { 1, 2, 3, 4, 5 };
            int firstElement2 = numbers2.First(n => n > 3);
            Console.WriteLine(firstElement2); // Output: 4

            // FirstOrDefault Method with Predicate
            List<int> numbers3 = new List<int> { 1, 2, 3, 4, 5 };
            int firstElement3 = numbers3.FirstOrDefault(n => n > 5);
            Console.WriteLine(firstElement3); // Output: 0

            // Note: First Method throws an InvalidOperationException if the sequence is empty or if no element satisfies the condition.
            // FirstOrDefault Method returns the default value of the type if the sequence is empty or if no element satisfies the condition.
        }
    }
}