using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project
{
    public class ExamUser
    {
        public int Id { get; set; }
        public int? ExamId { get; set; }
        public string userName { get; set; }
        public int Grade { get; set; }

        public ExamUser() { }
        public ExamUser(Exam exam, User user, int grade)
        {
            this.ExamId = exam.ExamId;
            this.userName = user.Name;
            Grade = grade;
        }
        public ExamUser(Exam exam, User user)
        {
            this.ExamId = exam.ExamId;
            this.userName = user.Name;
            Grade = 0;
        }
        public override string ToString()
        {
            return this.userName + ": " + this.Grade.ToString();
        }
    }
}
