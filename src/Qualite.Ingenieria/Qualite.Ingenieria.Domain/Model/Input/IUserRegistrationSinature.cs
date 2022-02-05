namespace Qualite.Ingenieria.Domain.Model.Input
{
    public interface IUserRegistrationSinature
    {        
        public string? Name { get; set; }

        public string? Username { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }
    }
}
