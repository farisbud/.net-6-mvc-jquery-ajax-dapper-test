using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pusdafi_Dev.Helper;
using Pusdafi_Dev.Interface;
using Pusdafi_Dev.Models;
using Pusdafi_Dev.ViewModels.LoginVM;
using System.Net;
using System.Net.WebSockets;
using System.Security.Claims;

namespace Pusdafi_Dev.Controllers.Admin
{
    //[Route("")]
    //[Route("home/admin")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly LoginIntf _loginIntf;

        public AdminController(ILogger<AdminController> logger, LoginIntf loginIntf)
        {
            _logger = logger;
            _loginIntf = loginIntf;
           
        }

        //[Authorize(Policy = "AdminOnly")]
        [Authorize]
        [Route("admin/dashboard")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("admin")]
        [HttpGet]
        public IActionResult Login()
        {
            if(HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Dashboard", "Admin");
            }
           
            
            return View();

           
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            var user = await _loginIntf.AuthenticateUserAsync(loginVM.Email);

            if (user != null)
            {

                if (Hashing.ValidatePassword(loginVM.Password, user.Password))
                {
                    
                    var claims = new List<Claim>
                    {
                        new Claim (ClaimTypes.Name, user.Name),
                        new Claim (ClaimTypes.Email, user.Email)
                      //  ,new Claim ("Departement","HR")
                    //  ,new Claim("Manager","true")
                       // ,new Claim ("Admin","True")
                    };

                    var identity = new ClaimsIdentity (claims, "pusdafiCookie");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal (identity);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = loginVM.rememberMe
                    };

                    await HttpContext.SignInAsync("pusdafiCookie", claimsPrincipal, authProperties);



                    return RedirectToAction("Dashboard", "Admin");
                    //Session.Add("Username", user.Username);
                }
                else
                {
                    //password incorecct
                    TempData["Error"] = "Wrong credentials. Please try again";
                    return View();
                }
            }

            TempData["Error"] = "Wrong credentials. Please try again";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
           await HttpContext.SignOutAsync("pusdafiCookie");
            return View("Login");
        }

       
    }
}
