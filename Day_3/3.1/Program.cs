using System;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;

class Program
{
    static void Main(string[] args)
    {
        // string filePath = "C:\\Users\\rosea\\Repos\\AdventOfCode2025\\Day_3\\testinput.txt";
        string filePath = "C:\\Users\\rosea\\Repos\\AdventOfCode2025\\Day_3\\input.txt";

        var lines = File.ReadAllLines(filePath);
        int total = 0;
        string result;

        foreach (var line in lines)
        {
            result = getDigits(line);
            total += int.Parse(result);
        }
        Console.WriteLine(total);
    }

    public static string getDigits(string input)
    {
        // Build the largest two-digit number possible without reordering digits.
        // Scan from right to left, keep the largest digit seen to the right of current
        // and compute d*10 + maxRight for each position.
        int n = input.Length;
        if (n < 2) return "0";

        int maxRight = -1; // largest digit seen to the right
        int best = -1;     // best two-digit value found

        for (int i = n - 1; i >= 0; i--)
        {
            char ch = input[i];
            int d = ch - '0';

            if (maxRight != -1)
            {
                int val = d * 10 + maxRight;
                if (val > best) best = val;
            }

            if (d > maxRight) maxRight = d;
        }

        return best.ToString();
    }
}

