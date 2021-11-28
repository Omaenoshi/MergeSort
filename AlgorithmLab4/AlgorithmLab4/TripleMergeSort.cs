using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLab4
{
    internal class TripleMergeSort : Sorter
    {
        readonly int AttributeId = 4;
        public override string[][] Sort(string[][] elements)
        {
            int length = elements.Length;
            return MergeSortMethod(elements, 0, length - 1);
        }

        private string[][] MergeSortMethod(string[][] elements, int left, int right)
        {
            if (right - left < 2) return new string[][] { elements[left] };

            int firstStop = left + ((right - left) / 3);
            int secondStop = left + ((right - left) / 3) + 1;
            string[][] leftArray = MergeSortMethod(elements, left, firstStop);
            string[][] middleArray = MergeSortMethod(elements, firstStop, secondStop);
            string[][] rightArray = MergeSortMethod(elements, secondStop, right);
         
            return Merge(leftArray, middleArray, rightArray);
        }

        private string[][] Merge(string[][] leftArray, string[][] middleArray, string[][] rightArray)
        {
            int leftLen = leftArray.Length;
            int middleLen = middleArray.Length;
            int rightLen = rightArray.Length;

            string[][] target = new string[leftLen + middleLen + rightLen][];
            int targetPos = 0;
            int leftPos = 0;
            int middlePos = 0;
            int rightPos = 0;

            while (leftPos < leftLen && middlePos < middleLen && rightPos < rightLen)
            {
                string[] leftValue = leftArray[leftPos];
                string[] middleValue = middleArray[middlePos];
                string[] rightValue = rightArray[rightPos];

                if (int.Parse(leftValue[AttributeId]) <= int.Parse(middleValue[AttributeId]) && int.Parse(leftValue[AttributeId]) <= int.Parse(rightValue[AttributeId]))
                {
                    target[targetPos++] = leftValue;
                    leftPos++;
                }
                else if (int.Parse(middleValue[AttributeId]) <= int.Parse(leftValue[AttributeId]) && int.Parse(middleValue[AttributeId]) <= int.Parse(rightValue[AttributeId]))
                {
                    target[targetPos++] = middleValue;
                    middlePos++;
                }
                else
                {
                    target[targetPos++] = rightValue;
                    rightPos++;
                }
            }

            while(leftPos < leftLen && middlePos < middleLen)
            {
                string[] leftValue = leftArray[leftPos];
                string[] middleValue = middleArray[middlePos];

                if (int.Parse(leftValue[AttributeId]) < int.Parse(middleValue[AttributeId]))
                {
                    target[targetPos++] = leftValue;
                    leftPos++;
                }
                else
                {
                    target[targetPos++] = middleValue;
                    middlePos++;
                }                   
            }
            while (middlePos < middleLen && rightPos < rightLen)
            {
                string[] middleValue = middleArray[middlePos];
                string[] rightValue = rightArray[rightPos];

                if (int.Parse(middleValue[AttributeId]) < int.Parse(rightValue[AttributeId]))
                {
                    target[targetPos++] = middleValue;
                    middlePos++;
                }
                else
                {
                    target[targetPos++] = rightValue;
                    rightPos++;
                }
            }
            while (leftPos < leftLen && rightPos < rightLen)
            {
                string[] leftValue = leftArray[leftPos];
                string[] rightValue = rightArray[rightPos];

                if (int.Parse(leftValue[AttributeId]) < int.Parse(rightValue[AttributeId]))
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
                target[targetPos++] = leftArray[leftPos++];
            }
            while (middlePos < middleLen)
            {
                target[targetPos++] = middleArray[middlePos++];
            }
            while (rightPos < rightLen)
            {
                target[targetPos++] = rightArray[rightPos++];
            }

            return target;
        }
    }
}
