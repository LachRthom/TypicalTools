using Microsoft.AspNetCore.Mvc;
using TypicalTechTools.Models;
using TypicalTechTools.Models.Repositories;

namespace TypicalTools.Controllers
{
    public class AdminController : Controller
    {

        private readonly IAuthenticationRepository _authenticationRepository;

        public AdminController(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }


        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminLogin(LoginDTO loginDTO)
        {
            var user = _authenticationRepository.Authenticate(loginDTO);

            if (user == null)
            {
                ViewBag.LoginMessage = "Username or Password incorrect";
                return View();
            }

            HttpContext.Session.SetString("Authenticated", "True");
            return RedirectToAction("Index", "Product");
        }

        public IActionResult AdminLogOff()
        {
            HttpContext.Session.SetString("Authenticated", "False");
            return RedirectToAction("Index", "Product");
        }


        public IActionResult AdminLoginSuccess()
        {
            return View();
        }

        public IActionResult Create()
        {
            string authenticated = HttpContext.Session.GetString("Authenticated") ?? "False";
            if (!authenticated.Equals("True", StringComparison.OrdinalIgnoreCase))
            {
                return RedirectToAction("AdminLogin", "Admin");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateUserDTO createDTO)
        {
            // Check for password match between the two fields
            if (!createDTO.Password.Equals(createDTO.PasswordConfirmation))
            {
                ViewBag.CreateUserError = "Passwords do not match";
                // Clear the password fields
                createDTO.Password = string.Empty;
                createDTO.PasswordConfirmation = string.Empty;
                return View(createDTO);
            }

            // Attempt to add the new user
            var newUser = _authenticationRepository.CreateAdminUser(createDTO);

            if (newUser == null)
            {
                ViewBag.CreateUserError = "Failed to create user account, user already exists";
                return View(createDTO);
            }

            // Clear the model state and confirm success
            ModelState.Clear();
            ViewBag.CreateUserConfirmation = "User account created successfully";
            return View();
        }

    }
}
