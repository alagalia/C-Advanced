using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Write a program that reads a text file and inserts line numbers in front of each of its lines. The result should be written to another text file. Use StreamReader in combination with */
namespace _02LineNumbers
{
    class LineNumbers
    {
        static void Main(string[] args)
        {
            StreamReader inputStream = new StreamReader(@"..\..\..\text.txt");
            StreamWriter outputStream = new StreamWriter(@"..\..\..\numberedCopy.txt");
            using (inputStream)
            {
                using (outputStream)
                {
                    string line = inputStream.ReadLine();
                    int counter =0;
                    while (line!=null)
                    {
                        outputStream.WriteLine("{0} "+line,counter);
                        line = inputStream.ReadLine();
                        counter++;
                    }
                }
            }

        }
    }
}
