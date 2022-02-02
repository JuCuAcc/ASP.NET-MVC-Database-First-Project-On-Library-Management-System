using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Library_Mvc_Jashim.Models;
using System.Data.Entity;

namespace Library_Mvc_Jashim.Controllers
{
    public class StudentController : Controller
    {
        myDBEntities _db = new myDBEntities();
        public ActionResult Index()
        {
            return View(_db.Students.ToList());
        }

        [HttpPost]
        public ActionResult MyCreatePartial(Student student)
        {
            var stuName = student.StudentName;
            var stuGender = student.Gender;
            var stuEmail = student.Email;
            if (!string.IsNullOrEmpty(stuName) && !string.IsNullOrEmpty(stuGender) && !string.IsNullOrEmpty(stuEmail))
            {
                _db.Students.Add(student);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return PartialView("CreatePartial");
        }
        [HttpGet]
        public ActionResult GetByID(int StudentID)
        {
            Student st = _db.Students.Find(StudentID);
            if (st == null)
            {
                return HttpNotFound();
            }
            return PartialView("EditPartial", st);
        }
        public ActionResult GetByDeleteID(int StudentID) // Check Action/Controller
        {
            Student st = _db.Students.Find(StudentID);
            if (st == null)
            {
                return HttpNotFound();
            }
            return PartialView("DeletePartial", st);
        }

        [HttpPost]
        public ActionResult MyEditPartial(Student student)
        {
            var stuName = student.StudentName;
            var stuEmail = student.Email;

            if (!string.IsNullOrEmpty(stuName) && !string.IsNullOrEmpty(stuEmail))
            {
                _db.Entry(student).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return PartialView("EditPartial");
        }

        [HttpPost]
        public ActionResult MyDeletePartial(int StudentID)
        {
            Student st = _db.Students.Find(StudentID);
            _db.Students.Remove(st);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}