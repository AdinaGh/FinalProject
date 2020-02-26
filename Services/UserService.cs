using DataAccess.Interfaces;
using Entities.Models;
using Services.Interfaces;

namespace Services
{
    public class UserService : Service<User>, IUserService
    {
        public UserService(IRepository<User> repository) : base(repository)
        {
        }
    }
}
