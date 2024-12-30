using Microsoft.AspNetCore.Mvc;

using MVCPractise.Models; // to access model
namespace MVCPractise.Controllers
{
    //constroller is used to handle and provide http request and response
    //for further data it can use model. in . net core controller is the c# class that inherits 
    //Controller class. it contains action method that return view i.e for every action method
    //ther should be view for it
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details()
        {

            //accessing model Student, setting it's properties and send to view
            Student s1 = new Student()
            {
                Id = 1,
                Name = "Atullya",
                Faculty = "Science"
            };
            return View(s1); //add views -> razor empty
        }
    }
}
