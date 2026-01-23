using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTerra_Zoo.DataAccess;

namespace TechTerra_Zoo.Models
{
    public class Verblijf
    {
        public int Id { get; set; }
        public string VerblijfNaam { get; set; }
        public int Capaciteit { get; set; }

        public Verblijf()
        {
        }

        public Verblijf(int id, string verblijfNaam, int capaciteit)
        {
            Id = id;
            VerblijfNaam = verblijfNaam;
            Capaciteit = capaciteit;
        }

        public void CreateVerblijf()
        {
            DALSQL dalSql = new DALSQL();
            dalSql.AddVerblijf(this);
        }

        public List<Verblijf> GetAllVerblijven()
        {
            DALSQL dalSql = new DALSQL();
            return dalSql.GetAllVerblijven();
        }
    }
}
