using System;
using System.Collections.Generic;

namespace Logistic_Regression_From_Scratch
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathToPimaDataset = "/Users/dallums/RiderProjects/Logistic_Regression_From_Scratch/pima-diabetes.csv";
            string[] columnNames =
            {
                "Pregnancies",
                "PlasmaGlucose",
                "Diastolic",
                "Triceps",
                "Insulin",
                "BMI",
                "PedigreeFunction",
                "Age",
                "DiabeticOrNot"
            };
            Matrix CSVasMatrix = CSVReader.ReadCSV(path: pathToPimaDataset,
                numberOfColumns: columnNames.Length,
                columnNames: columnNames);
            Matrix InitialWeights = Matrix.getMatrixOfZeros(rows: CSVasMatrix.numColumns-1, columns: 1);

            decimal learningRate = .05m;
            int maxIterations = 100;
            
            Training startTraining = new Training();
            startTraining.iterationNumber = 0;
            Matrix X = Matrix.getTrainingData(CSVasMatrix);
            Matrix y = Training.getYData(CSVasMatrix);

            while (startTraining.iterationNumber < maxIterations)
            {
                Matrix model = startTraining.runIteration(currentModel: InitialWeights, trainingData: CSVasMatrix, learningRate: learningRate, X: X, y: y);
            }
        }
    }
}