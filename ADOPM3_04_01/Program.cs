using System;

namespace ADOPM3_04_01
{
    class Program
    {
        [Flags]
        enum Days
        {
            None = 0b_0000_0000,  // 0
            Monday = 0b_0000_0001,  // 1
            Tuesday = 0b_0000_0010,  // 2
            Wednesday = 0b_0000_0100,  // 4
            Thursday = 0b_0000_1000,  // 8
            Friday = 0b_0001_0000,  // 16
            Saturday = 0b_0010_0000,  // 32
            Sunday = 0b_0100_0000,  // 64
            Weekend = Saturday | Sunday
        }
        static void Main(string[] args)
        {
            //enumerate a string
            foreach (char c in "beer")
            {
                Console.WriteLine(c); // b, e, e, r,
            }

            
            Console.WriteLine();
            //Same as above mor more explicit
            using (var enumerator = "beer".GetEnumerator())
                while (enumerator.MoveNext())
                {
                    var element = enumerator.Current;
                    Console.WriteLine(element); // b, e, e, r,
                }

            
            Console.WriteLine();
               //enumerate an enum
            foreach (Days day in Enum.GetValues(typeof(Days)))
                Console.WriteLine($"{day} = {(int)day:X4}"); // None = 0000 ... Weekend = 0060

            Console.WriteLine();
            foreach (Days day in typeof(Days).GetEnumValues())
                Console.WriteLine($"{day} = {(int)day:X4}"); // None = 0000 ... Weekend = 0060

            Console.WriteLine();
            //enumerate  an array
            int[] array2 = new int[] { 1, 3, 5, 7, 9 };
            int[] array3 = Array.FindAll<int>(array2, x => x > 3);

            foreach (int i in array3)
            {
                Console.WriteLine(i); // 5, 7, 9
            }
        }
    }
}
