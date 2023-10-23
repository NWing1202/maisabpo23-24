//using System;
//using System.IO;
////1. Бинарное представление данных.
//class Program
//{
//    static void Main(string[] args)
//    {
//        if (args.Length < 2)
//        {
//            Console.WriteLine("Ошибка! Недостаточно аргументов.");
//            return;
//        }

//        string format = args[0];
//        string filePath = args[1];

//        if (!File.Exists(filePath))
//        {
//            Console.WriteLine("Ошибка! Файл не найден.");
//            return;
//        }

//        byte[] fileBytes = File.ReadAllBytes(filePath);

//        switch (format.ToLower())
//        {
//            case "hex8":
//                foreach (byte b in fileBytes)
//                {
//                    Console.Write($"{b:X2} ");
//                }
//                Console.WriteLine();
//                break;
//            case "dec8":
//                foreach (byte b in fileBytes)
//                {
//                    Console.Write($"{b:D3} ");
//                }
//                Console.WriteLine();
//                break;
//            case "hex16":
//                for (int i = 0; i < fileBytes.Length; i += 2)
//                {
//                    ushort val = BitConverter.ToUInt16(fileBytes, i);
//                    Console.Write($"{val:X4} ");
//                }
//                Console.WriteLine();
//                break;
//            case "dec16":
//                for (int i = 0; i < fileBytes.Length; i += 2)
//                {
//                    ushort val = BitConverter.ToUInt16(fileBytes, i);
//                    Console.Write($"{val:D5} ");
//                }
//                Console.WriteLine();
//                break;
//            case "hex32":
//                for (int i = 0; i < fileBytes.Length; i += 4)
//                {
//                    uint val = BitConverter.ToUInt32(fileBytes, i);
//                    Console.Write($"{val:X8} ");
//                }
//                Console.WriteLine();
//                break;
//            default:
//                Console.WriteLine("Ошибка! Неподдерживаемый формат.");
//                break;
//        }
//    }
//}