using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTerra_Zoo.Models;
using TechTerra_Zoo.DataAccess.Interfaces;

namespace TechTerra_Zoo.DataAccess
{
    public class DierRepository
    {
        private DALSQL dal;

        public DierRepository()
        {
            dal = new DALSQL();
        }

        public void VoegDierToe(Dier dier)
        {
            dal.AddDier(dier);
        }

        public List<Dier> GetAllDieren()
        {
            return dal.GetAllDieren();
        }

        public Dier? GetById(int id)
        {
            return dal.GetDierById(id);
        }

        public void Delete(int id)
        {
            dal.DeleteDier(id);
        }

        public void Update(Dier dier)
        {
            dal.UpdateDier(dier);
        }

    }
}