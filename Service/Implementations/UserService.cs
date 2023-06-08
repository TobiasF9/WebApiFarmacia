using Model.DTO;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiMedicines.Models;

namespace Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly MedicinesAPIContext _context;

        public UserService(MedicinesAPIContext _context)
        {
            this._context = _context;
        }

        public UserDTO CreateUser(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserDTO> GetUserList()
        {
            throw new NotImplementedException();
        }

        public List<UserDTO> ModifyUser(int id, UserDTO user)
        {
            throw new NotImplementedException();
        }

        public List<UserDTO> RemoveUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
