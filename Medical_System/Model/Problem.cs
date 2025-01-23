using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Medical_System.Model
{
    public class Problem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [ValidateNever]
        public virtual ICollection<PatientProblem> PatientProblems { get; set; }
    }
}
