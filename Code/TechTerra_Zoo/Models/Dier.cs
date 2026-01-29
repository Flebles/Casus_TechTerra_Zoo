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

        public Dier(int id, string naam, string soort)
        {
            Id = id;
            Naam = naam;
            Soort = soort;
        }

        public virtual string Eet()
        {
            return $"{Naam} eet zijn voer.";
        }
    }

}
