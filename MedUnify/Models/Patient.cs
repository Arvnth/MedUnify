using System.ComponentModel.DataAnnotations;

namespace MedUnify.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [MaxLength(50)]
        public string State { get; set; }

        [MaxLength(50)]
        public string City { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        [Required]
        public int OrganizationId { get; set; }

        public ICollection<Visit> Visits { get; set; }
    }
}
