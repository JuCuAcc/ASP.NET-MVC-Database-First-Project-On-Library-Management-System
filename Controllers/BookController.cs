
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using Library_Mvc_Jashim.Models;
using System.Data.Entity;  // For Edit or Update Data
using PagedList;            // For pagination
using System.IO;

namespace Library_Mvc_Jashim.Controllers
{
    public class BookController : Controller
    {

        myDBEntities db = new myDBEntities();
        public ActionResult Index(int page = 1, int pageSize = 4)
        {
            List<Book> books = db.Books.ToList();
            PagedList<Book> model = new PagedList<Book>(books, page, pageSize);
            return View(model);
        }


        // Details
        public ActionResult Details(int id = 0)
        {

            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        IEnumerable<Book> GetAllBook()
        {
            using (myDBEntities db = new myDBEntities())
            {
                return db.Books.ToList<Book>();
            }
        }

        //Create
        public ActionResult Create()
        {
            Book book = new Book();
            ViewBag.CategoryID = new SelectList(db.BookCategories, "CategoryID", "Category");
            return View(book);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(Book book)
        {
            try
            {
                if (ModelState.IsValid && book.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(book.ImageUpload.FileName);
                    string extension = Path.GetExtension(book.ImageUpload.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    book.ImagePath = "~/Images/" + fileName;
                    book.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Images/"), fileName));

                    db.Books.Add(book);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else if (ModelState.IsValid && book.ImageUpload == null)
                {
                    db.Books.Add(book);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.CategoryID = new SelectList(db.BookCategories, "CategoryID", "Category", book.CategoryID);
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "Details", GetAllBook()), message = "The Record Submitted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }


        }


        // Edit 
        public ActionResult Edit(int id = 0)
        {

            Book book = db.Books.Find(id);

            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.BookCategories, "CategoryID", "Category", book.CategoryID);
            return View(book);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified; //using System.Data.Entity;
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(book);
        }


        public ActionResult Delete(int id = 0)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }



        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //Extra

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