using System;
using System.Collections;
using System.Collections.Generic;

namespace ADOPM3_04_04
{
    class Program
    {
		public class Rectangle : IEquatable<Rectangle>
		{
			public string Color { get; set; }
			public int Height { get; set; }
			public int Width { get; set; }

			public bool Equals(Rectangle other) => (Height, Width, Color) == (other.Height, other.Width, other.Color);

			#region Needed to implement as part of IEquatable
			public override int GetHashCode() => (Width, Height, Color).GetHashCode();  
			public override bool Equals(object obj) => Equals(obj as Rectangle); 
			#endregion
		}
		public class ColorComparer : EqualityComparer<Rectangle>
		{
			public override bool Equals(Rectangle x, Rectangle y) => x.Color == y.Color;
			public override int GetHashCode(Rectangle r) => r.Color.GetHashCode();
		}
		public class AreaComparer : EqualityComparer<Rectangle>
		{
			public override bool Equals(Rectangle x, Rectangle y) => (x.Height * x.Width) == (y.Height * y.Width);
			public override int GetHashCode(Rectangle r) => (r.Height * r.Width).GetHashCode();
		}

		static void Main(string[] args)
        {
			Rectangle r1 = new Rectangle() { Height = 50, Width = 100, Color = "red" };
			Rectangle r2 = new Rectangle() { Height = 50, Width = 100, Color = "red" };
			Rectangle r3 = new Rectangle() { Height = 100, Width = 50, Color = "red" };
			Rectangle r4 = new Rectangle() { Height = 200, Width = 50, Color = "blue" };
			Rectangle r5 = new Rectangle() { Height = 50, Width = 200, Color = "yellow" };

			Console.WriteLine(r1 == r2); // False
			Console.WriteLine(r1.Equals(r2)); // True

            Console.WriteLine();
			var d = new Dictionary<Rectangle, string>();
			d[r1] = "Rectange1"; d[r2] = "Rectange2"; d[r3] = "Rectange3"; d[r4] = "Rectange4"; d[r5] = "Rectange5";
			Console.WriteLine(d.Count); // 4
			Console.WriteLine($"d[r1]:{d[r1]} d[r2]:{d[r2]} d[r3]:{d[r3]} d[r4]:{d[r4]} d[r5]:{d[r5]}"); // Rectangle 2,2,3,4,5

            Console.WriteLine(d[r1]);
			Console.WriteLine(d[r2]);

            foreach (var item in d)
            {
                Console.WriteLine($"key: {item.Key.GetHashCode()}  value:{item.Value}");
            }

			/*
			Console.WriteLine();
			d = new Dictionary<Rectangle, string>(new ColorComparer());
			d[r1] = "Rectange1"; d[r2] = "Rectange2"; d[r3] = "Rectange3"; d[r4] = "Rectange4"; d[r5] = "Rectange5";
			Console.WriteLine(d.Count); // 3
			Console.WriteLine($"d[r1]:{d[r1]} d[r2]:{d[r2]} d[r3]:{d[r3]} d[r4]:{d[r4]} d[r5]:{d[r5]}"); // Rectangle 3,3,3,4,5
			
			foreach (var item in d)
			{
				Console.WriteLine($"key: {item.Key.Height}  value:{item.Value}");
			}


			
            Console.WriteLine();
			d = new Dictionary<Rectangle, string>(new AreaComparer());
			d[r1] = "Rectange1"; d[r2] = "Rectange2"; d[r3] = "Rectange3"; d[r4] = "Rectange4"; d[r5] = "Rectange5";
			Console.WriteLine(d.Count); // 2
			Console.WriteLine($"d[r1]:{d[r1]} d[r2]:{d[r2]} d[r3]:{d[r3]} d[r4]:{d[r4]} d[r5]:{d[r5]}"); // Rectangle 3,3,3,5,5
			*/
		}

		// Exercises:
		//1.	Explain why the count decreases in the 3 dictionaries while still 5 elements are accessible

	}
}
