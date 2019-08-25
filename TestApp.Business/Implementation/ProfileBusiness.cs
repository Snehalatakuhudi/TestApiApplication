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
    public class ProfileBusiness : IProfileBusiness
    {
        private readonly IProfileRepository profileRepository;

        public ProfileBusiness() => profileRepository = new ProfileRepository();
    
        public UserInfo Login(Login loginModel)
        {
            loginModel.Password = GetHash(loginModel.Password);
            return this.profileRepository.Login(loginModel);
        }
          
        private static string GetHash(string text)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}