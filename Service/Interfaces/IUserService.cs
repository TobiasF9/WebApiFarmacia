using Model.DTO;
using Model.Models;
using Model.ViewModel;
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
        UserDTO ModifyUser(UserViewModel user);
        UserDTO RemoveUser(int id);
    }
}
