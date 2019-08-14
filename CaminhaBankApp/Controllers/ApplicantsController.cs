using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using Model;

namespace CaminhaBankApp.Controllers
{
    public class ApplicantsController : Controller
    {
        private CaminhaBankContext db = new CaminhaBankContext();

        // GET: Applicants
        public ActionResult Index()
        {
            return View(db.Applicants.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Education,Age,Housing,Loan,Duration,EmpRateVar,ConsConfId,SearchData,DeservCredit,Cpf,BornDate,Name")] Applicant applicant)
        {
            const string fileBase = "D:/Users/Documentos/Desktop/bank-additional/bank-analiser.csv";
            const string fileLearning = "D:/Users/Documentos/Desktop/bank-additional/bank-analiser-learning.csv";

            if (ModelState.IsValid)
            {
                var applcant = new ApplicantDataCluster
                {
                    age = applicant.Age,
                    consconfid = applicant.ConsConfId,
                    duration = applicant.Duration,
                    education = applicant.Education,
                    empratevar = applicant.EmpRateVar,
                    housing = applicant.Housing,
                    loan = applicant.Loan
                };

                var sad = new DSS.Clusterizing().GetClusterizing(fileBase, fileLearning, applcant);

                if (sad.PredictedClusterId == 1)
                    return RedirectToAction("index", "AnaliseResult", new { approve = true });
                else
                    return RedirectToAction("index", "AnaliseResult", new { approve = false });
            }
            else
                return RedirectToAction("index", "AnaliseResult",new { approve =  false });
        }

      

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
