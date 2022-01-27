using ProiectDAW.Models;
using ProiectDAW.DTO;
using ProiectDAW.Repositories.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Services.UserService
{
    public class UserService :IUserService
    {
        public IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDTO GetDataMappedByUsername(string username)
        {
            User user = _userRepository.GetByUsernameIncludingAddress(username);
            UserDTO result = new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.Username,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email
            };
            return result;
        }

        public UserDTO Create(UserDTO user)
        {
            User newUser = new User
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.Username,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email
            };
            _userRepository.Create(newUser);
            return user;
        }

        public async Task<List<UserDTO>> Get()
        {
            var allUsers = await _userRepository.GetAll();
            var usersDTO = new List<UserDTO>();
            foreach (User user in allUsers)
            {
                UserDTO newUser = new UserDTO
                {
                    Id = user.Id,
                    Name = user.Name,
                    Username = user.Username,
                    Password = user.Password,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email
                };
                //System.Diagnostics.Debug.WriteLine("userService");
                usersDTO.Add(newUser);
            }

            return usersDTO;
        }

        public async Task<UserDTO> GetById(Guid id)
        {
            var user = await _userRepository.FindByIdAsync(id);
            UserDTO result = new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.Username,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email
            };
            return result;
        }

        public User Update(UserDTO user)
        {
            User newUser = new User
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.Username,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email
            };
            _userRepository.Update(newUser);
            return newUser;
        }

        public Guid Delete(Guid id)
        {
            _userRepository.Delete(id);
            return id;

        }
    }
}
