using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTerra_Zoo.Models
{
    internal class Olifant : Dier
    {
        public Olifant(int id, string naam, string soort, DateTime? geboortedatum, string opmerking)
            : base(id, naam, soort, geboortedatum, opmerking)
        {
        }

        public override string Eet()
        {
            return $"{Naam} eet planten en fruit.";
        }
    }
}
