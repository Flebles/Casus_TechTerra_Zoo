using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTerra_Zoo.Models
{
    internal class Olifant : Dier
    {
        public Olifant(int id, string naam, string soort)
            : base(id, naam, soort)
        {
        }

        public override string Eet()
        {
            return $"{Naam} eet planten en fruit.";
        }
    }
}
