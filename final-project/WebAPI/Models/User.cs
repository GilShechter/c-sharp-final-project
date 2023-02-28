namespace WebAPI.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public bool isTeacher { get; set; }
        public override string ToString()
        {
            return this.Name;
        }
        public User(string name, string id, bool isTeacher)
        {
            this.Name = name;
            this.Id = id;
            this.isTeacher = isTeacher;
        }
    }
}
