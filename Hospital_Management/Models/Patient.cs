using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Management.Models
{
	public class Patient
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Gender { get; set; }
		public int Age { get; set; }
		public string Phn_Number { get; set; }
		public IList<PatientDoctor> doctors { get; set; }

	}
}
