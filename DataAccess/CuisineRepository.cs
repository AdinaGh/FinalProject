using DataAccess.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CuisineRepository : Repository<Cuisine>, ICuisineRepository
    {
        public CuisineRepository(RecipesDataContext context) : base(context)
        {
        }
    }
}
