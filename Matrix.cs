using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

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

        public static void printMatrix(Matrix M)
        {
            for (int rowNum = 0; rowNum < M.numRows; rowNum++)
            {
                Console.WriteLine("[ " + String.Join(" ", M.Data[rowNum]) + " ]");
            }
            Console.WriteLine("");
        }

        public static Matrix addColumn(Matrix M)
        {
            //TODO: fill in
            return M;
        }

        public static Matrix addRow(Matrix M, Row R)
        {
            // TODO: test to confirm works
            M.Data.Add(R.Data);
            return M;
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