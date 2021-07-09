using System;
using System.Collections.Generic;

namespace Logistic_Regression_From_Scratch
{
    public class Training
    {
        public int iterationNumber { get; set; }

        public Matrix runIteration(Matrix currentModel, Matrix trainingData, decimal learningRate)
        {
            /*
             * 1. Make predictions, i.e., one iteration
             * 2. Adjust each weight w_i -> w_i - alpha * partial L w.r.t w_i
             * 3. return new model
             */
            // TODO: get this to work and make method
            // wrangle training data
            Matrix.printMatrix(trainingData);
            Matrix X = Matrix.getTrainingData(trainingData);
            Console.WriteLine("Got X"); // issue is this is still impacting trainingData somehow
            Matrix.printMatrix(trainingData);
            List<decimal> yData = Matrix.getColumn(trainingData, trainingData.numColumns - 1);
            List<List<decimal>> yDataForMatrix = new List<List<decimal>>(1);
            yDataForMatrix.Add(yData);
            Matrix yAsRow = new Matrix(1, trainingData.numRows, yDataForMatrix);
            Matrix y = MatrixMultiplication.getTranspose(yAsRow);
            
            // get predictions
            Matrix predictions = Prediction.makePredictions(inputData: X, model: currentModel);
            
            // compute gradient = features * (predictions - actuals)
            Matrix predictionsMinusActuals = MatrixMultiplication.addMatrices(predictions, y, true);
            Matrix predictionsMinusActualsT = MatrixMultiplication.getTranspose(predictionsMinusActuals);
            decimal? gradient = MatrixMultiplication.dotProduct(predictionsMinusActualsT.Data[0], yDataForMatrix[0]);

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