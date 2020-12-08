using System;

namespace Lab5
{
    class Program
    {
        static double a, b;
        static int m;

        static void Main(string[] args)
        {
            Input();
            CalculateAverageVoltage();

            Console.ReadKey();
        }

        static void Input()
        {
            Console.WriteLine("Введiть а:");
            a = double.Parse(Console.ReadLine());

            Console.WriteLine("Введiть b:");
            b = double.Parse(Console.ReadLine());

            Console.WriteLine("Введiть кiлькiсть пiдiнтервалiв:");
            m = int.Parse(Console.ReadLine());
        }

        static void CalculateAverageVoltage()
        {
            //формула середьного значення виглядає так:
            //1/(b-a) * integral[a;b](125 * sin (wt / 3) - 30 * wt

            //формула Сімпсона (для обрахунку визначеного інтегралу) 
            //виглядає так: h / 3 * sum(f1, 4*f2, f3)

            //кількість точок, що використовується
            int s = 3,
                //кількість вузлів
                k = (s - 1) * m + 1;
            //визначаємо крок інтегрування за формулою: h = |b - a| / (k - 1)
            double h = Math.Abs(b - a) / (k - 1);
            //початкове значення wt, що підставляється у функцію = a
            double wt = a;

            //спочатку рахуємо суму:
            double integralValue = 0;
            for (int i = 0; i < m; i++)
            {
                //h / 3 * (f0 + 4*f1 + f2)
                double f0 = MathHelper.CalculateVoltage(wt),
                    f1 = MathHelper.CalculateVoltage(wt + h),
                    f2 = MathHelper.CalculateVoltage(wt + 2 * h);

                //додаємо обраховану частину до загальної суми:
                integralValue += h / 3 * (f0 + 4 * f1 + f2);

                //Наступна wt -- попереднє значення + 2 кроки:
                wt += 2 * h;
            }

            //щоб знайти середнє значення, домножаємо інтеграл на 1/(b-a):
            double avgValue = 1 / (b - a) * integralValue;

            //Виводимо результат:
            Console.WriteLine($"\nПри а = {a}, b = {b} та кiлькостi пiдiнтервалiв = {m}," +
                $" середнє значення напруги дорiвнює:\nY ср. = {Math.Round(avgValue, 5)}");
        }
    }
}
