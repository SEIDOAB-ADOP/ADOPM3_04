using System;
using System.Collections.Generic;

namespace ADOPM3_04_08
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
                new Rectangle(){ Color = "blue", Height = 10, Width = 20 },
                new Rectangle(){ Color = "yellow", Height = 100, Width = 100 },
                new Rectangle(){ Color = "white", Height = 15, Width = 200 },
                new Rectangle(){ Color = "pink", Height = 45, Width =15 }};

            //Sort and print the list using Lambda Expression
            list1.Sort((r1, r2) =>
            {
                if (r1.Area != r2.Area)
                    return r1.Area.CompareTo(r2.Area);
                return r1.Color.CompareTo(r2.Color);
            }
            );
            
            list1.ForEach(r => Console.WriteLine($"Area: {r.Area}, Color:{r.Color}")); // red, blue, pink, white, yellow
            foreach (var r in list1)
            {
                Console.WriteLine($"Area: {r.Area}, Color:{r.Color}");
            }

            var list2 = list1.ConvertAll(r => r.Area);
            list2.ForEach(r => Console.WriteLine(r));

            
            //Queue<T>
            Queue<Rectangle> queue1 = new Queue<Rectangle>();
            queue1.Enqueue(new Rectangle() { Color = "red", Height = 10, Width = 20 });
            queue1.Enqueue(new Rectangle(){ Color = "blue", Height = 10, Width = 20 });
            queue1.Enqueue(new Rectangle(){ Color = "yellow", Height = 100, Width = 100 });
            queue1.Enqueue(new Rectangle(){ Color = "white", Height = 15, Width = 200 });
            queue1.Enqueue(new Rectangle(){ Color = "pink", Height = 45, Width =15 });

            Rectangle r1 = queue1.Dequeue();
            Console.WriteLine(r1.Color); // red

            r1 = queue1.Dequeue();
            Console.WriteLine(r1.Color); // blue

            r1 = queue1.Peek();
            Console.WriteLine(r1.Color); // yellow
            
            Console.WriteLine(queue1.Contains(new Rectangle() { Color = "yellow", Height = 100, Width = 100 })); //true

            
            //Stack<T>
            Stack<Rectangle> stack1 = new Stack<Rectangle>();
            stack1.Push(new Rectangle() { Color = "red", Height = 10, Width = 20 });
            stack1.Push(new Rectangle() { Color = "blue", Height = 10, Width = 20 });
            stack1.Push(new Rectangle() { Color = "yellow", Height = 100, Width = 100 });
            stack1.Push(new Rectangle() { Color = "white", Height = 15, Width = 200 });
            stack1.Push(new Rectangle() { Color = "pink", Height = 45, Width = 15 });

            Rectangle r2 = stack1.Pop();
            Console.WriteLine(r2.Color); // pink

            r2 = stack1.Pop();
            Console.WriteLine(r2.Color); // white

            r2 = stack1.Peek();
            Console.WriteLine(r2.Color); // yellow
           
        }
    }

    //Exercises:
    //1.    Remove the IEquatable<Rectangle> and run the code. Will stack1.Contains work? Explain.
    //2.    Modify Code and use Contains on all 3 collections.

}
