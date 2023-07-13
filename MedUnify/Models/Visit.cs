using System.ComponentModel.DataAnnotations;

namespace MedUnify.Models
{
    public class Visit
    {
        [Key]
        public int VisitId { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public DateTime VisitDate { get; set; }

        public ICollection<ProgressNote> ProgressNotes { get; set; }

        public Patient Patient { get; set; }
    }
}
