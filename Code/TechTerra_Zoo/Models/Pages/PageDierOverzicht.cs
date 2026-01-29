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
            Console.Write("\nVul het nummer van het dier in dat je wilt aanpassen: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int dierId))
            {
                Console.WriteLine("Ongeldige invoer.");
                Console.ReadKey();
                Show();
                return;
            }

            Dier gekozenDier = dieren.FirstOrDefault(d => d.Id == dierId);

            if (gekozenDier == null)
            {
                Console.WriteLine("Geen dier gevonden met dit nummer.");
                Console.ReadKey();
                Show();
                return;
            }

            PageDierMenu dierMenu = new PageDierMenu(gekozenDier, this);
            dierMenu.Show();

        }
    }
}
