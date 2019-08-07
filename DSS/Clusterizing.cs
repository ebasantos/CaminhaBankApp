using Microsoft.ML;
using Microsoft.ML.Data;
using Model;
using System;
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
            const string path = "./bank-additional-full.csv";
            GetClusterizing(path);
            return Commons.ConvertCSVtoDataTable(path);
        }

        public void GetClusterizing(string pathFile= "./bank-additional-full.data")
        {
            string _dataPath = Path.Combine(Environment.CurrentDirectory, "Data", "bank-additional-full.data");
            string _modelPath = Path.Combine(Environment.CurrentDirectory, "Data", "bankClusteringModel.zip");


            var context = new MLContext();
            IDataView dataView = context.Data.LoadFromTextFile<AppliantDataCluster>(_dataPath, hasHeader: true, separatorChar: ';');


            string featuresColumnName = "Features";
            var pipeline = context.Transforms
                .Concatenate(featuresColumnName, "age", "job", "education", "default" , "housing", "loan", "duration")
                .Append(context.Clustering.Trainers.KMeans(featuresColumnName, numberOfClusters: 3));

            var model = pipeline.Fit(dataView);


            using (var fileStream = new FileStream(_modelPath, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                context.Model.Save(model, dataView.Schema, fileStream);
            }

            var predictor = context.Model.CreatePredictionEngine<AppliantDataCluster, ClusterPrediction>(model);
        }
    }
}
