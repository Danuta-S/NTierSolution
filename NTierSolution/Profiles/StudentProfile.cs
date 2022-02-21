using AutoMapper;
using NTierSolution.Entity;
using NTierSolution.MVC.UI.Models;

namespace NTierSolution.MVC.UI.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Students, StudentsModel>().ReverseMap();
        }
    }
}
