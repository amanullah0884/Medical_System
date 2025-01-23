using System.ComponentModel.DataAnnotations.Schema;

namespace Medical_System.Model
{
    public class BMDCNO
    {
        public int Id { get; set; }
        public string BMDCNumber { get; set; }

        [ForeignKey("Consultation")]
        public int ConsultationId { get; set; }

        [ForeignKey("SpecialInterest")]
        public int SpecialInterestId { get; set; }

        public virtual Consultation Consultation { get; set; }
        public virtual SpecialInetrest SpecialInterest { get; set; }
    }
}
