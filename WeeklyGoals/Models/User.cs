namespace WeeklyGoals.Models
{
    public class User
    {
        public User(string username, string email)
        {
            Username = username;
            Email = email;
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
