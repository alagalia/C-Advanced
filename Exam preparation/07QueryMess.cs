using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07QueryMess
{
    class QueryMess
    {
        static void Main(string[] args)
        {
            
            string pattern = @"\?|&|=";
            string input = Console.ReadLine();

            while (input!="END")
            {
                Regex reg1 = new Regex(pattern);
                List<string> str = Regex.Split(input, pattern).ToList();
                if (str.Count%2!=0) str.RemoveAt(0);
                string patternRemoveSpaces = @"^(\+|%20)|(\+|%20)$";
                Regex regRemoveSpaces = new Regex(patternRemoveSpaces);
                for (int i = 0; i < str.Count; i++)
                {
                     str[i]=Regex.Replace(str[i], patternRemoveSpaces, "");
                     str[i] = Regex.Replace(str[i], @"(\+|%20)", " ");
                     //str[i] = Regex.Replace(str[i], @"[ ]{2,}", " ");
                     str[i] = Regex.Replace(str[i].Trim(), @"\s+", " ");
                }
            
                var dict = new Dictionary<string, List<string>>();
                string key ="";
                string value="";
                for (int i = 0; i <str.Count-1; i+=2)
                {
                    key=str[i];
                    value=str[i+1];
                    if (!dict.ContainsKey(key))
                    {
                        dict.Add(key, new List<string>());
                        dict[key].Add(value);
                    }
                    else
                    {
                        dict[key].Add(value);
                    }
                }
                foreach (var item in dict)
                {
                    Console.Write(item.Key+"=["+ string.Join(", ", item.Value)+"]");
                }
                Console.WriteLine();
                input = Console.ReadLine();

            }
        }
    }
}
