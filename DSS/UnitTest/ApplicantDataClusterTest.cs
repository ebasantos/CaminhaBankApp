namespace DSS.UnitTest
{
    public class ApplicantDataClusterTest
    {

        public bool ApplicantTest()
        {
            try
            {
                const string fileBase = "D:/Users/Documentos/Desktop/bank-additional/bank-analiser.csv";
                const string fileLearning = "D:/Users/Documentos/Desktop/bank-additional/bank-analiser-learning.csv";


                ///this is data test....
                var candidato = new Model.ApplicantDataCluster
                {
                    age = 25,
                    consconfid = -31,
                    education = 1,
                    empratevar = 1,
                    housing = 0,
                    loan = 1,
                    duration = 300
                };

                var result = new Clusterizing().GetClusterizing(fileBase, fileLearning, candidato);

                return result != null;
            }
            catch
            {
                return false;
            }
        }

    }
}
