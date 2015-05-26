using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UppercaseWords
{
    class UppercaseWords
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"([a-zA-Z]+)|(\s|\W+|(\d+))*";
            Regex word = new Regex(pattern);

            while (input!="END")
            {                
                MatchCollection words = word.Matches(input);
                StringBuilder result = new StringBuilder();

                foreach (var item in words)
                {
                    string forAppend = item.ToString();
                    if (IsUpper(forAppend))
                    {
                        if (IsPalindrome(forAppend))
                        {
                            forAppend = DoubleEachLetters(forAppend);
                        }
                        else
                        {
                            forAppend= Reverse(forAppend);
                        }
                    }                
                        result.Append(forAppend);
                }
                Console.WriteLine(EscapeXmlString(result.ToString()));
                input = Console.ReadLine();
            }
        }
        public static bool IsUpper(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (!Char.IsUpper(input[i]))
                    return false;
            }
            return true;
        }

        public static string EscapeXmlString(string value)
        {
            return System.Security.SecurityElement.Escape(value);
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private static string DoubleEachLetters(string forAppend)
        {
            StringBuilder doubledString = new StringBuilder();
            for (int i = 0; i < forAppend.Length; i++)
            {
                char letter = forAppend[i];
                doubledString.Append(letter);
                doubledString.Append(letter);
            }
            return doubledString.ToString();
        }

        public static bool IsPalindrome(string value)
        {
            int min = 0;
            int max = value.Length - 1;
            while (true)
            {
                if (min > max)
                {
                    return true;
                }
                char a = value[min];
                char b = value[max];
                if (char.ToLower(a) != char.ToLower(b))
                {
                    return false;
                }
                min++;
                max--;
            }
        }
    }
}
