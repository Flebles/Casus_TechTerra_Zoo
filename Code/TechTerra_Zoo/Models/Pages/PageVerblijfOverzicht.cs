using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTerra_Zoo.DataAccess;

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
                        $"-------------- \n{v.Id}. \nVerblijfnaam: {v.VerblijfNaam} \nType: {v.Type} \nCapaciteit: {v.Capaciteit} \nTemperatuur: {v.Temperatuur}"
                    );
                    var dieren = v.GetDierNamen();

                    Console.WriteLine("Dieren:");
                    if (dieren.Count == 0)
                    {
                        Console.WriteLine("- Nog geen dieren in dit verblijf");
                    }
                    else
                    {
                        Console.WriteLine("- " + string.Join(", ", dieren));
                    }
                }
            }

            Console.WriteLine("\nDruk op ESC om terug te gaan...");
            while (Console.ReadKey(true).Key != ConsoleKey.Escape) { }

            _returnPage.Show();
        }
    }
}
