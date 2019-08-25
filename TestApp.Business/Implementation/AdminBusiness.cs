using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TestApp.Data;
using TestApp.Data.Implementaion;
using TestApp.Data.Models;

namespace TestApp.Business.Implementation
{
    public class AdminBusiness : IAdminBusiness
    {
        private readonly IAdminRepository adminRepository;

        public AdminBusiness() => adminRepository = new AdminRepository();

        public List<UsersList> GetUsersList()
        {
            return this.adminRepository.GetUsersList();
        }
        public bool DeleteUser(int id)
        {
            return this.adminRepository.DeleteUser(id);
        }

    }
}