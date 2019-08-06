using System.Data;
using System.IO;
using Utilities;

namespace DSS
{
    public class Clusterizing
    {
        public DataTable GetData()
        {
            ///temporaly path, the next step is upload this file to any other only repo...
            const string path = "C:/Users/Erik Santos/source/repos/CaminhaBank/DSS/datas/bank-additional-full.csv";
            return Commons.ConvertCSVtoDataTable(path);
        }
    }
}
