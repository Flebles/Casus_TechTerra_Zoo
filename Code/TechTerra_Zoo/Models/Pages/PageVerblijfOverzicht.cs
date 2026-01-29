using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTerra_Zoo.Models.Pages
{
    internal class PageVerblijfOverzicht : IPage
    {
        private readonly IPage _returnPage;

        public PageVerblijfOverzicht(IPage returnPage)
        {
            _returnPage = returnPage;
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("=== Verblijven Overzicht ===\n");
            Verblijf verblijf = new Verblijf();
            List<Verblijf> verblijven = verblijf.GetAllVerblijven();

            if (verblijven.Count == 0)
            {
                Console.WriteLine("Geen verblijven gevonden.");
            }
            else
            {
                foreach (var v in verblijven)
                {
                    Console.WriteLine(
                        $"-------------- \nVerblijf: {v.Id}: \nNaam: {v.VerblijfNaam} \nCapaciteit: {v.Capaciteit}\n--------------"
                    );
                }
            }

            Console.WriteLine("\nDruk op ESC om terug te gaan...");
            while (Console.ReadKey(true).Key != ConsoleKey.Escape) { }

            _returnPage.Show();
        }
    }
}
