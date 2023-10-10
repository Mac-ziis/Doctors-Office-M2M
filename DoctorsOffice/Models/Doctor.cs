using System.Collections.Generic;

namespace DoctorsOffice.Models
{
  public class Doctor
  {
    public string Name { get; set; }
    public string Specialty { get; set; }
    public int DoctorId { get; set; }
    public List<Patient> Patients { get; set; }
    public List<DoctorSpecialty> JoinEntities { get; }
  }
}