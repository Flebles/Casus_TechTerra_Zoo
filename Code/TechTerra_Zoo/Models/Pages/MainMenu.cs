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
            bool doorgaan = true;
            while (doorgaan)
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
                        doorgaan = false;
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        new PageVerblijven(this).Show();
                        doorgaan = false;
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        new PageVerzorgers(this).Show();
                        doorgaan = false;
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        Console.WriteLine("\nProgramma wordt afgesloten.");
                        Environment.Exit(0);
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