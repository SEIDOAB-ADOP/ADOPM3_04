using System;
using System.ComponentModel;
using System.Text;

namespace ADOPM3_04_06
{
    class Program
    {
        struct A { int i; int p; }
        static void Main(string[] args)
        {
            int[] a = {1,2,3};
            //Array.Clear(a, 0, a.Length);

            foreach (var item in a)
            {
                Console.WriteLine(item);
            }

            Array.ForEach(a, myPrint);
            Array.ForEach(a, (int i) => {
                Console.WriteLine(i);
            });
            Array.ForEach(a, i => Console.WriteLine(i));


            int[] newA = Array.ConvertAll<int, int>(a, (int i) => 3 * i);
            Array.ForEach(newA, i => Console.WriteLine(i));

            A[] mystruct = new A[5];

            StringBuilder[] builders = new StringBuilder[5];
            builders[0] = new StringBuilder("builder0");
            builders[1] = new StringBuilder("builder1");
            builders[2] = new StringBuilder("builder2");

            StringBuilder[] builders2 = builders; // Copy of the reference, One array
            builders[2].Append("...added to builders");
            Console.WriteLine(builders2[2]); // builder2...added to builders

            StringBuilder[] shallowClone = (StringBuilder[])builders.Clone();
            builders[2].Append("...change again to builders");
            Console.WriteLine(shallowClone[2]); // builder2...added to builders...change again to builders

            
            //Convert array to lengths using Lambda Expression delegate
            int?[] builder_lengths = Array.ConvertAll<StringBuilder, int?>(builders2, sb => sb?.Length);
            foreach (int? i in builder_lengths)
                Console.WriteLine(i); //8, 8, 55
            
        }

        static void myPrint(int i)
        {
            Console.WriteLine(i);
        }
    }

    //Exercises:
    //1.    Make a deep Clone of array "builders". Make a textual change to all elements in array "builders" using Lambda Expressions.
    //      Printout and confirm that the deep clone is unchanged
    //2.    Make a deep Clone of array "builders" using Lambda Expressions
}
