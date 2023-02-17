
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using WebApp1.Data;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext context;

        public UserController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost("Login")]
        public IActionResult Login(Login loginmodel)
        {

            //if(!ModelState.IsValid) return View(loginmodel);

            var user = context.Users.FirstOrDefault(row => row.Username.Equals(loginmodel.Username) && row.Password.Equals(loginmodel.Password));

            if (user == null) return View(loginmodel);

           return RedirectToAction("Index", "Home");
           
        }
        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost("Register")]
        public IActionResult Register(Registration registermodel)
        {

            if (!ModelState.IsValid) return View(registermodel);
            var user = new UserModel()
            {
                Email = registermodel.Email,
                Name = registermodel.Name,
                Password = registermodel.Password,
                Username = registermodel.Username
            };
            context.Users.Add(user);
            context.SaveChanges();


            //var user = context.Users.FirstOrDefault(row => row.Username.Equals(loginmodel.Username) && row.Password.Equals(loginmodel.Password));

            return View("Login");
        }
    }
}
