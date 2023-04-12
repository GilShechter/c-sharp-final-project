using System.Collections.Generic;

namespace final_project
{
    public class User
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Password { get; set; }
        public bool IsTeacher { get; set; }
        public ICollection<ExamUser>? examUser { get; set; }
        public override string ToString()
        {
            return this.Name;
        }

        public User() { }
        public User(string name, string id, string password, bool isTeacher)
        {
            this.Name = name;
            this.Id = id;
            this.Password = password;
            this.IsTeacher = isTeacher;
        }
        public User(string name, string id, string password, bool isTeacher, List<ExamUser> exams)
        {
            this.Name = name;
            this.Id = id;
            this.Password = password;
            this.IsTeacher = isTeacher;
            this.examUser = exams;
        }
    }
}
