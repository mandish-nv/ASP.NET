using Microsoft.AspNetCore.Mvc;
using StateManagementDemo.Models;

namespace StateManagementDemo.Controllers
{
    public class CookieController : Controller
    {
        //Cookie is a information of user id, phone
        //username which
        //stored in client's browser to track client activity.
        //to create cookie, CookieOption is used
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        //controller for creating cookie
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Person p)
        {
            //creating cookie
            CookieOptions cookie = new CookieOptions();
            //expire time limit of cookie. Here it expires after 10 sec
            cookie.Expires = DateTime.Now.AddSeconds(5);
            //setting cookie variable
            Response.Cookies.Append("Username", p.Name, cookie);
                                    //var   //value
            ViewBag.saved = "Cookie saved";
            return View("Index");
        }
        public IActionResult Test()
        {
            //accessing cookie and placing in viewBag
            ViewBag.msg = Request.Cookies["Username"].ToString();
                                                //cookie variable
            return View("Index");              
        }
    }
}
