using System;
using System.Text;

public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
    public int MoodRating { get; set; } // 1–5 scale

    public string GetDisplayText()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nMood Rating: {MoodRating}/5\nResponse: {Response}\n";
    }

    // Escape quotes and commas for proper CSV
    private static string EscapeCsv(string input)
    {
        if (input.Contains(",") || input.Contains("\"") || input.Contains("\n"))
            return $"\"{input.Replace("\"", "\"\"")}\"";
        return input;
    }

    public string ToCsv()
    {
        return $"{EscapeCsv(Date)},{EscapeCsv(Prompt)},{EscapeCsv(Response)},{MoodRating}";
    }

    public static Entry FromCsv(string csvLine)
    {
        var values = ParseCsv(csvLine);
        return new Entry
        {
            Date = values[0],
            Prompt = values[1],
            Response = values[2],
            MoodRating = int.Parse(values[3])
        };
    }

    // Simple CSV parser
    private static string[] ParseCsv(string line)
    {
        var result = new System.Collections.Generic.List<string>();
        bool inQuotes = false;
        StringBuilder value = new StringBuilder();

        foreach (char c in line)
        {
            if (c == '"' && !inQuotes)
                inQuotes = true;
            else if (c == '"' && inQuotes)
                inQuotes = false;
            else if (c == ',' && !inQuotes)
            {
                result.Add(value.ToString());
                value.Clear();
            }
            else
                value.Append(c);
        }
        result.Add(value.ToString());
        return result.ToArray();
    }
}
