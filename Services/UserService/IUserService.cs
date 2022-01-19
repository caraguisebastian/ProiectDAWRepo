using ProiectDAW.DTO;
using ProiectDAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Services.UserService
{
    public interface IUserService
    {
        UserDTO GetDataMappedByUsername(string username);
        UserDTO Create(UserDTO user);
    }
}
