using Model.DTO;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Models.DTO;

namespace Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly MedicinesAPIContext _context;

        public UserService(MedicinesAPIContext _context)
        {
            this._context = _context;
        }

        public List<UserDTO> GetUserList()
        {
            var users = _context.User.ToList();
            var response = new List<UserDTO>();

            foreach (var x in users)
            {
                response.Add(new UserDTO()
                {
                    Id = x.Id,
                    Name = x.Name,
                    IdRole = x.IdRole
                });
            }

            return response;
        }

        public UserDTO GetUserById(int id)
        {
            var users = _context.User.ToList().Where(x => x.Id == id).First();
            var response = new UserDTO()
            {
                Id = users.Id,
                Name = users.Name,
                IdRole = users.IdRole
            };

            return response;
        }
        //Rompe aca
        public UserDTO CreateUser(UserDTO user)
        {
            _context.User.Add(new User()
            {
                //Id = user.Id,
                Name = user.Name,
                IdRole = user.IdRole
            });
            _context.SaveChanges();
            return user;
        }

        public List<User> ModifyUser(int id, UserDTO user)
        {
            _context.User.ToList().Where(x => x.Id == id).First().Id = user.Id;
            _context.User.ToList().Where(x => x.Id == id).First().Name = user.Name;
            _context.User.ToList().Where(x => x.Id == id).First().IdRole = user.IdRole;

            _context.SaveChanges();
            return _context.User.ToList();
        }

        public User RemoveUser(int id)
        {
            var userToDelete = _context.User.ToList().Where(x => x.Id == id).First();
            _context.User.Remove(userToDelete);

            _context.SaveChanges();

            return userToDelete;
        }
    }
}
