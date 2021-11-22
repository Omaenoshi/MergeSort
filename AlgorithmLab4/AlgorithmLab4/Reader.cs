using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AlgorithmLab4
{
    internal class Reader
    {
        public string[][] ReadFile(string name)
        {          
            var lines = File.ReadLines($"../../../{name}").ToArray();
            string[][] result = new string[lines.Length][];

            for (var i = 0; i < lines.Length; i++)
            {                
                var middle = lines[i].Split();
                result[i] = middle;
            }

            return result;
        }
    }
}
