using System;
using System.Collections.Generic;
using System.Linq;

namespace ADOPM3_04_10
{
    class Program
    {
        class Car : IEquatable<Car>
        {
            public int Year { get; set; }
            public string Make { get; set; }

            public override string ToString() => $"Year: {Year}, Make: {Make}";

            //IEquatable
            public override int GetHashCode() => (Year, Make).GetHashCode();
            public bool Equals(Car other) => (Year, Make) == (other.Year, other.Make);
            public override bool Equals(object obj) => Equals(obj as Car);
        }

        static void Main(string[] args)
        {
            //List of cars
            List<Car> listRegNr= new List<Car>();
            listRegNr.Add(new Car { Year = 2022, Make = "Volvo" });
            listRegNr.Add(new Car { Year = 2019, Make = "Suzuki" });
            System.Console.WriteLine(listRegNr[0]);
            Car myCar0 = listRegNr[0];
            System.Console.WriteLine(myCar0.GetHashCode());
            
            //Dictionary of cars
            Dictionary<string, Car> dicRegNr= new Dictionary<string, Car>();
            dicRegNr.Add("NMN 854", new Car { Year = 2022, Make = "Volvo" });
            dicRegNr.Add("YMY 789", new Car { Year = 2019, Make = "Suzuki" });
            
            System.Console.WriteLine("NMN 854".GetHashCode());

            //Accessing the Dictionary
            Console.WriteLine(dicRegNr["NMN 854"]);
            Car myCar = dicRegNr["YMY 789"];
            Console.WriteLine(myCar);

            //Using Car as Key
            Dictionary<Car, string> dicCarUri = new Dictionary<Car, string>();
            dicCarUri[new Car { Year = 2019, Make = "Suzuki" }] = "Uri to webpages for suzuki";
            dicCarUri[new Car { Year = 2022, Make = "Volvo" }] = "Uri to webpages for volvo";
            System.Console.WriteLine(dicCarUri[myCar0]);
            System.Console.WriteLine(dicCarUri[myCar]);


            //Value in Dictionary can be of any type, also a List
            Dictionary<string, List<string>> dicFavoriteBands = new Dictionary<string, List<string>>();

            dicFavoriteBands.Add("AC/DC", new List<string>() { "Fly on the Wall", "TnT", "For those about to Rock" });
            dicFavoriteBands.Add("Pink Floyd", new List<string>() { "Dark side of the moon", "The Wall", "Final Cut" });
            dicFavoriteBands.Add("Bob Dylan", new List<string>() { "Infidels", "Slow Train Comming" });

            Console.WriteLine();
            var l = dicFavoriteBands["AC/DC"];
            l.ForEach(item => Console.WriteLine(item));

            //Dictionay Keys and Values can be accessed as collections
            foreach (var performer in dicFavoriteBands.Keys)
            {
                Console.WriteLine($"\n{performer} albums:");
                foreach (var album in dicFavoriteBands[performer])
                {
                    Console.WriteLine(album);
                }
            }

            //Fast check if a Dictionary contains a key
            Console.WriteLine(dicFavoriteBands.ContainsKey("Abba"));
            var myAlbums = dicFavoriteBands.ToList();


            //Keys can also be of a complex type, because the IEquatable are used
            Dictionary<Car, List<string>> dicSpareParts = new Dictionary<Car, List<string>>();

            dicSpareParts.Add(new Car { Year = 2022, Make = "Volvo" },
                new List<string>(){ "Sparepart1 for a 2020 Volvo", "Sparepart2 for a 2020 Volvo"});

            dicSpareParts.Add(new Car { Year = 2019, Make = "Suzuki" },
                new List<string>() { "Sparepart1 for a 2019 Suzuki", "Sparepart2 for a 2019 Suzuki",
                                     "Sparepart3 for a 2019 Suzuki", "Sparepart3 for a 2019 Suzuki"});

            foreach (var car in dicSpareParts.Keys)
            {
                Console.WriteLine($"\nSpareparts for {car}:");
                foreach (var parts in dicSpareParts[car])
                {
                    Console.WriteLine(parts);
                }
            }
        }
    }
}
