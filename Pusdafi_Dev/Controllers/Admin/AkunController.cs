using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pusdafi_Dev.Helper;
using Pusdafi_Dev.Interface;
using Pusdafi_Dev.Models;
using Pusdafi_Dev.ViewModels.RegisterVM;

namespace Pusdafi_Dev.Controllers.Admin
{
    [Authorize(Policy = "AdminOnly")]
    public class AkunController : Controller
    {
        private readonly RegisterIntf _registerIntf;
       // private readonly IWebHostEnvironment webHostEnvironment;

        public AkunController(RegisterIntf registerIntf)
        {
            _registerIntf = registerIntf;
           // webHostEnvironment = webHostEnvironment;
        }

        [Route("register")]
        public IActionResult Index()
        {
            return View("~/Views/Admin/Akun/Index.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> registered(RegisterVM registerVM)
        {
            registerVM.Password = Hashing.HashPassword(registerVM.Password);

            if(!ModelState.IsValid)
            {    
                return View("~/Views/Admin/Akun/Index.cshtml");
            }
            var user = new User
            {
                Name = registerVM.Name,
                Username = registerVM.UserName,
                Email = registerVM.Email,
                Password = registerVM.Password,
            };

            var cek = user;

            _registerIntf.Add(user);
            TempData["SuccessMessage"] = "The operation was successful!";
            return View("~/Views/Admin/Login.cshtml");
        }

        
    }
}
