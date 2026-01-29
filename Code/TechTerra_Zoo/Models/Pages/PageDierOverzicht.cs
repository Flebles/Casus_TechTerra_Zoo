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
                foreach (var v in dieren)
                {
                    Console.WriteLine("--------------");
                    Console.WriteLine($"{v.Id}.");
                    Console.WriteLine($"Naam: {v.Naam}");
                    Console.WriteLine($"Soort: {v.Soort}");
                    Console.WriteLine($"Opmerking: {v.Opmerking}");
                }
            }

            Console.WriteLine("\nDruk op ESC om terug te gaan...");
            while (Console.ReadKey(true).Key != ConsoleKey.Escape) { }

            _returnPage.Show();
        }
    }
}
