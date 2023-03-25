using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project
{
    public class Exam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset DateTime { get; set; }
/*        public User Teacher { get; private set; }
*/        public string TeacherName { get; set; }
        public int Duration { get; set; }
        public bool isRandom { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<User> Students { get; set; }

        public Exam() { }
        public Exam(string name, DateTimeOffset dateTime, User teacher, int duration, bool isRandom, List<Question> questions)
        {
            this.Id = Guid.NewGuid().GetHashCode();
            this.Name = name;
            this.DateTime = dateTime.Date;
            this.TeacherName = teacher.Name;
            this.Duration = duration;
            this.isRandom = isRandom;
            this.Questions = questions;
            this.Students = new List<User>();
        }

        public Exam(string name, DateTimeOffset dateTime, string teacher, int duration, bool isRandom, List<Question> questions)
        {
            this.Id = Guid.NewGuid().GetHashCode();
            this.Name = name;
            this.DateTime = dateTime.Date;
            this.TeacherName = teacher;
            this.Duration = duration;
            this.isRandom = isRandom;
            this.Questions = questions;
            this.Students = new List<User>();
        }

        public int getSolvedQuestionsCount()
        {
            int counter = 0;
            foreach (Question question in this.Questions)
            {
                if (question.chosenAnswer != -1)
                {
                    counter++;
                }
            }
            return counter;
        }

        public override string ToString()
        {
            return $"{this.Name} \t\t {this.Duration} mins \t\t Teacher: {this.TeacherName} \t\t Starts at: {this.DateTime.Date} {this.DateTime.TimeOfDay}";
        }
    }
}
