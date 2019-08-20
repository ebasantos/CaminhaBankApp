using DAL;
using DSS;
using Model;
using System.Linq;
using System.Web.Mvc;

namespace CaminhaBankApp.Controllers
{
    public class ApplicantsController : Controller
    {
        private CaminhaBankContext db = new CaminhaBankContext();
        public float[] noResult = { 0, 0 };

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
                    consconfid = -(applicant.ConsConfId+400 / 10),
                    duration = (applicant.Duration*10)+500,
                    education = applicant.Education,
                    empratevar = applicant.EmpRateVar,
                    housing = applicant.Housing,
                    loan = applicant.Loan
                };

                var analiseResult = new Clusterizing().GetClusterizing(fileBase, fileLearning, applcant);
                
                return RedirectToAction("Index", "AnaliseResult", new { group1 = analiseResult.Distances[0],
                                                                        group2 = analiseResult.Distances[1],
                                                                        resultGroup = analiseResult.PredictedClusterId });
            }
            else
                return RedirectToAction("index", "AnaliseResult", new { group1 = 0, group2 = 0 , resultGroup  = 1} );
        }

    }
}
