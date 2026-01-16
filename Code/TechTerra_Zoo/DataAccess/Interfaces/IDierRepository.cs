using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTerra_Zoo.Models;

namespace TechTerra_Zoo.DataAccess.Interfaces
{
    internal interface IDierRepository
    {
        void VoegDierToe(Dier dier);
        List<Dier> GetAllDieren();
    }
}