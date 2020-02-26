using DataAccess.Interfaces;
using Entities.Models;
using Services.Interfaces;

namespace Services
{
    public class CuisineService : Service<Cuisine>, ICuisineService
    {
        public CuisineService(IRepository<Cuisine> repository) : base(repository)
        {
        }
    }
}
