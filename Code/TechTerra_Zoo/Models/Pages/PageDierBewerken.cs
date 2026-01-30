using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTerra_Zoo.DataAccess;

namespace TechTerra_Zoo.Models.Pages
{
    internal class PageDierBewerken : IPage
    {
        private readonly Dier _dier;
        private readonly IPage _returnPage;

        public PageDierBewerken(Dier dier, IPage returnPage)
        {
            _dier = dier;
            _returnPage = returnPage;
        }

        public void Show()
        {
            bool doorgaan = true;
            while (doorgaan)
            {
                Console.Clear();
                Console.WriteLine($"=== Bewerk {_dier.Naam} ===\n");

                Console.WriteLine("--------------");
                Console.WriteLine($"Naam: {_dier.Naam}");
                Console.WriteLine($"Soort: {_dier.Soort}");
                Console.WriteLine($"Geboortedatum: {(_dier.Geboortedatum?.ToString("dd-MM-yyyy") ?? "Onbekend")}");
                Console.WriteLine($"Opmerking: {_dier.Opmerking}");
                Console.WriteLine("--------------\n");

                Console.WriteLine("1. Naam aanpassen");
                Console.WriteLine("2. Soort aanpassen");
                Console.WriteLine("3. Geboortedatum aanpassen");
                Console.WriteLine("4. Opmerking aanpassen");
                Console.WriteLine("S. Opslaan");
                Console.WriteLine("\nDruk op ESC om terug te gaan...");

                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.Write("Vul een nieuwe naam in:\n> ");
                        _dier.WijzigNaam(Console.ReadLine());
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.Write("Vul een nieuwe soort in:\n> ");
                        _dier.WijzigSoort(Console.ReadLine());
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Console.Write("Vul een nieuwe geboortedatum in (dd-MM-yyyy, leeg = onbekend):\n> ");
                        string input = Console.ReadLine();

                        DateTime? nieuweDatum = null;

                        if (!string.IsNullOrWhiteSpace(input))
                        {
                            if (!DateTime.TryParseExact(
                                input,
                                "dd-MM-yyyy",
                                null,
                                System.Globalization.DateTimeStyles.None,
                                out DateTime parsed))
                            {
                                Console.WriteLine("\nOngeldig formaat.");
                                Console.WriteLine("Druk op een toets om terug te gaan");
                                Console.ReadKey();
                                return;
                            }

                            nieuweDatum = parsed;
                        }

                        _dier.WijzigDatum(nieuweDatum);
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        Console.Write("Vul een nieuwe opmerking in:\n> ");
                        _dier.WijzigOpmerking(Console.ReadLine());
                        break;

                    case ConsoleKey.S:
                        Opslaan();
                        doorgaan = false;
                        break;

                    case ConsoleKey.Escape:
                        _returnPage.Show();
                        break;
                }
            }
        }

        private void Opslaan()
        {
            DierRepository repo = new DierRepository();
            repo.Update(_dier);

            Console.WriteLine("\nDier opgeslagen.");
            Console.WriteLine("Druk op een toets om terug te gaan");
            Console.ReadKey();
            _returnPage.Show();
        }
    }
}
