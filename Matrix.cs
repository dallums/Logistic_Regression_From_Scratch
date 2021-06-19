namespace Logistic_Regression_From_Scratch
{
    public class Matrix
    {
        public int numRows { get; set; }
        public int numColumns { get; set; }

        public Matrix(int rows, int columns)
        {
            numRows = rows;
            numColumns = columns;
            
        }
    }
}