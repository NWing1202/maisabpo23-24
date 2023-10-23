//using System;
//using System.Collections.Generic;
////4. Проверка числа на простоту

//public class PrimeNumberGenerator
//{
//    public List<int> GenerateFirstNPrimes(int n)
//    {
//        List<int> primes = new List<int>();
//        int num = 2;

//        while (primes.Count < n)
//        {
//            if (IsPrime(num))
//            {
//                primes.Add(num);
//            }
//            num++;
//        }

//        return primes;
//    }

//    public bool IsPrime(int number)
//    {
//        if (number <= 1)
//        {
//            return false;
//        }

//        for (int i = 2; i <= Math.Sqrt(number); i++)
//        {
//            if (number % i == 0)
//            {
//                return false;
//            }
//        }

//        return true;
//    }
//}

//public class Program
//{
//    static void Main(string[] args)
//    {
//        PrimeNumberGenerator primeGenerator = new PrimeNumberGenerator();

//        // Вывод N первых простых чисел
//        Console.WriteLine("Введите число N вывода первых простых чисел:");
//        int n = int.Parse(Console.ReadLine()); // Замените на желаемое количество простых чисел
//        List<int> firstNPrimes = primeGenerator.GenerateFirstNPrimes(n);
//        Console.WriteLine($"Первые {n} простых чисел: ");
//        foreach (int prime in firstNPrimes)
//        {
//            Console.Write(prime + " ");
//        }
//        Console.WriteLine();

//        // Проверка введенного числа на простоту
//        Console.Write("Введите число для проверки: ");
//        int inputNumber = Convert.ToInt32(Console.ReadLine());
//        bool isPrime = primeGenerator.IsPrime(inputNumber);
//        if (isPrime)
//        {
//            Console.WriteLine($"{inputNumber} является простым числом.");
//        }
//        else
//        {
//            Console.WriteLine($"{inputNumber} не является простым числом.");
//        }
//    }
//}