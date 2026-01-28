using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTerra_Zoo.Models.Pages
{
    internal class PageVerblijfToevoegen : IPage
    {
        private readonly IPage _returnPage;

        public PageVerblijfToevoegen(IPage returnPage)
        {
            _returnPage = returnPage;
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("=== Verblijf toevoegen ===\n");

            Console.Write("Voer de verblijfnaam in: ");
            string verblijfNaam = Console.ReadLine();

            int capaciteit;
            Console.Write("Voer de capaciteit in: ");
            while (!int.TryParse(Console.ReadLine(), out capaciteit))
            {
                Console.Write("Ongeldige invoer. Voer een geldig getal in: ");
            }

            Verblijf nieuwVerblijf = new Verblijf
            {
                VerblijfNaam = verblijfNaam,
                Capaciteit = capaciteit
            };

            nieuwVerblijf.CreateVerblijf();

            Console.WriteLine("\n===Verblijf is Succesvol Toegevoegd===");
            Console.WriteLine("Druk op ESC om terug te gaan...");

            while (Console.ReadKey(true).Key != ConsoleKey.Escape) { }

            _returnPage.Show();
        }
    }
}
