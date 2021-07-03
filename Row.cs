using System;
using System.Collections.Generic;
using static System.Console;
// TODO: if the matrix class is well written, this class is completely redundant since a row is a Nx0 matrix
namespace Logistic_Regression_From_Scratch
{
    public class Row : Matrix
    {
        public int XDim { get; set; }
        public new List<decimal> Data { get; set; }

        public Row()
        {
            //this is an empty row
            XDim = 0;
            Data = new List<decimal>();
        }

        public Row(int length, List<decimal> data)
        {
            XDim = length;
            Data = data;
        }
        
        public static void printRow(Row R)
        {
            Console.WriteLine("[ " + String.Join(" ", R.Data) + " ]");
            Console.WriteLine("");
        }
    }
}