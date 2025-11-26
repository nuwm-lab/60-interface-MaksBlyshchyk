using System;

namespace MathFunctions
{
    // Base Class: Fractional-Linear Function
    // Formula: (a1*x + a0) / (b1*x + b0)
    class FractionalLinear
    {
        // Protected allows the derived class to access these variables directly
        protected double a1, a0;
        protected double b1, b0;

        // Method 1: Set coefficients (4 values)
        public virtual void SetCoefficients(double a1, double a0, double b1, double b0)
        {
            this.a1 = a1;
            this.a0 = a0;
            this.b1 = b1;
            this.b0 = b0;
        }

        // Method 2: Print coefficients
        public virtual void PrintCoefficients()
        {
            Console.WriteLine($"Function Form: ({a1}x + {a0}) / ({b1}x + {b0})");
        }

        // Method 3: Calculate value at point x0
        public virtual double Calculate(double x0)
        {
            double numerator = (a1 * x0) + a0;
            double denominator = (b1 * x0) + b0;

            if (denominator == 0)
            {
                Console.WriteLine("Error: Division by zero.");
                return 0;
            }

            return numerator / denominator;
        }
    }

    // Derived Class: Fractional Function (Quadratic)
    // Formula: (a2*x^2 + a1*x + a0) / (b2*x^2 + b1*x + b0)
    class FractionalQuadratic : FractionalLinear
    {
        // New coefficients specific to the quadratic version
        private double a2;
        private double b2;

        // Overloading SetCoefficients to accept 6 values
        public void SetCoefficients(double a2, double a1, double a0, double b2, double b1, double b0)
        { 
            this.a2 = a2;
            this.b2 = b2;
            // Use the base class method to set the linear parts
            base.SetCoefficients(a1, a0, b1, b0);
        }

        // Overriding Print to show the quadratic form
        public override void PrintCoefficients()
        {
            Console.WriteLine($"Function Form: ({a2}x^2 + {a1}x + {a0}) / ({b2}x^2 + {b1}x + {b0})");
        }

        // Overriding Calculate to include the squared terms
        public override double Calculate(double x0)
        {
            double numerator = (a2 * Math.Pow(x0, 2)) + (a1 * x0) + a0;
            double denominator = (b2 * Math.Pow(x0, 2)) + (b1 * x0) + b0;

            if (denominator == 0)
            {
                Console.WriteLine("Error: Division by zero.");
                return 0;
            }

            return numerator / denominator;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // --- Testing Base Class ---
            Console.WriteLine("--- 1. Fractional-Linear Function ---");
            FractionalLinear linearFunc = new FractionalLinear();

            // Equation: (2x + 5) / (x + 1)
            linearFunc.SetCoefficients(2, 5, 1, 1);
            linearFunc.PrintCoefficients();

            double x = 2.0;
            double result1 = linearFunc.Calculate(x);
            Console.WriteLine($"Value at x = {x}: {result1}");
            Console.WriteLine();


            // --- Testing Derived Class ---
            Console.WriteLine("--- 2. Fractional Function (Quadratic) ---");
            FractionalQuadratic quadFunc = new FractionalQuadratic();

            // Equation: (1x^2 + 2x + 3) / (1x^2 + 0x + 1)
            quadFunc.SetCoefficients(1, 2, 3, 1, 0, 1);
            quadFunc.PrintCoefficients();

            double result2 = quadFunc.Calculate(x);
            Console.WriteLine($"Value at x = {x}: {result2}");

            Console.ReadKey();
        }
    }
}