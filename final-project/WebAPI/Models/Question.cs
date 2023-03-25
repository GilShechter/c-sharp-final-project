namespace WebAPI.Models
{
    public class Question
    {
        public int? QuestionId { get; set; }
        public string? Content { get; set; }
        public string? ImgPath { get; set; }
        public string? ImgName { get; set; }
        public int ChosenAnswer { get; set; }
        public int ExamID { get; set; }
        public ICollection<Answer>? Answers { get; set; }
    }
}
