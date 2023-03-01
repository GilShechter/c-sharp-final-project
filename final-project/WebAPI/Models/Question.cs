namespace WebAPI.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string ImgPath { get; set; }
        public string ImgName { get; set; }
        public int ChosenAnswer { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public Exam Exam { get; set; }
    }
}
