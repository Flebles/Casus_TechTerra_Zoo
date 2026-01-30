using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTerra_Zoo.Models.Pages
{
    internal class PageVerzorgers : IPage
    {
        private readonly IPage _returnPage;

        public PageVerzorgers(IPage returnPage)
        {
            _returnPage = returnPage;
        }

        public void Show()
        {
            bool doorgaan = true;
            while (doorgaan)
            {
                Console.Clear();
                Console.WriteLine("=== Verzorgers ===\n");

                // aangezien dit niet voor vanacht af komt zet ik hier deze melding neer
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Deze pagina is onder constructie, kom later terug");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("\nDruk op ESC om terug te gaan...");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        _returnPage.Show();
                        doorgaan = false;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nOngeldige keuze, probeer opnieuw...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Thread.Sleep(1500);
                        break;
                }
            }
        }
    }
}
