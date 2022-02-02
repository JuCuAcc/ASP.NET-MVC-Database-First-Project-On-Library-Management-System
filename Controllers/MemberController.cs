using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Library_Mvc_Jashim.Models;

namespace Library_Mvc_Jashim.Controllers
{
    public class MemberController : Controller
    {
        myDBEntities db = new myDBEntities();
        public ActionResult Index()
        {
            return View(db.Members.ToList());
        }



        public ActionResult Member1()
        {
            return Content("Member 1", "text/html");
        }

        public ActionResult Member2(string fullName)
        {
            return Content("Hi " + fullName, "text/html");
        }

        public ActionResult Member3()
        {
            Member member = new Member()
            {
                MemberID = 600,
                MemberName = "Jashim",
                MemberStatus = "Student"
            };
            return Json(member, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Member4()
        {
            List<Member> members = new List<Member>() {
                new Member() {
                    MemberID = 601,
                    MemberName = "Ashim",
                    MemberStatus = "Student"
                },
                new Member() {
                    MemberID = 602,
                    MemberName = "Hashim",
                    MemberStatus = "Student"
                },
                new Member() {
                    MemberID = 603,
                    MemberName = "Kashim",
                    MemberStatus = "Student"
                }
            };
            return Json(members, JsonRequestBehavior.AllowGet);
        }
    }
}