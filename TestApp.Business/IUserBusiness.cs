using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Data;
using TestApp.Data.Models;

namespace TestApp.Business
{
    public interface IUserBusiness
    {
        bool AddUser(Register regModel);
        UsersList GetUser(int id);
        bool UpdateUser(UpdateUser model);
        bool AddUserSkills(UserData model);
    }
}
