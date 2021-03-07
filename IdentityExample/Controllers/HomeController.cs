using IdentityExample.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public HomeController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var identityUser = await _userManager.FindByNameAsync(userName);
            var result= await _signInManager.PasswordSignInAsync(identityUser, password, false, false);
            if(result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(string username, string password)
        {
            var identityUser = new IdentityUser
            {
                UserName = username,
                Email = ""
            };
           var result= await _userManager.CreateAsync(identityUser, password);
            if(result.Succeeded)
            {
                await _signInManager.PasswordSignInAsync(identityUser, password, false, false);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await  _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
