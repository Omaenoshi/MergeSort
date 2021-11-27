namespace AlgorithmLab4
{
    internal class MergeSort
    {
        public string[][] Sort(string[][] elements)
        {
            int length = elements.Length;
            return MergeSortMethod(elements, 0, length - 1);
        }

        private string[][] MergeSortMethod(string[][] elements, int left, int right)
        {
            if (left == right) return new string[][] { elements[left]};

            int middle = left + (right - left) / 2;
            string[][] leftArray = MergeSortMethod(elements, left, middle);
            string[][] rightArray = MergeSortMethod(elements, middle + 1, right);

            return Merge(leftArray, rightArray);
        }

        private string[][] Merge(string[][] leftArray, string[][] rightArray)
        {
            int leftLen = leftArray.Length;
            int rightLen = rightArray.Length;

            string[][] target = new string[leftLen + rightLen][];
            int targetPos = 0;
            int leftPos = 0;
            int rightPos = 0;

            while(leftPos < leftLen && rightPos < rightLen)
            {
                string[] leftValue = leftArray[leftPos];
                string[] rightValue = rightArray[rightPos];

                if(int.Parse(leftValue[4]) <= int.Parse(rightValue[4]))
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
            while (rightPos < rightLen)
            {
                target[targetPos++] = rightArray[rightPos++];
            }

            return target;
        }
    }
}
