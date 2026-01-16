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

        public int AantalPoten { get; protected set; }
        public string Naam => naam;
        public string Geluid => geluid;
        public bool HeeftVacht => heeftVacht;

        protected Dier(int id, string naam, string geluid, int aantalPoten, bool heeftVacht)
        {
            this.id = id;
            this.naam = naam;
            this.geluid = geluid;
            this.AantalPoten = aantalPoten;
            this.heeftVacht = heeftVacht;
        }

        public virtual string MaakGeluid()
        {
            return $"{naam} maakt het geluid: {geluid}";
        }

        public virtual string Eet()
        {
            return $"{naam} eet zijn voer.";
        }

        public override string ToString()
        {
            return $"Dier #{id} - {naam} ({AantalPoten} poten)";
        }

    }

}
