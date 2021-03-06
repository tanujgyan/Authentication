using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace Basics.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }
        public IActionResult Authenticate()
        {
            //We are trying to create an identity for the user. User can have many identities like passport, driver's license
            //may be someone can vouch for you that also becomes an identity. Here momClaims is like your mom vouching for you and establishing your identity
            var momClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,"Tanuj"),
                new Claim(ClaimTypes.Email,"Tanuj@tanuj.com"),
                new Claim("Nickname","Shannu")
            };
            //Here we add another Identity
            var licenseClaims = new List<Claim>()
            {
            new Claim(ClaimTypes.Name,"Tanuj Gyan"),
            new Claim(ClaimTypes.Email,"Tanuj@tanuj.com"),
            new Claim("LicenseNumber","3421")
            };
            //Once you have the claim ready you can use the claim to create an identity
            //The identity here is created using momClaims and has a name Mom Authentication
            var momIdentity = new ClaimsIdentity(momClaims, "Mom Authentication");
            
            //The identity here is created using licenseClaims and has a name License Authentication
            var licenseIdentity = new ClaimsIdentity(licenseClaims, "License Authentication");
            
            //Once you have your identity/identities we will add it to your ClaimsPrincipal 
            var userprincipal = new ClaimsPrincipal(new[] { momIdentity,licenseIdentity });

            HttpContext.SignInAsync(userprincipal);
            return RedirectToAction("Index");
        }
    }
}
