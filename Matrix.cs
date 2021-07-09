using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Logistic_Regression_From_Scratch
{
    public class Matrix
    {
        public int numRows { get; set; }
        public int numColumns { get; set; }
        public List<List<decimal>> Data { get; set; }

        public Matrix()
        {
            // dummy matrix
            numRows = 0;
            numColumns = 0;
            Data = new List<List<decimal>>();
        }

        public Matrix(int rows, int columns)
        {
            numRows = rows;
            numColumns = columns;
            List<List<decimal>> data = new List<List<decimal>>(numRows);

            for (int rowNum = 0; rowNum < rows; rowNum++)
            {
                data.Add(new List<decimal>(new decimal[numColumns])); 
            }
            Data = data;
        }
        
        public Matrix(int rows, int columns, List<List<decimal>> data)
        {
            numRows = rows;
            numColumns = columns;
            Data = data;
        }

        public static Matrix getMatrixOfZeros(int rows, int columns)
        {
            Matrix M = new Matrix();
            M.numRows = rows;
            M.numColumns = columns;
            List<List<decimal>> data = new List<List<decimal>>(M.numRows);

            for (int rowNum = 0; rowNum < rows; rowNum++)
            {
                data.Add(new List<decimal>(new decimal[M.numColumns]));

                // TODO: find a better way to do this
                for (int colNum = 0; colNum < columns; colNum++)
                {
                    data[rowNum].Add(0);
                }
            }
            M.Data = data;
            return M;
        }

        public static Matrix getWeightMatrix(int rows, int columns, List<List<decimal>> probabilities)
        {
            // TODO: fill in
            return new Matrix();
        }

        public static Matrix getTrainingData(Matrix X)
        {
            // this doesn't seem to be making a deep copy somehow and is altering the data
            // of X
            // TODO: fix
            List<List<decimal>> copyOfX = X.Data.ConvertAll(p=>p);
            Matrix trainingDataFromX = new Matrix(rows: X.numRows, columns: X.numColumns, data: copyOfX);
            int lastColumnIndex = trainingDataFromX.numColumns - 1;
            for (int rowNum = 0; rowNum < trainingDataFromX.numRows; rowNum++)
            {
                copyOfX[rowNum].RemoveAt(lastColumnIndex);
            }
            return trainingDataFromX;
        }

        public static void printMatrix(Matrix M)
        {
            for (int rowNum = 0; rowNum < M.numRows; rowNum++)
            {
                Console.WriteLine("[ " + String.Join(" ", M.Data[rowNum]) + " ]");
            }
            Console.WriteLine("");
        }

        public static List<decimal> getColumn(Matrix M, int columnNumber)
        {
            Console.WriteLine("Beginning");
            printMatrix(M);
            List<decimal> resultsList = new List<decimal>(M.numRows);
            for (int rowNum = 0; rowNum < M.numRows; rowNum++)
            {
                Console.WriteLine("Trying " + rowNum + " at " + columnNumber);
                Console.WriteLine("Adding " + M.Data[rowNum][columnNumber]+ " at row number " + rowNum);
                //resultsList.Add(M.Data[rowNum][columnNumber]);
                resultsList.Add(0);
                Console.WriteLine("Added");
            }
            Console.WriteLine("Done");
            return resultsList;
        }
    }
}