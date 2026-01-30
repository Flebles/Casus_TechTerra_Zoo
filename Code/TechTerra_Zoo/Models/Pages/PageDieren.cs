using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTerra_Zoo.Models.Pages
{
    internal class PageDieren : IPage
    {
        private readonly IPage _returnPage;

        public PageDieren(IPage returnPage)
        {
            _returnPage = returnPage;
        }

        public void Show()
        {
            bool doorgaan = true;
            while (doorgaan)
            {
                Console.Clear();
                Console.WriteLine("=== Dieren ===\n");
                Console.WriteLine("1. Dier Registreren");
                Console.WriteLine("2. Overzicht");
                Console.WriteLine("\nDruk op ESC om terug te gaan...");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        new PageDierRegistreren(this).Show();
                        doorgaan = false;
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        new PageDierOverzicht(this).Show();
                        doorgaan = false;
                        break;

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