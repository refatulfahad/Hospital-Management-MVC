using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Management.Models
{
    public class MedicalReport
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Patient Problem")]
        public string PatientProblem { get; set; }
        public string MedicalTest { get; set; }
        public string MedicalResult { get; set; }
        public string date { get; set; }
        public int? PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
