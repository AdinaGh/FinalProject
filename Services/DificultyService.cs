using DataAccess.Interfaces;
using Entities.Models;
using Services.Interfaces;

namespace Services
{
    public class DificultyService : Service<Dificulty>, IDificultyService
    {
        public DificultyService(IRepository<Dificulty> repository) : base(repository)
        {
        }
    }
}
