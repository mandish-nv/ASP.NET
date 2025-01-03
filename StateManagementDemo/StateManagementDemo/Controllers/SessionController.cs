using Microsoft.AspNetCore.Mvc;
using StateManagementDemo.Models;

namespace StateManagementDemo.Controllers
{
    public class SessionController : Controller
    {
        //session is used to save user's information through one
        //particular login time. After logout the information of
        //session is destroyed. To create session either HTTPSession or
        //response.session is used
        public IActionResult CreateSession()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateSession(User u)
        {
            //extracting data from moddel and setting session variable
            string uname = u.Username; //taking data from User model
            string pass = u.Password;
            //setting session
            HttpContext.Session.SetString("susername", uname);
                                            //sessionvar, session value
            HttpContext.Session.SetString("spass", pass);
            return RedirectToAction("Index");
        }
        //accessing session variable in next page
        public IActionResult Index()
        {
            //accessing session variable and sending to view
            ViewBag.firstSession = HttpContext.Session.GetString("susername");
            ViewBag.secondSession = HttpContext.Session.GetString("spass");
            return View();
        }
    }
}
