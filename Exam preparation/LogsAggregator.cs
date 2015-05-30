using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsAggregator
{
    class LogsAggregator
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, User> infoByUserName = new Dictionary<string, User>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();


                string ip = input[0];
                string name = input[1];
                int duration = int.Parse(input[2]);

                if (!infoByUserName.ContainsKey(name))
                {
                    infoByUserName[name] = new User();
                    infoByUserName[name].Ip = new List<string>();
                    infoByUserName[name].Duration = 0;
                }

                if (!infoByUserName[name].Ip.Contains(ip))
                {
                    infoByUserName[name].Ip.Add(ip);                    
                }
                infoByUserName[name].Duration += duration;

            }
        }
    }

    class User
    {

        public int Duration { get; set; }

        public List<string> Ip { get; set; }

    }
}
