using Microsoft.ML;
using Model;
using System.IO;

namespace DSS
{
    public class Clusterizing
    {
        //public DataTable GetData()
        //{
        //    ///temporaly path, the next step is upload this file to any other only repo...
        //    const string fileBase = "./bank-analiser.csv";
        //    const string fileLearning = "./bank-analiser-learning.csv";
        //    GetClusterizing(fileBase, fileLearning);
        //    //return Commons.ConvertCSVtoDataTable(path);
        //}

        public void GetClusterizing(string pathFile, string pathFileLearning)
        {
            string _dataPath = pathFile;//Path.Combine(Environment.CurrentDirectory, pathFile);
            string _modelPath = pathFileLearning;//Path.Combine(Environment.CurrentDirectory, pathFileLearning);


            var context = new MLContext(seed: 0);
            IDataView dataView = context.Data.LoadFromTextFile<Model.AppliantDataCluster>(_dataPath, separatorChar: ',', hasHeader: true, allowQuoting: true,
                                                                                    trimWhitespace: true, allowSparse: true);


            var sales = context.Data.CreateEnumerable<Model.AppliantDataCluster>(dataView, reuseRowObject: false);

            string outputParam = "y";
            string[] inputParams = { "age", "education", "housing", "loan", "duration", "empratevar", "consconfid", "y" };

            var pipeline = context.Transforms
                .Concatenate(outputParam, inputParams)
                .Append(context.Clustering.Trainers.KMeans("y", null, 2 ) );

            var model = pipeline.Fit(dataView);


            using (var fileStream = new FileStream(_modelPath, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                context.Model.Save(model, dataView.Schema, fileStream);
            }

            var predictor = context.Model.CreatePredictionEngine<Model.AppliantDataCluster, ClusterPrediction>(model);

            ///this is data test....
            var candidato = new Model.AppliantDataCluster
            {
                age = 25,
                consconfid = -31,
                education = 1,
                empratevar = 1,
                housing = 0,
                loan = 1,
                duration = 300
            };

            var prediction = predictor.Predict(candidato);

        }
    }
}
