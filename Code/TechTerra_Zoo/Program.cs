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

            VoedingSchema voeding = new VoedingSchema
            {
                Tijd = "08:00",
                Voeding = "Vlees",
                Hoeveelheid = "5 kg",
                Uitzonderingen = "Niet op zondag"
            };

            voeding.AddVoeding();

            VoedingSchema empty = new VoedingSchema();
            List<VoedingSchema> voedingen = empty.GetAllVoeding();

            Console.WriteLine("Voedingschema:\n");

            foreach (var v in voedingen)
            {
                Console.WriteLine(
                    $"{v.Id} | {v.Tijd} | {v.Voeding} | {v.Hoeveelheid} | {v.Uitzonderingen}"
                );
            }

            Console.Write("Voer de verblijfnaam in: ");
            string verblijfNaam = Console.ReadLine();

            int capaciteit;
            Console.Write("Voer de capaciteit in: ");
            while (!int.TryParse(Console.ReadLine(), out capaciteit))
            {
                Console.Write("Ongeldige invoer. Voer een geldig getal in voor capaciteit: ");
            }

            Verblijf nieuwVerblijf = new Verblijf
            {
                VerblijfNaam = verblijfNaam,
                Capaciteit = capaciteit
            };

            nieuwVerblijf.CreateVerblijf();

            Verblijf emptyVerblijf = new Verblijf();
            List<Verblijf> verblijven = emptyVerblijf.GetAllVerblijven();

            Console.WriteLine("\nOverzicht van alle verblijven:\n");

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