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
    }
}