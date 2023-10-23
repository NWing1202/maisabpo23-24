//using System;
//2. Битовые операции
//class Program
//{
//    static void Main(string[] args)
//    {
//        if (args.Length < 3)
//        {
//            Console.WriteLine("Необходимо указать 3 аргумента: команда, число1 и число2.");
//            return;
//        }

//        string command = args[0];
//        ulong number1 = ulong.Parse(args[1]);
//        ulong number2 = ulong.Parse(args[2]);

//        ulong result = 0;

//        switch (command)
//        {

//            /*xor - исключающее или
//            and - бинарное И
//            or - бинарное ИЛИ
//            set1 - установить бит под номером число1 равным 1
//            set0 - установить бит под номером число1 равным 0
//            shl - сдвинуть число2 на число1 бит влево
//            shr - сдвинуть число2 на число1 бит вправо
//            shl - циклически сдвинуть число2 на число1 бит влево
//            shr - циклически сдвинуть число2 на число1 бит вправо
//            mix - число1 указывает порядок бит (числа от 0 до 7), каждый байт числа 2 переставить указанном порядке */

//            case "xor":
//                result = number1 ^ number2;
//                break;
//            case "and":
//                result = number1 & number2;
//                break;
//            case "or":
//                result = number1 | number2;
//                break;
//            case "set1":
//                result = SetBit(number2, (int)number1, true);
//                break;
//            case "set0":
//                result = SetBit(number2, (int)number1, false);
//                break;
//            case "shl":
//                result = number2 << (int)number1;
//                break;
//            case "shr":
//                result = number2 >> (int)number1;
//                break;
//            case "cshl":
//                result = CircularShiftLeft(number2, (int)number1);
//                break;
//            case "cshr":
//                result = CircularShiftRight(number2, (int)number1);
//                break;
//            case "mix":
//                result = MixBits(number2, (int)number1);
//                break;
//            default:
//                Console.WriteLine("Неизвестная команда.");
//                return;
//        }

//        Console.WriteLine($"Результат в десятичном виде: {result}");
//        Console.WriteLine($"Результат в шестнадцатеричном виде: {result:X}");
//        Console.WriteLine($"Результат в двоичном виде: {Convert.ToString((long)result, 2)}");
//    }

//    static ulong SetBit(ulong number, int bitPosition, bool value)
//    {
//        if (value)
//        {
//            number |= (ulong)1 << bitPosition;
//        }
//        else
//        {
//            number &= ~((ulong)1 << bitPosition);
//        }
//        return number;
//    }

//    static ulong CircularShiftLeft(ulong number, int shiftAmount)
//    {
//        shiftAmount %= sizeof(ulong) * 8;
//        ulong shiftedBits = number << shiftAmount;
//        ulong wrappedBits = number >> (sizeof(ulong) * 8 - shiftAmount);
//        return shiftedBits | wrappedBits;
//    }

//    static ulong CircularShiftRight(ulong number, int shiftAmount)
//    {
//        shiftAmount %= sizeof(ulong) * 8;
//        ulong shiftedBits = number >> shiftAmount;
//        ulong wrappedBits = number << (sizeof(ulong) * 8 - shiftAmount);
//        return shiftedBits | wrappedBits;
//    }

//    static ulong MixBits(ulong number, int bitOrder)
//    {
//        ulong result = 0;

//        for (int i = 0; i < 8; i++)
//        {
//            int sourceIndex = bitOrder * 8 + i;
//            int targetIndex = i * 8 + bitOrder;
//            ulong sourceMask = (ulong)1 << sourceIndex;
//            ulong sourceBit = (number & sourceMask) >> sourceIndex;
//            ulong targetMask = (ulong)1 << targetIndex;
//            result |= sourceBit << targetIndex;
//        }

//        return result;
//    }
//}