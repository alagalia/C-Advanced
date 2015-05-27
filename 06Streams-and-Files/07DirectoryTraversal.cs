using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Traverse a given directory for all files with the given extension. Search through the first level of the directory only and write information about each found file in report.txt.*/
namespace _07DirectoryTraversal
{
    class DirectoryTraversal
    {
        static void Main(string[] args)
        {
            Dictionary<string, SortedDictionary<string, double>> extentionNameBytes = new Dictionary<string, SortedDictionary<string, double>>();
            string[] filePaths = Directory.GetFiles("../../");

            for (int i = 0; i < filePaths.Length; i++)
            {
               string extention = Path.GetExtension(filePaths[i]);
               string fileName = Path.GetFileName(filePaths[i]);
               double bytes = filePaths[i].Length;
               if (!extentionNameBytes.ContainsKey(extention))
               {
                   extentionNameBytes.Add(extention, new SortedDictionary<string, double> { { fileName, bytes } });
               }
               else
               {
                  extentionNameBytes[extention].Add(fileName, bytes);
               }
            }


            StreamWriter outputStream = new StreamWriter(@"../../txtFileWithDirectories.txt");
            using (outputStream)
            {
                foreach (var item in extentionNameBytes)
                {
                    //Console.WriteLine(item.Key);
                    outputStream.WriteLine(item.Key);
                    foreach (var item1 in item.Value)
                    {
                        //Console.WriteLine(item1.Key+ " =>" + item1.Value);
                        outputStream.WriteLine("--" + item1.Key + " - " + item1.Value + "kb\n");

                    }
                }
            }
        }
    }
}
