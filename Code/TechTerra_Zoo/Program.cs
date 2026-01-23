using System.Text;
using TechTerra_Zoo.DataAccess;
using TechTerra_Zoo.Models;

namespace TechTerra_Zoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Dier leeuw = new Leeuw(
                id: 0,
                naam: "Leeuw",
                geluid: "Roar",
                aantalPoten: 4,
                heeftVacht: true
            );

            DierRepository repo = new DierRepository();
            repo.VoegDierToe(leeuw);

            Console.WriteLine("Dier toegevoegd aan database\n");

            List<Dier> dieren = repo.GetAllDieren();

            Console.WriteLine("Alle dieren in de database:\n");

            foreach (Dier dier in dieren)
            {
                Console.WriteLine(
                    $"{dier.Naam} | Geluid: {dier.Geluid} | Poten: {dier.AantalPoten} | Vacht: {dier.HeeftVacht}"
                );
            }

            Console.ReadLine();

            Verblijf nieuwVerblijf = new Verblijf
            {
                VerblijfNaam = "A102",
                Capaciteit = 13
            };

            nieuwVerblijf.CreateVerblijf();

            Verblijf emptyVerblijf = new Verblijf();
            List<Verblijf> verblijven = emptyVerblijf.GetAllVerblijven();

            Console.WriteLine("Overzicht van alle verblijven:\n");

            foreach (Verblijf verblijf in verblijven)
            {
                Console.WriteLine(
                    $"{verblijf.Id}: {verblijf.VerblijfNaam} (Capaciteit: {verblijf.Capaciteit})"
                );
            }
            Console.ReadLine();

        }
    }
}