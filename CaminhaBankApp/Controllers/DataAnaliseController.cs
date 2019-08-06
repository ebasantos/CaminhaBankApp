using DSS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaminhaBankApp.Controllers
{
    public class DataAnaliseController : Controller
    {
        // GET: DataAnalise
        public void Index()
        {
            var dataAnaliser = new Clusterizing();
            dataAnaliser.GetData();
        }
    }
}