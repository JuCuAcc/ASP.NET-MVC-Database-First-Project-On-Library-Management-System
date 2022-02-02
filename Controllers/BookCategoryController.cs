using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Additional

using Library_Mvc_Jashim.Models;
using System.Data.Entity;

namespace Library_Mvc_Jashim.Controllers
{
    public class BookCategoryController : Controller
    {
        myDBEntities db = new myDBEntities();
        public ActionResult Index()
        {
            return View(db.BookCategories.ToList());
        }

        // Details

        public ActionResult Details(int id = 0)
        {
            BookCategory bookCategory = db.BookCategories.Find(id);

            if (bookCategory == null)
            {
                return HttpNotFound();
            }
            return View(bookCategory);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookCategory bookCategory)
        {
            

            if (ModelState.IsValid)
            {
                db.BookCategories.Add(bookCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookCategory);
        }


        // For Edit

        public ActionResult Edit(int id = 0)
        {

            BookCategory bookCategory = db.BookCategories.Find(id);
            if (bookCategory == null )
            {
                return HttpNotFound();
            }
            return View(bookCategory);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(BookCategory bookCategory)
        {

            if (ModelState.IsValid)
            {
                db.Entry(bookCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookCategory);
        }

        // For Delete

        public ActionResult Delete(int id = 0)
        {

            BookCategory bookCategory = db.BookCategories.Find(id);
            if (bookCategory == null)
            {
                return HttpNotFound();
            }

            return View(bookCategory);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookCategory bookCategory = db.BookCategories.Find(id);
            db.BookCategories.Remove(bookCategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // Extra

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);    
        }
    }
}