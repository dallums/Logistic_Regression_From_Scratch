using System;

namespace Logistic_Regression_From_Scratch
{
    public class Prediction
    { 
        public static  decimal makePrediction(Matrix model, Matrix inputData)
        {
            return 0m;
        }

        public static double logLoss(double prediction, double actual)
        {
            double firstSummand = -(actual * Math.Log(prediction));
            double secondSummand = (1 - actual) * (Math.Log(1 - prediction));
            double logLossValue = firstSummand + secondSummand;
            return logLossValue;
        }

        public static double sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }
    }
}