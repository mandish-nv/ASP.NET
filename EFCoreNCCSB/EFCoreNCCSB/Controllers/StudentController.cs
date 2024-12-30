using Microsoft.AspNetCore.Mvc;
using EFCoreNCCSB.Models;

namespace EFCoreNCCSB.Controllers
{
    //controller is responsible for transferring the request and
    //handling the income request
    //to interact with database and table context class (StudentContext)
    //will be used
    public class StudentController : Controller
    {
        //setting the object of student context
        private readonly StudentContext sc; //db transaction model //readonly -> set only no need to edit
        public StudentController(StudentContext sc)
        {
            this.sc = sc;
        }
        //creating action method for form
        [HttpGet]
        public IActionResult AddStudent()
        {
            //create form
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(InsertStudent s)
        {
            //transferring form value to database table
            var s1 = new Student()
            {
                //left-hand-side = table & right-hand-side = form
                Id = s.Id,
                Name = s.Name,
                Gender = s.Gender,
                Faculty = s.Faculty,
                Fee = s.Fee
            };
            //trnasferring into database table
            sc.Students.Add(s1);
            sc.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            var disStd = sc.Students.ToList();
            return View(disStd);
        }
        //creating action method for edit operation
        //it takes id as parameter and check if id is matched
        //with database record or not. If matched retrieve all
        //the data and send to model.
        //create view to edit info and save to database
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            //cehcking whether id is matched with database model
            var upstd = sc.Students.FirstOrDefault(x => x.Id == id);
            if (upstd != null)
            {
                //sending data of upstd to model
                var up1 = new UpdateStudent()
                {
                    Id = upstd.Id,
                    Name = upstd.Name,
                    Gender = upstd.Gender,
                    Faculty = upstd.Faculty,
                    Fee = upstd.Fee
                };
                return View(up1);
            }
            return RedirectToAction("Index");
        }
        //data after updation will redirect into post method of edit
        [HttpPost]
        public IActionResult Edit(UpdateStudent u)
        {
            //check id from UpdateStident is correct or not then save to db
            var editStd = sc.Students.Find(u.Id);
            if (editStd != null)
            {
                editStd.Id = u.Id; //submitting updateStudent id to object
                editStd.Name = u.Name;
                editStd.Gender = u.Gender;
                editStd.Faculty = u.Faculty;
                editStd.Fee = u.Fee;
                sc.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        //delete operation: id sent from index should be
        //checked with database
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var delStd = sc.Students.Find(id);
            if (delStd != null)
            {
                sc.Students.Remove(delStd);
                sc.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
