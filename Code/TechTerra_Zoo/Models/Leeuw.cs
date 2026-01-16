using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTerra_Zoo.Models
{
    internal class Leeuw : Dier
    {
        public Leeuw(int id, string naam, string geluid, int aantalPoten, bool heeftVacht)
            : base(id, naam, geluid, aantalPoten, heeftVacht)
        {
        }

        public override string Eet()
        {
            return $"{naam} eet vlees.";
        }
    }
}
