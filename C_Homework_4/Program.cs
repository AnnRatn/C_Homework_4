using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Homework_4
{
    class Program
    {
        public delegate double Equation(double x, List<double> param);

        class root_finding
        {
            //линейная функция
            public double Linear_function(double x, List<double> param)
            {
                return (param[0] * x + param[1]);
            }

            //Квадратичная функция
            public double Quadratic_function(double x, List<double> param)
            {
                return (param[0] * Math.Pow(x, 2) + param[1] * x + param[2]);
            }

            //Кубическая функция
            public double Cubic_function(double x, List<double> param)
            {
                return (param[0] * Math.Pow(x, 3) + param[1] * Math.Pow(x, 2) + param[2] * x + param[3]);
            }

            //Показательная функция
            public double Exponential_function(double x, List<double> param)
            {
                return (Math.Pow(param[0], x));
            }

            //Вычисление корня с заданной точностью e и обозначенным интервалом
            public double Root(Equation equation, List<double> param, double e, double a, double b)
            {
                if (equation.Invoke(a, param) * equation.Invoke(b, param) > 0)
                {
                    throw new Exception();
                }
                else
                {
                    double root = (a + b) / 2;
                    while (Math.Abs(equation.Invoke(root, param)) > e)
                    {
                        if (equation.Invoke(a, param) * equation.Invoke(root, param) < 0)
                        {
                            b = root;
                            root = (a + b) / 2;
                        }
                        else
                        {
                            a = root;
                            root = (a + b) / 2;
                        }
                    }
                    return root;
                }
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("What function do you prefer?");
            Console.WriteLine("Linear_function - 1");
            Console.WriteLine("Quadratic_function - 2");
            Console.WriteLine("Cubic_function - 3");
            Console.WriteLine("Exponential_function - 4");
            string answ = Console.ReadLine();
            Console.WriteLine("Enter parameters. End of input is '.'");
            List<double> parameter = new List<double>();
            string param = Console.ReadLine();
            try
            {
                while (param != ".")
                {
                    parameter.Add(Convert.ToDouble(param));
                    param = Console.ReadLine();
                }
                Console.WriteLine("Enter an accuracy of calculations");
                double e = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter the bounds");
                double a = Convert.ToDouble(Console.ReadLine());
                double b = Convert.ToDouble(Console.ReadLine());
                root_finding root_find = new root_finding();
                switch (answ)
                {
                    case "1":
                        Equation eq = root_find.Linear_function;
                        Console.WriteLine("Root is " + root_find.Root(eq, parameter, e, a, b).ToString());
                        break;
                    case "2":
                        eq = root_find.Quadratic_function;
                        Console.WriteLine("Root is " + root_find.Root(eq, parameter, e, a, b).ToString());
                        break;
                    case "3":
                        eq = root_find.Cubic_function;
                        Console.WriteLine("Root is " + root_find.Root(eq, parameter, e, a, b).ToString());
                        break;
                    case "4":
                        eq = root_find.Exponential_function;
                        Console.WriteLine("Root is " + root_find.Root(eq, parameter, e, a, b).ToString());
                        break;
                    default:
                        Console.WriteLine("default answers");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong format");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Wrong parameters");
            }
            catch (Exception)
            {
                Console.WriteLine("No root in this bounds");
            }
            Console.ReadKey();
        }
    }
}
