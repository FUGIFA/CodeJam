internal class Program
{
    private static void Main(string[] args)
    {
        string[] lines = System.IO.File.ReadAllLines(@"./SampleInput.txt");

        int rowCount = 0;
        int columnCount = 0;
        for (int i = 0; i < lines.Count(); i++)
        {
            int spaceIndex = lines[i].IndexOf(' ');
            if (spaceIndex < 0)
                continue;

            rowCount = int.Parse(lines[i].Substring(0, spaceIndex));
            columnCount = int.Parse(lines[i].Substring(spaceIndex));

            Console.WriteLine($"Case #{i}:");
            for (int r = 0; r < rowCount; r++)
            {
                string cellTop = "";
                string cellMiddle = "";
                for (int c = 0; c < columnCount; c++)
                {
                    if (r == 0 && c == 0)
                    {
                        cellTop += "..";
                        cellMiddle += "..";
                        continue;
                    }
                    cellTop += "+-";
                    cellMiddle += "|.";

                    if (c == columnCount - 1)
                    {
                        cellTop += "+";
                        cellMiddle += "|";
                        continue;
                    }
                }
                Console.WriteLine(cellTop);
                Console.WriteLine(cellMiddle);
            }

            string cellBottom = "";
            for (int c = 0; c < columnCount; c++)
            {
                cellBottom += "+-";
                if (c == columnCount - 1)
                {
                    cellBottom += "+";
                    continue;
                }
            }
            Console.WriteLine(cellBottom);
        }
    }
}