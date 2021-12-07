using System;
using System.IO;
using System.Net;

namespace AlgorithmLab4
{
    internal class NaturalMergeSort : Sorter
    {
        readonly int AttributeId = 4;
        private int currentFileSize;
        private string currentFileAdress;
        
        public void Sort(string fileName, int fileSize)
        {
            currentFileSize = fileSize;
            currentFileAdress = fileName;

            string[][] tmp = new string[currentFileSize][];
            int[] starts = new int[currentFileSize + 1];
            int runCount = 0;
            starts[0] = 0;
            for (var i = 1; i <= currentFileSize; i++)
            {
                var sr = new StreamReader(fileName);
                var value = sr.ReadLine().Split();
                sr.Close();
                if (i == currentFileSize || int.Parse(value[AttributeId]) < int.Parse(value[AttributeId]))
                    starts[++runCount] = i;
            }
            
            var sr1 = new StreamReader(fileName);
            var value1 = sr1.ReadLine().Split();
            string[] from = value1;
            string[][] to = tmp;

            while (runCount > 1)
            {
                int newRunCount = 0;
                for (var i = 0; i < runCount - 1; i += 2)
                {
                    starts[newRunCount++] = starts[i];
                }

                if (runCount % 2 == 1)
                {
                    int lastStart = starts[runCount - 1];
                    Array.Copy(from, lastStart, to, lastStart, currentFileSize - lastStart);
                    starts[newRunCount++] = lastStart;
                }

                starts[newRunCount] = currentFileSize;
                runCount = newRunCount;

                string[] help = from;
            }

            if (from != value1)
            {
                Array.Copy(from, 0, value1, 0, currentFileSize);
            }
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

        private void Merge(string source, string target, int startLeft, int startRight, int endRight)
        {
            int leftPos = startLeft;
            int rightPos = startRight;
            int targetPos = startLeft;
            StreamReader sr = new StreamReader(source);
            sr.Close();
            while(leftPos < startRight && rightPos < endRight)
            {
                string[] leftValue = sr.ReadLine().Split();
                string[] rightValue = sr.ReadLine().Split();
                if (int.Parse(leftValue[AttributeId]) <= int.Parse(rightValue[AttributeId]))
                {
                    target = WriteInFile(source, leftPos, rightPos);
                    leftPos++;
                }
                else
                {
                    target = WriteInFile(source, leftPos, rightPos);
                    rightPos++;
                }
            }

            while(leftPos < startRight)
            {
                target = WriteInFile(source, leftPos, rightPos);

            }
            while(rightPos < endRight)
            {
                target = WriteInFile(source, leftPos, rightPos);
            }
        }
        
        public override string[][] Sort(string[][] elements)
        {
            int length = elements.Length;

            string[][] tmp = new string[length][];
            int[] starts = new int[length + 1];
            int runCount = 0;
            starts[0] = 0;
            for (var i = 1; i <= length; i++)
            {
                if (i == length || int.Parse(elements[i][AttributeId]) < int.Parse(elements[i - 1][AttributeId]))
                    starts[++runCount] = i;
            }

            string[][] from = elements;
            string[][] to = tmp;

            while (runCount > 1)
            {
                int newRunCount = 0;
                for (var i = 0; i < runCount - 1; i += 2)
                {
                    Merge(from, to, starts[i], starts[i + 1], starts[i + 2]);
                    starts[newRunCount++] = starts[i];
                }

                if (runCount % 2 == 1)
                {
                    int lastStart = starts[runCount - 1];
                    Array.Copy(from, lastStart, to, lastStart, length - lastStart);
                    starts[newRunCount++] = lastStart;
                }

                starts[newRunCount] = length;
                runCount = newRunCount;

                string[][] help = from;
                from = to;
                to = help;
            }

            if (from != elements)
            {
                Array.Copy(from, 0, elements, 0, length);
            }

            return elements;
        }

        private void Merge(string[][] source, string[][] target, int startLeft, int startRight, int endRight)
        {
            int leftPos = startLeft;
            int rightPos = startRight;
            int targetPos = startLeft;

            while(leftPos < startRight && rightPos < endRight)
            {
                string[] leftValue = source[leftPos];
                string[] rightValue = source[rightPos];
                if (int.Parse(leftValue[AttributeId]) <= int.Parse(rightValue[AttributeId]))
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

            while(leftPos < startRight)
            {
                target[targetPos++] = source[leftPos++];

            }
            while(rightPos < endRight)
            {
                target[targetPos++] = source[rightPos++];
            }
        }
    }
}
