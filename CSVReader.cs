using System;
using System.Collections.Generic;
using System.IO;
namespace Logistic_Regression_From_Scratch
{
    public class CSVReader
    {
        public CSVReader(string path)
        {
            using(var reader = new StreamReader(path))
            {
                List<string> Pregnancies = new List<string>();
                List<string> PlasmaGlucose = new List<string>();
                List<string> Diastolic = new List<string>();
                List<string> Triceps = new List<string>();
                List<string> Insulin = new List<string>();
                List<string> BMI = new List<string>();
                List<string> PedigreeFunction = new List<string>();
                List<string> Age = new List<string>();
                List<string> DiabeticOrNot = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    Pregnancies.Add(values[0]);
                    PlasmaGlucose.Add(values[1]);
                    Diastolic.Add(values[2]);
                    Triceps.Add(values[3]);
                    Insulin.Add(values[4]);
                    BMI.Add(values[5]);
                    PedigreeFunction.Add(values[6]);
                    Age.Add(values[7]);
                    DiabeticOrNot.Add(values[8]);
                }
            }
        }
    }
}