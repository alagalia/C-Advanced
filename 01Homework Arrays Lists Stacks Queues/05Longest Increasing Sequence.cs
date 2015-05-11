using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05Longest_Increasing_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = new List<int>(Console.ReadLine().Split().Select(int.Parse).ToList());
            List<int> max = new List<int>();
            List<int> temp = new List<int>();
            for (int startSeq = 0; startSeq < input.Count-1; startSeq++)
            {
                temp.Add(input[startSeq]);
                if (startSeq<input.Count-1)
                {
                    while (startSeq < input.Count - 1 && input[startSeq] < input[startSeq + 1])
                    {
                        temp.Add(input[startSeq + 1]);
                        startSeq++;
                    } 
                }
                                
                foreach (var element in temp)
                {
                    Console.Write(element+ " ");
                }
                Console.WriteLine();
                if (temp.Count>max.Count)
                {
                   max = temp.ToList();
                }
                temp.Clear();
            }
            Console.Write("Longest: ");
            foreach (var item in max)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
