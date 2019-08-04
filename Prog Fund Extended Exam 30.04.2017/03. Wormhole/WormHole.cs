namespace _03.Wormhole
{
    using System;
    using System.Linq;

    public class WormHole
    {
        public static void Main()
        {
            var inputArray = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var wormCurrlocation = 0;
            var stepsCount = 1;

            while (true)
            {
                if (wormCurrlocation == inputArray.Length - 1 && inputArray[inputArray.Length - 1] == 0)
                {
                    break;
                }

                if (inputArray[wormCurrlocation] == 0)
                {
                    wormCurrlocation++;
                    stepsCount++;
                }

                else
                {
                    var oldPlace = wormCurrlocation;
                    wormCurrlocation = inputArray[wormCurrlocation];
                    inputArray[oldPlace] = 0;
                }
            }

            Console.WriteLine(stepsCount);
        }
    }
}
