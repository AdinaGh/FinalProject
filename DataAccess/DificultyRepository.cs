using DataAccess.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DificultyRepository : Repository<Dificulty>, IDificultyRepository
    {
        public DificultyRepository(RecipesDataContext context) : base(context)
        {
        }
    }
}
