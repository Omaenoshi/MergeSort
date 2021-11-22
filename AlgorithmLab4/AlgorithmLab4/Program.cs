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
            TrippleMergeSort(table, 0, table.Length - 1);
        }

        static void MergeSort(string[][] currentArr, int start, int end)
        {
            if (start >= end) return;

            int middle = (start + end) / 2;

            MergeSort(currentArr, start, middle);
            MergeSort(currentArr, middle + 1, end);
            Merge(currentArr, start, middle, end);
        }

        static void Merge(string[][] currentArr, int start, int middle, int end)
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

        static void Natural(string[][] sequence)     //Естественное слияние
        {
            if (sequence.Length < 0)
                return;
            int start = 0;
            int stop1 = getNextStop(start, sequence);
            int stop2;
            for (; stop1 < sequence.Length; stop1++)
            {
                stop2 = getNextStop(stop1 + 1, sequence);
                MergeForNatural(sequence, start, stop1, stop2);
                stop1 = stop2;
            }
        }

        static void MergeForNatural(string[][] sequence, int start, int stop1, int stop2)
        {
            string[][] temp = new string[stop1][];
            string[][] tem = new string[stop2][];
            int i = 0;
            for (int k = start; k < stop1; k++)
                temp[i] = sequence[k];
            i = start;
            int j = stop1 + 1;
            for (int k = start; k <= stop2; k++)
            {
                if (i > stop1)
                    break;
                else if (j > stop2)
                {
                    sequence[k] = temp[i];
                    i++;
                }
                else if (temp.Length != 0 && int.Parse(temp[i][4]) > int.Parse(sequence[j][4]))
                {
                    sequence[k] = sequence[j];
                    j++;
                }
                else if (temp.Length != 0)
                {
                    sequence[k] = temp[i];
                    i++;
                }
                if ( i == tem.Length)
                    tem[i-1] = sequence[k];
                else
                    tem[i] = sequence[k];
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
