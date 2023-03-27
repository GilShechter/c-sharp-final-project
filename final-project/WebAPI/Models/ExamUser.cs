namespace WebAPI.Models
{
    public class ExamUser
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public string userName { get; set; }
        public int Grade { get; set; }
    }
}
