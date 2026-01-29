using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTerra_Zoo.Models
{
    public class Dier
    {
        public int Id { get; protected set; }
        public string Naam { get; protected set; }
        public string Soort { get; protected set; }
        public string Opmerking { get; protected set; }

        public Dier(int id, string naam, string soort, string opmerking)
        {
            Id = id;
            Naam = naam;
            Soort = soort;
            Opmerking = opmerking;
        }

        public virtual string Eet()
        {
            return $"{Naam} eet zijn voer.";
        }

        public void WijzigNaam(string naam) => Naam = naam;
        public void WijzigSoort(string soort) => Soort = soort;
        public void WijzigOpmerking(string opmerking) => Opmerking = opmerking;
    }
}
