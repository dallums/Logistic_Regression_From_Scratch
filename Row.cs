using System;
using System.Collections.Generic;
using static System.Console;
// TODO: if the matrix class is well written, this class is completely redundant since a row is a Nx0 matrix
namespace Logistic_Regression_From_Scratch
{
    public class Row
    {
        public int XDim { get; set; }
        public List<decimal> Data { get; set; }

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
    }
}