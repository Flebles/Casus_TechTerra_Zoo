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
                Console.WriteLine("1. ");
                Console.WriteLine("2. ");
                Console.WriteLine("\nDruk op ESC om terug te gaan...");

                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        doorgaan = false;
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        doorgaan = false;
                        break;

                    case ConsoleKey.Escape:
                        _returnPage.Show();
                        doorgaan = false;
                        break;
                }
            }
        }
    }
}
