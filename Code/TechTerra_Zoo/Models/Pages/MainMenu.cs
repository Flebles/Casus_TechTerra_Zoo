using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTerra_Zoo.Models.Pages
{
    internal class MainMenu : IPage
    {
        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== TechTerra Zoo ===\n");
                Console.WriteLine("1. Dieren");
                Console.WriteLine("2. Verblijven");
                Console.WriteLine("3. Verzorgers");
                Console.WriteLine("4. Afsluiten");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        new PageDieren(this).Show();
                        return;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        new PageVerblijven(this).Show();
                        return;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        new PageVerzorgers(this).Show();
                        return;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}