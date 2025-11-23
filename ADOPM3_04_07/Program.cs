using System;
using System.Collections;

namespace ADOPM3_04_07
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creates and initializes several BitArrays.
            BitArray myBA2 = new BitArray(5, false);
            PrintValues(myBA2, 8);

            byte[] myBytes = new byte[5] { 1, 2, 3, 4, 5 };
            BitArray myBA3 = new BitArray(myBytes);
            PrintValues(myBA3, 8);

            bool[] myBools = new bool[5] { true, false, true, true, false };
            BitArray myBA4 = new BitArray(myBools);
            PrintValues(myBA4, 8);

            int[] myInts = new int[5] { 6, 7, 8, 9, 10 };
            BitArray myBA5 = new BitArray(myInts);
            PrintValues(myBA5, 8);
            PrintValues(myBA5.Not(), 8);    //Bitwise manipulation is easy

        }

        // Note Type IEnumerable, very useful way of passing collections
        public static void PrintValues(IEnumerable myList, int myWidth) 
        {
            int i = myWidth;
            foreach (Object obj in myList)
            {
                if (i % myWidth == 0) Console.WriteLine();
                Console.Write($"{obj,10}");
                i++;
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
