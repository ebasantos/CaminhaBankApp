using CaminhaBankApp.Models;
using Model;
using System;
using System.Linq;
using System.Web.Mvc;
using Utilities;

namespace CaminhaBankApp.Controllers
{
    public class AnaliseResultController : Controller
    {
        public ClusterPrediction global = new ClusterPrediction();
        // GET: AnaliseResult
        public ActionResult Index(float group1, float group2, int resultGroup)
        {
            ViewBag.Cluster1 = Convert.ToInt32(group1);
            ViewBag.Cluster2 = Convert.ToInt32(group2);

            if (resultGroup == 2)
                return View("winner");
            else
                return View("bad");
        }

        public JsonResult GetApproved()
        {
            var dt = Commons.ConvertCSVtoDataTable("D:/Users/Documentos/Desktop/bank-additional/bank-analiser.csv");
            var list = Commons.ConvertDataTable<ApplicantReader>(dt);

            return Json(list.Where( x=> x.y == "1"), JsonRequestBehavior.AllowGet);
        }
    }
}