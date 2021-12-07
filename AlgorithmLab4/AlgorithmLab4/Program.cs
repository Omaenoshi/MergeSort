using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace AlgorithmLab4
{
    internal static class Program
    {
        private static readonly Dictionary<int, string> SortsName = new()
            {{1, "MergeSort"}, {2, "NaturalMergeSort"}, {3, "TripleMergeSort"}};

        static void Main(string[] args)
        {
            var fileLength = File.ReadLines("../../../Input.txt").Count();
            Console.WriteLine("Выберете метод сортировки:");
            foreach (var el in SortsName)
            {
                Console.WriteLine($"{el.Key} - {el.Value}");
            }

            var SortId = int.Parse((Console.ReadLine() ?? null) ?? throw new Exception("Uncorrectly input"));
            var sorter = ChooseSort(SortId);
            Console.WriteLine("Выберете по какому ключу сортировать");
            var answer = Console.ReadLine();
            PrintTable("Было:", ReadAndSplitTable("../../../Input.txt"));
            var res = Remove(ReadAndSplitTable("../../../Input.txt"), answer);
            PrintTable("Стало:", sorter.Sort(res));
        }

        static string[][] Remove(string[][] table, string attributeKey)
        {
            var result = new List<string[]>();

            for(var i = 0; i < table.Length; i++)
            {
                if (table[i][1].ToLower() == attributeKey.ToLower())
                    result.Add(table[i]);
            }

            return result.ToArray();
        }

        static void PrintTable(string message, string[][] currentArray)
        {
            Console.WriteLine(message);

            for (var i = 0; i < currentArray.Length; i++)
            {
                for (var j = 0; j < currentArray[i].Length; j++)
                    Console.Write(currentArray[i][j] + " ");
                Console.WriteLine("\n");
            }
        }

        static Sorter ChooseSort(int str)
        {
            return str switch
            {
                1 => new MergeSort(),
                2 => new NaturalMergeSort(),
                3 => new TripleMergeSort(),
                _ => throw new Exception("ERROR")
            };
        }

        private static string[][] ReadAndSplitTable(string path)
        {
            var table = File.ReadAllLines(path);
            var result = new string[table.Length][];

            for (var i = 0; i < table.Length; i++)
            {
                result[i] = table[i].Split();
            }

            return result;
        }
    }
}
