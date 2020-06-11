using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Reporting.WebForms;
using ReportMvc.Models;

namespace ReportMvc.Controllers
{
    public class HomeController : Controller
    {
        DefaultConnection db = new DefaultConnection();
        public ActionResult StudentList()
        {

            return View(db.Students.ToList());
        }

         public ActionResult Reports(string ReportType)
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/StudentReport.rdlc");

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "StudentDataSet";
            reportDataSource.Value = db.Students.ToList();


            localReport.DataSources.Add(reportDataSource);

            string reportType = ReportType;
            string mimeType;
            string encoding;
            string fileNameExtension;
            if (reportType == "Excel")
            {
                fileNameExtension = "xls";
            }
            else if (reportType == "PDF")
            {
                fileNameExtension = "pdf";
            }
            else if (reportType == "Word")
            {
                fileNameExtension = "docx";
            }
            else
            {
                fileNameExtension = "jpg";

            }

            string[] streams;
            Warning[] warnings;
            byte[] renderedByte;

            renderedByte = localReport.Render(reportType, "", out mimeType, out encoding, out fileNameExtension
                , out streams, out warnings);
            Response.AddHeader("content-disposition", "attachment;filename= Student_Report." + fileNameExtension);
            return File(renderedByte, fileNameExtension);


/*            return Json(0);
*/        }


    }
}