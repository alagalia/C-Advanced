using System;
using System.Collections.Generic;

namespace LogsAggregator
{
    class LogsAggregator
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            SortedDictionary<string, User> infoByUserName = new SortedDictionary<string, User>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();


                string ip = input[0];
                string name = input[1];
                int duration = int.Parse(input[2]);

                if (!infoByUserName.ContainsKey(name))
                {
                    infoByUserName[name] = new User();
                    infoByUserName[name].Ip = new SortedSet<string>();
                    infoByUserName[name].Duration = 0;
                }

                if (!infoByUserName[name].Ip.Contains(ip))
                {
                    infoByUserName[name].Ip.Add(ip);                    
                }
                infoByUserName[name].Duration += duration;

            }

            foreach (var name in infoByUserName)
            {
                Console.Write(name.Key+": "); //имената
                Console.Write(name.Value.Duration+" ["); //потреблението на всеки юзър - общо
                string allIPAdress = string.Join(", ", name.Value.Ip);//IP адресите
                Console.WriteLine(allIPAdress+"]");
            }
        }
    }

    class User
    {

        public int Duration { get; set; }

        public SortedSet<string> Ip { get; set; }

    }
}
