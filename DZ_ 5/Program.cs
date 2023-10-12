using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DZ_5
{
    enum Mouths { Январь, Февраль, Март, Апрель, Май, Июнь, Июль, Август, Сентябрь, Октябрь, Ноябрь, Декабрь }
    internal class Program
    {
        /// <summary>
        /// Умножает матрицы(LinkedList)
        /// </summary>
        /// <param name="array_1"></param>
        /// <param name="array_2"></param>
        /// <returns></returns>
        static int[,] MultiplicationArrayLinkedList(LinkedList<int[,]> linkedList)
        {
            int[,] array_1 = linkedList.First?.Value;
            int[,] array_2 = linkedList.First?.Value;
            int[,] result = new int[array_1.GetLength(0), array_2.GetLength(1)];
            for (int i = 0; i < array_1.GetLength(0); i++)
            {
                for (int j = 0; j < array_2.GetLength(1); j++)
                {
                    for (int k = 0; k < array_1.GetLength(1); k++)
                    {
                        result[i, j] += array_1[i, k] * array_2[k, j];
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// Считывает текст с файла(List)
        /// </summary>
        /// <returns></returns>
        static List<char> fileTextList()
        {
            string path = Environment.CurrentDirectory + @"\Text.txt";
            string fileText = File.ReadAllText(path);
            List<char> latters = new List<char>();
            for (int i = 0; i < fileText.Length; i++)
            {
                latters.Add(fileText[i]);
            }
            return latters;
        }
        /// <summary>
        /// Считывает текст с файла
        /// </summary>
        /// <returns></returns>
        static char[] fileText()
        {
            string path = Environment.CurrentDirectory + @"\Text.txt";
            string fileText = File.ReadAllText(path);
            char[] latters = new char[fileText.Length];
            for (int i = 0; i < fileText.Length; i++)
            {
                latters[i] = fileText[i];
            }
            return latters;
        }

        /// <summary>
        /// Считать среднее арифметическое(Dictionary)
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        static double[] AverageVolumDictionary(Dictionary<string, int[]> degrees)
        {
            double[] average = new double[12];
            for (int i = 0; i < degrees.Count; i++)
            {
                average[i] = Math.Round((double)degrees[((Mouths)i).ToString()].Sum() / 30, 3);
            }
            return average;
        }
        /// <summary>
        /// Считать среднее арифметическое
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        static double[] AverageVolum(int[,] array)
        {
            double[] average = new double[12];
            int sum = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    sum += array[i, j];
                }
                average[i] = Math.Round((double)sum / 30, 3);
                sum = 0;
            }
            return average;
        }


        /// <summary>
        /// Умножает матрицы
        /// </summary>
        /// <param name="array_1"></param>
        /// <param name="array_2"></param>
        /// <returns></returns>
        static int[,] MultiplicationArray(int[,] array_1, int[,] array_2)
        {
            int[,] result = new int[array_1.GetLength(0), array_2.GetLength(1)];
            for (int i = 0; i < array_1.GetLength(0); i++)
            {
                for (int j = 0; j < array_2.GetLength(1); j++)
                {
                    for (int k = 0; k < array_1.GetLength(1); k++)
                    {
                        result[i, j] += array_1[i, k] * array_2[k, j];
                    }
                }
            }
            return result;


        }
        /// <summary>
        /// Печатает матрицу
        /// </summary>
        /// <param name="array"></param>
        static void PrintArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Упражнение 6.1 число гласных и согласных букв в файле");
            char[] letters = fileText();
            string vowel = "aoeiuy";
            string consonant = "bcdfghjklmnpqrstvwxyz";
            int countVowel = 0;
            int countConsonanrt = 0;
            for (int i = 0; i < letters.Length; i++)
            {
                if (vowel.Contains(letters[i]))
                {
                    countVowel++;
                }
                else if (consonant.Contains(letters[i]))
                {
                    countConsonanrt++;
                }
            }
            Console.WriteLine($"Кол-во гласных - {countVowel}\nКол-во согласных - {countConsonanrt}");
            Console.ReadKey();


            Console.WriteLine("Упражнение 6.2 Умножение матриц");
            int[,] numbers = new int[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 6, 7, 8 }
            };
            int[,] numbers_1 = new int[,]
            {
                { 9, 2, 3 },
                { 4, 10, 0 },
                { 3, 7, 8 }
            };
            Console.WriteLine("Первая матрица:");
            PrintArray(numbers);
            Console.WriteLine("Вторая матрица:");
            PrintArray(numbers_1);
            Console.WriteLine($"Перемноженные матрицы:");
            PrintArray(MultiplicationArray(numbers, numbers_1));
            Console.ReadKey();

            Console.WriteLine("Упражнение 6.3 Метод вычисляет среднюю температуру");
            int[,] temperature = new int[12, 30];
            Random rand = new Random();
            for (int i = 0; i < temperature.GetLength(0); i++)
            {
                for (int j = 0; j < temperature.GetLength(1); j++)
                {
                    temperature[i, j] = rand.Next(-30, 30);
                }
            }
            PrintArray(temperature);
            double[] average = AverageVolum(temperature);
            for (int i = 0; i < 12; i++)
            {
                Console.WriteLine(($"{(Mouths)i} - {average[i]} градусов"));
            }
            Console.ReadKey();

            Console.WriteLine("Домашнее задание 6.1 Упражнение 6.1 выполнить с помощью коллекции List<T>");
            List<char> letters_1 = fileTextList();
            string vowel_1 = "aoeiuy";
            string consonant_1 = "bcdfghjklmnpqrstvwxyz";
            int countVowel_1 = 0;
            int countConsonanrt_1 = 0;
            for (int i = 0; i < letters_1.Count; i++)
            {
                if (vowel_1.Contains(letters_1[i]))
                {
                    countVowel_1++;
                }
                else if (consonant_1.Contains(letters_1[i]))
                {
                    countConsonanrt_1++;
                }
            }
            Console.WriteLine($"Кол-во гласных - {countVowel}\nКол-во согласных - {countConsonanrt}");
            Console.ReadKey();

            Console.WriteLine("Домашнее задание 6.2 Упражнение 6.2 выполнить с помощью коллекций LinkedList<LinkedList<T>>.");
            LinkedList<int[,]> arrayOfArrays = new LinkedList<int[,]>();
            int[,] numbers_3 = new int[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 6, 7, 8 }
            };
            int[,] numbers_4 = new int[,]
            {
                { 9, 2, 3 },
                { 4, 10, 0 },
                { 3, 7, 8 }
            };
            arrayOfArrays.AddFirst(numbers_3);
            arrayOfArrays.AddLast(numbers_4);
            Console.WriteLine("Первая матрица:");
            PrintArray(numbers_3);
            Console.WriteLine("Вторая матрица:");
            PrintArray(numbers_4);
            Console.WriteLine($"Перемноженные матрицы:");
            PrintArray(MultiplicationArrayLinkedList(arrayOfArrays));
            Console.ReadKey();





            Console.WriteLine("Домашнее задание 6.3 Написать программу для упражнения 6.3, использовав класс Dictionary<TKey, TValue>.");
            Dictionary<string, int[]> mouth = new Dictionary<string, int[]>();
            int[] temperature_1 = new int[30];
            Random rand_1 = new Random();
            for (int j = 0; j < 12; j++)
            {
                for (int i = 0; i < temperature_1.Length; i++)
                {
                    temperature_1[i] = rand_1.Next(-30, 30);
                }
                mouth.Add(((Mouths)j).ToString(), temperature_1);
                temperature_1 = new int[30];
            }

            foreach (var erty in mouth)
            {
                Console.WriteLine(erty.Key);
                for (int i = 0; i < 30; i++)
                {
                    Console.Write(erty.Value[i] + " ");
                }
                Console.WriteLine();
            }
            double[] array = AverageVolumDictionary(mouth);
            for (int i = 0; i < mouth.Count; i++)
            {
                Console.WriteLine($"Средняя темпиратура {(Mouths)i} - {array[i]}");
            }
            Console.ReadKey();
        }
    }
}