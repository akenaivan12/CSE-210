using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> _goals = new List<Goal>();
        private int _score = 0;

        public int Score => _score;

        public void AddGoal(Goal g)
        {
            _goals.Add(g);
        }

        public IReadOnlyList<Goal> Goals => _goals.AsReadOnly();

        public void RecordEvent(int index)
        {
            if (index < 0 || index >= _goals.Count) return;
            var g = _goals[index];
            var pts = g.RecordEvent();
            _score += pts;
            Console.WriteLine($"You earned {pts} points.");
        }

        public void ShowGoals()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals yet.");
                return;
            }
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i+1}. {_goals[i].Display()}");
            }
        }

        public void Save(string filename)
        {
            using (var sw = new StreamWriter(filename))
            {
                sw.WriteLine(_score);
                foreach (var g in _goals)
                {
                    sw.WriteLine(g.Serialize());
                }
            }
            Console.WriteLine($"Saved to {filename}");
        }

        public void Load(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            _goals.Clear();
            var lines = File.ReadAllLines(filename);
            if (lines.Length == 0) return;
            _score = int.Parse(lines[0]);
            for (int i = 1; i < lines.Length; i++)
            {
                var line = lines[i];
                var parts = SplitPreservingEscapes(line);
                var type = parts[0];
                if (type == "SimpleGoal")
                {
                    _goals.Add(SimpleGoal.Deserialize(parts));
                }
                else if (type == "EternalGoal")
                {
                    _goals.Add(EternalGoal.Deserialize(parts));
                }
                else if (type == "ChecklistGoal")
                {
                    _goals.Add(ChecklistGoal.Deserialize(parts));
                }
            }
            Console.WriteLine($"Loaded {filename}");
        }

        private static string[] SplitPreservingEscapes(string line)
        {
            var parts = new List<string>();
            var current = "";
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '|' )
                {
                    parts.Add(current);
                    current = "";
                }
                else if (line[i] == '\\' && i + 1 < line.Length && line[i+1] == '|')
                {
                    current += '|';
                    i++; // skip next
                }
                else
                {
                    current += line[i];
                }
            }
            parts.Add(current);
            return parts.ToArray();
        }

        // Extra utility: level based on score
        public int GetLevel()
        {
            return 1 + (_score / 1000);
        }
    }
}
