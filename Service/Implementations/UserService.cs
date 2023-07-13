using Model.DTO;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Models.DTO;
using Model.ViewModel;
using AutoMapper;
using Services.Mappings;
using Services.Helper;

namespace Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly MedicinesAPIContext _context;
        private readonly IMapper _mapper;

        public UserService(MedicinesAPIContext _context)
        {
            this._context = _context;
            _mapper = AutoMapperConfig.Configure();
        }

        public List<UserDTO> GetUserList()
        {
            return _mapper.Map<List<UserDTO>>(_context.Users.ToList());
        }

        public UserDTO GetUserById(int id)
        {
            var users = _context.Users.ToList().Where(x => x.Id == id).First();
            var response = new UserDTO()
            {
                Id = users.Id,
                Name = users.Name,
                IdRole = users.IdRole,
                Email = users.Email
            };

            return response;
        }

        public UserDTO ModifyUser(UserViewModel user)
        {
            Users userToModify = _context.Users.Single(s => s.Id == user.Id);
            //sellToModify.Id = sell.Id;
            userToModify.Name = user.Name;
            userToModify.IdRole = user.IdRole;
            userToModify.Email = user.Email;
            userToModify.Password = user.Password.GetSHA256();

            _context.SaveChanges();
            var userModfied = _context.Users.FirstOrDefault(x => x.Id == user.Id);

            return _mapper.Map<UserDTO>(userModfied);
        }

        public UserDTO RemoveUser(int id)
        {
            var userToDelete = _context.Users.ToList().Where(x => x.Id == id).First();
            _context.Users.Remove(userToDelete);

            _context.SaveChanges();
            var response = new UserDTO
            {
                Id = userToDelete.Id,
                Name = userToDelete.Name,
                IdRole = userToDelete.IdRole,
                Email = userToDelete.Email
            };
            return response;
        }
    }
}