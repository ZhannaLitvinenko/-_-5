using System;

namespace Lab5
{
	class Program
	{
		static double a, b;		
		static int _2n;

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

			Console.WriteLine("Введiть 2n:");
			_2n = int.Parse(Console.ReadLine());
		}

		static void CalculateAverageVoltage()
		{
			//формула середьного значення виглядає так:
			//1/(b-a) * integral[a;b](125 * sin (wt / 3) - 30 * wt
			//змінна - wt

			//1. визначаємо крок інтегрування за формулою: h = (b - a) / 2n
			double h = (b - a) / _2n;
			//2. початкове значення wt, що підставляється у функцію = a
			double wt = a;

			//3. формула Сімпсона (для обрахунку визначеного інтегралу) 
			//виглядає так: h / 3 * sum(f1, 2*f2, 4*f3, 2*f4, 4*f5, ... , f[2n])

			//спочатку рахуємо суму:
			double sum = 0;
			for(int i = 0; i < _2n; i++)
			{
				//обрахуємо поточне значення функції:
				double currVoltage = MathHelper.CalculateVoltage(wt);

				//при першому або останньому і, додається значення функції:
				if (i == 0 || i == _2n - 1)
					sum += currVoltage;
				//при парному і, додається значення функції, помножене на 2:
				else if (i % 2 == 0)
					sum += 2 * currVoltage;
				//при непарному і, додається значення функції, помножене на 4:
				else if (i % 2 != 0)
					sum += 4 * currVoltage;

				//Поточна wt -- попереднє значення + крок(h):
				wt += h;
			}

			//після обрахування суми, множимо на h/3, щоб отримати значення інтегралу:
			double integralValue = (h / 3) * sum;

			//щоб знайти середнє значення, домножаємо інтеграл на 1/(b-a):
			double avgValue = 1 / (b - a) * integralValue;

			//Виводимо результат:
			Console.WriteLine($"\nПри а = {a}, b = {b} та кiлькостi крокiв 2n = {_2n}," +
				$" середнє значення напруги дорiвнює:\nY ср. = {Math.Round(avgValue, 5)}");
		}
	}
}
