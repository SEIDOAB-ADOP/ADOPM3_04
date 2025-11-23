using System;
using System.Collections; // needed as IEnumerable<> implmenents IEnumerable.
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ADOPM3_04_03
{
	public class EnumerableSimple : IEnumerable<int>
	{
		int[] data = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
		public int this[int idx] => data[idx]; 

		public int Length => data.Length;
		
		
		public IEnumerator<int> GetEnumerator()
		{
			foreach (int i in data)
				yield return i;
		}

		// 	/*
		// 	for (int i = 4; i < 8; i++)
		// 	{
        //         yield return data[i];
        //     }
		// 	*/
			
        // }
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator(); 
		// needed as IEnumerable<> implmenents IEnumerable.
		// keep private
																
	}
	public class EnumerableFromScratch : IEnumerable<int>
	{
		int[] data = { 1, 2, 3 };

		public IEnumerator<int> GetEnumerator() => new EnumeratorFromScratch(this);
		IEnumerator IEnumerable.GetEnumerator() => new EnumeratorFromScratch(this); // needed as IEnumerable<> implmenents IEnumerable. 
																					// keep private

		class EnumeratorFromScratch : IEnumerator<int>
		{
			int currentIndex = -1;
			EnumerableFromScratch collection;

			internal EnumeratorFromScratch(EnumerableFromScratch collection) => this.collection = collection;

			public int Current { get { return collection.data[currentIndex]; } }
			object IEnumerator.Current { get { return Current; } } // needed as IEnumerable<> implmenents IEnumerable. Private
			public bool MoveNext() => ++currentIndex < collection.data.Length;
			public void Reset() => currentIndex = -1;

			void IDisposable.Dispose() { } // Needed by IEnumerable<> in case unmanged memory needs to be released
		}
	}
	class Program
    {
        static void Main(string[] args)
        {
            var myClass = new EnumerableSimple();
			for (int i = 0; i < myClass.Length; i++)
			{
				System.Console.WriteLine(myClass[i]);
			}


			// for (int i = 0; i < myClass.Length; i++)
			// {
			// 	Console.WriteLine(myClass[i]);
			// }
			foreach (var item in myClass.Take(5).Reverse())
			{
				Console.WriteLine(item);
			}

            /*
			var myClass = new EnumerableSimple();
			foreach (int element in myClass)
				Console.WriteLine(element); // 1, 2, 3
			*/
            /*
            Console.WriteLine();
			foreach (int i in new EnumerableFromScratch())
				Console.WriteLine(i);
			*/
        }
    }

	//Exercise:
	//1.	Why the internal keyword for the constructor of EnumeratorFromScratch, try private. What happens? Why not public?
	//2.	Go through the code with the debugger step by step and explore what happens. Particular around the yield return statment,
	//		Current, MoveNext and Reset. Explore variables as you debug. Discuss in the group so you understand the flow. Explain
	//3.	Iterate over EnumerableFromScratch using Current, MoveNext and Reset. Printout as you iterate.
	//4.	Create a class type Shapes, which implements IEnumerable<Shape> with simple iterator. Shape from Example 1.19. Populate with
	//		Triangles and Rectangles and enumerate of Shapes both with foreach.
	//5.	Create a class type Shapes, which implements IEnumerable<Shape> from scratch. Shape from Example 1.19. Populate with
	//		Triangles and Rectangles and enumerate of Shapes both with foreach and with Current, MoveNext and Reset
}
