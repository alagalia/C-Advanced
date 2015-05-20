using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03WordCount
{
    class WordCount
    {
        static void Main(string[] args)
        {
            StreamReader imputWordsStream = new StreamReader("words.txt");
            StreamReader inputTextStream = new StreamReader("text.txt");
            StreamWriter outputResultStream = new StreamWriter("result.txt");
            List<string> wordsAsList = new List<string>();
            SortedDictionary<int, string> dictionaryCounterAndMachedWord = new SortedDictionary<int, string>();

            using (imputWordsStream)
            {
                string word = imputWordsStream.ReadLine();
                while (word!=null)
                {
                    wordsAsList.Add(word);
                    word = imputWordsStream.ReadLine();
                }
                
                using (inputTextStream)
                {
                    string text = inputTextStream.ReadToEnd().ToLower();
                    for (int i = 0; i < wordsAsList.Count; i++)
                    {
                        int count = ChechForWord(wordsAsList[i],text);
                        if (count>0)
                        {
                            dictionaryCounterAndMachedWord.Add(count, wordsAsList[i]);
                        }
                    }  

                    using (outputResultStream)
                    {
                        foreach (var item in dictionaryCounterAndMachedWord.Reverse())
                        {
                            string machesForOutput = item.Value+ " - " + item.Key;
                            outputResultStream.WriteLine(machesForOutput);
                        }
                    }
                }
                
                
            }
            
        }
       static int ChechForWord(string word, string text)
        {
           string pattern = @"\b"+word+"\\b";
           Regex reg = new Regex(pattern);
           MatchCollection allMaches = reg.Matches(text);
           int counter = allMaches.Count;
           return counter;
        }
    }
}
