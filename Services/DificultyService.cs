using DataAccess.Interfaces;
using Entities.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DificultyService : Service<Dificulty>, IDificultyService
    {
        public DificultyService(IRepository<Dificulty> repository) : base(repository)
        {
        }
    }
}
