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
            StringBuilder start = new StringBuilder();

            string input = Console.ReadLine();
            while (input != "END")
            {
                start.Append(input);
                input = Console.ReadLine();
            }
            string text = start.ToString();

            //match groups №1 "name"  and №2"phone number"
            string nameAndPhonePattern = @"([A-Z][a-zA-Z]*)[^a-zA-Z\+]*?(?=\+|[0-9]{2})([0-9\+]{0,1}[0-9][0-9\/(). -]*[0-9])";

            MatchCollection machesNameAndPhone = Regex.Matches(text, nameAndPhonePattern);

            if (machesNameAndPhone.Count == 0)
            {
                Console.WriteLine("<p>No matches!</p>");
                return;
            }


            StringBuilder finalResult = new StringBuilder("<ol>");

            for (int i = 0; i < machesNameAndPhone.Count; i++)
            {
                string name = machesNameAndPhone[i].Groups[1].ToString();
                string telephone = machesNameAndPhone[i].Groups[2].ToString();

                telephone = telephone.Replace("(", "");
                telephone = telephone.Replace(")", "");
                telephone = telephone.Replace("/", "");
                telephone = telephone.Replace(".", "");
                telephone = telephone.Replace("-", "");
                telephone = telephone.Replace(" ", "");

                if (telephone == " " || telephone == "" || name == " " || name == "" || name[0] < 65 || name[0] > 90)
                {
                    continue;
                }
                else
                {
                    finalResult.Append("<li><b>" + machesNameAndPhone[i].Groups[1] + ":</b> " + telephone.Trim() + "</li>");
                }

            }

            finalResult.Append(("</ol>"));
            Console.WriteLine(finalResult.ToString());

        }
    }
}
