namespace WebAPI.Models
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

    }
}
