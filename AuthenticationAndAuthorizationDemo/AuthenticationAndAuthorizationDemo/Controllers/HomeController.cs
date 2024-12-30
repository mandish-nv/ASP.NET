using System.Diagnostics;
using AuthenticationAndAuthorizationDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication; //req
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization; //req
using System.Security.Claims; 

namespace AuthenticationAndAuthorizationDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        //to authorize a person should be authenticate first
        //for authentication and authorization cookie is used as unique identifier
        //step 1: create controller and use annotation [authorize]
        //step 2: add authentication mechanism (cookie) in program.cs
        //step 3: make user to login first if login success then make authorize
        [Authorize]
        public IActionResult Dashboard()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Contact()
        {
            return View();
        }
        //creating login controller for authentication
        [HttpGet]
        public IActionResult Login(String returnUrl)
        {
            //semd url to view for this we will use viewData
            ViewData["returnUrl"] = returnUrl; //pass data to view
            return View();
        }
        //creating login action method with post annotation
        //checking authentication: username password if match add
        [HttpPost]
        public IActionResult Login(string uname, string pass, string returnUrl)
        {
            if (uname == "ram" && pass == "ram")
            {
                //add authorization: claim, claimIdentity, claimPrincipal
                //claim: detail of authorization, which indentifier to be used
                List<Claim> cl = new List<Claim>();
                cl.Add(new Claim(ClaimTypes.NameIdentifier, uname));
                cl.Add(new Claim(ClaimTypes.Name, uname));
                //for roles admin: add role
                cl.Add(new Claim(ClaimTypes.Role, "Admin")); //for others as well
                //claim identity: how to authoriza (token or cookie)
                ClaimsIdentity ci = new ClaimsIdentity(cl, CookieAuthenticationDefaults.AuthenticationScheme);
                //claim principal: whom to authorize
                ClaimsPrincipal cp = new ClaimsPrincipal(ci);
                //executing authorization mechanism
                HttpContext.SignInAsync(cp);
                return Redirect(returnUrl);
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
