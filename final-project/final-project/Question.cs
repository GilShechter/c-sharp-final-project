using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project
{
    public class Question
    {
        public string content { get; set; }
        public string imgPath { get; set; }
        public string imgName { get; set; }
        public int chosenAnswer { get; set; }
        public ICollection<Answer> answers { get; set; }
        public int? questionId { get; set; }
        public int ExamID { get; set; }

        public Question() { }

        public Question(string content, List<Answer> answers)
        {
            this.content = content;
            this.imgPath = "";
            this.imgName = "";
            this.answers = answers;
            this.chosenAnswer = -1;
        }

        public Question(string imgPath, string imgName, List<Answer> answers)
        {
            this.content = "";
            this.imgPath = imgPath;
            this.imgName = imgName;
            this.answers = answers;
            this.chosenAnswer = -1;
        }

        public override string ToString()
        {
            return "Question " + this.questionId.ToString();
        }
    }
}
