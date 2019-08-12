using DSS;
using System.Web.Mvc;

namespace CaminhaBankApp.Controllers
{
    public class DataAnaliseController : Controller
    {
        // GET: DataAnalise
        public void Index()
        {
            const string fileBase = "bank-analiser.csv";
            const string fileLearning = "bank-analiser-learning.csv";
            var dataAnaliser = new Clusterizing();
            dataAnaliser.GetClusterizing(fileBase, fileLearning);
        }
    }
}