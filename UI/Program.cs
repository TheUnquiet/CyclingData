using BL.interfaces;
using BL.managers;
using BL.models;
using DL;
using System.Numerics;
using System.Text.RegularExpressions;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            IFileProcessor fp = new FileProcessor();
            string filepath = @"C:\Users\hp\Desktop\Hogent\Sem2\ontwerp\oefeningen\CyclingData\DL\bin\Debug\net8.0\text_files\CyclingData.txt";
            CycleManager cm = new CycleManager(fp);
            var strings = fp.LeesData(filepath);
            var data = cm.MaakData(strings);

            //Console.WriteLine("Aantal Sessies Query 1: " + Query1(data));

            //Query2(data);

            //foreach ( var item in Query3(data)) { Console.WriteLine( "Klant : " + item); }

            //Console.WriteLine(Query4(data));

            //foreach (var item in Query5(data)) { Console.WriteLine("Klant : " + item); }

            //Query6(data);

            //Query7(data);
        }

        static int Query1(List<CycleData> data)
        {
            var res = data.Where(x => x.GemiddeldeWattage < 125 && x.MaximumWattage > 200).Count();

            return res;
        }

        static int Query2(List<CycleData> data)
        {
            var res = data.Where(x => x.GemiddeldeWattage < 125 &&
                x.MaximumWattage > 200
                && (x.TrainingsType == "interval" || x.TrainingsType == "endurance")).Count();
            return res;
        }

        static List<int> Query3(List<CycleData> data)
        {
            var res = data
              .Where(x => x.Date_Time.Year == 2021
                && x.Date_Time.Month == 8 && x.GemiddeldeWattage > 350);
            var g1 = res.GroupBy(x => x.KlantNummer); // <--

            var g2 = g1.Where(group => group.Count() >= 5); // <--
            var g3 = g2.Select(group => group.Key);

            return g3.ToList();
        }

        static int Query4(List<CycleData> data)
        {
            var res = data.Where(x => x.Date_Time.Year == 2021
                && (x.GemiddeldeWattage < 100 || x.GemiddeldeCadans < 75));

            return res.Count();
        }

        static List<int> Query5(List<CycleData> data)
        {
            var res = data.Where(x => x.Date_Time.DayOfWeek == DayOfWeek.Monday)
                    .GroupBy(x => x.KlantNummer)
                    .OrderBy(x => x.Count()).Take(3).Select(group => group.Key);

            return res.ToList();
        }

        static void Query6(List<CycleData> data)
        {
            var hard = data.Where(x => x.TrainingsType == "interval"
                && x.Tijdsduur > 60 && x.MaximumWattage > 300).Count();

            var heavy = data.Where(x => x.TrainingsType == "endurance"
                && x.Tijdsduur > 100 && x.GemiddeldeWattage > 200).Count();

            var short_but_heavy = data.Where(x => x.TrainingsType == "interval"
                && x.Tijdsduur < 45 && x.GemiddeldeWattage > 250).Count();

            Console.WriteLine("Hard : " + hard);
            Console.WriteLine("heavy : " + heavy);
            Console.WriteLine("Short but heavy : " + short_but_heavy);

        }

        static void Query7(List<CycleData> data)
        {
            var klant = data.Where(x => x.KlantNummer == 10);
            
            int totaleTijd = klant.Sum(x => x.Tijdsduur);
            double gemiddeldeTijd = Math.Round(klant.Average(t => t.Tijdsduur));

            int kortsteTijd = klant.Min(t => t.Tijdsduur);
            int langsteTijd = klant.Max(t => t.Tijdsduur);
            int aantalSessies = klant.Count();

            Console.WriteLine("Totale tijd : " + totaleTijd);
            Console.WriteLine("Gemiddelde tijd : " + gemiddeldeTijd);
            Console.WriteLine("Korste tijd : " + kortsteTijd);
            Console.WriteLine("Langste tijd : " + langsteTijd);
            Console.WriteLine("Aantal Sessies : " + aantalSessies);

        }

        static void Query8(List<CycleData> data)
        {
            var res = data.Where(x => x.GemiddeldeWattage > 350
                && x.Tijdsduur > 100 &&
                (x.MaximumCadans - x.GemiddeldeCadans) < 10)
                .OrderBy(x => x.GemiddeldeCadans)
                .ThenBy(x => x.Tijdsduur)
                .ThenByDescending(x => x.GemiddeldeWattage);
        }
    }
}
