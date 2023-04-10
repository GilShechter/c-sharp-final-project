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
        public int ExamId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset DateTime { get; set; }
        public string TeacherName { get; set; }
        public int Duration { get; set; }
        public bool isRandom { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<ExamUser>? examUser { get; set; }

        public Exam() { }
        public Exam(string name, DateTimeOffset dateTime, User teacher, int duration, bool isRandom, List<Question> questions)
        {
            this.Name = name;
            this.DateTime = dateTime.Date;
            this.TeacherName = teacher.Name;
            this.Duration = duration;
            this.isRandom = isRandom;
            this.Questions = questions;
            this.examUser = new List<ExamUser>();
        }

        public Exam(string name, DateTimeOffset dateTime, string teacher, int duration, bool isRandom, List<Question> questions)
        {
            this.Name = name;
            this.DateTime = dateTime.Date;
            this.TeacherName = teacher;
            this.Duration = duration;
            this.isRandom = isRandom;
            this.Questions = questions;
            this.examUser = new List<ExamUser>();
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
            string nameCol = (this.Name.Length - 70).ToString();
            string durationCol = (this.Duration.ToString().Length - 10).ToString();
            string teacherCol = (this.TeacherName.Length - 70).ToString();
            return string.Format("{0," + nameCol + "}{1," + durationCol + "}{2," + teacherCol + "}{3,10}",
            this.Name, this.Duration, this.TeacherName, this.DateTime.Date);
        }
    }
}
