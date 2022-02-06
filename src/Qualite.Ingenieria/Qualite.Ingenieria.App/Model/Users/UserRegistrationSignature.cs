using Qualite.Ingenieria.Domain.Model.Input;
using System.ComponentModel.DataAnnotations;

namespace Qualite.Ingenieria.App.Model.Users
{
    public class UserRegistrationSignature : IUserRegistrationSinature
    {        
        public string? Name { get; set; }

        public string? Username { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? ConfirmEmail { get; set; }

        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }

        public bool IsStatementsAgreed { get; set; }
    }
}
