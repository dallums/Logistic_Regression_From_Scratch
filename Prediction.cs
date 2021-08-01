using System;

namespace Logistic_Regression_From_Scratch
{
    public class Prediction
    { 
        public static decimal makeSinglePrediction(Matrix model, Matrix inputData)
        {
            return sigmoid(MatrixMultiplication.multiplyMatrices(inputData, model).Data[0][0]);
        }

        public static Matrix makePredictions(Matrix inputData, Matrix model, decimal coefficient)
        {
            Matrix predictions = MatrixMultiplication.multiplyMatrices(inputData, model);
            for (int rowNum = 0; rowNum < model.numRows; rowNum++)
            {
                predictions.Data[rowNum][0] = sigmoid(predictions.Data[rowNum][0] + coefficient);
            }
            
            return predictions;
        }

        public static decimal logLoss(decimal prediction, decimal actual)
        {
            decimal firstSummand = -(actual * (decimal) Math.Log((double) prediction));
            decimal secondSummand = (1 - actual) * (decimal) (Math.Log((double) (1 - prediction)));
            decimal logLossValue = firstSummand + secondSummand;
            return logLossValue;
        }

        public static decimal computeAllLogLoss(Matrix predictions, Matrix actuals)
        {
            decimal totalLogLoss = 0m;
            for (int rowNum=0; rowNum < predictions.numRows; rowNum++)
            {
                totalLogLoss += logLoss(predictions.Data[rowNum][0], actuals.Data[rowNum][0]);
            }

            return totalLogLoss / predictions.numRows;
        }

        public static decimal sigmoid(decimal x)
        {
            return (decimal) (1 / (1 + Math.Exp((double) -x)));
        }
    }
}