using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask10
{
    class Program
    {
        static ICalculator Calculator { get; set; }
        public static void Main(string[] args)
        {
            Calculator = new BaseCalculator();
            Calculator.Solve();
        }
    }

    public interface ICalculator
    {
        void Solve();
    }

    public class BaseCalculator : ICalculator
    {
        public void Solve()
        {
            Console.WriteLine("Вас приветствует консольный мини-калькулятор!");

            while (true)
            {
                try
                {
                    Console.WriteLine("Введите, пожалуйста, вашу первую цифру..");
                    double NumberOne = double.Parse(Console.ReadLine());
                    Console.WriteLine("Введите, пожалуйста, вашу вторую цифру..");
                    double NumberTwo = double.Parse(Console.ReadLine());

                    Logger.Event("Сумма ваших чисел равна: " + (NumberOne + NumberTwo));
                }

                catch (FormatException)
                {
                    Logger.Error("Введено некорректное значение, попробуйте еще раз!");
                    continue;
                }
            }
        }
    }

    public interface ILogger
    {
        static abstract void Error(string message);
        static abstract void Event(string message);
    }

    public class Logger : ILogger
    {
        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Event(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
