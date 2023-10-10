using System.Collections.Generic;

namespace DoctorsOffice.Models
{
  public class Tag
  {
    public int TagId { get; set; }
    public string Title { get; set; }
    public List<PatientTag> JoinEntities { get; }
  }
}