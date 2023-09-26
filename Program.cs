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
                writer.WriteLine($"{Convert.ToString(AtszamolPercbe(item.OraPerc))};{item.Nev};{item.AdasDb}");
            }

            //var f8 = radio.GroupBy(h => h.Nev).Count();
            //Console.WriteLine($"8.Feladat: Sofőrök száma: {f8} fő");

            var f8dic = radio
                .GroupBy(h => h.Nev)
                .ToDictionary(n => n.Key, hsz => hsz.Sum(h => h.AdasDb));
            Console.WriteLine($"8.f: soforok szama: {f8dic.Count} fo");

            var f9 = f8dic.OrderBy(kvp => kvp.Value).Last();
            Console.WriteLine("9.f.: legtobb adast indito sofor:");
            Console.WriteLine($"\tnev: {f9.Key}");
            Console.WriteLine($"\tadasok szama: {f9.Value} alkalom");

            //var f9 = radio.OrderBy(kvp => kvp.AdasDb).Last();
            //Console.WriteLine("9.Feladat: Legtöbb adást indító sofőr");
            //Console.WriteLine($"\t Név: {f9.Nev}");
            //Console.WriteLine($"\t Adások száma: {f9.AdasDb} alkalom");
        }
        static int AtszamolPercbe(TimeSpan oraPerc)
        {
            return Convert.ToInt32(oraPerc.TotalMinutes);
        }
    }
}
