using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Xml.Schema;

namespace Logistic_Regression_From_Scratch
{
    public class MatrixMultiplication
    {
        public MatrixMultiplication() {}
        
        public bool isMultiplicationPossible(Matrix M1, Matrix M2)
        {
            // check dimensions
            int M1_columns = M1.numColumns;
            int M2_rows = M2.numRows;
            if(M1_columns == M2_rows)
            {
                return true;
            }
            return false;
        }

        public static List<decimal> getColumnAsRow(Matrix M, int columnNumber)
        {
            List<decimal> resultList = new List<decimal>(M.numRows);
            for (int rowNum = 0; rowNum < M.numRows; rowNum++)
            {
                resultList.Add(M.Data[rowNum][columnNumber]);
            }
            return resultList;
        }
        
        public static decimal? dotProduct(Matrix R1, Matrix R2)
        {
            if (R1.numColumns != R2.numRows)
            {
                // TODO: create custom wrong dimension exception to be cleaner
                Console.WriteLine($"Impossible: dimensions are not equal with {R1.numColumns} columns and {R2.numRows} rows");
                return null;
            }
            decimal result = 0m;

            List<decimal> R2asRow = getColumnAsRow(R2, 0);
            
            for (int i = 0; i < R1.numColumns; i++)
            {
                // we do this because the row has been transposed
                result += (R1.Data[0][i] * R2asRow[i]);
            }

            return result;
        }
        
        // Overloading to use in matrix multiplication when just giving list of decimals
        public static decimal? dotProduct(List<decimal> R1, List<decimal> R2)
        {
            if (R1.Count != R2.Count)
            {
                // TODO: create custom wrong dimension exception to be cleaner
                Console.WriteLine($"Impossible: dimensions are not equal with {R1.Count} and {R2.Count}");
                return null;
            }
            decimal result = 0m;

            for (int i = 0; i < R1.Count; i++)
            {
                result += (R1[i] * R2[i]);
            }

            return result;
        }
        
        public static Matrix multiplyMatrices(Matrix M1, Matrix M2)
        {
            Matrix resultMatrix = new Matrix(M1.numRows, M2.numColumns);
            for (int rowNum = 0; rowNum < resultMatrix.numRows; rowNum++)
            {
                List<decimal> rowRowNumFromM1 = M1.Data[rowNum];
                for (int colNum = 0; colNum < resultMatrix.numColumns; colNum++)
                {
                    List<decimal> colColNumFromM2 = getColumnAsRow(M2, colNum);
                    decimal? entryToAdd = dotProduct(rowRowNumFromM1, colColNumFromM2); 
                    Console.WriteLine($"Adding {entryToAdd} to row {rowNum} and column {colNum}");
                    resultMatrix.Data[rowNum][colNum] = (decimal) entryToAdd;
                }
            }
            return resultMatrix;
        }
    }
}