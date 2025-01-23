using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medical_System.Model
{
    public class PatientProblem
    {
        public int Id { get; set; }

        
        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        [ForeignKey("Problem")]
        public int ProblemId { get; set; }

        [ValidateNever] 
        public virtual Patient Patient { get; set; }
        public virtual Problem Problem { get; set; }
    }
}
