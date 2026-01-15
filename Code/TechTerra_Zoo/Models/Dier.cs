using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTerra_Zoo.Models
{
    internal abstract class Dier
    {
        protected int id;
        protected string naam;
        protected string geluid;
        protected bool heeftVacht;

        public int aantalPoten { get; protected set; }

        public Dier(int id, string naam, string geluid, int aantalPoten)
        {
            this.id = id;
            this.naam = naam;
            this.aantalPoten = aantalPoten;
        }
     
        public string MaakGeluid()
        {
            return $"{naam} maakt het geluid {geluid}";
        }

        public string Eten()
        {
            return $"{naam} eet zijn voer";
        }
    }
}
