using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using Library_Mvc_Jashim.ViewModels;
using Library_Mvc_Jashim.Models;
using PagedList;

namespace Library_Mvc_Jashim.Controllers
{
    public class LibrarianController : Controller
    {

        public ViewResult Details()
        {
            Librarian librarian = new Librarian()
            {
                LibrarianID = 101,
                Name = "Jahangir",
                Age = 25,
                Email = "ju786@gmail.com",
                Address = "Dhaka"
            };

            //Creating the View model
            LibrarianInfoViewModel librarianInfoViewModel = new LibrarianInfoViewModel()
            {
                Librarian = librarian,
                PageTitle = "Librarian Info Page",
                PageHeader = "Librarian Information",
            };
            return View(librarianInfoViewModel);
        }
    }
}