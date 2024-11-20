using System;
using System.Collections.Generic;
using System.Linq;

namespace ADOPM3_04_10
{
    class Program
    {
        class csCar
        {
            public int Year { get; set; }
            public string Make { get; set; }

            public override string ToString() => $"Year: {Year}, Make: {Make}";
            public override int GetHashCode() => (Year, Make).GetHashCode();
        }

        static void Main(string[] args)
        {
            //Dictionary of cars
            Dictionary<string, csCar> dicRegNr= new Dictionary<string, csCar>();
            dicRegNr.Add("NMN 854", new csCar { Year = 2022, Make = "Volvo" });
            dicRegNr.Add("YMY 789", new csCar { Year = 2019, Make = "Suzuki" });
            
            //Accessing the Dictionary
            Console.WriteLine(dicRegNr["NMN 854"].Make);
            csCar myCar = dicRegNr["YMY 789"];
            Console.WriteLine(myCar);


            //Dictionary uses HashCode for the key
            Console.WriteLine();
            Console.WriteLine("NMN 854".GetHashCode());
            Console.WriteLine("YMY 789".GetHashCode());


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


            //Keys can also be of a complex type, because the types hash code is used
            Dictionary<csCar, List<string>> dicSpareParts = new Dictionary<csCar, List<string>>();

            dicSpareParts.Add(new csCar { Year = 2022, Make = "Volvo" },
                new List<string>(){ "Sparepart1 for a 2020 Volvo", "Sparepart2 for a 2020 Volvo"});

            dicSpareParts.Add(new csCar { Year = 2019, Make = "Suzuki" },
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

    //Exercise:
    //1.    Use Rectangle from Example6_09 and implement a Dictionary that from a SortedSet<T> extracts the largest Rectangle of each Color. 
    //      Printout the result
}
