using System;
using System.Collections.Generic;

namespace AlgorithmLab4
{
    internal class Program
    {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
        static string[][] result;
        
        static void Main(string[] args)
        {
            string[][] table;
            Reader rd = new Reader();
            table = rd.ReadFile("Input.txt");
            Writer wr = new Writer();
            Tuple<string, string> answers = wr.Ask();
            var removedTable = Remove(table, answers.Item2);
            Console.Clear();
            PrintTable("Было:", table);
            Sorter sorter = ChooseSort(answers.Item1);
            result = sorter.Sort(removedTable);
            PrintTable("Стало:", result);
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

        static Sorter ChooseSort(string str)
        {
            switch(str)
            {
                case "1":
                    return new MergeSort();
                case "2":
                    return new NaturalMergeSort();
                case "3":
                    return new TripleMergeSort();
                default:
                    throw new Exception("ERROR");
            }
        }
    }
}
