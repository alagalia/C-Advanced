using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders
{
    class Orders
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            Dictionary<string, SortedDictionary<string, int>> allInfo = new Dictionary<string, SortedDictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();


                string coustumer = input[0];
                int amount  = int.Parse(input[1]);
                string product = input[2];


                if (!allInfo.ContainsKey(product))
                {
                    SortedDictionary<string, int> coustumersAmount = new SortedDictionary<string, int>();
                    coustumersAmount[coustumer]=amount;
                    allInfo[product] = coustumersAmount;
                }

                else if (!allInfo[product].ContainsKey(coustumer))
                {
                    allInfo[product][coustumer] = amount;
                }

                else
                {
                    allInfo[product][coustumer] += amount; ;
                }
            }
        }
    }
}
