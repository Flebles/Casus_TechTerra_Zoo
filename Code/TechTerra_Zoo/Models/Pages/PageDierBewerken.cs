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
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"=== Bewerk dier (ID {_dier.Id}) ===\n");

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
                Console.WriteLine("5. Dier verwijderen");
                Console.WriteLine("\nS. Opslaan");
                Console.WriteLine("ESC. Terug");

                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.Write("Nieuwe naam: ");
                        _dier.WijzigNaam(Console.ReadLine());
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.Write("Nieuwe soort: ");
                        _dier.WijzigSoort(Console.ReadLine());
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Console.Write("Nieuwe geboortedatum (dd-MM-yyyy, leeg = onbekend): ");
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
                                Console.WriteLine("Ongeldig formaat.");
                                Console.ReadKey();
                                return;
                            }

                            nieuweDatum = parsed;
                        }

                        _dier.WijzigDatum(nieuweDatum);
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        Console.Write("Nieuwe opmerking: ");
                        _dier.WijzigOpmerking(Console.ReadLine());
                        break;

                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        VerwijderDier();
                        return;

                    case ConsoleKey.S:
                        Opslaan();
                        return;

                    case ConsoleKey.Escape:
                        _returnPage.Show();
                        return;
                }
            }
        }

        private void Opslaan()
        {
            DierRepository repo = new DierRepository();
            repo.Update(_dier);

            Console.WriteLine("\nDier opgeslagen.");
            Console.ReadKey();
            _returnPage.Show();
        }

        private void VerwijderDier()
        {
            Console.Clear();
            Console.WriteLine("Weet je zeker dat je dit dier wilt verwijderen?\n");

            Console.WriteLine("--------------");
            Console.WriteLine($"ID: {_dier.Id}");
            Console.WriteLine($"Naam: {_dier.Naam}");
            Console.WriteLine($"Soort: {_dier.Soort}");
            Console.WriteLine($"Geboortedatum: {(_dier.Geboortedatum?.ToString("dd-MM-yyyy") ?? "Onbekend")}");
            Console.WriteLine($"Opmerking: {_dier.Opmerking}");
            Console.WriteLine("--------------\n");

            Console.WriteLine("1. Ja, verwijderen");
            Console.WriteLine("2. Nee, annuleren");

            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
            {
                DierRepository repo = new DierRepository();
                repo.Delete(_dier.Id);

                Console.WriteLine("\nDier verwijderd.");
                Console.ReadKey();
                _returnPage.Show();
            }
        }
    }
}
