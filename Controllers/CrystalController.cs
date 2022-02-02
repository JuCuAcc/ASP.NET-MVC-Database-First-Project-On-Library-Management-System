using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


//Namespaces added later
using Library_Mvc_Jashim.Models;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace Library_Mvc_Jashim.Controllers
{
    [Authorize]
    public class CrystalController : Controller
    {

        myDBEntities db = new myDBEntities();

        public ActionResult BookList()
        {
            return View(db.Books.ToList());
        }

        public ActionResult exportReport()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CrystalReport.rpt"));
            rd.SetDataSource(db.Books.ToList());

            try
            {
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf");

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}