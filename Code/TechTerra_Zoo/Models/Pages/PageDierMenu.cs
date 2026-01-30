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

            var key = Console.ReadKey(true);

            switch (key.Key)
            {

                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    DierRepository repo = new DierRepository();
                    DALSQL dal = new DALSQL();

                    if (dal.IsDierVandaagGevoerd(_dier.Id))
                    {
                        Console.WriteLine("\nDit dier is vandaag al gevoerd.");
                    }
                    else
                    {
                        dal.RegistreerVoeding(_dier.Id);
                        Console.WriteLine("\nVoeding geregistreerd.");
                    }

                    Console.WriteLine("Druk op een toets om terug te gaan");
                    Console.ReadKey();
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    PageDierBewerken bewerkPagina = new PageDierBewerken(_dier, this);
                    bewerkPagina.Show();
                    break;

                case ConsoleKey.Delete:
                    VerwijderDier();
                    break;

                case ConsoleKey.Escape:
                    _returnPage.Show();
                    break;
            }
        }

        private void VerwijderDier()
        {
            Console.Clear();
            Console.WriteLine("Weet je zeker dat je dit dier wilt verwijderen?\n");

            Console.WriteLine("--------------");
            Console.WriteLine($"ID: {_dier.Id}");
            Console.WriteLine($"Naam: {_dier.Naam}");
            Console.WriteLine($"Soort: {_dier.Soort}");
            Console.WriteLine($"Geboortedatum: {(_dier.Geboortedatum?.ToString("dd-MM-yyyy") ?? "Onbekend")}");
            Console.WriteLine($"Opmerking: {_dier.Opmerking}");
            Console.WriteLine("--------------\n");

            Console.WriteLine("1. Ja, verwijderen");
            Console.WriteLine("2. Nee, annuleren");

            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
            {
                DierRepository repo = new DierRepository();
                repo.Delete(_dier.Id);

                Console.WriteLine("\nDier verwijderd.");
                Console.WriteLine("Druk op een toets om terug te gaan");
                Console.ReadKey();
                _returnPage.Show();
            }
        }
    }

}
