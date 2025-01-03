using Microsoft.AspNetCore.Mvc;

namespace StateManagementDemo.Controllers
{
    public class PracticeController : Controller
    {
        //state management refers to saving the user information
        //through the session
        //if state management is not handled then we have to login each
        //time for each redirect
        //Server side state management:
        //1. temp data: manage the state in page level (for only one page)
        //2. session

        //https://localhost:7245/Practice
        //https://localhost:7245/Practice/AboutUs
        public IActionResult Index()
        {
            //used to pass data from controller to view by managing state
            ViewData["data1"] = "this is data from view data";
            //keyword   var     data
            ViewBag.data2 = "this is data from view bag";
            TempData["data3"] = "data from temp data";
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();        }
    }
}
