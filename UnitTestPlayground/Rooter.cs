using System;

namespace UnitTestPlayground
{
    class Rooter
    {
        internal double SquareRoot(double input)
        {
            //throw new NotImplementedException();
            //return input/2;

            if (input <= 0.0)
            {
                throw new ArgumentOutOfRangeException();
            }
            double result = input;
            double previousResult = -input;

            while (Math.Abs(previousResult - result) > result / 1000)
            {
                previousResult = result;
                result = (result + input / result) / 2;
                //result = result - (result * result - input) / (2 * result);
            }

            return result;
        }
    }
}