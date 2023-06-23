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
            //var users = _context.Users.ToList();
            //var response = new List<UserDTO>();

            //foreach (var x in users)
            //{
            //    response.Add(new UserDTO()
            //    {
            //        Id = x.Id,
            //        Name = x.Name,
            //        IdRole = x.IdRole
            //    });
            //}

            //return response;
            return _mapper.Map<List<UserDTO>>(_context.Users.ToList());
        }

        public UserDTO GetUserById(int id)
        {
            var users = _context.Users.ToList().Where(x => x.Id == id).First();
            var response = new UserDTO()
            {
                Id = users.Id,
                Name = users.Name,
                IdRole = users.IdRole
            };

            return response;
        }
        public UserDTO CreateUser(UserViewModel user)
        {
            _context.Users.Add(new Users()
            {
                //Id = user.Id,
                Name = user.Name,
                IdRole = user.IdRole
            });
            _context.SaveChanges();
            var response = new UserDTO
            {
                    Id = user.Id,
                    Name = user.Name,
                    IdRole = user.IdRole
            };
            
            return response;
        }

        public List<UserDTO> ModifyUser(int id, UserViewModel user)
        {
            _context.Users.ToList().Where(x => x.Id == id).First().Id = user.Id;
            _context.Users.ToList().Where(x => x.Id == id).First().Name = user.Name;
            _context.Users.ToList().Where(x => x.Id == id).First().IdRole = user.IdRole;

            _context.SaveChanges();
            var response = new List<UserDTO>();

            foreach (var x in _context.Users)
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

        public UserDTO RemoveUser(int id)
        {
            var userToDelete = _context.Users.ToList().Where(x => x.Id == id).First();
            _context.Users.Remove(userToDelete);

            _context.SaveChanges();
            var response = new UserDTO
            {
                Id = userToDelete.Id,
                Name = userToDelete.Name,
                IdRole = userToDelete.IdRole
            };
            return response;
        }
    }
}
