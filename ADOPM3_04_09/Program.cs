using System;
using System.Collections.Generic;

namespace ADOPM3_04_09
{
    class Program
    {
        public enum RectColor
        {
            red, blue, yellow, white, pink
        }
        public class Rectangle : IEquatable<Rectangle>
        {
            public RectColor Color { get; set; }
            public int Height { get; set; }
            public int Width { get; set; }
            public int Area => Height * Width;
            public bool Equals(Rectangle other) => (Height, Width, Color) == (other.Height, other.Width, other.Color);
            public override int GetHashCode() => (Width, Height, Color).GetHashCode();  //Needed to implement as part of IEquatable
            public override bool Equals(object obj) => Equals(obj as Rectangle); //Needed to implement as part of IEquatable
        }
        public class AreaComparer : Comparer<Rectangle>
        {
            public override int Compare(Rectangle x, Rectangle y) =>  x.Area.CompareTo(y.Area);
        }
        static void Main(string[] args)
        {
            //HashSet<T>
            HashSet<Rectangle> hs1 = new HashSet<Rectangle>() {
                new Rectangle(){ Color = RectColor.yellow, Height = 100, Width = 100 },
                new Rectangle(){ Color = RectColor.white, Height = 15, Width = 20 },
                new Rectangle(){ Color = RectColor.pink, Height = 45, Width =15 }};

            HashSet<Rectangle> hs2 = new HashSet<Rectangle>() {
                new Rectangle(){ Color = RectColor.pink, Height = 45, Width =15 },
                new Rectangle(){ Color = RectColor.red, Height = 10, Width = 20 },
                new Rectangle(){ Color = RectColor.blue, Height = 10, Width = 20 }};

            hs1.UnionWith(hs2);
            new List<Rectangle>(hs1).ForEach(r => Console.WriteLine($"Color: {r.Color}  Area:{r.Area}")); 
            // yellow, white, pink, pink, red, blue

            SortedSet<Rectangle> hs3 = new SortedSet<Rectangle>(new AreaComparer()) {
                new Rectangle() { Color = RectColor.yellow, Height = 100, Width = 100 },
                new Rectangle() { Color = RectColor.white, Height = 15, Width = 200 },
                new Rectangle() { Color = RectColor.pink, Height = 45, Width =15 },
                new Rectangle() { Color = RectColor.red, Height = 10, Width = 20 },
                new Rectangle() { Color = RectColor.blue, Height = 10, Width = 20 }};

            SortedSet<Rectangle> hs4 = new SortedSet<Rectangle>(new AreaComparer()) {
                new Rectangle() { Color = RectColor.blue, Height = 100, Width = 100 },
                new Rectangle() { Color = RectColor.red, Height = 15, Width = 200 },
                new Rectangle() { Color = RectColor.pink, Height = 45, Width =15 },
                new Rectangle() { Color = RectColor.white, Height = 10, Width = 20 },
                new Rectangle() { Color = RectColor.yellow, Height = 10, Width = 20 }};

            hs3.UnionWith(hs4);
            Console.WriteLine();
            new List<Rectangle>(hs3).ForEach(r => Console.WriteLine($"Color: {r.Color}  Area:{r.Area}")); 
            //red, pink, white, yellow
        }
    }

    //Exercise
    //1.   Why does not blue appear in the last UnionWith. Explain
    //2.   Modify the AreaComparer so sorting is first on red < blue < yellow < white < pink and then on Area size. 
    //3.   Remove all pink and blue rectangles from hs2 by using RemoveWhere and Lambda Expressions
}
