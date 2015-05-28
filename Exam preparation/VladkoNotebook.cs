using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VladkoNotebook
{
    class VladkoNotebook
    {
        
        static void Main(string[] args)
        {
            string entry = Console.ReadLine();
            Dictionary<string,Player>  pagesByColor= new Dictionary<string,Player>();
            while (entry!="END")
            {
                string[] data = entry.Split('|');
                string color = data[0];
                if (!pagesByColor.ContainsKey(color))
                {
                    pagesByColor[color] = new Player();
                    pagesByColor[color].Opponents = new List<string>();
                }
                switch (data[1])
                {
                    case "age":
                        pagesByColor[color].Age = int.Parse(data[2]); break;
                    case "name":
                        pagesByColor[color].Name = data[2]; break;
                    case "win":
                        pagesByColor[color].WinCount++;
                        pagesByColor[color].Opponents.Add((data[2]));
                        break;
                    case "loss":
                        pagesByColor[color].LostCount++;
                        pagesByColor[color].Opponents.Add(data[2]);
                        break;
                    default:
                        break;
                }
                entry = Console.ReadLine();
            }

            var validPages = pagesByColor
                .Where(p => p.Value.Age != 0)
                .Where(p =>p.Value.Name != null)
                .OrderBy(p => p.Key);
            if (validPages.Count()==0)
            {
                Console.WriteLine("No data recovered.");
                return;
            }

            StringBuilder outputPage = new StringBuilder();
            foreach (var page in validPages)
            {
                outputPage.AppendLine(string.Format("Color: {0}", page.Key));
                outputPage.AppendLine(string.Format("-age: {0}", page.Value.Age));
                outputPage.AppendLine(string.Format("-name: {0}", page.Value.Name));
                var allOpponent = page.Value.Opponents.OrderBy(o => o,StringComparer.Ordinal);
                string allOpponentAsString = string.Join(", ",allOpponent); 
                if (allOpponent.Count()==0)
                {
                    allOpponentAsString="(empty)";
                }
                outputPage.AppendLine(string.Format("-opponents: {0}", allOpponentAsString));
                //(wins+1) / (losses+1)
                double rank = (double)(page.Value.WinCount + 1) / (page.Value.LostCount + 1);
                outputPage.AppendLine(string.Format("-rank: {0:F2}", rank));
            }
            Console.WriteLine(outputPage.ToString());
              
        }
    }

        class Player
        {
            public string Name { get; set; }

            public int Age { get; set; }

            public List<string> Opponents { get; set; }

            public int WinCount { get; set; }

            public int LostCount { get; set; }

        }
    }
