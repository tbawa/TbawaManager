using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Reporting.WebForms;
using MemberManager.Models;

namespace MemberManager.Controllers
{
    public class ReportsController : Controller
    {
        private tbawaEntities db = new tbawaEntities();

        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        // GET: Reports
        public ActionResult Results()
        {
            ReportDataSource dataSet = new ReportDataSource("DataSet1", db.TeamLadderAndGames_Crosstab.Where(l => l.CompID == 33).ToList());

            return RenderReport("Results_Lightning", dataSet);
        }

        // GET: Reports/ScoreSlips
        public ActionResult ScoreSlips(string timeSlot)
        {
            ReportDataSource dataSet;
            int ts;
            if (Int32.TryParse(timeSlot, out ts))
                dataSet = new ReportDataSource("ScoreSlips", db.ScoreSlips.Where(l => l.CompID == 33 && l.TimeSlot == ts).ToList());
            else
                dataSet = new ReportDataSource("ScoreSlips", db.ScoreSlips.Where(l => l.CompID == 33).ToList());
            return RenderReport("ScoreSlips", dataSet);
        }

        private ActionResult RenderReport(string reportName, ReportDataSource dataSource)
        {
            //Step 1 : Create a Local Report.
            LocalReport localReport = new LocalReport();

            //Step 2 : Specify Report Path.
            localReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\" + reportName + ".rdlc";

            //Step 3 : Create Report DataSources
            ReportDataSource dataSet = new ReportDataSource("Competition", db.Comps.Where(l => l.CompID == 33).ToList());

            //Step 4 : Bind DataSources into Report
            localReport.DataSources.Add(dataSource);
            localReport.DataSources.Add(dataSet);

            //Step 5 : Call render method on local Report to generate report contents in Bytes array
            string deviceInfo = "<DeviceInfo>" + "  <OutputFormat>PDF</OutputFormat>" + "</DeviceInfo>";
            Warning[] warnings;
            string[] streams;
            string mimeType;
            byte[] renderedBytes;
            string encoding;
            string fileNameExtension;
            //Render the report           
            renderedBytes = localReport.Render("PDF", deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);


            //Step 6 : Set Response header to pass filename that will be used while saving report.
            Response.AddHeader("Content-Disposition", "attachment; filename=" + reportName + ".pdf");

            //Step 7 : Return file content result
            return new FileContentResult(renderedBytes, mimeType);
        }

    }
}