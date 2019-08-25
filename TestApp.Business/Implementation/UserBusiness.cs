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
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository userRepository;

        public UserBusiness() => userRepository = new UserRepository();
        public bool AddUser(Register regModel)
        {
            regModel.Password = GetHash(regModel.Password); 
            return this.userRepository.AddUser(regModel);
        } 
          
        private static string GetHash(string text)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        public UsersList GetUser(int id)
        {
            return this.userRepository.GetUser(id);
        }

        public bool UpdateUser(UpdateUser model)
        {
            return this.userRepository.UpdateUser(model); ;
        }

        public bool AddUserSkills(UserData model)
        {
            return this.userRepository.AddUserSkills(model);
        }
    }
}