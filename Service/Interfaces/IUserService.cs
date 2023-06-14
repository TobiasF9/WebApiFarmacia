using Model.DTO;
using Model.Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserService
    {
        List<UserDTO> GetUserList();
        UserDTO GetUserById(int id);
        UserDTO CreateUser(UserDTO user);
        List<User> ModifyUser(int id, UserDTO user);
        User RemoveUser(int id);
    }
}
