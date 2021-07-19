using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Xml.Schema;

namespace Logistic_Regression_From_Scratch
{
    public class MatrixMultiplication
    {
        public MatrixMultiplication() {}
        
        public static bool isMultiplicationPossible(Matrix M1, Matrix M2)
        {
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
            Console.WriteLine("Trying matrix dot product...");
            if (R1.numColumns != R2.numRows)
                throw new Exception("Dimensions do not match");
            
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
                Console.WriteLine($"{R1.Count} does not equal {R2.Count}");
                //throw new Exception($"Dimensions do not match: {R1.Count} versus {R2.Count}");

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
                    resultMatrix.Data[rowNum][colNum] = (decimal) entryToAdd;
                }
            }
            return resultMatrix;
        }

        public static Matrix addMatrices(Matrix M1, Matrix M2, bool subtract)
        {
            decimal subtractionCoefficient = subtract ? -1 : 1;
            Matrix resultMatrix = new Matrix(M1.numRows, M2.numColumns);
            for(int rowNum = 0; rowNum < resultMatrix.numRows; rowNum++)
            {
                for (int colNum = 0; colNum < resultMatrix.numColumns; colNum++)
                {
                    resultMatrix.Data[rowNum][colNum] = M1.Data[rowNum][colNum] + subtractionCoefficient * M2.Data[rowNum][colNum];
                }
            }
            return resultMatrix;
        }

        public static Matrix getTranspose(Matrix M)
        {
            Matrix transposedM = new Matrix(rows: M.numColumns, columns: M.numRows);
            for (int colNum = 0; colNum < M.numColumns; colNum++)
            {
                for (int rowNum = 0; rowNum < M.numRows; rowNum++)
                {
                    transposedM.Data[colNum][rowNum] = M.Data[rowNum][colNum];
                }
            }
            return transposedM;
        }
    }
}