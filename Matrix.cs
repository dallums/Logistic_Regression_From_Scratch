using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

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

        public static List<T> CloneList<T>(List<T> oldList)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, oldList);
            stream.Position = 0;
            return (List<T>)formatter.Deserialize(stream);
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
            List<List<decimal>> copyOfX = CloneList(X.Data);
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
            List<decimal> resultsList = new List<decimal>(M.numRows);
            for (int rowNum = 0; rowNum < M.numRows; rowNum++)
            {
                resultsList.Add(M.Data[rowNum][columnNumber]);
            }
            return resultsList;
        }
    }
}