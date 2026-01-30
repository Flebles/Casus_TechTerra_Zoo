using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTerra_Zoo.Models.Pages
{
    internal class PageVerblijven : IPage
    {
        private readonly IPage _returnPage;

        public PageVerblijven(IPage returnPage)
        {
            _returnPage = returnPage;
        }

        public void Show()
        {
            bool doorgaan = true;
            while (doorgaan)
            {
                Console.Clear();
                Console.WriteLine("=== Verblijven ===\n");
                Console.WriteLine("1. Verblijf Toevoegen");
                Console.WriteLine("2. Overzicht");
                Console.WriteLine("3. Verblijf Verwijderen");
                Console.WriteLine("\nDruk op ESC om terug te gaan...");

                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        new PageVerblijfToevoegen(this).Show();
                        doorgaan = false;
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        new PageVerblijfOverzicht(this).Show();
                        doorgaan = false;
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        new PageVerblijfVerwijderen(this).Show();
                        doorgaan = false;
                        break;

                    case ConsoleKey.Escape:
                        _returnPage.Show();
                        doorgaan = false;
                        break;
                    default:
                        Console.WriteLine("\nOngeldige keuze, probeer opnieuw...");
                        Thread.Sleep(1500);
                        break;
                }
            }
        }
    }
}