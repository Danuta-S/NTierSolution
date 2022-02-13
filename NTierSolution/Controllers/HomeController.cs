using Microsoft.AspNetCore.Mvc;
using NtierSolution.BLL;
using NTierSolution.Entity;
using NTierSolution.Models;
using NTierSolution.MVC.UI.Models;
using System.Diagnostics;

namespace NTierSolution.MVC.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BusinessLogic _businessLogic;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _businessLogic = new BusinessLogic();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //public IActionResult OnPost()
        //{
        //    if (!(students is null || !ModelState.IsValid))
        //    {
        //        db.Students.Add(Students);
        //        db.SaveChanges();
        //        return RedirectToPage("/StudentList");
        //    }
        //    else
        //    {
        //        return StudentList(); // return to original page
        //    }
        //}
        //[HttpPost]

        public List<Students> GetListOfStudents()
        {
            return _businessLogic.GetStudentsList();

        }

        public IActionResult StudentList()
        {
            IList<Students> studentList = new List<Students>();
            studentList.Add(new Students() { Name = "Bill" });
            studentList.Add(new Students() { Name = "Steve" });
            studentList.Add(new Students() { Name = "Ram" });

            ViewData["StudentList"] = studentList;
            //var students = _businessLogic.GetStudentsList();
            return View();
        }

        //[HttpGet]
        //public IActionResult ModifyViewData(StudentsModel viewModel)
        //{
        //    var students = viewModel.Students;
        //    _businessLogic.AddStudents(student);
        //    return RedirectToAction("StudentList");
        //}

        //public IActionResult StudentList()
        //{
        //    var students = _businessLogic.GetStudentsList();
        //    var model = new StudentsModel();
        //    return View(model);
        //}

        //[HttpPost]
        //public IActionResult StudentList(UI.Models.StudentsModel viewModel)
        //{
        //    IEnumerable<NTierSolution.Entity.Students> students;
        //    return View(viewModel);
        //}

        [HttpPost]
        public IActionResult AddStudent()
        {
            var student = new Students()
            {
                Id = 1,
                Name = "John",
                Surname = "Doe"
            };

            _businessLogic.AddStudents(student);
            var viewModel = new StudentsModel();
            return View(viewModel);
        }

        public IActionResult DeleteStudent(int id)
        {
            _businessLogic.DeleteStudent(id);
            return RedirectToAction("StudentList");
        }
     
        public IActionResult UpdateStudent(int id, StudentsModel viewModel)
        {
            _businessLogic.UpdateStudent(id);
            return RedirectToAction("StudentList");
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}