using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine($"{_dier.Id}.");
            Console.WriteLine($"Soort: {_dier.Soort}");
            Console.WriteLine($"Geboortedatum: {(_dier.Geboortedatum?.ToString("dd-MM-yyyy") ?? "Onbekend")}");
            Console.WriteLine($"Opmerking: {_dier.Opmerking}");
            Console.WriteLine("--------------");

            Console.WriteLine("1. Bewerk dier");
            Console.WriteLine("2. Verwijder dier");
            Console.WriteLine("ESC. Terug");

            var key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.D1:
                
                    PageDierBewerken bewerkPagina = new PageDierBewerken(_dier, this);
                    bewerkPagina.Show();
                    break;
                    

                case ConsoleKey.D2:
                    // verwijderlogica
                    break;

                case ConsoleKey.Escape:
                    _returnPage.Show();
                    break;
            }
        }
    }

}
