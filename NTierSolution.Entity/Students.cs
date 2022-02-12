using System.ComponentModel.DataAnnotations;

namespace NTierSolution.Entity
{
    public class Students
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}