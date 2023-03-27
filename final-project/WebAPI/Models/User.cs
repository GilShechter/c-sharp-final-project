using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class User
    {
        [Key]
        public string Name { get; set; }
        public string Id { get; set; }
        public string Password { get; set; }
        public bool isTeacher { get; set; }
        public ICollection<ExamUser>? examUser { get; set; }
    }
}
