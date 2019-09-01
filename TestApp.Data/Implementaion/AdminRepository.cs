using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Data.Models;

namespace TestApp.Data.Implementaion
{
    public class AdminRepository : IAdminRepository
    {
        public List<UsersList> GetUsersList()
        {
            using (TestAppDbEntities context = new TestAppDbEntities())
            {
                List<UsersList> result = new List<UsersList>();
                UsersList _list = new UsersList();
                List<UserInfo> data = context.UserInfoes.Where(a => a.UsrType == "User").ToList();

                foreach (var x in data)
                {
                    _list = new UsersList();
                    _list.UserId = x.UserId;
                    _list.Name = x.Name;
                    _list.Email = x.Email;
                    _list.DOB = x.DOB;
                    _list.Location = x.Location;

                    result.Add(_list);
                    _list = null;
                }
                return result;
            };
        }

        public bool DeleteUser(int id)
        {
            using (TestAppDbEntities context = new TestAppDbEntities())
            {
                try
                {
                    var user = context.UserInfoes.Where(x => x.UserId == id);
                    var userDetail = context.UserDatas.Where(x => x.UserId == id);

                    context.UserInfoes.RemoveRange(user);
                    context.UserDatas.RemoveRange(userDetail);

                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return true;
        }
    }
}
