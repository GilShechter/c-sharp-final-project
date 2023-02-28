using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project
{
    public class Exam
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset DateTime { get; set; }
        public Teacher Teacher { get; set; }
        public int Duration { get; set; }
        public bool isRandom { get; set; }

        public Exam(string name, DateTimeOffset dateTime, Teacher teacher, int duration, bool isRandom)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Name = name;
            this.DateTime = dateTime.Date;
            this.Teacher = teacher;
            this.Duration = duration;
            this.isRandom = isRandom;
        }
    }
}
