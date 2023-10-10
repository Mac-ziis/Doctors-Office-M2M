namespace DoctorsOffice.Models
{
  public class DoctorSpecialty
  {
    public int DoctorSpecialtyId { get; set; }
    public int DoctorId { get; set; }
    public Patient Patient { get; set; }
    public int SpecialtyId { get; set; }
    public Specialty Specialty { get; set; }
  }
}