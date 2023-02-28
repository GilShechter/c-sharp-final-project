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
        public Answer[] answers { get; set; }
        public int Id { get; set; }

        public Question(string content, Answer[] answers)
        {
            Id = -1;
            this.content = content;
            this.imgPath = "";
            this.imgName = "";
            this.answers = answers;
            this.chosenAnswer = -1;
        }

        public Question(string imgPath, string imgName, Answer[] answers)
        {
            Id = -1;
            this.content = "";
            this.imgPath = imgPath;
            this.imgName = imgName;
            this.answers = answers;
            this.chosenAnswer = -1;
        }
        public override string ToString()
        {
            return "Question " + this.Id.ToString();
        }
    }
}
