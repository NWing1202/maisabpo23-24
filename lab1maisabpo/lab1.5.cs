using System;
using System.Numerics;
//5. Арифметика больших чисел.
public class MyBigInteger
{
    private string number;

    // конструктор класса
    public MyBigInteger(string number)
    {
        this.number = number;
    }

    // сложение
    public MyBigInteger Add(MyBigInteger other)
    {
        BigInteger bigInteger1 = BigInteger.Parse(this.number);
        BigInteger bigInteger2 = BigInteger.Parse(other.number);
        BigInteger result = BigInteger.Add(bigInteger1, bigInteger2);

        return new MyBigInteger(result.ToString());
    }

    // умножение
    public MyBigInteger Multiply(MyBigInteger other)
    {
        BigInteger bigInteger1 = BigInteger.Parse(this.number);
        BigInteger bigInteger2 = BigInteger.Parse(other.number);
        BigInteger result = BigInteger.Multiply(bigInteger1, bigInteger2);

        return new MyBigInteger(result.ToString());
    }

    // приведение по модулю
    public MyBigInteger Mod(MyBigInteger other)
    {
        BigInteger bigInteger1 = BigInteger.Parse(this.number);
        BigInteger bigInteger2 = BigInteger.Parse(other.number);
        BigInteger result = BigInteger.Remainder(bigInteger1, bigInteger2);

        return new MyBigInteger(result.ToString());
    }

    // вывод на экран
    public void Print()
    {
        Console.WriteLine(this.number);
    }
    public static void Main(string[] args)
    {
        // создаем два объекта MyBigInteger
        MyBigInteger bigInteger1 = new MyBigInteger("12345678901234567890");
        MyBigInteger bigInteger2 = new MyBigInteger("98765432109876543210");

        // сложение
        MyBigInteger sum = bigInteger1.Add(bigInteger2);
        Console.Write("Сумма: ");
        sum.Print();

        // умножение
        MyBigInteger mult = bigInteger1.Multiply(bigInteger2);
        Console.Write("Произведение: ");
        mult.Print();

        // приведение по модулю
        MyBigInteger mod = bigInteger1.Mod(bigInteger2);
        Console.Write("Остаток от деления: ");
        mod.Print();
    }
}