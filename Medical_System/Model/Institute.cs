using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Medical_System.Model
{
    public class Institute
    {
        public int Id { get; set; }
        public string InstituteName { get; set; }
        
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
