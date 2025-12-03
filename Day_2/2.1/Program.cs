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
        var digits = id.ToString().Length;
        // If odd number of digits, it's valid
        if (digits % 2 != 0)
        {
            return false;
        }
        
        var firstHalf = id.ToString().Substring(0, digits / 2);
        var secondHalf = id.ToString().Substring(digits / 2, digits / 2);

        // If halves match, it's invalid (should be added to total)
        if(firstHalf == secondHalf)
        {
            return true;
        }
        return false;
    }

}

