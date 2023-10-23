//using System;
////3. Модульная арифметика
////разработать консольное приложение, выполняющее базовые арифметические операции в поле модуля m (mod M): сложение, вычитание, умножение, возведение в степень, поиск обратного элемента, деление.
//public class ModuloArithmetic
//{
//    public static int Add(int a, int b, int m)
//    {
//        int sum = (a + b) % m;
//        return sum >= 0 ? sum : sum + m;
//    }

//    public static int Subtract(int a, int b, int m)
//    {
//        int difference = (a - b) % m;
//        return difference >= 0 ? difference : difference + m;
//    }

//    public static int Multiply(int a, int b, int m)
//    {
//        int product = (a * b) % m;
//        return product >= 0 ? product : product + m;
//    }

//    public static int Power(int a, int exponent, int m)
//    {
//        int result = 1;
//        a = a % m;

//        while (exponent > 0)
//        {
//            if (exponent % 2 == 1)
//                result = (result * a) % m;

//            exponent = exponent >> 1;
//            a = (a * a) % m;
//        }

//        return result;
//    }

//    public static int FindInverse(int a, int m)
//    {
//        int m0 = m;
//        int a1 = a;
//        int y = 0, x = 1;

//        if (m == 1)
//            return 0;
//        if (a1 == 0)
//        {
//            throw new ArgumentException("Divisor cannot be zero.");
//        }

//        while (a > 1)
//        {
//            if (m == 0)
//            {
//                // Обработка деления на ноль
//                throw new DivideByZeroException("Attempted to divide by zero.");
//            }

//            int q = a / m;
//            int t = m;

//            m = a % m;
//            a = t;
//            t = y;

//            y = x - q * y;
//            x = t;
//        }

//        if (x < 0)
//            x += m0;

//        return x;
//    }

//    public static int Divide(int a, int b, int m)
//    {
//        if (b == 0)
//        {
//            throw new ArgumentException("Divisor cannot be zero.");
//        }

//        int inverseB = FindInverse(b, m);
//        int quotient = Multiply(a, inverseB, m);
//        return quotient;
//    }

//    public static void Main(string[] args)
//    {
//        Console.WriteLine("Enter the value of m: ");
//        int m = int.Parse(Console.ReadLine());

//        Console.WriteLine("Enter the value of a: ");
//        int a = int.Parse(Console.ReadLine());

//        Console.WriteLine("Enter the value of b: ");
//        int b = int.Parse(Console.ReadLine());

//        Console.WriteLine("Сложение: " + Add(a, b, m));
//        Console.WriteLine("Вычитание: " + Subtract(a, b, m));
//        Console.WriteLine("Умножение: " + Multiply(a, b, m));
//        Console.WriteLine("Степень: " + Power(a, b, m));
//        Console.WriteLine("Поиск обратного элемента по а: " + FindInverse(a, m));
//        Console.WriteLine("Деление: " + Divide(a, b, m));
//    }
//}