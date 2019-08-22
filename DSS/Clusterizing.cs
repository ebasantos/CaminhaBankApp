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
            string _dataPath =  pathFile;
            string _modelPath = pathFileLearning;


            var context = new MLContext(seed: 0);
            IDataView dataView = context.Data.LoadFromTextFile<Model.ApplicantDataCluster>(_dataPath, separatorChar: ',', hasHeader: true, allowQuoting: true,
                                                                                    trimWhitespace: true, allowSparse: true);

            string outputParam = "y";
            string[] inputParams = { "age", "education", "housing", "loan", "duration", "empratevar", "consconfid"  };

            var pipeline = context.Transforms
                .Concatenate(outputParam, inputParams)
                .Append(context.Clustering.Trainers.KMeans("y", null, 2 ) );

            var model = pipeline.Fit(dataView);


            using (var fileStream = new FileStream(_modelPath, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                context.Model.Save(model, dataView.Schema, fileStream);
            }

            var predictor = context.Model.CreatePredictionEngine<Model.ApplicantDataCluster, ClusterPrediction>(model);            

            var result =  predictor.Predict(applicant);

            return result;

        }
    }
}
