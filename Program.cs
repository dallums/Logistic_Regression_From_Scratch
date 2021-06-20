using System;
using System.Collections.Generic;

namespace Logistic_Regression_From_Scratch
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathToPimaDataset = "/Users/dallums/RiderProjects/Logistic_Regression_From_Scratch/pima-diabetes.csv";
            Console.WriteLine("Hello World!");
            Row row = new Row();
            CSVReader csvReader = new CSVReader(pathToPimaDataset);

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
            CSVReader csvReaderGeneralized = new CSVReader(path: pathToPimaDataset,
                numberOfColumns: columnNames.Length,
                columnNames: columnNames);
                
            // TODO: initialize properly and test dot product as matrix not as row
            List<List<decimal>> R1XData = new List<List<decimal>> {{1, 2, 3, 4, 5}};
            List<List<decimal>> R2XData = new List<List<decimal>> {{1}, {2}, {3}, {4}, {5}};
            Matrix R1 = new Matrix(1, R1XData.Count, R1XData);
            Matrix R2 = new Matrix(R2XData.Count, 1, R2XData);
            decimal? dotProduct = MatrixMultiplication.dotProduct(R1, R2);
            Console.WriteLine(dotProduct);
        }
    }
}