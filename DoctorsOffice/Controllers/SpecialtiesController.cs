using Microsoft.AspNetCore.Mvc;
using DoctorsOffice.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DoctorsOffice.Controllers
{
  public class SpecialtiesController : Controller
  {
    private readonly DoctorsOfficeContext _db;

    public SpecialtiesController(DoctorsOfficeContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Specialties.ToList());
    }

    public ActionResult Details(int id)
    {
      Specialty thisSpecialty = _db.Specialties
          .Include(specialty => specialty.JoinEntities)
          .ThenInclude(join => join.Doctor)
          .FirstOrDefault(specialty => specialty.SpecialtyId == id);
      return View(thisSpecialty);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Specialty specialty)
    {
      _db.Specialties.Add(specialty);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddDoctor(int id)
    {
      Specialty thisSpecialty = _db.Specialties.FirstOrDefault(specialties => specialties.SpecialtyId == id);
      ViewBag.DoctorId = new SelectList(_db.Patients, "PatientId", "Description");
      return View(thisTag);
    }

    [HttpPost]
    public ActionResult AddItem(Tag tag, int patientId)
    {
      #nullable enable
      PatientTag? joinEntity = _db.PatientTags.FirstOrDefault(join => (join.PatientId == patientId && join.TagId == tag.TagId));
      #nullable disable
      if (joinEntity == null && patientId != 0)
      {
        _db.PatientTags.Add(new PatientTag() { PatientId = patientId, TagId = tag.TagId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = tag.TagId });
    }

    public ActionResult Edit(int id)
    {
      Tag thisTag = _db.Tags.FirstOrDefault(tags => tags.TagId == id);
      return View(thisTag);
    }

    [HttpPost]
    public ActionResult Edit(Tag tag)
    {
      _db.Tags.Update(tag);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Tag thisTag = _db.Tags.FirstOrDefault(tags => tags.TagId == id);
      return View(thisTag);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Tag thisTag = _db.Tags.FirstOrDefault(tags => tags.TagId == id);
      _db.Tags.Remove(thisTag);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      PatientTag joinEntry = _db.PatientTags.FirstOrDefault(entry => entry.PatientTagId == joinId);
      _db.PatientTags.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}