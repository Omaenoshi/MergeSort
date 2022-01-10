using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sort
{
    public static class Sort
    {
        public static int[] BubbleSort(int[] array)
        {
            for (var i = array.Length - 1; i >= 0; i--)
            {
                for (var j = 0; j < i; j++)
                {
                    if (array[j + 1] < array[j])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }

            return array;
        }

        public static int[] InsertionSort(int[] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                var key = array[i];

                for (var j = i - 1; j >= 0 && array[j] > key; j--)
                {
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }

            return array;
        }

        public static int[] SelectionSort(int[] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                var min = array[i];
                var selectedIndex = i;

                for (var j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < min)
                    {
                        min = array[j];
                        selectedIndex = j;
                    }
                }

                array[selectedIndex] = array[i];
                array[i] = min;
            }

            return array;
        }

        public static int[] ShakerSort(int[] array)
        {
            var left = 0;
            var right = array.Length - 1;

            while (left < right)
            {
                for (var i = left; i < right; i++)
                {
                    if (array[i + 1] < array[i])
                        (array[i], array[i + 1]) = (array[i + 1], array[i]);
                }

                right--;

                for (var j = right; j > left; j--)
                {
                    if (array[j - 1] > array[j])
                        (array[j], array[j - 1]) = (array[j - 1], array[j]);
                }

                left++;
            }

            return array;
        }

        public static int[] ShellSort(int[] array)
        {
            var length = array.Length;
            var step = length / 2;

            while (step > 0)
            {
                for (var i = 0; i < (length - step); i++)
                {
                    for (var j = i; j >= 0 && array[j] > array[j + step]; j -= step)
                        (array[j], array[j + step]) = (array[j + step], array[j]);
                }

                step /= 2;
            }

            return array;
        }

        public static int BinarySearch(int value, int[] array)
        {
            var start = 0;
            var end = array.Length - 1;

            while (start <= end)
            {
                var middle = (start + end) / 2;

                if (value == array[middle])
                    return middle;
                if (value < array[middle])
                    end = middle - 1;
                else
                    start = middle + 1;
            }

            return -1;
        }

        public static int[] QuickSort(int[] array, int startIndex, int endIndex)
        {
            var i = startIndex;
            var j = endIndex;
            var pivot = array[(startIndex + endIndex) / 2];
            while (i <= j)
            {
                while (array[i] < pivot) i++;
                while (array[j] > pivot) j--;

                if (i > j) continue;
                (array[i], array[j]) = (array[j], array[i]);
                i++;
                j--;
            }

            if (startIndex < j)
                QuickSort(array, startIndex, j);
            if (endIndex > i)
                QuickSort(array, i, endIndex);

            return array;
        }

        public static int[] RadixSort(int[] array)
        {
            var temporary = new List<int>[10];
            temporary = temporary.Select(x => x = new List<int>()).ToArray();
            var width = array.Max().ToString().Length;

            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < array.Length; j++)
                {
                    var number = array[j] % (int) Math.Pow(10, i + 1) / (int) Math.Pow(10, i);
                    temporary[number].Add(array[j]);
                }

                array = Convert(temporary);
                temporary = new List<int>[temporary.Length];
                temporary = temporary.Select(x => x = new List<int>()).ToArray();
            }

            return array;
        }

        public static int[] TreeSort(int[] array)
        {
            var root = new Vertex(array[0]);
            
            for (var i = 1; i < array.Length; i++)
                root.Insert(array[i]);

            return root.Parse(new List<int>());
        }
        
        private static int[] Convert(List<int>[] from)
        {
            var result = new List<int>();
            foreach (var item in @from)
            {
                for (var j = 0; j < item.Count; j++)
                {
                    result.Add(item[j]);
                }
            }

            return result.ToArray();
        }
        public class MergeSort
        {
            private string A = "../../../A.txt";
            private string B = "../../../B.txt";
            private string C = "../../../C.txt";

            public void MergeSorting(string path)
            {
                var length = 0;
                using(var sr = new StreamReader(path)) 
                {
                    while (sr.ReadLine() is not null)
                        length++;
                }
                
                var count = (int)Math.Ceiling(Math.Log2(length));

                for (var i = 0; i < count; i++)
                {
                    ReadFromFile((int) Math.Pow(2, i));
                }
                
            }

            public void ReadFromFile(int width)
            {
                var writerB = new StreamWriter(B);
                var writerC = new StreamWriter(C);

                var index = 0;
                var writtenToB = false;
                
                using (var reader = new StreamReader(A))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        if (index % width == 0)
                            writtenToB = !writtenToB;
                    
                        if (writtenToB)
                            writerB.WriteLine(line);
                        else
                        {
                            writerC.WriteLine(line);
                        }

                        index++;
                        line = reader.ReadLine();
                    }
                }
                
                writerB.Close();
                writerC.Close();
                WriteInFile(A, width);
            }

            private void WriteInFile(string pathTo, int width)
            {
                File.Create(pathTo).Dispose();

                using (var writer = new StreamWriter(pathTo))
                {
                    var readerB = new StreamReader(B);
                    var readerC = new StreamReader(C);

                    while (!readerB.EndOfStream || !readerC.EndOfStream)
                    {
                        Merge(readerB, readerC, writer, width);
                    }
                    
                    readerB.Dispose();
                    readerC.Dispose();
                }
            }

            private void Merge(StreamReader path1, StreamReader path2, StreamWriter pathTo, int width)
            {
                var indexB = 0;
                var indexC = 0;
                var lineB = path1.ReadLine();
                var lineC = path2.ReadLine();
                while ((indexB < width || indexC < width) && (lineB != null || lineC != null))
                {
                    int compare;
                    if (lineB == null) compare = 1;
                    else if (lineC == null) compare = -1;
                    else compare = int.Parse(lineB).CompareTo(int.Parse(lineC));

                    if (compare < 0 || compare == 0)
                    {
                        pathTo.WriteLine(lineB);
                        indexB++;
                        lineB = indexB >= width ? null : path1.ReadLine();
                    }
                    if (compare > 0 || compare == 0)
                    {
                        pathTo.WriteLine(lineC);
                        indexC++;
                        lineC = indexC >= width ? null : path2.ReadLine();
                    }
                }
            }
        }
    }
}