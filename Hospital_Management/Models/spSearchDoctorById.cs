using Microsoft.EntityFrameworkCore;

namespace Hospital_Management.Models
{
    [Keyless]
    public class spSearchDoctorById
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phn_Number { get; set; }
        public string Specialist { get; set; }
        public int PatientId { get; set; }
    }
}
