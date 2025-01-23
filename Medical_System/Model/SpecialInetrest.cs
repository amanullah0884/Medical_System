using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Medical_System.Model
{
    public class SpecialInetrest
    {
        public int Id { get; set; }
        public string InterestName { get; set; }

        [ValidateNever]
        public virtual ICollection<BMDCNO> BMDCNOs { get; set; }
    }
}
