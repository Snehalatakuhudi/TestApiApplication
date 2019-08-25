using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Data.Models
{
    public class UpdateUser
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? Age { get; set; }
        public DateTime? DOB { get; set; }
        public string Location { get; set; }
        public string UsrType { get; set; }
        public List<UserSkill> userSkills { get; set; }
    }
    public class UserSkill
    {
        public int id { get; set; }
        public string Skill { get; set; }
        public string Experience { get; set; }
        public string Certification { get; set; }
        public int? UserId { get; set; }
    }
}
