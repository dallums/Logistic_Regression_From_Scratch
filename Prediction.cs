using System;

namespace Logistic_Regression_From_Scratch
{
    public class Prediction
    { 
        public static double makeSinglePrediction(Matrix model, Matrix inputData)
        {
            return sigmoid((double) MatrixMultiplication.multiplyMatrices(inputData, model).Data[0][0]);
        }

        public static Matrix makePredictions(Matrix inputData, Matrix model, decimal coefficient)
        {
            Matrix predictions = MatrixMultiplication.multiplyMatrices(inputData, model);
            for (int rowNum = 0; rowNum < model.numRows; rowNum++)
            {
                double castedInput = (double) predictions.Data[rowNum][0] + (double) coefficient;
                predictions.Data[rowNum][0] = (decimal) sigmoid(castedInput);
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

        public static double sigmoid(double x)
        {
            return 1.0 / (1.0 + Math.Exp(-x));
        }
    }
}