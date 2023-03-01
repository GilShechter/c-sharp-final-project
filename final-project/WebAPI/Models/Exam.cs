namespace WebAPI.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset DateTime { get; set; }
        public User Teacher { get; set; }
        public int Duration { get; set; }
        public bool isRandom { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<User> Students { get; set; }

    }
}
