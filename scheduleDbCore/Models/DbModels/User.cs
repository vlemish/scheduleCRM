namespace scheduleDbCore.Models.DbModels
{
    public class User
    {
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public User() { }


        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public IdentityType Identity { get; set; }
    }
}
