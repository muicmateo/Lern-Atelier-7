using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        // Replace with the actual file path to your input data
        string filePath = "C:\\Users\\muicm\\OneDrive\\Desktop\\day2_part1.txt";

        try
        {
            // Read all reports (lines) from the input file
            var reports = File.ReadAllLines(filePath);

            int safeReportsCount = reports.Count(IsSafeReport);

            Console.WriteLine($"Number of safe reports: {safeReportsCount}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static bool IsSafeReport(string report)
    {
        // Parse the report into an array of integers
        int[] levels = report.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                             .Select(int.Parse)
                             .ToArray();

        // Check if the report meets the "safe" conditions
        return IsIncreasingOrDecreasingWithValidDiff(levels);
    }

    static bool IsIncreasingOrDecreasingWithValidDiff(int[] levels)
    {
        if (levels.Length < 2)
            return false;

        bool isIncreasing = levels[1] > levels[0];
        for (int i = 1; i < levels.Length; i++)
        {
            int difference = levels[i] - levels[i - 1];

            // Check if the difference is within the allowed range
            if (Math.Abs(difference) < 1 || Math.Abs(difference) > 3)
                return false;

            // Ensure the trend (increasing or decreasing) is consistent
            if ((isIncreasing && difference < 0) || (!isIncreasing && difference > 0))
                return false;
        }

        return true;
    }
}
