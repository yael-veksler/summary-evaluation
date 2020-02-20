using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryEvaluation
{
    class Rational
    {

        private int Numerator { get; set; }
        public int Denominator { get; set; }

        public Rational(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        /// <summary>
        /// Approximates a Rational from the provided double
        /// </summary>
        public static Rational Parse(double d)
        {
            return ApproximateFraction(d);
        }

        /// <summary>
        /// Returns this Rational expressed as a double, rounded to the specified number of decimal places.
        /// Returns double.NaN if denominator is zero
        /// </summary>
        public double ToDouble()
        {
            if (this.Denominator == 0)
                return double.NaN;

            return (double) Numerator / Denominator;
        }


        /// <summary>
        /// Approximates the provided value to a Rational.
        /// http://stackoverflow.com/questions/95727/how-to-convert-floats-to-human-readable-fractions
        /// </summary>
        private static Rational ApproximateFraction(double value)
        {

            if (value == 0)
                return new Rational(0, 0);

            const double EPSILON = .000001d;

            int n = 1;  // numerator
            int d = 1;  // denominator
            double fraction = n / d;

            while (System.Math.Abs(fraction - value) > EPSILON)
            {
                if (fraction < value)
                {
                    n++;
                }
                else
                {
                    d++;
                    n = (int)System.Math.Round(value * d);
                }

                fraction = n / (double)d;
            }

            return new Rational(n, d);
        }

        public static Rational operator +(Rational r1, Rational r2)
        {
            return new Rational(r1.Numerator + r2.Numerator, r1.Denominator + r2.Denominator);
        }
    }
}
