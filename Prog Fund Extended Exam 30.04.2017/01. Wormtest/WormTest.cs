namespace _01.Wormtest
{
    using System;

    public class WormTest
    {
        public static void Main()
        {
            var wormsLengthInMeters = double.Parse(Console.ReadLine());
            var wormsWidthInCentimeters = double.Parse(Console.ReadLine());

            var wormsLengthInCentimeters = wormsLengthInMeters * 100;

            var remainder = wormsLengthInCentimeters % wormsWidthInCentimeters;

            double result = 0;

            if (remainder == 0 || wormsWidthInCentimeters == 0)
            {
                result = wormsLengthInCentimeters * wormsWidthInCentimeters;

                Console.WriteLine($"{result:f2}");
            }

            else 
            {
                result = wormsLengthInCentimeters / wormsWidthInCentimeters * 100;

                Console.WriteLine($"{result:f2}%");
            }
        }
    }
}
