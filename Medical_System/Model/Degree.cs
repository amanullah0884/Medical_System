using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Medical_System.Model
{
    public class Degree
    {
        public int Id { get; set; }
        public string DegreeName { get; set; }

        [ValidateNever]
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
