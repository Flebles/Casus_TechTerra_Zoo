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
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Dieren Overzicht ===\n");

                DierRepository repo = new DierRepository();
                List<Dier> dieren = repo.GetAllDieren();

                if (dieren.Count == 0)
                {
                    Console.WriteLine("Geen dieren gevonden.");
                }
                else
                {
                    foreach (var d in dieren)
                    {
                        Console.WriteLine("--------------");
                        Console.WriteLine($"ID: {d.Id}");
                        Console.WriteLine($"Naam: {d.Naam}");
                        Console.WriteLine($"Soort: {d.Soort}");
                        Console.WriteLine($"Opmerking: {d.Opmerking}");
                    }

                    Console.WriteLine("--------------");
                }

                Console.WriteLine("\nVoer een dier-ID in om te bewerken");
                Console.WriteLine("Druk op ESC om terug te gaan");

                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Escape)
                {
                    _returnPage.Show();
                    return;
                }

                Console.Write("ID: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int dierId))
                    continue;

                Dier gekozenDier = dieren.FirstOrDefault(d => d.Id == dierId);
                if (gekozenDier == null)
                    continue;

                new PageDierBewerken(gekozenDier, this).Show();
            }
        }
    }
}
