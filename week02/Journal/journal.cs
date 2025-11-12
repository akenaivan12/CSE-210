using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display.\n");
            return;
        }

        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry.GetDisplayText());
        }

        DisplaySummary();
    }

    public void DisplaySummary()
    {
        Console.WriteLine($"Total entries: {_entries.Count}");
        if (_entries.Count > 0)
        {
            double avgMood = _entries.Average(e => e.MoodRating);
            Console.WriteLine($"Average mood: {avgMood:F1}/5\n");
        }
    }

    public void SaveToFile(string filename)
    {
        Directory.CreateDirectory("SavedJournals");
        string path = Path.Combine("SavedJournals", filename);

        using (StreamWriter outputFile = new StreamWriter(path))
        {
            outputFile.WriteLine("Date,Prompt,Response,MoodRating");
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.ToCsv());
            }
        }

        Console.WriteLine($"Journal saved successfully to {path}");
    }

    public void LoadFromFile(string filename)
    {
        string path = Path.Combine("SavedJournals", filename);
        if (!File.Exists(path))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _entries.Clear();

        string[] lines = File.ReadAllLines(path);
        foreach (string line in lines.Skip(1)) // Skip header
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            _entries.Add(Entry.FromCsv(line));
        }

        Console.WriteLine($"Loaded {_entries.Count} entries from {path}\n");
    }
}
