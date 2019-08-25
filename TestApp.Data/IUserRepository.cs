using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Data.Models;

namespace TestApp.Data
{
    public interface IUserRepository
    {
        bool AddUser(Register regModel);
        UsersList GetUser(int id);
        bool UpdateUser(UpdateUser model);
        bool AddUserSkills(UserData model);
    }
}
