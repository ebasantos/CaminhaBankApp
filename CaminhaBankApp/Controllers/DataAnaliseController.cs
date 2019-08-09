using DSS;
using System.Web.Mvc;

namespace CaminhaBankApp.Controllers
{
    public class DataAnaliseController : Controller
    {
        // GET: DataAnalise
        public void Index()
        {
            var dataAnaliser = new Clusterizing();
            dataAnaliser.GetClusterizing("D:/Users/Documentos/Desktop/bank-additional/bank-additional-full.csv");
        }
    }
}