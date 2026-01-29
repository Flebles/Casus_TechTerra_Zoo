using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTerra_Zoo.DataAccess;

namespace TechTerra_Zoo.Models.Pages
{
    internal class PageDierBewerken : IPage
    {
        public  Dier _dier { get; set; }
        private  IPage _returnPage;

        public PageDierBewerken(Dier dier, IPage returnPage)
        {
            _dier = dier;
            _returnPage = returnPage;
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine($"=== Bewerk {_dier.Naam} ===\n");

            Console.WriteLine("1. Naam aanpassen");
            Console.WriteLine("2. Soort aanpassen");
            Console.WriteLine("3. Opmerking aanpassen");
            Console.WriteLine("S. Opslaan");
            Console.WriteLine("ESC. Annuleren");

            var key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.D1:
                    Console.Write("Nieuwe naam: ");
                    string nieuweNaam = Console.ReadLine();
                    Show();
                    break;

                case ConsoleKey.D2:
                    Console.Write("Nieuwe soort: ");
                    string nieuweSoort = Console.ReadLine();
                    Show();
                    break;

                case ConsoleKey.D3:
                    Console.Write("Nieuwe opmerking: ");
                    string NieuweOpmerking = Console.ReadLine();
                    Show();
                    break;

                case ConsoleKey.S:
                    Opslaan();
                    break;

                case ConsoleKey.Escape:
                    _returnPage.Show();
                    break;
            }
        }

        private void Opslaan()
        {
            DierRepository repo = new DierRepository();
            repo.Update(_dier);

            Console.WriteLine("\nDier succesvol aangepast!");
            Console.ReadKey();
            _returnPage.Show();
        }

    }

}
