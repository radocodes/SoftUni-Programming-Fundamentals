namespace _04.Worms_World_Party
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class WormsWorldParty
    {
        public static void Main()
        {
            var inputStore = new Dictionary<string, Dictionary<string, long>>();

            var input = Console.ReadLine();

            while (input != "quit")
            {
                var inputParams = input.Split(new[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
                var teamName = inputParams[1].TrimStart().TrimEnd();
                var wormName = inputParams[0].TrimStart().TrimEnd();
                var wormScore = long.Parse(inputParams[2].TrimStart().TrimEnd());

                if (!inputStore.ContainsKey(teamName))
                {
                    inputStore[teamName] = new Dictionary<string, long>();
                }

                var containsName = true;

                foreach (var team in inputStore.Values)
                {
                    if (team.ContainsKey(wormName))
                    {
                        containsName = false;
                        break;
                    }
                }

                if (containsName)
                {
                    inputStore[teamName][wormName] = wormScore;
                }

                input = Console.ReadLine();
            }

            inputStore = inputStore
                .OrderByDescending(x => x.Value.Values.Sum())
                .ThenByDescending(x => x.Value.Values.Sum() / x.Value.Count)
                .ToDictionary(x => x.Key, x => x.Value);

            var count = 1;

            foreach (var kvp in inputStore)
            {
                Console.WriteLine($"{count}. Team: {kvp.Key} - {kvp.Value.Values.Sum()}");

                var currTeam = kvp.Value.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

                foreach (var person in currTeam)
                {
                    Console.WriteLine($"###{person.Key} : {person.Value}");
                }

                count++;
            }
        }
    }
}
