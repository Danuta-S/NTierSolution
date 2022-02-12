namespace NTierSolution.MVC.UI.Models
{
    public class StudentsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public IEnumerable<StudentsModel> Students { get; set; }
    }
}