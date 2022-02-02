
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Library_Mvc_Jashim.Models;

namespace Library_Mvc_Jashim.Controllers
{
    public class LibrariansController : Controller
    {
        LibrariansDB lbnDB = new LibrariansDB();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult List()
        {
            return Json(lbnDB.ListAll(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(Librarians lbn)
        {
            return Json(lbnDB.Add(lbn), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            var Librarian = lbnDB.ListAll().Find(x => x.LibrarianID.Equals(ID));
            return Json(Librarian, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(Librarians lbn)
        {
            return Json(lbnDB.Update(lbn), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            return Json(lbnDB.Delete(ID), JsonRequestBehavior.AllowGet);
        }
    }
}