using System.Collections.Generic;

namespace Logistic_Regression_From_Scratch
{
    public class Training
    {
        public int iterationNumber { get; set; }
        
        public Matrix runIteration(Matrix currentModel, Matrix trainingData)
        {
            /*
             * IRLS:
             * 1. X = x values
             * 2. y = y values
             * 3. P = matrix of probabilities, i.e., currentModel * trainingData
             * 4. W = diagonal weight matrix, (i,i) entry p(1-p)
             * 5. newModel = (X^TWX)^-1*X^TWz for z = XoldModel + W^{-1}(y-p)
             */
            
            Matrix X = Matrix.getTrainingData(trainingData);
            Matrix XT = MatrixMultiplication.getTranspose(X);
            
            // TODO: get this to work and make method
            List<decimal> yData = Matrix.getColumn(trainingData, trainingData.numColumns - 1);
            List<List<decimal>> yDataForMatrix = new List<List<decimal>>(1);
            yDataForMatrix.Add(yData);
            Matrix yAsRow = new Matrix(1, trainingData.numRows, yDataForMatrix);
            Matrix y = MatrixMultiplication.getTranspose(yAsRow);
            
            Matrix P = MatrixMultiplication.multiplyMatrices(trainingData, currentModel);
            Matrix W = Matrix.getWeightMatrix(rows: X.numRows, columns: X.numColumns, probabilities: P.Data);
            Matrix WInverse = MatrixMultiplication.getInverse(W);
            Matrix yMinusP = MatrixMultiplication.addMatrices(y, P, true);
            Matrix zFirstSummand = MatrixMultiplication.multiplyMatrices(X, currentModel);
            Matrix zSecondSummand = MatrixMultiplication.multiplyMatrices(WInverse, yMinusP);
            Matrix z = MatrixMultiplication.addMatrices(zFirstSummand, zSecondSummand, false);
            
            Matrix XTW = MatrixMultiplication.multiplyMatrices(XT, W);
            Matrix XTWX = MatrixMultiplication.multiplyMatrices(XTW, X);
            Matrix XTWXInverse = MatrixMultiplication.getInverse(XTWX);
            Matrix XTWXInverseXTW = MatrixMultiplication.multiplyMatrices(XTWXInverse, XTW);
            Matrix bNew = MatrixMultiplication.multiplyMatrices(XTWXInverseXTW, z);

            iterationNumber++;
            return bNew;
        }

        public Matrix runIteration(Matrix currentModel, Matrix trainingData, decimal learningRate)
        {
            /*
             * 1. Make predictions, i.e., one iteration
             * 2. Adjust each weight w_i -> w_i - alpha * partial L w.r.t w_i
             * 3. return new model
             */
            // TODO: get this to work and make method
            // wrangle training data
            Matrix X = Matrix.getTrainingData(trainingData);
            List<decimal> yData = Matrix.getColumn(trainingData, trainingData.numColumns - 1);
            List<List<decimal>> yDataForMatrix = new List<List<decimal>>(1);
            yDataForMatrix.Add(yData);
            Matrix yAsRow = new Matrix(1, trainingData.numRows, yDataForMatrix);
            Matrix y = MatrixMultiplication.getTranspose(yAsRow);
            
            // get predictions
            Matrix predictions = Prediction.makePredictions(model: currentModel, inputData: X);
            
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
            return currentModel;
        }
    }
}