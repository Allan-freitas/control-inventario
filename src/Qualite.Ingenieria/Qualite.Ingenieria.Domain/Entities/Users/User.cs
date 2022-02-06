namespace Qualite.Ingenieria.Domain.Entities.Users
{
    public class User
    {
        public User(long id, string username, string password, string name, string email, DateTime createdOn)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Username = username;
            CreatedOn = createdOn;
        }

        public User(string name, string username, string email, string password, DateTime createdOn, int roleId)
        {
            Name = name;
            Username = username;
            Email = email;
            Password = password;
            CreatedOn = createdOn;
            RoleId = roleId;
        }

        public long Id { get; init; }

        public string Name { get; init; }

        public string Username { get; init; }

        public string Email { get; init; }

        public string Password { get; init; }

        public DateTime CreatedOn { get; init; }

        public int RoleId { get; init; }
    }
}
