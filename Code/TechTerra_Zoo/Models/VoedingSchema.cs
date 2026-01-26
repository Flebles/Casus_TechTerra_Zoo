using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTerra_Zoo.DataAccess;

namespace TechTerra_Zoo.Models
{
    public class VoedingSchema
    {
        public int Id { get; set; }
        public string Tijd { get; set; }
        public string Voeding { get; set; }
        public string Hoeveelheid { get; set; }
        public string? Uitzonderingen { get; set; }

        public VoedingSchema()
        {
        }

        public VoedingSchema(int id, string tijd, string voeding, string hoeveelheid, string? uitzonderingen)
        {
            Id = id;
            Tijd = tijd;
            Voeding = voeding;
            Hoeveelheid = hoeveelheid;
            Uitzonderingen = uitzonderingen;
        }

        public void AddVoeding()
        {
            DALSQL dalSql = new DALSQL();
            dalSql.AddVoeding(this);
        }

        public List<VoedingSchema> GetAllVoeding()
        {
            DALSQL dalSql = new DALSQL();
            return dalSql.GetAllVoeding();
        }
    }
}
