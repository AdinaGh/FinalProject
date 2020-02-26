using DataAccess.Interfaces;
using Entities.Models;

namespace DataAccess
{
    public class DificultyRepository : Repository<Dificulty>, IDificultyRepository
    {
        public DificultyRepository(RecipesDataContext context) : base(context)
        {
        }
    }
}
