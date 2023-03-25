using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string? Content { get; set; }
        public bool CorrectAnswer { get; set; }
        public int QuestionId { get; set; }
    }
}
