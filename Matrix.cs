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
        public Matrix(int rows, int columns, List<List<decimal>> data)
        {
            numRows = rows;
            numColumns = columns;
            Data = data;

        }
    }
}