using Qualite.Ingenieria.Domain.Model.Input;
using System.ComponentModel.DataAnnotations;

namespace Qualite.Ingenieria.App.Model.Users
{
    public class LoginSignature : ILoginSignature
    {
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        public string? Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
