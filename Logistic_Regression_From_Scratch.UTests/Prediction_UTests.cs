using NUnit.Framework;

namespace Logistic_Regression_From_Scratch.UTests
{
    public class Prediction_UTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LogLossShouldWork()
        {
            decimal prediction = .995m;
            decimal actual = 1.0m;
            decimal logLossValue = Prediction.logLoss(prediction, actual);
            Assert.AreEqual(logLossValue, 0.00501254182354429m);
        }
    }
}