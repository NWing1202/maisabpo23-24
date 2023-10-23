//using System;
//3.2 Модульная арифметика на полиномах GF(2,n)
//class Program
//{
//    static void Main()
//    {
//        int[] a = new int[] { 1, 0, 1 }; // Представление полинома: x^2 + 0x + 1
//        int[] b = new int[] { 1, 1, 1 }; // Представление полинома: x^2 + x + 1

//        Console.WriteLine("Полином A:");
//        printPolynomial(a);

//        Console.WriteLine("\nПолином B:");
//        printPolynomial(b);

//        int n = Math.Max(a.Length, b.Length);

//        int[] c = new int[n];

//        for (int i = 0; i < n; i++)
//        {
//            int coefA = i < a.Length ? a[i] : 0;
//            int coefB = i < b.Length ? b[i] : 0;

//            c[i] = (coefA + coefB) % 2; // GF(2) операциям сложения и вычитания эквиваленты
//        }

//        Console.WriteLine("\nРезультат сложения A и B в GF(2,n):");
//        printPolynomial(c);
//    }

//    static void printPolynomial(int[] polynomial)
//    {
//        int n = polynomial.Length;

//        for (int i = n - 1; i >= 0; i--)
//        {
//            if (i == 0)
//                Console.Write(polynomial[i]);
//            else if (polynomial[i] != 0)
//                Console.Write(polynomial[i] + "x^" + i + " + ");
//        }
//    }
//}