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
            // rianne zei dat while true niet heel goed is, dus ik heb deze bool toegevoegd die false wordt als je een andere pagina kiest
            bool doorgaan = true;
            while (doorgaan)
            {
                Console.Clear(); // maak het scherm leeg, dit is nodig omdat je anders de vorige pagina blijft zien
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("=== TechTerra Zoo ===\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1. Dieren");
                Console.WriteLine("2. Verblijven");
                Console.WriteLine("3. Verzorgers");
                Console.WriteLine("4. Afsluiten");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        new PageDieren(this).Show(); // this is in dit geval de MainMenu pagina, hiermee kan je later terug naar het hoofdmenu
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
                    case ConsoleKey.Escape:
                        Console.WriteLine("\nProgramma wordt afgesloten.");
                        Environment.Exit(0);
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