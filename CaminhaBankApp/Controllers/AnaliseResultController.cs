using Model;
using System;
using System.Web.Mvc;

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
    }
}