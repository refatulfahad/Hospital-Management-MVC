using System.ComponentModel.DataAnnotations;

namespace Hospital_Management.Models
{
    public class PatientBill
    {
        [Key]
        public int Id { get; set; }
        public string Bill_Type { get; set; }
        public int Bill_Amount { get; set; }
        public string date { get; set; }
        public int? PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
