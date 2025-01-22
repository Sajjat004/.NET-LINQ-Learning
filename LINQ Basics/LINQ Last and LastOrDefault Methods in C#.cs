using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class Test
    {
        public static void Main()
        {
            // Last Method
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            int lastElement = numbers.Last();
            Console.WriteLine(lastElement); // Output: 5

            // LastOrDefault Method
            List<int> numbers1 = new List<int>();
            int lastElement1 = numbers1.LastOrDefault();
            Console.WriteLine(lastElement1); // Output: 0

            // Last Method with Predicate
            List<int> numbers2 = new List<int> { 1, 2, 3, 4, 5 };
            int lastElement2 = numbers2.Last(n => n > 3);
            Console.WriteLine(lastElement2); // Output: 5

            // LastOrDefault Method with Predicate
            List<int> numbers3 = new List<int> { 1, 2, 3, 4, 5 };
            int lastElement3 = numbers3.LastOrDefault(n => n > 5);
            Console.WriteLine(lastElement3); // Output: 0

            // Note: Last Method throws an InvalidOperationException if the sequence is empty or if no element satisfies the condition.
            // LastOrDefault Method returns the default value of the type if the sequence is empty or if no element satisfies the condition.
        }
    }
}