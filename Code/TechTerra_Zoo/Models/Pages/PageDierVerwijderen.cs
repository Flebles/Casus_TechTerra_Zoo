using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTerra_Zoo.DataAccess;

namespace TechTerra_Zoo.Models.Pages
{
    internal class PageDierVerwijderen : IPage
    {
        private readonly IPage _returnPage;

        public PageDierVerwijderen(IPage returnPage)
        {
            _returnPage = returnPage;
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("=== Dier Verwijderen ===\n");
            Console.Write("Voer het ID van het dier in: ");

            if (!int.TryParse(Console.ReadLine(), out int dierId))
            {
                ToonMelding("Ongeldig ID.");
                _returnPage.Show();
                return;
            }

            DierRepository repo = new DierRepository();
            Dier? dier = repo.GetById(dierId);

            if (dier == null)
            {
                ToonMelding("Geen dier gevonden met dit ID.");
                _returnPage.Show();
                return;
            }

            BevestigVerwijderen(dier, repo);
            _returnPage.Show();
        }

        private void BevestigVerwijderen(Dier dier, DierRepository repo)
        {
            Console.Clear();
            Console.WriteLine("Weet je zeker dat je dit dier wilt verwijderen?\n");

            ToonDierInfo(dier);

            Console.WriteLine("\n1. Ja, verwijderen");
            Console.WriteLine("2. Nee, annuleren");

            bool doorgaan = true;
            while (doorgaan)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        repo.Delete(dier.Id);
                        ToonMelding("Dier succesvol verwijderd.");
                        doorgaan = false;
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.Escape:
                        doorgaan = false;
                        break;
                }
            }
        }

        private void ToonDierInfo(Dier dier)
        {
            Console.WriteLine("--------------");
            Console.WriteLine($"ID:    {dier.Id}");
            Console.WriteLine($"Naam:  {dier.Naam}");
            Console.WriteLine($"Soort: {dier.Soort}");
            Console.WriteLine($"Opmerking: {dier.Opmerking}");
            Console.WriteLine("--------------");
        }

        private void ToonMelding(string tekst)
        {
            Console.WriteLine($"\n{tekst}");
            Console.WriteLine("Druk op een toets om verder te gaan...");
            Console.ReadKey(true);
        }
    }
}