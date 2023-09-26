using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp53
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Radio> radio = new List<Radio>();
            using StreamReader sr = new StreamReader(
                path: "../../../src/cb.txt",
                Encoding.UTF8
                );
            _ = sr.ReadLine();
            while (!sr.EndOfStream) radio.Add(new Radio(sr.ReadLine()));

            Console.WriteLine($"3.Feladat: Bejegyzések száma:{radio.Count}");

            bool f4 = radio.Any(h => h.AdasDb == 4);
            Console.WriteLine($"4.Feladat: {(f4 ? "volt" : "nem volt")} 4 adást indító sofőr");

            Console.Write("5.Feladat: Kérek egynevet:");
            string nev = Console.ReadLine();
            int f5 = radio
                .Where(h => h.Nev.ToLower() == nev.ToLower())
                .Sum(h => h.AdasDb);
            if (f5 != 0) Console.WriteLine($"\t {nev} {f5}x használta a CB-rádiót");
            else Console.WriteLine("\t Nincs ilyen nevű sofőr!");

            using StreamWriter writer = new StreamWriter(
                path: "../../../src/cb2.txt",
                append: false
                );

            writer.WriteLine("Kezdes;Nev;AdasDb");
            foreach (var item in radio)
            {
                writer.WriteLine($"{Convert.ToString(item.AtszamolPercre)};{item.Nev};{item.AdasDb}");
            }
        }
    }
}
