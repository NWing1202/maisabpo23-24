# maisabpo23-24
МАиСАБПО Лаб_1
Выполнил студент: Черных А.О. БИ-41
(Делалось еще до предоставления примеров, поэтому выглядит решение иначе)

1. Бинарное представление данных.

        string format = args[0];
        string filePath = args[1];

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Ошибка! Файл не найден.");
            return;
        }

        byte[] fileBytes = File.ReadAllBytes(filePath);

        switch (format.ToLower())
        {
            case "hex8":
                foreach (byte b in fileBytes)
                {
                    Console.Write($"{b:X2} ");
                }
                Console.WriteLine();
                break;
            case "dec8":
                foreach (byte b in fileBytes)
                {
                    Console.Write($"{b:D3} ");
                }
                Console.WriteLine();
                break;
            case "hex16":
                for (int i = 0; i < fileBytes.Length; i += 2)
                {
                    ushort val = BitConverter.ToUInt16(fileBytes, i);
                    Console.Write($"{val:X4} ");
                }
                Console.WriteLine();
                break;
            case "dec16":
                for (int i = 0; i < fileBytes.Length; i += 2)
                {
                    ushort val = BitConverter.ToUInt16(fileBytes, i);
                    Console.Write($"{val:D5} ");
                }
                Console.WriteLine();
                break;
            case "hex32":
                for (int i = 0; i < fileBytes.Length; i += 4)
                {
                    uint val = BitConverter.ToUInt32(fileBytes, i);
                    Console.Write($"{val:X8} ");
                }
                Console.WriteLine();
                break;
            default:
                Console.WriteLine("Ошибка! Неподдерживаемый формат.");
                break;
        }

Поддерживаемые форматы:   
hex8 - в байтовом представлении в шестнадцатеричном исчислении, разделенное пробелами: 01 02 ... FF  
dec8 - в байтовом представлении в десятичном исчислении, разделенное пробелами: 001 002 ... 255  
hex16 - в word представлении в шестнадцатеричном исчислении, разделенное пробелами: 0001 0002 ... FFFF  
dec16 - в word представлении в десятичном исчислении, разделенное пробелами: 00001 00002 ... 65535  
hex32 - в Int32 представлении в шестнадцатеричном исчислении, разделенное пробелами: 00000001 00000002 ... FFFFFFFF  

![image](https://github.com/NWing1202/maisabpo23-24/assets/90266433/088758f9-0fc6-445f-a411-b737bfd84b88)

  
==============================================================
  

2.Битовые операции

        string command = args[0];
        ulong number1 = ulong.Parse(args[1]);
        ulong number2 = ulong.Parse(args[2]);

        ulong result = 0;

        switch (command)
        {

            /*xor - исключающее или
            and - бинарное И
            or - бинарное ИЛИ
            set1 - установить бит под номером число1 равным 1
            set0 - установить бит под номером число1 равным 0
            shl - сдвинуть число2 на число1 бит влево
            shr - сдвинуть число2 на число1 бит вправо
            shl - циклически сдвинуть число2 на число1 бит влево
            shr - циклически сдвинуть число2 на число1 бит вправо
            mix - число1 указывает порядок бит (числа от 0 до 7), каждый байт числа 2 переставить указанном порядке */

            case "xor":
                result = number1 ^ number2;
                break;
            case "and":
                result = number1 & number2;
                break;
            case "or":
                result = number1 | number2;
                break;
            case "set1":
                result = SetBit(number2, (int)number1, true);
                break;
            case "set0":
                result = SetBit(number2, (int)number1, false);
                break;
            case "shl":
                result = number2 << (int)number1;
                break;
            case "shr":
                result = number2 >> (int)number1;
                break;
            case "cshl":
                result = CircularShiftLeft(number2, (int)number1);
                break;
            case "cshr":
                result = CircularShiftRight(number2, (int)number1);
                break;
            case "mix":
                result = MixBits(number2, (int)number1);
                break;
            default:
                Console.WriteLine("Неизвестная команда.");
                return;
        }

        Console.WriteLine($"Результат в десятичном виде: {result}");
        Console.WriteLine($"Результат в шестнадцатеричном виде: {result:X}");
        Console.WriteLine($"Результат в двоичном виде: {Convert.ToString((long)result, 2)}");
    }

    static ulong SetBit(ulong number, int bitPosition, bool value)
    {
        if (value)
        {
            number |= (ulong)1 << bitPosition;
        }
        else
        {
            number &= ~((ulong)1 << bitPosition);
        }
        return number;
    }

    static ulong CircularShiftLeft(ulong number, int shiftAmount)
    {
        shiftAmount %= sizeof(ulong) * 8;
        ulong shiftedBits = number << shiftAmount;
        ulong wrappedBits = number >> (sizeof(ulong) * 8 - shiftAmount);
        return shiftedBits | wrappedBits;
    }

    static ulong CircularShiftRight(ulong number, int shiftAmount)
    {
        shiftAmount %= sizeof(ulong) * 8;
        ulong shiftedBits = number >> shiftAmount;
        ulong wrappedBits = number << (sizeof(ulong) * 8 - shiftAmount);
        return shiftedBits | wrappedBits;
    }

    static ulong MixBits(ulong number, int bitOrder)
    {
        ulong result = 0;

        for (int i = 0; i < 8; i++)
        {
            int sourceIndex = bitOrder * 8 + i;
            int targetIndex = i * 8 + bitOrder;
            ulong sourceMask = (ulong)1 << sourceIndex;
            ulong sourceBit = (number & sourceMask) >> sourceIndex;
            ulong targetMask = (ulong)1 << targetIndex;
            result |= sourceBit << targetIndex;
        }

        return result;
    }


Пример:
    
![image](https://github.com/NWing1202/maisabpo23-24/assets/90266433/6c58ee0b-b00f-42ed-a2f8-a002fb4a846e)
  
==============================================================  


3. Модульная арифметика:
разработать консольное приложение, выполняющее базовые арифметические операции в поле модуля m (mod M): сложение, вычитание, умножение, возведение в степень, поиск обратного элемента, деление.


    
public class ModuloArithmetic
{
    public static int Add(int a, int b, int m)
    {
        int sum = (a + b) % m;
        return sum >= 0 ? sum : sum + m;
    }

    public static int Subtract(int a, int b, int m)
    {
        int difference = (a - b) % m;
        return difference >= 0 ? difference : difference + m;
    }

    public static int Multiply(int a, int b, int m)
    {
        int product = (a * b) % m;
        return product >= 0 ? product : product + m;
    }

    public static int Power(int a, int exponent, int m)
    {
        int result = 1;
        a = a % m;

        while (exponent > 0)
        {
            if (exponent % 2 == 1)
                result = (result * a) % m;

            exponent = exponent >> 1;
            a = (a * a) % m;
        }

        return result;
    }

    public static int FindInverse(int a, int m)
    {
        int m0 = m;
        int a1 = a;
        int y = 0, x = 1;

        if (m == 1)
            return 0;
        if (a1 == 0)
        {
            throw new ArgumentException("Divisor cannot be zero.");
        }

        while (a > 1)
        {
            if (m == 0)
            {
                // Обработка деления на ноль
                throw new DivideByZeroException("Attempted to divide by zero.");
            }

            int q = a / m;
            int t = m;

            m = a % m;
            a = t;
            t = y;

            y = x - q * y;
            x = t;
        }

        if (x < 0)
            x += m0;

        return x;
    }

    public static int Divide(int a, int b, int m)
    {
        if (b == 0)
        {
            throw new ArgumentException("Divisor cannot be zero.");
        }

        int inverseB = FindInverse(b, m);
        int quotient = Multiply(a, inverseB, m);
        return quotient;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the value of m: ");
        int m = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the value of a: ");
        int a = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the value of b: ");
        int b = int.Parse(Console.ReadLine());

        Console.WriteLine("Сложение: " + Add(a, b, m));
        Console.WriteLine("Вычитание: " + Subtract(a, b, m));
        Console.WriteLine("Умножение: " + Multiply(a, b, m));
        Console.WriteLine("Степень: " + Power(a, b, m));
        Console.WriteLine("Поиск обратного элемента по а: " + FindInverse(a, m));
        Console.WriteLine("Деление: " + Divide(a, b, m));
    }
}
  

  ![image](https://github.com/NWing1202/maisabpo23-24/assets/90266433/0dd74981-28e1-44e6-8a0d-6ed2ba4ea42e)

=================================================


3.1 Модульная арифметика на полиномах GF(2,n): разработать консольное приложение, выполняющее базовые арифметические операции в поле полинома GF(2,n) (mod M): сложение, вычитание, умножение, поиск обратного элемента, деление.  


// входные данные
uint a = 365;   // 101101101
uint b = 1514;  // 10111101010
uint M = 69665; // 10001000000100001

Console.WriteLine($"a = {a} = {Convert.ToString(a, 2)}");
Console.WriteLine($"b = {b} = {Convert.ToString(b, 2)}");
Console.WriteLine($"M = {M} = {Convert.ToString(M, 2)}");

// сложение
uint sum = Add(a, b, M);
Console.WriteLine($"a+b mod M = {sum}");

// вычитание
uint sub = Sub(a, b, M);
Console.WriteLine($"a-b mod M = {sub}");

// умножение
uint mul = Mul(a, b, M);
Console.WriteLine($"a*b mod M = {mul}");

// поиск обратного элемента
uint inv = Inv(2, M);
Console.WriteLine($"2^(-1) mod M = {inv}");

// деление
uint div = Div(a, b, M);
Console.WriteLine($"a/b mod M = {div}");

// функция сложения двух чисел в поле GF(2,n)
static uint Add(uint a, uint b, uint M)
{
    return a ^ b;
}

// функция вычитания двух чисел в поле GF(2,n)
static uint Sub(uint a, uint b, uint M)
{
    return a ^ b;
}

// функция умножения двух чисел в поле GF(2,n)
static uint Mul(uint a, uint b, uint M)
{
    uint res = 0;
    while (b != 0)
    {
        if ((b & 1) != 0)
        {
            res ^= a;
        }
        a <<= 1;
        if ((a & (1 << 16)) != 0)
        {
            a ^= M;
        }
        b >>= 1;
    }
    return res;
}

// функция поиска обратного элемента в поле GF(2,n)
static uint Inv(uint a, uint M)
{
    uint x = 1, y = 0;
    for (int i = 0; i < 16; i++)
    {
        if ((a & (1 << i)) != 0)
        {
            y ^= x;
        }
        x <<= 1;
        if ((x & (1 << 16)) != 0)
        {
            x ^= M;
        }
    }
    return y;
}

// функция деления двух чисел в поле GF(2,n)
static uint Div(uint a, uint b, uint M)
{
    uint inv = Inv(b, M);
    return Mul(a, inv, M);
}

![image](https://github.com/NWing1202/maisabpo23-24/assets/90266433/49220c83-5fee-4851-8533-6ed88c722b8e)


=================================================


4. Проверка числа на простоту

public class PrimeNumberGenerator
{
    public List<int> GenerateFirstNPrimes(int n)
    {
        List<int> primes = new List<int>();
        int num = 2;

        while (primes.Count < n)
        {
            if (IsPrime(num))
            {
                primes.Add(num);
            }
            num++;
        }

        return primes;
    }

    public bool IsPrime(int number)
    {
        if (number <= 1)
        {
            return false;
        }

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}

public class Program
{
    static void Main(string[] args)
    {
        PrimeNumberGenerator primeGenerator = new PrimeNumberGenerator();

        // Вывод N первых простых чисел
        Console.WriteLine("Введите число N вывода первых простых чисел:");
        int n = int.Parse(Console.ReadLine()); // Замените на желаемое количество простых чисел
        List<int> firstNPrimes = primeGenerator.GenerateFirstNPrimes(n);
        Console.WriteLine($"Первые {n} простых чисел: ");
        foreach (int prime in firstNPrimes)
        {
            Console.Write(prime + " ");
        }
        Console.WriteLine();

        // Проверка введенного числа на простоту
        Console.Write("Введите число для проверки: ");
        int inputNumber = Convert.ToInt32(Console.ReadLine());
        bool isPrime = primeGenerator.IsPrime(inputNumber);
        if (isPrime)
        {
            Console.WriteLine($"{inputNumber} является простым числом.");
        }
        else
        {
            Console.WriteLine($"{inputNumber} не является простым числом.");
        }
    }
}

![image](https://github.com/NWing1202/maisabpo23-24/assets/90266433/127cea17-c700-46b3-b17b-c18e7783c923)

=================================================

5. Арифметика больших чисел.

  
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

![image](https://github.com/NWing1202/maisabpo23-24/assets/90266433/792c866a-07f0-4ffb-a6a1-3c28b3f14f18)

