using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ADOPM3_04_11
{
    class Program
    {
        public class Rectangle : IEquatable<Rectangle>
        {
            public string Color { get; set; }
            public int Height { get; set; }
            public int Width { get; set; }
            public int Area => Height * Width;
            public bool Equals(Rectangle other) => (Height, Width, Color) == (other.Height, other.Width, other.Color);
            public override int GetHashCode() => (Width, Height, Color).GetHashCode();  //Needed to implement as part of IEquatable
            public override bool Equals(object obj) => Equals(obj as Rectangle); //Needed to implement as part of IEquatable
        }
        static void Main(string[] args)
        {
            //List<T>
            List<Rectangle> list1 = new List<Rectangle>() {
                new Rectangle(){ Color = "red", Height = 10, Width = 20 },
                new Rectangle(){ Color = "blue", Height = 10, Width = 20 } };



            //Sort and print the list using Lambda Expression
            list1.Add(new Rectangle() { Color = "pink", Height = 5, Width = 5 });
            list1.Sort((r1, r2) => r1.Area.CompareTo(r2.Area));
            list1.ForEach(r => Console.WriteLine(r.Color)); // pink, red, blue


            
            ReadOnlyCollection<Rectangle> readonly_list1 = new ReadOnlyCollection<Rectangle>(list1);

            foreach (Rectangle r in readonly_list1) Console.WriteLine(r.Color); // red, blue
        }
    }

    //Exercise:
    //1.    Inspect the methods of "readonly_list1" and try to add elements to the list
    //2.    Try to manupilate an elements in readonly_list1, can you explain why this thiss still works? (hint: reference vs value types)
    //2.    Create a readonly version of the Dictionary created in Exercise 6_10
}
