internal class Program
{
    // C, M, Y, K Represents the amount of ink units in the line (printer)
    // C + M + Y + K != 1000000
    private static void Main(string[] args)
    {
        string[] lines = System.IO.File.ReadAllLines(@"./SampleInput.txt");
        int numberOfTestcases = int.Parse(lines[0]);
        lines = lines.Where((source, index) => index != 0).ToArray();

        int requiredNumberOfUnits = 1000000;

        for (int i = 0; i < numberOfTestcases; i++)
        {
            string output = String.Empty;

            List<long> printerOneValues = lines[i].Split(' ').Select(x => long.Parse(x)).ToList();
            List<long> printerTwoValues = lines[i + 1].Split(' ').Select(x => long.Parse(x)).ToList();
            List<long> printerThreeValues = lines[i + 2].Split(' ').Select(x => long.Parse(x)).ToList();
            lines = lines.Where((source, index) => index >= 2).ToArray();

            long maxCUnits = (new List<long>() { printerOneValues[0], printerTwoValues[0], printerThreeValues[0] }).Min();
            long maxMUnits = (new List<long>() { printerOneValues[1], printerTwoValues[1], printerThreeValues[1] }).Min();
            long maxYUnits = (new List<long>() { printerOneValues[2], printerTwoValues[2], printerThreeValues[2] }).Min();
            long maxKUnits = (new List<long>() { printerOneValues[3], printerTwoValues[3], printerThreeValues[3] }).Min();

            Random r = new Random();
            long randomCUnits = r.NextInt64();
            long randomMUnits = r.NextInt64();
            long randomYUnits = r.NextInt64();
            long randomKUnits = r.NextInt64();
            
            decimal factor = requiredNumberOfUnits / (randomCUnits + randomMUnits + randomYUnits + randomKUnits);

            randomCUnits = (long)Math.Round(randomCUnits * factor);
            randomMUnits = (long)Math.Round(randomMUnits * factor);
            randomYUnits = (long)Math.Round(randomYUnits * factor);
            randomKUnits = (long)Math.Round(randomKUnits * factor);

            output = $"{randomCUnits} {randomMUnits} {randomYUnits} {randomKUnits}";

            Console.WriteLine($"Case #{i}: {output}");
            Console.WriteLine("");

            // while (true)
            // {
            //     long randomCUnits = random.NextInt64(maxCUnits);
            //     long randomMUnits = random.NextInt64(maxMUnits);
            //     long randomYUnits = random.NextInt64(maxYUnits);
            //     long randomKUnits = random.NextInt64(maxKUnits);
            //     if (randomCUnits + randomMUnits + randomYUnits + randomKUnits == requiredNumberOfUnits)
            //     {
            //         output = $"{randomCUnits} {randomMUnits} {randomYUnits} {randomKUnits}";
            //         break;
            //     }
            // }

            // Console.WriteLine($"Case #{i + 1}: {output}");
            // Console.WriteLine(output);
        }
    }
}
