using NUnit.Framework;

namespace Logistic_Regression_From_Scratch.UTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LogLossShouldWork()
        {
            double prediction = .995;
            double actual = 1.0;
            double logLossValue = Prediction.logLoss(prediction, actual);
            Assert.AreEqual(logLossValue, 0.0050125418235442863d);
        }
    }
}