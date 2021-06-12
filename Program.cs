using System;

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
                numberOfColumns: 9,
                columnNames: columnNames);
        }
    }
}