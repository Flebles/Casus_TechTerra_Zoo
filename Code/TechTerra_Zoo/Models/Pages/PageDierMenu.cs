using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTerra_Zoo.DataAccess;

namespace TechTerra_Zoo.Models.Pages
{
    internal class PageDierMenu : IPage
    {
        private readonly Dier _dier;
        private readonly IPage _returnPage;

        public PageDierMenu(Dier dier, IPage returnPage)
        {
            _dier = dier;
            _returnPage = returnPage;
        }

        public void Show()
        {
            bool doorgaan = true;
            while (doorgaan)
            {
                Console.Clear();
                Console.WriteLine($"=== {_dier.Naam} ===\n");

                Console.WriteLine("--------------");
                Console.WriteLine($"Naam: {_dier.Naam}");
                Console.WriteLine($"Soort: {_dier.Soort}");
                Console.WriteLine($"Geboortedatum: {(_dier.Geboortedatum?.ToString("dd-MM-yyyy") ?? "Onbekend")}");
                Console.WriteLine($"Opmerking: {_dier.Opmerking}");
                Console.WriteLine("--------------\n");

                Console.WriteLine("1. Dier voeren (nu)");
                Console.WriteLine("2. Bewerk dier");
                Console.WriteLine("DEL. Verwijder dier");
                Console.WriteLine("\nDruk op ESC om terug te gaan...");

                switch (Console.ReadKey(true).Key)
                {

                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        DierRepository repo = new DierRepository();
                        DALSQL dal = new DALSQL();

                        if (dal.IsDierVandaagGevoerd(_dier.Id))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("\nDit dier is vandaag al gevoerd.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            dal.RegistreerVoeding(_dier.Id);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nVoeding geregistreerd.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        Console.WriteLine("Druk op een toets om terug te gaan");
                        Console.ReadKey();
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        PageDierBewerken bewerkPagina = new PageDierBewerken(_dier, this);
                        bewerkPagina.Show();
                        doorgaan = false;
                        break;

                    case ConsoleKey.Delete:
                        VerwijderDier();
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

        // ik had eigenlijk een nieuwe pagina moeten maken in een aparte class maar dit werkt ook prima
        private void VerwijderDier()
        {
            bool doorgaan = true;
            while (doorgaan)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Weet je zeker dat je dit dier wilt verwijderen?\n");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("--------------");
                Console.WriteLine($"ID: {_dier.Id}");
                Console.WriteLine($"Naam: {_dier.Naam}");
                Console.WriteLine($"Soort: {_dier.Soort}");
                Console.WriteLine($"Geboortedatum: {(_dier.Geboortedatum?.ToString("dd-MM-yyyy") ?? "Onbekend")}");
                Console.WriteLine($"Opmerking: {_dier.Opmerking}");
                Console.WriteLine("--------------\n");

                // ik heb de keuzes "Y" en "N" gekozen omdat de gebruiker niet meteen weer op 1 of 2 drukt en werkelijk over de actie nadenkt
                Console.WriteLine("Y. Ja, verwijderen");
                Console.WriteLine("N. Nee, annuleren");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Y:
                        DierRepository repo = new DierRepository();
                        repo.Delete(_dier.Id);

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nDier verwijderd.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Druk op een toets om terug te gaan");
                        Console.ReadKey();
                        _returnPage.Show();
                        doorgaan = false;
                        break;
                    case ConsoleKey.N:
                        this.Show(); // terug naar het dier menu
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
