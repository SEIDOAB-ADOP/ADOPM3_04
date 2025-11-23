using System;
using System.Collections.Generic;
using System.Linq;

namespace ADOPM3_04_05
{
    class Program
    {
		public class Rectangle : IEquatable<Rectangle>, IComparable<Rectangle>
		{
			public string Color { get; set; }
			public int Height { get; set; }
			public int Width { get; set; }

			public bool Equals(Rectangle other) => (Height, Width, Color) == (other.Height, other.Width, other.Color);

			#region Needed to implement as part of IEquatable
			public override int GetHashCode() => (Width, Height, Color).GetHashCode();  
			public override bool Equals(object obj) => Equals(obj as Rectangle);
			#endregion

			public static bool operator == (Rectangle r1, Rectangle r2) => r1.Equals(r2);
			public static bool operator !=(Rectangle r1, Rectangle r2) => !r1.Equals(r2);

			public int CompareTo(Rectangle other)
            {
				if (this.Color != other.Color)
					return this.Color.CompareTo(other.Color);
				
				return this.Height.CompareTo(other.Height);
            }

			public Rectangle() { }
			public Rectangle (Rectangle src)
            {
				this.Color = src.Color;
				this.Height = src.Height;
				this.Width = src.Width;
            }
		}
		public class AreaComparer : Comparer<Rectangle>
		{
			public override int Compare(Rectangle x, Rectangle y) => (x.Height * x.Width).CompareTo(y.Height * y.Width);
		}

		static void Main(string[] args)
		{
			Rectangle r1 = new Rectangle() { Height = 50, Width = 100, Color = "red" };

			Rectangle r2 = new Rectangle() { Height = 50, Width = 100, Color = "red" };
			Rectangle r3 = new Rectangle() { Height = 70, Width = 20, Color = "red" };
			Rectangle r4 = new Rectangle() { Height = 200, Width = 50, Color = "blue" };
			Rectangle r5 = new Rectangle() { Height = 50, Width = 30, Color = "yellow" };

			Console.WriteLine(r1 == r2); // False
			Console.WriteLine(r1.Equals(r2)); // True


			var r6 = r1;					//shallow copy
			var r7 = new Rectangle(r1);     //Deep copy

			//
			Rectangle[] RectArray1 = new Rectangle[] { r1, r2, r3, r4, r5 };
			Rectangle[] RectArray2 = (Rectangle[]) RectArray1.Clone();			//shallow copy

			var RectArray3 = RectArray1.Select(item => new Rectangle(item));	//deep copy



			Console.WriteLine();
			var d = new SortedList<Rectangle, string>();
			d[r1] = "Rectange1"; d[r2] = "Rectange2"; d[r3] = "Rectange3"; d[r4] = "Rectange4"; d[r5] = "Rectange5";
			Console.WriteLine(d.Count); // 3
			foreach (string s in d.Values)
				Console.WriteLine(s); // Rectangle 4, 3, 5

            Console.WriteLine();
			d = new SortedList<Rectangle,string>(new AreaComparer());
			d[r1] = "Rectange1"; d[r2] = "Rectange2"; d[r3] = "Rectange3"; d[r4] = "Rectange4"; d[r5] = "Rectange5";
			Console.WriteLine(d.Count); // 4
			foreach (string s in d.Values)
				Console.WriteLine(s); // Rectangle 3, 5, 2, 4
 		}

		// Exercises:
		//1.	Modify the AreaComparer so sorting is first on red < blue < yellow and then on Area size. 
	}
}
