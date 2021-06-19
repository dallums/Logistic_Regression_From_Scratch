namespace Logistic_Regression_From_Scratch
{
    public class MatrixMultiplication
    {
        public MatrixMultiplication(Matrix M1, Matrix M2)
        {
            int x;
        }
        
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
    }
}