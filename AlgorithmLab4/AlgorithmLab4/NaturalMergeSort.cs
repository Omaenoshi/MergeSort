using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLab4
{
    internal class NaturalMergeSort
    {
        public string[][] Sort(string[][] elements)
        {
            int length = elements.Length;

            string[][] tmp = new string[length][];
            int[] starts = new int[length + 1];

            int runCount = 0;
            starts[0] = 0;
            for (var i = 1; i <= length; i++)
            {
                if (i == length || int.Parse(elements[i][4]) < int.Parse(elements[i - 1][4]))
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
                if (int.Parse(leftValue[4]) <= int.Parse(rightValue[4]))
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
