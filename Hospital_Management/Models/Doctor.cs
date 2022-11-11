using System.ComponentModel.DataAnnotations;

namespace Hospital_Management.Models
{
    public class Doctor
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phn_Number { get; set; }
        [Required]
        public string Specialist { get; set; }
        public IList<PatientDoctor> patients { get; set; }
    }
}
