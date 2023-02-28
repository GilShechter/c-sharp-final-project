using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project
{
    public class Answer
    {
        public string content { get; set; }
        public bool correct_answer { get; set; }
        public override string ToString()
        {
            return this.content;
        }

        public Answer(String content)
        {
            this.content = content;
            correct_answer = false;
        }



    }
}
