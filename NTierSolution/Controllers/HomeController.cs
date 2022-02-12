using Microsoft.AspNetCore.Mvc;
using NtierSolution.BLL;
using NTierSolution.Entity;
using NTierSolution.Models;
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

        [HttpPost]
        public IActionResult StudentList()
        {
            var students = _businessLogic.GetStudentsList();
            var viewModel = new StudentsModel();
            return View(viewModel);
        }

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

        public List<Students> GetListOfStudents()
        {
            return _businessLogic.GetStudentsList();

        }
        [HttpPost]
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