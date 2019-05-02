namespace WeeklyGoals.Models
{
    public class User
    {
        public User(string externalId, string username, string email)
        {
            ExternalId = externalId;
            Username = username;
            Email = email;
        }

        public int Id { get; set; }

        public string ExternalId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
