using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTerra_Zoo.Models
{
    internal class Olifant : Dier
    {
        public Olifant(int id, string naam, string geluid, int aantalPoten, bool heeftVacht)
            : base(id, naam, geluid, aantalPoten, heeftVacht)
        {
        }

        public override string Eet()
        {
            return $"{naam} eet planten en fruit.";
        }
    }
}
