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
            Console.WriteLine("\n");
            Matrix.printMatrix(inputData);
            Console.WriteLine("\n");
            Matrix.printMatrix(model);
            Console.WriteLine("\n");
            Matrix.printMatrix(predictions);
  
            for (int rowNum = 0; rowNum < inputData.numRows; rowNum++)
            {
                double castedInput = (double) predictions.Data[rowNum][0] + (double) coefficient;
                Console.WriteLine($"Row {rowNum}, castedInput: {castedInput}");
                predictions.Data[rowNum][0] = (decimal) sigmoid(castedInput);
                Console.WriteLine($"Prediction: {predictions.Data[rowNum][0]}");
                
            }
            
            return predictions;
        }

        public static decimal logLoss(decimal prediction, decimal actual)
        {
            if (prediction == 0)
            {
                return 0;
            }
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
            var result = 1.0 / (1.0 + Math.Exp(-x));
            Console.WriteLine($"Sigmoid input {x}; result {result}");
            return result;
        }
    }
}