using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTerra_Zoo.DataAccess;

namespace TechTerra_Zoo.Models.Pages
{
    internal class PageDierAanVerblijfToevoegen : IPage
    {
        private readonly IPage _returnPage;

        public PageDierAanVerblijfToevoegen(IPage returnPage)
        {
            _returnPage = returnPage;
        }

        public void Show()
        {
            Console.Clear();
            DALSQL dal = new DALSQL();

            // 1️⃣ Toon verblijven
            Console.WriteLine("=== Kies een verblijf ===\n");

            var verblijven = dal.GetAllVerblijven();
            foreach (var v in verblijven)
            {
                Console.WriteLine($"{v.Id} | {v.VerblijfNaam} | Cap: {v.Capaciteit}");
            }

            Console.Write("\nVerblijf ID: ");
            if (!int.TryParse(Console.ReadLine(), out int verblijfId))
            {
                Terug("Ongeldig verblijf ID.");
                return;
            }

            // 2️⃣ Toon dieren
            Console.Clear();
            Console.WriteLine("=== Kies dieren ===\n");

            var dieren = dal.GetAllDieren();
            foreach (var d in dieren)
            {
                Console.WriteLine($"{d.Id} | {d.Naam} | {d.Soort}");
            }

            Console.WriteLine("\nVoer dier ID's in (bijv: 1,3,5):");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Terug("Geen dieren gekozen.");
                return;
            }

            // 3️⃣ Koppelen
            foreach (string idStr in input.Split(','))
            {
                if (int.TryParse(idStr.Trim(), out int dierId))
                {
                    dal.AddDierToVerblijf(verblijfId, dierId);
                }
            }

            Terug("Dieren succesvol toegevoegd aan verblijf.");
        }

        private void Terug(string melding)
        {
            Console.WriteLine($"\n{melding}");
            Console.WriteLine("Druk op een toets...");
            Console.ReadKey();
            _returnPage.Show();
        }
    }
}
