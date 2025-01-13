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
            //LINQ Query using Query Syntax to fetch all numbers which are > 5
            var querySyntax = from num in numbers // Data Source
                            where num > 5 // Condition
                            select num; // Selection

            // Step 3: Query Execution
            foreach (var num in querySyntax)
            {
                Console.WriteLine(num);
            }
        }
    }
}