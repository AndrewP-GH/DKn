using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_Self_organizingFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> dict = File.ReadAllLines("Data.txt").Select(line =>
            {
                var parts = line.Split('-');
                return new KeyValuePair<int, string>(Convert.ToInt32(parts.First()), parts.Last().Trim());
            }) as Dictionary<int, string>;
            if (dict == null)
                throw new Exception("Все плохо.");


        }
    }
}

