using Microsoft.ML;
using Model;
using System.IO;
using System.Reflection;

namespace DSS
{
    public class Clusterizing
    {
        public ClusterPrediction GetClusterizing(string pathFile, string pathFileLearning, ApplicantDataCluster applicant)
        {
            string _dataPath =  pathFile;// Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), pathFile);//Path.Combine(Environment.CurrentDirectory, pathFile);
            string _modelPath = pathFileLearning;// Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), pathFileLearning);//Path.Combine(Environment.CurrentDirectory, pathFileLearning);


            var context = new MLContext(seed: 0);
            IDataView dataView = context.Data.LoadFromTextFile<Model.ApplicantDataCluster>(_dataPath, separatorChar: ',', hasHeader: true, allowQuoting: true,
                                                                                    trimWhitespace: true, allowSparse: true);

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

            var predictor = context.Model.CreatePredictionEngine<Model.ApplicantDataCluster, ClusterPrediction>(model);

            

            return predictor.Predict(applicant);

        }
    }
}
