using AutoMapper;
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
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IMapper mapper)
        {
            _logger = logger;
            _businessLogic = new BusinessLogic();
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public List<Students> GetListOfStudents()
        {
            return _businessLogic.GetStudentsList();
        }
        
        public IActionResult StudentList()
        {
            //IList<Students> studentList = new List<Students>();
            //ViewData["StudentList"] = studentList;
            var students = _businessLogic.GetStudentsList();
            var mapperStudents = _mapper.Map<List<Students>, List<StudentsModel>>(students);
            //var modelList = new List<StudentsModel>();
            //foreach (var student in students)
            //{
            //    var modelStudent = new StudentsModel();
            //    modelStudent.Id = student.Id;
            //    modelStudent.Name = student.Name;
            //    modelStudent.Surname = student.Surname;
            //    modelList.Add(modelStudent);
            //}
            //return View(modelList);
            return View(mapperStudents);
        }
        
        public IActionResult AddStudent(StudentsModel studentsModel)
        {
            var student = new Students()
            {
                Id = studentsModel.Id,
                Name = studentsModel.Name,
                Surname = studentsModel.Surname
            };

            _businessLogic.AddStudents(student);
            return RedirectToAction("StudentList");
        }

        public IActionResult DeleteStudent(int id)
        {
            _businessLogic.DeleteStudent(id);
            return RedirectToAction("StudentList");
        }
        
        //[HttpGet]
        public IActionResult UpdateStudent(int id)
        {
            var studentList = _businessLogic.GetStudentById(id);
            var model = new StudentsModel()
            {
                Id = id,
                Name = studentList.Name,
                Surname = studentList.Surname
            };
            return View(model);
            //1.Here yoy should find student by ID
            //2.Add all data from student to student model
            //3.Pass to view
        }

        [HttpPost]
        public IActionResult SubmitUpdateStudent(StudentsModel viewModel)
        {
            var student = new Students
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Surname = viewModel.Surname
            };

            _businessLogic.UpdateStudent(student);
            return Redirect("~/Home/StudentList");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}