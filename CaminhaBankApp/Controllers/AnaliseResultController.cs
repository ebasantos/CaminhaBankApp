using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaminhaBankApp.Controllers
{
    public class AnaliseResultController : Controller
    {
        // GET: AnaliseResult
        public ActionResult Index(bool approve)
        {
            if (approve)
                return View("winner");
            else
                return View("bad");
        }
    }
}