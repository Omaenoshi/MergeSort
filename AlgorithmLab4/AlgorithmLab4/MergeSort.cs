using System;
using System.IO;
using System.Linq;
using System.Net;

namespace AlgorithmLab4
{
    internal class MergeSort : Sorter
    {
        readonly int AttributeId = 4;
        private int currentFileSize;
        private string currentFileAdress;
        
        public void Sort(string fileName, int fileSize)
        {
            currentFileSize = fileSize;
            currentFileAdress = fileName;
            MergeSortMethod(0, fileSize);
        }

        private void MergeSortMethod(int left, int right)
        {
            if (left == right) return;

            int middle = left + (right - left) / 2;

            string leftArray = WriteInFile("../../../B.txt", left, middle);
            string rightArray = WriteInFile("../../../C.txt", middle, right);
            Merge(leftArray, rightArray);
        }
        
        private string WriteInFile(string fileTo, int start, int end)
        {
            var sr = new StreamReader(currentFileAdress);
            var sw = new StreamWriter(fileTo);
            for (var i = 0; i < currentFileSize; i++)
            {
                var line = sr.ReadLine();

                if (i >= start && i < end)
                {
                    sw.WriteLine(line);
                }
            }
            sw.Close();

            return fileTo;
        }

        private string[] ReadOutFile(string fileFrom, int index)
        {
            var sr = new StreamReader(fileFrom);
            var size = File.ReadLines(fileFrom).Count();
            for (var i = 0; i < size; i++)
            {
                var line = sr.ReadLine();

                if (i == index)
                {
                    return line.Split();
                }
            }
            sr.Close();

            return ReadOutFile(fileFrom, index);
        }

        private string[][] Merge(string leftArray, string rightArray)
        {
            var leftLen = File.ReadLines(leftArray).Count();
            var rightLen = File.ReadLines(rightArray).Count();

            var target = new string[leftLen + rightLen][];
            var targetPos = 0;
            var leftPos = 0;
            var rightPos = 0;

            while(leftPos < leftLen && rightPos < rightLen)
            {
                StreamReader sr = new StreamReader(leftArray);
                string[] leftValue = sr.ReadLine().Split();
                sr.Close();
                StreamReader sr1 = new StreamReader(rightArray);
                string[] rightValue = sr.ReadLine().Split();
                sr.Close();

                if(int.Parse(leftValue[AttributeId]) <= int.Parse(rightValue[AttributeId]))
                {
                    target[targetPos++] = leftValue;
                    leftPos++;
                }
                else
                {
                    target[targetPos++] = rightValue;
                    rightPos++;
                }
            }

            while (leftPos < leftLen)
            {
                target[targetPos++] = ReadOutFile(leftArray, leftPos);
                leftPos++;
            }
            while (rightPos < rightLen)
            {
                target[targetPos++] = ReadOutFile(rightArray, rightPos);
                rightPos++;
            }

            return target;
        }
        
        
        private string[][] MergeSortMethod(string[][] elements, int left, int right)
        {
            if (left == right) return new string[][] {elements[left]};

            int middle = left + (right - left) / 2;

            string[][] leftArray = MergeSortMethod(elements, left, middle);
            string[][] rightArray = MergeSortMethod(elements, middle + 1, right);
            return Merge(leftArray, rightArray);
        }
        
        private string[][] Merge(string[][] leftArray, string[][] rightArray)
        {
            var leftLen = leftArray.Length;
            var rightLen = rightArray.Length;

            var target = new string[leftLen + rightLen][];
            var targetPos = 0;
            var leftPos = 0;
            var rightPos = 0;

            while(leftPos < leftLen && rightPos < rightLen)
            {
                string[] leftValue = leftArray[leftPos];
                Console.WriteLine("Записываем значение из 1-й половины файла А в файл В");
                string[] rightValue = rightArray[rightPos];
                Console.WriteLine("Записываем значение из 2-й половины файла А в файл С");
                
                if(int.Parse(leftValue[AttributeId]) <= int.Parse(rightValue[AttributeId]))
                {
                    target[targetPos++] = leftValue;
                    leftPos++;
                    Console.WriteLine("Сравниваем");
                }
                else
                {
                    target[targetPos++] = rightValue;
                    rightPos++;
                    Console.WriteLine("Сравниваем");
                }
            }

            while (leftPos < leftLen)
            {
                target[targetPos++] = leftArray[leftPos++];
                Console.WriteLine("Оставшиеся элементы из В скидываем в А");
            }
            while (rightPos < rightLen)
            {
                target[targetPos++] = rightArray[rightPos++];
                Console.WriteLine("Оставшиеся элементы из С скидываем в А");
            }

            return target;
        }
        
        public override string[][] Sort(string[][] elements)
        {
            var length = elements.Length;
            return MergeSortMethod(elements, 0, length - 1);
        }
    }
}
