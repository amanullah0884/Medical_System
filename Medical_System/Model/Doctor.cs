using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medical_System.Model
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Degree")]
        public int DegreeId { get; set; }

        [ForeignKey("Institute")]
        public int InstituteId { get; set; }

        [ForeignKey("SpecialInterest")]
        public int SpecialInterestID { get; set; }

        public virtual Degree Degree { get; set; }
        public virtual Institute Institute { get; set; }
        public virtual SpecialInterest SpecialInterest { get; set; }
        public virtual ICollection<Consultation> Consultations { get; set; }
    }

}
