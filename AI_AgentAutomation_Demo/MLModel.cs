using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;

namespace AI_AgentAutomation_Demo
{
    // Veri yapısı
    public class CustomerRequest
    {
        [LoadColumn(0)]
        public string Text;

        [LoadColumn(1)]
        public string Label;
    }

    // Tahmin sonuç yapısı
    public class RequestPrediction
    {
        [ColumnName("PredictedLabel")]
        public string PredictedLabel;

        public float[] Score;
    }

    public class MLModel
    {
        private readonly string dataPath = "customer_requests.csv"; // CSV dosya adı

        private MLContext mlContext;
        private ITransformer trainedModel;
        private PredictionEngine<CustomerRequest, RequestPrediction> predEngine;

        public MLModel()
        {
            mlContext = new MLContext();
        }

        // Modeli eğit
        public void Train()
        {
            var dataView = mlContext.Data.LoadFromTextFile<CustomerRequest>(
                path: dataPath,
                hasHeader: true,
                separatorChar: ',');

            var pipeline = mlContext.Transforms.Text.FeaturizeText(
                outputColumnName: "Features", inputColumnName: nameof(CustomerRequest.Text))
                .Append(mlContext.Transforms.Conversion.MapValueToKey(
                    outputColumnName: "LabelKey", inputColumnName: nameof(CustomerRequest.Label)))
                .Append(mlContext.MulticlassClassification.Trainers
                    .LightGbm(labelColumnName: "LabelKey", featureColumnName: "Features"))
                .Append(mlContext.Transforms.Conversion.MapKeyToValue(
                    outputColumnName: "PredictedLabel", inputColumnName: "PredictedLabel"));

            trainedModel = pipeline.Fit(dataView);

            predEngine = mlContext.Model.CreatePredictionEngine<CustomerRequest, RequestPrediction>(trainedModel);

            Console.WriteLine("Model eğitildi.");
        }

        // Tahmin yap
        public string Predict(string inputText)
        {
            var request = new CustomerRequest() { Text = inputText };
            var prediction = predEngine.Predict(request);
            return prediction.PredictedLabel;
        }
    }
}
