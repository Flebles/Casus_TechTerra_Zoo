using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTerra_Zoo.DataAccess;

namespace TechTerra_Zoo.Models.Pages
{
    internal class PageDierRegistreren : IPage
    {
        private readonly IPage _returnPage;

        public PageDierRegistreren(IPage returnPage)
        {
            _returnPage = returnPage;
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("=== Dier toevoegen ===\n");

            Console.Write("Voer de naam van het dier in: ");
            string? dierNaamInput = Console.ReadLine();
            string dierNaam = dierNaamInput ?? string.Empty;

            Console.Write("Wat voor soort is het dier? ");
            string? dierSoortInput = Console.ReadLine();
            string dierSoort = dierSoortInput ?? string.Empty;

            Console.Write("Geboortedatum (dd-MM-yyyy, leeg = onbekend): ");
            string geboorteInput = Console.ReadLine();

            DateTime? dierDatum = null;

            if (!string.IsNullOrWhiteSpace(geboorteInput))
            {
                if (DateTime.TryParseExact(
                    geboorteInput,
                    "dd-MM-yyyy",
                    null,
                    System.Globalization.DateTimeStyles.None,
                    out DateTime parsedDate))
                {
                    dierDatum = parsedDate;
                }
                else
                {
                    Console.WriteLine("Ongeldig formaat. Gebruik dd-MM-yyyy.");
                    Console.ReadKey();
                    _returnPage.Show();
                    return;
                }
            }

            Console.Write("Voeg eventuele opmerkingen toe: ");
            string? dierOpmerkingInput = Console.ReadLine();
            string dierOpmerking = dierOpmerkingInput ?? string.Empty;

            Dier nieuwDier = new Dier(
                id: 0,
                naam: dierNaam,
                soort: dierSoort,
                geboortedatum: dierDatum,
                opmerking: dierOpmerking
            );

            DierRepository repo = new DierRepository();
            repo.VoegDierToe(nieuwDier);

            Console.WriteLine($"\n=== Dier succesvol toegevoegd ===");
            Console.WriteLine("Druk op ESC om terug te gaan...");

            while (Console.ReadKey(true).Key != ConsoleKey.Escape) { }

            _returnPage.Show();
        }
    }
}
