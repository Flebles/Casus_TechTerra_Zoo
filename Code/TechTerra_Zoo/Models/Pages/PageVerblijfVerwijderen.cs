using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTerra_Zoo.DataAccess;

namespace TechTerra_Zoo.Models.Pages
{
    internal class PageVerblijfVerwijderen : IPage
    {
        private readonly IPage _returnPage;

        public PageVerblijfVerwijderen(IPage returnPage)
        {
            _returnPage = returnPage;
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("=== Verblijf Verwijderen ===\n");
            Console.Write("Voer het ID in: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                ToonMelding("Ongeldig ID.");
                _returnPage.Show();
                return;
            }

            Verblijf? verblijf = Verblijf.GetById(id);

            if (verblijf == null)
            {
                ToonMelding("Geen verblijf gevonden.");
                _returnPage.Show();
                return;
            }

            Bevestig(verblijf);
            _returnPage.Show();
        }

        private void Bevestig(Verblijf verblijf)
        {
            Console.Clear();
            Console.WriteLine("Weet je zeker dat je dit verblijf wilt verwijderen?\n");

            Console.WriteLine($"ID: {verblijf.Id}");
            Console.WriteLine($"Naam: {verblijf.VerblijfNaam}");
            Console.WriteLine($"Capaciteit: {verblijf.Capaciteit}");

            Console.WriteLine("\n1. Ja");
            Console.WriteLine("2. Nee");

            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
            {
                Verblijf.Delete(verblijf.Id);
                ToonMelding("Verblijf verwijderd.");
            }
        }

        private void ToonMelding(string tekst)
        {
            Console.WriteLine($"\n{tekst}");
            Console.WriteLine("Druk op een toets...");
            Console.ReadKey();
        }
    }


}
