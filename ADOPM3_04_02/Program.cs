using System;
using System.Collections.Generic;
using System.Linq;

namespace ADOPM3_04_02
{
    class Program
    {

        static string NotAnEnumerable()
        {
            return "Hello";
            return "World";			//We will never come here
            return "Hello again";
        }
        
		static IEnumerable<string> AnEnumerable()
        {
			yield return "Hello";
			yield return "World";
			yield return "Hello again";
        }

		
		static IEnumerable<string> BogusLatin()
		{
			var latin = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt" +
				" ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris" +
				" nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse" +
				" cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa" +
				" qui officia deserunt mollit anim id est laborum.";
			var words = latin.Split(' ');

			var rnd = new Random();
			for (int i = 0; i < 10; i++)
			{
				yield return words[rnd.Next(0, words.Length)] + " ";
			}			
		}
	
		static IEnumerable<int> Fibs(int fibCount)
		{
			for (int i = 0, prevFib = 1, curFib = 1; i < fibCount; i++)
			{
				yield return prevFib;
				int newFib = prevFib + curFib;
				prevFib = curFib;
				curFib = newFib;
			}
		}
		/*
		static IEnumerable<int> EvenNumbersOnly(IEnumerable<int> sequence)
		{
			foreach (int x in sequence)
				if ((x % 2) == 0)
					yield return x;
		}
		*/
		

		static void Main(string[] args)
        {
			Console.WriteLine(NotAnEnumerable());
			Console.WriteLine(NotAnEnumerable());
			Console.WriteLine(NotAnEnumerable());

            Console.WriteLine();
            foreach (var item in AnEnumerable())
            {
                Console.WriteLine(item);
            }

			var list = AnEnumerable().ToList();

			Console.WriteLine();
            foreach (var item in BogusLatin())
            {
                Console.WriteLine(item);
            }

			System.Console.WriteLine("\nWith Linq");
			foreach (var item in BogusLatin().OrderBy(x => x))
			{
				System.Console.WriteLine(item);
			}



			foreach (var item in Fibs(15))
			{
				Console.WriteLine(item);
			}
			

            /*
			foreach (var item in BogusLatin())
            {
                Console.WriteLine(item);
            }

			
			foreach (int fib in Fibs(15))
				Console.WriteLine(fib);

			
            Console.WriteLine();
			foreach (int fib in EvenNumbersOnly(Fibs(15)))
				Console.WriteLine(fib);
			*/

        }
	}
	//Exercise:
	//1.	Go through the code with the debugger step by step and explore what happens. Particular around the yield return statment.
	//		Explore variables as you debug. Discuss in the group so you understand the flow. Explain
}
