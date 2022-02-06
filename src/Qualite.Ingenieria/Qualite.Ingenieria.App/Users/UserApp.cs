using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Qualite.Ingenieria.App.Model.Users;
using Qualite.Ingenieria.Domain.Entities.Users;
using Qualite.Ingenieria.Domain.Helper;
using Qualite.Ingenieria.Domain.Services.Users;

namespace Qualite.Ingenieria.App.Users
{
    public class UserApp : IUserApp
    {
        private readonly IUserService _userService;                
        private readonly IAuthenticationService _authenticationService;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserApp(IUserService userService, 
            IAuthenticationService authenticationService, IPasswordHasher<User> passwordHasher)
        {
            _userService = userService;            
            _authenticationService = authenticationService;
            _passwordHasher = passwordHasher;
        }

        public async Task<User> FindByEmail(string email)
        {
            return await _userService.FindByEmail(email);
        }

        public async Task<User> FindByUsername(string username)
        {
            return await _userService.FindByUsername(username);
        }

        public async Task<IActionResult> SignInUserAsync(User user, string returnUrl, bool isPersist = false)
        {
            await _authenticationService.SignInAsync(user, isPersist);

            return new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Products", Action = "Index" }));
        }

        public async Task<UserLoginResults> ValidateUserAsync(string? usernameOrEmail, string? password)
        {
            User user = usernameOrEmail.Contains('@') ? await _userService.FindByEmail(usernameOrEmail) : await _userService.FindByUsername(usernameOrEmail);

            if (user == null)
                return UserLoginResults.UserNotExist;

            var verificationResult = _passwordHasher.VerifyHashedPassword(user, user.Password, password);

            if (verificationResult == PasswordVerificationResult.Failed)
                return UserLoginResults.WrongPassword;

            return UserLoginResults.Successful;
        }

        public async Task<UserRegistrationResult> RegisterUserAsync(UserRegistrationSignature signature)
        {
            UserRegistrationResult result = new();

            if (signature == null)
            {
                result.AddError("El formulario debe ser llenado");
                return result;
            }

            if (string.IsNullOrEmpty(signature.Email))
            {
                result.AddError("El campo de correo electrónico debe ser completado");
                return result;
            }

            if (string.IsNullOrEmpty(signature.Username))
            {
                result.AddError("El campo de nombre de usuario debe completarse");
                return result;
            }

            User user = await _userService.FindByEmail(signature.Email);

            if (user != null)
            {
                result.AddError("El usuario ya existe en nuestra base de datos");
                return result;
            }

            if (!CommonHelper.IsValidEmail(signature.Email))
            {
                result.AddError("Email inválido");
                return result;
            }

            User userToStore = new(signature.Name, signature.Username, signature.Email, signature.Password, DateTime.Now, 1);

            string passwordHashed = _passwordHasher.HashPassword(userToStore, signature.Password);

            await _userService.CreateAsync(new User(signature.Name, signature.Username, signature.Email, passwordHashed, DateTime.Now, 1));

            return result;
        }
    }
}
