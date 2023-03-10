using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project
{
    public class User
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Password { get; set; }
        public bool isTeacher { get; set; }
        public override string ToString()
        {
            return this.Name;
        }
        public User(string name, string id, string password, bool isTeacher)
        {
            this.Name = name;
            this.Id = id;
            this.Password = password;
            this.isTeacher = isTeacher;
        }
    }
}
