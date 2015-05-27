using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
             StreamReader streamforRead = new StreamReader("text.txt");
            using (streamforRead)
            {
                string line = streamforRead.ReadLine();
                int counter = 0;
                while (line!=null)
                {
                    if (counter%2!=0)
                    {
                        Console.WriteLine(line);
                    }
                    counter++;
                    line = streamforRead.ReadLine();
                }
            }
        }
    }
}
