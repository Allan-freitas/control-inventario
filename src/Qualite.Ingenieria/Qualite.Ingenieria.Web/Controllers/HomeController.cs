using Microsoft.AspNetCore.Mvc;
using Qualite.Ingenieria.App.Model.Users;
using Qualite.Ingenieria.App.Users;
using Qualite.Ingenieria.Domain.Entities.Users;
using Qualite.Ingenieria.Web.Models;
using System.Diagnostics;

namespace Qualite.Ingenieria.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserApp _userApp;

        public HomeController(ILogger<HomeController> logger, IUserApp userApp)
        {
            _logger = logger;
            _userApp = userApp;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginSignature loginSignature, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                UserLoginResults loginResults = await _userApp.ValidateUserAsync(loginSignature.Email, loginSignature.Password);

                switch (loginResults)
                {
                    case UserLoginResults.Successful:
                        {
                            var user = loginSignature.Email.Contains('@') ? 
                                await _userApp.FindByEmail(loginSignature.Email) : await _userApp.FindByUsername(loginSignature.Email);

                            return await _userApp.SignInUserAsync(user, returnUrl, loginSignature.RememberMe);
                        }
                    case UserLoginResults.UserNotExist:
                        ModelState.AddModelError("", "el usuario no existe");
                        break;
                    case UserLoginResults.WrongPassword:
                    default:
                        ModelState.AddModelError("", "Las credenciales proporcionadas son incorrectas");
                        break;
                }
            }

            return View(loginSignature);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegistrationSignature userRegistrationSignature)
        {            
            return View();
        }

        public IActionResult Forgot()
        {
            return View();
        }

        public IActionResult Reset()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}