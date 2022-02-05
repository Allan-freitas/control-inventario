using Qualite.Ingenieria.Domain.Model.Input;

namespace Qualite.Ingenieria.App.Model.Users
{
    public class UserRegistrationSignature : IUserRegistrationSinature
    {        
        public string? Name { get; set; }

        public string? Username { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }
    }
}
