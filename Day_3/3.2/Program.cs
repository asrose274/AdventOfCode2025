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
        long total = 0;
        string result;

        foreach (var line in lines)
        {
            result = getDigits(line);
            total += long.Parse(result);
        }
        Console.WriteLine(total);
    }

    public static string getDigits(string input)
    {
        // Build the largest 12-digit subsequence possible without reordering digits.
        // Use a greedy stack: for each digit, pop smaller digits from the stack
        // if we can still fill k digits from the remaining characters.
        int k = 12;
        // collect only digit characters
        var digits = input.Where(char.IsDigit).ToArray();
        int m = digits.Length;
        if (m < k) return "0";

        var stack = new List<char>();
        for (int i = 0; i < m; i++)
        {
            char c = digits[i];
            // while we can pop and doing so yields a larger leading number
            while (stack.Count > 0 && stack[stack.Count - 1] < c && (stack.Count - 1 + (m - i)) >= k)
            {
                stack.RemoveAt(stack.Count - 1);
            }

            if (stack.Count < k)
            {
                stack.Add(c);
            }
        }

        return new string(stack.Take(k).ToArray());
    }
}

