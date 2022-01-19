using ProiectDAW.DTO;
using ProiectDAW.Models;
using ProiectDAW.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Repositories.UserRepository
{
    public interface IUserRepository: IGenericRepository<User>
    {
        User GetByUsername(string username);
        User GetByUsernameIncludingAddress(string username);

        List<User> GetAllWithInclude();
        List<User> GetAllWithJoin();
    }
}
