using System;
using System.Collections.Generic;

namespace Logistic_Regression_From_Scratch
{
    public class Training
    {
        public int iterationNumber { get; set; }

        public static Matrix getYData(Matrix trainingData)
        {
            List<decimal> yData = Matrix.getColumn(trainingData, trainingData.numColumns - 1);
            List<List<decimal>> yDataForMatrix = new List<List<decimal>>(1);
            yDataForMatrix.Add(yData);
            Matrix yAsRow = new Matrix(1, trainingData.numRows, yDataForMatrix);
            Matrix y = MatrixMultiplication.getTranspose(yAsRow);
            return y;
        }

        public Matrix runIteration(Matrix currentModel, Matrix trainingData, decimal learningRate, Matrix X, Matrix y)
        {
            /*
             * 1. Make predictions, i.e., one iteration
             * 2. Adjust each weight w_i -> w_i - alpha * partial L w.r.t w_i
             * 3. return new model
             */

            // get predictions
            Console.Write("Making predicitons...");
            Matrix predictions = Prediction.makePredictions(inputData: X, model: currentModel);
            Console.WriteLine("Predictions done");
            Matrix.printMatrix(predictions);

            // compute gradient = features * (predictions - actuals)
            Matrix predictionsMinusActuals = MatrixMultiplication.addMatrices(predictions, y, true);
            Console.WriteLine("Predictions minus actuals...");
            Matrix predictionsMinusActualsT = MatrixMultiplication.getTranspose(predictionsMinusActuals);
            Console.WriteLine("Now transposed...");
            Console.WriteLine("Trying to compute gradient");
            decimal? gradient = MatrixMultiplication.dotProduct(predictionsMinusActualsT.Data[0], MatrixMultiplication.getTranspose(y).Data[0]);

            // adjust weights
            for (int rowNum = 0; rowNum < currentModel.numRows; rowNum++)
            {
                currentModel.Data[rowNum][0] -= learningRate * ((gradient ?? 0) / currentModel.numRows);
            }

            iterationNumber++;
            Console.WriteLine("Finished iteration " + iterationNumber);
            return currentModel;
        }
    }
}