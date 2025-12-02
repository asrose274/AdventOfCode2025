using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "C:\\Users\\rosea\\Repos\\AdventOfCode2025\\Day_1\\input.txt";

        var lines = File.ReadAllLines(filePath);

        int dial = 50;
        int wraparounds = 0;
        int zerosHit = 0;
        int clicks;

        foreach (var line in lines)
        {
            if (lines.Length > 0)
            {
                clicks = GetAmountOfClicks(line);
                int oldDial = dial;

                if (line.StartsWith("R"))
                {
                    dial += clicks;
                }
                else if (line.StartsWith("L"))
                {
                    dial -= clicks;
                }

                // Count times dial passes through or lands on 0
                if (oldDial < dial)
                {
                    // Moving right - check if we cross 0
                    if (oldDial < 0 && dial >= 0)
                    {
                        zerosHit++;
                    }
                    // Check multiples of 100
                    zerosHit += dial / 100 - oldDial / 100;
                }
                else if (oldDial > dial)
                {
                    // Moving left - check if we cross 0
                    if (oldDial > 0 && dial <= 0)
                    {
                        zerosHit++;
                    }
                    // Check multiples of 100
                    zerosHit += oldDial / 100 - dial / 100;
                }

                // Handle wrapping with modulo arithmetic
                wraparounds += dial / 100;
                dial = dial % 100;

                // Handle negative wrapping
                if (dial < 0)
                {
                    dial += 100;
                    wraparounds--;
                }
            }
        }
        Console.WriteLine($"Final Dial Position: {dial}");
        // Console.WriteLine($"Total Wraparounds: {wraparounds}");
        Console.WriteLine($"Times Dial Hit 0: {zerosHit}");
    }

    public static int GetAmountOfClicks(string instruction)
    {
        return int.Parse(instruction.Substring(1));
    }
}