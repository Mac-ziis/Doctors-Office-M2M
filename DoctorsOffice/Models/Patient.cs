using System.Collections.Generic;

namespace DoctorsOffice.Models
{
  public class Patient
  {
    public string Name { get; set; }
    public int BirthDate { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    public List<DoctorPatient> JoinEntities { get; }
  }
}