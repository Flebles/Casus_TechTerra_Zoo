using System.Text;
using TechTerra_Zoo.DataAccess;
using TechTerra_Zoo.Models;
using TechTerra_Zoo.Models.Pages;

namespace TechTerra_Zoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            IPage mainMenu = new MainMenu();
            mainMenu.Show();
        }
    }
}


/*
Console.OutputEncoding = Encoding.UTF8;

Dier leeuw = new Leeuw(
    id: 0,
    naam: "Leeuw",
    geluid: "Roar",
    aantalPoten: 4,
    heeftVacht: true
);

DierRepository repo = new DierRepository();
repo.VoegDierToe(leeuw);

Console.WriteLine("Dier toegevoegd aan database\n");

List<Dier> dieren = repo.GetAllDieren();

Console.WriteLine("Alle dieren in de database:\n");

foreach (Dier dier in dieren)
{
    Console.WriteLine(
        $"{dier.Naam} | Geluid: {dier.Geluid} | Poten: {dier.AantalPoten} | Vacht: {dier.HeeftVacht}"
    );
}

Console.ReadLine();
*/
