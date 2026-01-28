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
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Verblijf ===\n");
                Console.WriteLine("1. Verblijf Toevoegen");
                Console.WriteLine("2. Overzicht");
                Console.WriteLine("\nDruk op ESC om terug te gaan...");

                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        new PageVerblijfToevoegen(this).Show();
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        new PageVerblijfOverzicht(this).Show();
                        break;

                    case ConsoleKey.Escape:
                        _returnPage.Show();
                        return;
                }
            }
        }
    }
}