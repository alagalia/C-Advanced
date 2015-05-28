using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleJohn
{
    class LittleJohn
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 4; i++)
            {
              sb.AppendFormat(" {0}",Console.ReadLine());
               
            }

            string arrowPattern = @"(>>>----->>)|(>>----->)|(>----->)";
            Regex arrowsMacher= new Regex(arrowPattern);
            var arrows = arrowsMacher.Matches(sb.ToString());

            int arrowLargeCount = 0;
            int arrowMedCount = 0;
            int arrowSmallCount = 0;

            foreach (Match arrow in arrows)
            {
                if (!string.IsNullOrEmpty(arrow.Groups[1].Value))
                {
                    arrowLargeCount++;
                }
                if (!string.IsNullOrEmpty(arrow.Groups[2].Value))
                {
                    arrowMedCount++;
                }
                if (!string.IsNullOrEmpty(arrow.Groups[3].Value))
                {
                    arrowSmallCount++;
                }
            }
            string concateAsString = string.Format("{0}{1}{2}", arrowSmallCount, arrowMedCount, arrowLargeCount);
            long number = long.Parse(concateAsString);
            string binaryNum = Convert.ToString(number, 2);

            string reversBinaryNum = new string(binaryNum.Reverse().ToArray());

            string resultAsBinnaryConcate = binaryNum + reversBinaryNum;

            long result = Convert.ToInt64(resultAsBinnaryConcate, 2);
            Console.WriteLine(result);
        }
    }
}
