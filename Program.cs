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
            
            List<List<decimal>> R1XData = new List<List<decimal>>
            {
                new List<decimal>{1, 2, 3, 4, 6}
            };
            List<List<decimal>> R2XData = new List<List<decimal>> 
            {
                new List<decimal>{1}, 
                new List<decimal>{2}, 
                new List<decimal>{3}, 
                new List<decimal>{4}, 
                new List<decimal>{5}
            };
            Matrix R1 = new Matrix(1, R1XData[0].Count, R1XData);
            Matrix R2 = new Matrix(R2XData.Count, 1, R2XData);
            decimal? dotProduct = MatrixMultiplication.dotProduct(R1, R2);
            Console.WriteLine(dotProduct);
            
            // Testing 2x2 product
            List<List<decimal>> M1Data = new List<List<decimal>>
            {
                new List<decimal> {1, 2},
                new List<decimal> {2, 3}
            };
            List<List<decimal>> M2Data = new List<List<decimal>>
            {
                new List<decimal> {-1, 0},
                new List<decimal> {4, 3}
            };
            Matrix M1 = new Matrix(2, 2, M1Data);
            Matrix M2 = new Matrix(2, 2, M2Data);
            Matrix result = MatrixMultiplication.multiplyMatrices(M1, M2);
            Console.WriteLine($"[{result.Data[0][0]} , {result.Data[0][1]}]");
            Console.WriteLine($"[{result.Data[1][0]} , {result.Data[1][1]}]");
        }
    }
}