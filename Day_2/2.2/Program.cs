using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "C:\\Users\\rosea\\Repos\\AdventOfCode2025\\Day_2\\input.txt";

        var lines = File.ReadAllLines(filePath);
        string[] ranges = lines[0].Split(',');
        long minimum;
        long maximum;
        long currentId;
        long total = 0;

        foreach (var range in ranges)
        {
            minimum = long.Parse(range.Split('-')[0]);
            maximum = long.Parse(range.Split('-')[1]);
            currentId = minimum;
            while (currentId <= maximum)
            {
                if (validateId(currentId))
                {
                    total += currentId;
                }
                currentId++;
            }
        }

        Console.WriteLine(total);
    }

    public static bool validateId(long id)
    {
        var idString = id.ToString();
        var digits = idString.Length;

        // Try all possible repeating sequence lengths (from 1 to half the length)
        for (int seqLen = 1; seqLen <= digits / 2; seqLen++)
        {
            // Only check if sequence length divides evenly into total digits
            if (digits % seqLen == 0)
            {
                string sequence = idString.Substring(0, seqLen);
                bool isRepeating = true;

                // Check if the entire ID is made of this sequence repeated
                for (int i = 0; i < digits; i += seqLen)
                {
                    if (idString.Substring(i, seqLen) != sequence)
                    {
                        isRepeating = false;
                        break;
                    }
                }

                // If we found a repeating sequence, ID is invalid
                if (isRepeating)
                {
                    return true;
                }
            }
        }

        return false;
    }

}

