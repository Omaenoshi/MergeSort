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
            sorts.Add(2, "Natural MergeSort");
            sorts.Add(3, "Tripple MergeSort");
        }

        public Tuple<string, string> Ask()
        {
            Console.WriteLine("Выберете метод сортировки:");
            foreach (var e in sorts)
                Console.WriteLine(e.Key + " - " + e.Value);
            string sortId = Console.ReadLine();
            Console.WriteLine("Выберете ключевой атрибут");
            string attribute = Console.ReadLine();

            return Tuple.Create(sortId, attribute);
        }
    }
}
