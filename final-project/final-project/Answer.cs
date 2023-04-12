namespace final_project
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string Content { get; set; }
        public bool CorrectAnswer { get; set; }

        public override string ToString()
        {
            return this.Content;
        }

        public Answer(string Content, bool CorrectAnswer)
        {
            this.Content = Content;
            this.CorrectAnswer = CorrectAnswer;
        }



    }
}
