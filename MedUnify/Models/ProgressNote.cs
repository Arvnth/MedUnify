using System.ComponentModel.DataAnnotations;

namespace MedUnify.Models
{
    public class ProgressNote
    {
        [Key]
        public int ProgressNoteId { get; set; }

        [Required]
        public int VisitId { get; set; }
        public int PatientId { get; set; }

        [Required]
        [MaxLength(50)]
        public string SectionName { get; set; }

        [MaxLength(500)]
        public string SectionText { get; set; }

        public Visit Visit { get; set; }
    }
}
