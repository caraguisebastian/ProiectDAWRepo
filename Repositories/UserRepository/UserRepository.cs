using Microsoft.EntityFrameworkCore;
using ProiectDAW.Data;
using ProiectDAW.DTO;
using ProiectDAW.Models;
using ProiectDAW.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Repositories.UserRepository
{
    public class UserRepository: GenericRepository<User>, IUserRepository
    {
        public UserRepository(ProiectDAWContext context) : base(context)
        {

        }

        public List<User> GetAllWithInclude()
        {
            return _table.Include(user => user.Address).ToList();
        }

        public async Task<List<User>> GetAllWithIncludeAsync()
        {
            return await _table.Include(user => user.Address).ToListAsync();
        }

        public List<User> GetAllWithJoin()
        {
            var result = _table.Join(_context.Addresses, user => user.Id, address => address.UserId, (user, address) => new { user, address }).Select(obj => obj.user);
            return result.ToList();
        }
        public async Task<List<User>> GetAllWithJoiAsync()
        {
            var result = _table.Join(_context.Addresses, user => user.Id, address => address.UserId, (user, address) => new { user, address }).Select(obj => obj.user);
            return await result.ToListAsync();
        }

        public User GetByUsername(string username)
        {
            return _table.FirstOrDefault(user => user.Username.ToLower().Equals(username.ToLower()));
        }
        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _table.FirstOrDefaultAsync(user => user.Username.ToLower().Equals(username.ToLower()));
        }
        public User GetByUsernameIncludingAddress(string username)
        {
            return _table.Include(user => user.Address).FirstOrDefault(user => user.Username.ToLower().Equals(username.ToLower()));
        }
    }
}
