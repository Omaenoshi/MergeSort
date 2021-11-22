using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLab4
{
    internal class Writer
    {
        Dictionary<int, string> sorts = new Dictionary<int, string>();

        public Writer()
        {
            sorts.Add(1, "MergeSort");
        }

        public void Ask()
        {
            Console.WriteLine("Выберете метод сортировки:");
            
        }
    }
}
