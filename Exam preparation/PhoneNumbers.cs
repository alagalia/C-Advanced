using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumbers
{
    class PhoneNumbers
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"[^\+\d\[A-Za-z]"; //match all chars without name and phone number
            StringBuilder finalResult = new StringBuilder("<ol>");
            bool checkForMatches = false; //if there aren`t matches -> print "<p>No matches!</p>"

            while (input != "END")
            {
                //replease all char, without name and phone number with " " and then replease all whitespaces with " "
                string cleared = Regex.Replace(input, pattern, " ").Trim();
                string cleartByWhiteSpaces = Regex.Replace(cleared, @"\s+", " ");

                //match groups №1 "name"  and №2"phone number"
                string nameAndPhonePattern = @"([A-z]+)((?:\+*\d*\s*)+)";
                MatchCollection machesNameAndPhone = Regex.Matches(cleartByWhiteSpaces, nameAndPhonePattern);

                for (int i = 0; i < machesNameAndPhone.Count; i++)
                {
                    string name = machesNameAndPhone[i].Groups[1].ToString();
                    string telephone = RemoveSpace(machesNameAndPhone[i].Groups[2].ToString());

                    if (telephone == " " || telephone == "" || name == " " || name == "" || name[0] < 65 || name[0] > 90)
                    {
                        continue;
                    }
                    else
                    {
                        finalResult.Append("<li><b>" + machesNameAndPhone[i].Groups[1] + ":</b> " + telephone.Trim() + "</li>");
                        checkForMatches = true;
                    }
                }

                input = Console.ReadLine();
            }
            if (!checkForMatches)
            {
                Console.WriteLine("<p>No matches!</p>");
                return;
            }
            else
            {
                finalResult.Append(("</ol>"));
                Console.WriteLine(finalResult);
            }

        }



        private static bool CheckIfHasMaches(MatchCollection machesNameAndPhone)
        {
            bool checkName = false;
            bool checkPhone = false;
            for (int i = 0; i < machesNameAndPhone.Count; i++)
            {
                if (machesNameAndPhone[i].Groups[1].ToString() != "")
                {
                    checkName = true;
                }
                if (machesNameAndPhone[i].Groups[2].ToString() != "")
                {
                    checkName = true;
                }
            }
            return (checkName && checkPhone);
        }

        private static string RemoveSpace(string value)
        {
            return Regex.Replace(value, @"\s+", "");
        }
    }
}
