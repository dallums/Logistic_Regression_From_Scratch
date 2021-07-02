using System.Collections.Generic;
using NUnit.Framework;

namespace Logistic_Regression_From_Scratch.UTests

{
    public class Matrix_UTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DotProductShouldWork()
        {
            List<List<decimal>> R1XData = new List<List<decimal>>
            {
                new List<decimal>{1, 2, 3, 4, 6}
            };
            List<List<decimal>> R2XData = new List<List<decimal>> 
            {
                new List<decimal>{1}, 
                new List<decimal>{2}, 
                new List<decimal>{3}, 
                new List<decimal>{4}, 
                new List<decimal>{5}
            };
            Matrix R1 = new Matrix(1, R1XData[0].Count, R1XData);
            Matrix R2 = new Matrix(R2XData.Count, 1, R2XData);
            decimal? dotProduct = MatrixMultiplication.dotProduct(R1, R2);
            Assert.AreEqual(dotProduct, 60);
        }
        
        [Test]
        public void TwoByTwoProduct()
        {
            List<List<decimal>> M1Data = new List<List<decimal>>
            {
                new List<decimal> {1, 2},
                new List<decimal> {2, 3}
            };
            List<List<decimal>> M2Data = new List<List<decimal>>
            {
                new List<decimal> {-1, 0},
                new List<decimal> {4, 3}
            };
            Matrix M1 = new Matrix(2, 2, M1Data);
            Matrix M2 = new Matrix(2, 2, M2Data);
            Matrix result = MatrixMultiplication.multiplyMatrices(M1, M2);
            Assert.AreEqual(result.Data[0], new List<decimal> {7, 6});
            Assert.AreEqual(result.Data[1], new List<decimal> {10, 9});
        }
        
        [Test]
        public void TwoByThreeByThreeByTwoProduct()
        {
            List<List<decimal>> M3Data = new List<List<decimal>>
            {
                new List<decimal> {1, 2, 0},
                new List<decimal> {2, 3, 1}
            };
            List<List<decimal>> M4Data = new List<List<decimal>>
            {
                new List<decimal> {-1, 0},
                new List<decimal> {4, 3},
                new List<decimal> {0, 1}
            };
            Matrix M3 = new Matrix(2, 3, M3Data);
            Matrix M4 = new Matrix(3, 2, M4Data);
            MatrixMultiplication.isMultiplicationPossible(M3, M4);
            Matrix result = MatrixMultiplication.multiplyMatrices(M3, M4);
            Assert.AreEqual(result.Data[0], new List<decimal> {7, 6});
            Assert.AreEqual(result.Data[1], new List<decimal> {10, 10});
        }
    }
}