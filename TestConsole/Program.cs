using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Please insert input sentence:");

        var testString = Console.ReadLine();

        var result = DistinctWordCount(testString);
        foreach (var resultItem in result)
        {
            Console.WriteLine(resultItem.Key + " - " + resultItem.Value);
        }

        Console.ReadLine();
    }

    public static Dictionary<string, int> DistinctWordCount(string testString)
    {
        var result = new Dictionary<string, int>();
        // remove non-alphanumeric characters and space
        testString = Regex.Replace(testString.Trim().ToLower(), "[^a-zA-Z0-9 ]", "");

        if (!testString.Any())
        {
            return result;
        }

        var testStringArrayGrouped = testString.Split(' ').Where(s => s.Length > 0).GroupBy(s => s);
        result = testStringArrayGrouped.ToDictionary(t => t.Key, t => t.Count());
        return result;
    }
}