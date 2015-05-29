using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticHTML
{
    class SemanticHTML
    {
        static void Main(string[] args)
        {
            string row = Console.ReadLine();
            string openTagPattern = @"\n*(?<spaces>\s*)<div(?<before>.*)(?:id|class)\s*=\s*""(?<tag>\w+)""(?<after>.*)>";//отделяме таг-а (група 2), отделяме преди атрибута(група 1), отделяме след атрибута id="header" (група 3)

            string closeTagPatern = @"\n*(\s*)<\/div>\s*<!--\s*(\w+)\s*-->";

            while (row != "END")
            {
                if (Regex.IsMatch(row, openTagPattern))
                {
                    var match = Regex.Match(row, openTagPattern);
                    string whiteSpaces = match.Groups[1].Value;
                    string tagname = match.Groups[3].Value.Trim();
                    string before = " " + match.Groups[2].Value.Trim();
                    string after = " " + match.Groups[4].Value.Trim();
                    if (before == " ")
                    {
                        before = "";
                    }
                    if (after == " ")
                    {
                        after = "";
                    }
                    string result = "<" + tagname + before + after + ">";
                    string clearResult = Regex.Replace(result, @"\s+", " ");
                    Console.WriteLine(whiteSpaces + clearResult);
                }
                else if (Regex.IsMatch(row, closeTagPatern))
                {
                    var match = Regex.Match(row, closeTagPatern);
                    string whiteSpaces = match.Groups[1].Value;
                    string tagname = match.Groups[2].Value;
                    string result = "</" + tagname.Trim() + ">";
                    string clearResult = Regex.Replace(result, @"\s+", " ");
                    Console.WriteLine(whiteSpaces + result);
                }
                else
                {
                    Console.WriteLine(row);
                }

                row = Console.ReadLine();
            }
        }
    }
}