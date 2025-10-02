using System;

namespace Lab1math
{
    static class Program
    {
        static double F(double x)
        {
            return Math.Pow(x, 4) + Math.Pow(x, 3) - 6 * Math.Pow(x, 2) + 20 * x - 16;
        }

        static double Phi(double x)
        {
            return x + F(x) / (x - 30);
        }

        static double Ao(double q, double xn, double xn_1)
        {
            return (q / (1 - q)) * Math.Abs(xn - xn_1);
        }

        static void IterativeMethod()
        {
            double x0 = 0.8;
            double epsilon = 1e-4;
            double q = 0.5;
            int n = (int)(Math.Log(Math.Abs(Phi(x0) - x0) / ((1 - q) * epsilon)) / Math.Log(1 / q)) + 1;

            double x = x0;

            Console.WriteLine("{0,-5} | {1,-20} | {2,-20} | {3,-20}", "n", "x", "f(x)", "ao");
            Console.WriteLine(new string('-', 70));
            Console.WriteLine("{0,-5} | {1,-20} | {2,-20} | {3,-20}", 0, x, F(x), "-");

            for (int i = 1; i <= n; i++)
            {
                double xn_1 = x;
                x = Phi(x);
                double aoValue = Ao(q, x, xn_1);
                Console.WriteLine("{0,-5} | {1,-20} | {2,-20} | {3,-20}", i, x, F(x), aoValue);
            }
        }

        static void RelaxationMethod()
        {
            double x0 = 0.8;
            double epsilon = 1e-4;

            double m1 = 14;
            double M1 = 24;
            double t = 2 / (M1 + m1);
            double q = (M1 - m1) / (M1 + m1);

            int n = (int)(Math.Log(Math.Abs(x0) / epsilon) / Math.Log(1 / q)) + 1;

            double x = x0;

            Console.WriteLine("{0,-5} | {1,-20} | {2,-20} | {3,-20}", "n", "x", "f(x)", "ao");
            Console.WriteLine(new string('-', 70));
            Console.WriteLine("{0,-5} | {1,-20} | {2,-20} | {3,-20}", 0, x, F(x), "-");

            for (int i = 1; i <= n; i++)
            {
                x = x - t * F(x);
                double ao = Math.Pow(q, i) * Math.Abs(x0);
                Console.WriteLine("{0,-5} | {1,-20} | {2,-20} | {3,-20}", i, x, F(x), ao);
            }
        }

        static void Main()
        {
            while (true)
            {
                Console.Write("Select algorithm to solve x^4 + x^3 - 6x^2 + 20x - 16 = 0:\n1: Iterative method\n2: Relaxation method\n> ");
                string? mode = Console.ReadLine();

                if (mode != "1" && mode != "2")
                {
                    Console.WriteLine("Try again\n");
                    continue;
                }

                if (mode == "1")
                    IterativeMethod();
                else
                    RelaxationMethod();

                break;
            }
        }
    }
}
