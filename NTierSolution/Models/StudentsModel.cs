namespace NTierSolution.Entity
{
    public class StudentsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Students>? Students { get; set; }
    }
}