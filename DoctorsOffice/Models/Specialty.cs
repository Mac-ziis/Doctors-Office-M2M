using System.Collections.Generic;

namespace DoctorsOffice.Models
{
  public class Specialty
  {
    public int SpecialtyId { get; set; }
    public string Title { get; set; }
    public List<DoctorSpecialty> JoinEntities { get; }
  }
}