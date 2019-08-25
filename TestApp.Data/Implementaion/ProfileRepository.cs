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
    public class ProfileRepository : IProfileRepository
    {  
        public UserInfo Login(Login loginModel)
        {
            using (TestAppDbEntities context = new TestAppDbEntities())
            {
                UserInfo result=null;
                var data = context.UserInfoes
                       .Where(o => o.Email == loginModel.Email && o.Password == loginModel.Password)
                       .FirstOrDefault();
                if (data != null)
                {

                    result = new UserInfo()
                    {
                        Name = data.Name,
                        Email = data.Email,
                        UserId = data.UserId,
                        Age = data.Age,
                        DOB = data.DOB,
                        Location = data.Location,
                        UsrType = data.UsrType
                    };
                }
                return result;
            }
        }
      
    }
}
