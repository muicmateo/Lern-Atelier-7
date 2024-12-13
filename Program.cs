using System.Runtime.InteropServices;

namespace AoC_day1
{
    class Program
    {
        static void Main()
        {
            string filePath = "C:\\Users\\muicm\\OneDrive\\Desktop\\day1_part1.txt"; // Path to your input file
            try
            {
                // Initialize the lists for the left and right numbers
                List<int> leftList = new List<int>();
                List<int> rightList = new List<int>();

                // Read all lines from the file
                string[] lines = File.ReadAllLines(filePath);

                // Parse the numbers from each line
                foreach (var line in lines)
                {
                    // Split the line by the gap (default whitespace, assuming 4+ spaces separate the two lists)
                    string[] parts = line.Split(new[] { "   " }, StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length == 2)
                    {
                        // Add numbers to the left and right lists
                        leftList.AddRange(parts[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
                        rightList.AddRange(parts[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
                    }
                    else
                    {
                        Console.WriteLine($"Skipping invalid line: {line}");
                    }
                }

                // Sort both lists
                leftList.Sort();
                rightList.Sort();

                // Calculate the total distance
                int totalDistance = 0;
                for (int i = 0; i < Math.Min(leftList.Count, rightList.Count); i++)
                {
                    totalDistance += Math.Abs(leftList[i] - rightList[i]);
                }

                // Output the result
                Console.WriteLine($"Total Distance: {totalDistance}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}

    