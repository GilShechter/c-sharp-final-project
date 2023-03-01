using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public Question Question { get; set; }
        public string Content { get; set; }
        public bool CorrectAnswer { get; set; }
    }
}
