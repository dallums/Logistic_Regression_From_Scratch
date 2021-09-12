using System;
using System.Collections.Generic;
using System.Security.Principal;

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
            Matrix InitialWeights = Matrix.getMatrixOfNearZeros(rows: CSVasMatrix.numColumns-1, columns: 1);
            //Matrix.printMatrix(InitialWeights);
            decimal InitialCoefficient = 1m;

            decimal learningRate = .001m;
            int maxIterations = 2;
            
            Training startTraining = new Training();
            startTraining.iterationNumber = 0;
            Matrix X = Matrix.getTrainingData(CSVasMatrix);
            Matrix y = Training.getYData(CSVasMatrix);

            while (startTraining.iterationNumber < maxIterations)
            {
                Matrix model = startTraining.runIteration(currentModel: InitialWeights, coefficient: InitialCoefficient, learningRate: learningRate, X: X, y: y);
            }
        }
    }
}