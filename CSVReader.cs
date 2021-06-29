using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Logistic_Regression_From_Scratch
{
    public class CSVReader
    {
        public CSVReader(string path, int numberOfColumns, string[] columnNames)
        {
            IDictionary<int, string> ColumnNames = new Dictionary<int, string>();
            IDictionary<int, List<double>> ColumnData = new Dictionary<int, List<double>>();
            List<List<decimal>> allData = new List<List<decimal>>();

            for (int i=0; i < numberOfColumns; i++)
            {
                ColumnNames.Add(i, columnNames[i]);
                ColumnData.Add(i, new List<double>());
            }

            int rowCounter = 0;
            using(var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',').Select(decimal.Parse).ToList();
                    allData.Add(values);
                    rowCounter++;

                    for (int i = 0; i < numberOfColumns; i++)
                    {
                        ColumnData[i].Add(Convert.ToDouble(values[i]));
                    }
                }
            }
            Matrix resultsMatrix = new Matrix(rows: rowCounter, columns: numberOfColumns, data: allData);
            List<decimal> lastColumn = Matrix.getColumn(M:resultsMatrix, columnNumber:8);
            //TODO: method to actually return the results matrix
        }
    }
}