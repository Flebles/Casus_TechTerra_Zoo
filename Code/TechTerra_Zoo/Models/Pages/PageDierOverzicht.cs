using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTerra_Zoo.DataAccess;

namespace TechTerra_Zoo.Models.Pages
{
    internal class PageDierOverzicht : IPage
    {
        private readonly IPage _returnPage;

        public PageDierOverzicht(IPage returnPage)
        {
            _returnPage = returnPage;
        }

        public void Show()
        {
            DALSQL dal = new DALSQL();

            bool doorgaan = true;
            while (doorgaan)
            {
                Console.Clear();
                Console.WriteLine("=== Dieren Overzicht ===\n");

                DierRepository repo = new DierRepository();
                List<Dier> dieren = repo.GetAllDieren();

                if (dieren.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Geen dieren gevonden.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    foreach (var d in dieren)
                    {
                        Console.WriteLine(">---------------------------<");
                        Console.WriteLine($"| ID: {d.Id}");
                        Console.WriteLine($"| Naam: {d.Naam}");
                        Console.WriteLine($"| Soort: {d.Soort}");
                        Console.WriteLine($"| Geboortedatum: {(d.Geboortedatum?.ToString("dd-MM-yyyy") ?? "Onbekend")}");
                        Console.WriteLine($"| Opmerking: {d.Opmerking}");

                        // controleer of het dier is gevoerd en wanneer
                        bool gevoerdVandaag = dal.IsDierVandaagGevoerd(d.Id);
                        DateTime? laatsteVoeding = dal.GetLaatsteVoeding(d.Id);

                        Console.WriteLine($"| Gevoerd vandaag: {(gevoerdVandaag ? "JA" : "NEE")}");
                        Console.WriteLine($"| Laatste voeding: {(laatsteVoeding?.ToString("dd-MM-yyyy HH:mm") ?? "Nooit")}");

                    }

                    Console.WriteLine(">----------------------------<"); // afsluitende lijn
                }

                Console.WriteLine("\nVul een dier-ID in om te bewerken");
                Console.WriteLine("Druk op ESC om terug te gaan...");

                // "if" ipv "switch" was makkelijker hier
                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Escape)
                {
                    _returnPage.Show();
                    doorgaan = false;
                    break;
                }

                Console.Write("ID: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int dierId))
                    continue;

                Dier gekozenDier = dieren.FirstOrDefault(d => d.Id == dierId);
                if (gekozenDier == null)
                    continue;

                new PageDierMenu(gekozenDier, this).Show(); // open de dier pagina en stuur het dier en deze pagina als return page mee
                doorgaan = false;
            }
        }
    }
}
