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
        public string Type { get; set; }
        public int Temperatuur { get; set; }

        public Verblijf()
        {
        }

        public Verblijf(int id, string verblijfNaam, int capaciteit, string type, int temperatuur)
        {
            Id = id;
            VerblijfNaam = verblijfNaam;
            Capaciteit = capaciteit;
            Type = type;
            Temperatuur = temperatuur;
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

        public static Verblijf? GetById(int id)
        {
            DALSQL dal = new DALSQL();
            return dal.GetVerblijfById(id);
        }

        public static void Delete(int id)
        {
            DALSQL dal = new DALSQL();
            dal.DeleteVerblijf(id);
        }
        public List<string> GetDierNamen()
        {
            DALSQL dal = new DALSQL();
            return dal.GetDierNamenByVerblijfId(this.Id);
        }
    }

}
