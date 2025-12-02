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
        int numOfZeros = 0;
        int clicks;

        foreach (var line in lines)
        {
            if (lines.Length > 0)
            {
                if (line.StartsWith("R"))
                {
                    clicks = GetAmountOfClicks(line);
                    int numHun = clicks / 100 > 0 ? clicks / 100 : 0;
                    dial += clicks < 100 ? clicks : clicks - (numHun * 100);
                }
                else if (line.StartsWith("L"))
                {
                    clicks = GetAmountOfClicks(line);
                    int numHun = clicks / 100 > 0 ? clicks / 100 : 0;
                    dial -= clicks < 100 ? clicks : clicks - (numHun * 100);
                }

                if (dial > 99)
                {
                    dial -= 100;
                }
                else if (dial < 0)
                {
                    dial += 100;
                }

                if (dial == 0)
                {
                    numOfZeros++;
                }
            }
        }
        Console.WriteLine($"Number of Zeros: {numOfZeros}");
    }

    public static int GetAmountOfClicks(string instruction)
    {
        return int.Parse(instruction.Substring(1)); 
    }
}