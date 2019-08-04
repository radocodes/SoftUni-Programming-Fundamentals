namespace _02.Worm_Ipsum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class WormIpsum
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            while (input != "Worm Ipsum")
            {
                var inputSentence = input.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                var ModyfiedWords = new List<string>();

                if (inputSentence.Count == 1)
                {
                    var WordList = inputSentence[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                    foreach (var word in WordList)
                    {
                        var isNotWord = Regex.Match(word, @".\d+.");

                        if (!isNotWord.Success)
                        {
                            if (word.Length > 1)
                            {
                                var countOccurence = 0;
                                var bestOccurence = ' ';

                                for (int i = 0; i < word.Length - 1; i++)
                                {
                                    var currCountOccurence = 0;

                                    for (int b = i + 1; b < word.Length; b++)
                                    {
                                        if (word[i] == word[b])
                                        {
                                            currCountOccurence++;
                                        }
                                    }

                                    if (currCountOccurence > countOccurence)
                                    {
                                        countOccurence = currCountOccurence;
                                        bestOccurence = word[i];
                                    }
                                }

                                if (countOccurence > 0)
                                {
                                    var currModifiedword = new string(bestOccurence, word.Length);
                                    ModyfiedWords.Add(currModifiedword);
                                }

                                else
                                {
                                    ModyfiedWords.Add(word);
                                }
                            }

                            else
                            {
                                ModyfiedWords.Add(word);
                            }
                        }

                        else
                        {
                            ModyfiedWords.Add(word);
                        }
                    }

                    ModyfiedWords[ModyfiedWords.Count - 1] = ModyfiedWords[ModyfiedWords.Count - 1] + ".";

                    var resultString = string.Join(" ", ModyfiedWords);

                    Console.WriteLine(resultString);
                }

                input = Console.ReadLine();
            }
        }
    }
}
