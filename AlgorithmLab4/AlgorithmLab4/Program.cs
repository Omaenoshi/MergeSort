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
            //MergeSort(table, 0, table.Length - 1);
            //TrippleMergeSort(table, 0, table.Length - 1);

            NaturalMergeSort sorter = new NaturalMergeSort();
            result = sorter.Sort(table);
        }

        static void MergeSort1(string[][] currentArr, int start, int end)
        {
            if (start >= end) return;

            int middle = (start + end) / 2;

            MergeSort1(currentArr, start, middle);
            MergeSort1(currentArr, middle + 1, end);
            Merge1(currentArr, start, middle, end);
        }

        static void Merge1(string[][] currentArr, int start, int middle, int end)
        {
            int n1 = middle - start + 1;
            int n2 = end - middle;

            string[][] L = new string[n1][];
            string[][] M = new string[n2][];
            int i, j, k;
            i = j = 0;
            for (i = 0; i < n1; i++)
                L[i] = currentArr[start + i];
            for (j = 0; j < n2; j++)
                M[j] = currentArr[middle + 1 + j];

            
            i = 0;
            j = 0;
            k = start;

            while (i < n1 && j < n2)
            {
                if (int.Parse(L[i][4]) <= int.Parse(M[j][4]))
                {
                    currentArr[k] = L[i];
                    i++;
                }
                else
                {
                    currentArr[k] = M[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                currentArr[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                currentArr[k] = M[j];
                j++;
                k++;
            }

            result = currentArr;
        }

        static void TrippleMergeSort(string[][] currentArr, int start, int end)
        {
            if (start >= end) return;

            int stop1 = (start + end) / 3;
            int stop2 = stop1 * 2;

            TrippleMergeSort(currentArr, start, stop1);
            TrippleMergeSort(currentArr, stop1 + 1, stop2);
            TrippleMergeSort(currentArr, stop2 + 1, end);
            TrippleMerge(currentArr, start, stop1, stop2, end);
        }

        static void TrippleMerge(string[][] currentArr, int start, int stop1, int stop2, int end)
        {
            int n1 = stop1 - start + 1;
            int n2 = stop2 - stop1 + 1;
            int n3 = end - stop2;

            string[][] L = new string[n1][];
            string[][] M = new string[n2][];
            string[][] X = new string[n3][];

            int i, j, d, k;
            i = j = d =  0;
            for (i = 0; i < n1; i++)
                L[i] = currentArr[start + i];
            for (j = 0; j < n2; j++)
                M[j] = currentArr[stop1 + j];
            for (d = 0; d < n3; d++)
                X[d] = currentArr[stop2 + 1 + d];


            i = 0;
            j = 0;
            d = 0;
            k = start;

            while (i < n1 && j < n2 && d < n3)
            {
                if (int.Parse(L[i][4]) <= int.Parse(M[j][4]))
                {
                    currentArr[k] = L[i];
                    i++;
                }
                else if (int.Parse(M[j][4]) <= int.Parse(X[d][4]))
                {
                    currentArr[k] = M[j];
                    j++;
                }
                else
                {
                    currentArr[k] = X[d];
                    d++;
                }
                k++;
            }

            k--;

            while (i < n1)
            {
                currentArr[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                currentArr[k] = M[j];
                j++;
                k++;
            }

            while (d < n3)
            {
                currentArr[k] = X[d];
                d++;
                k++;
            }

            result = currentArr;
        }

        static void NaturalMergeSort(string[][] currentArr)     //Естественное слияние
        {
            int length = currentArr.Length;

            string[][] tmp = new string[length][];
            int[] starts = new int[length + 1];

            int runCount = 0;
            starts[0] = 0;
            for(var i = 1; i <= length; i++)
            {
                if (i == length || int.Parse(currentArr[i][4]) < int.Parse(currentArr[i - 1][4]))
                    starts[++runCount] = i;
            }

            string[][] from = currentArr;
            string[][] to = tmp;

            while(runCount > 1)
            {
                int newRunCount = 0;
                for (var i = 0; i < runCount - 1; i +=2)
                {
                    
                }
            }
        }
        

        static int getNextStop(int i, string[][] sequence)
        {
            if (i == sequence.Length)
                return i - 1;
            for (; i < sequence.Length && int.Parse(sequence[i][4]) < int.Parse(sequence[i + 1][4]);) 
                i++;
            return i;
        }



    }
}
