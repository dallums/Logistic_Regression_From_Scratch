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
            Matrix InitialWeights = Matrix.getMatrixOfZeros(rows: 1, columns: CSVasMatrix.numColumns);
        }
    }
}