using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class Test
    {
        public static void Main()
        {
            // Step 1: Data Source
            List<int> numbers = new List<int>() 
            { 
                0, 1, 2, 3, 4, 5, 6, 7, 8, 9 
            };

            // Step 2: Query Creation
            var sum = (from num in numbers
                       where num > 5
                       select num).Sum();
            
            // Step 3: Query Execution
            Console.WriteLine(sum);
        }
    }
}