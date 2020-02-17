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
    public class CuisineService : Service<Cuisine>, ICuisineService
    {
        public CuisineService(IRepository<Cuisine> repository) : base(repository)
        {
        }
    }
}
