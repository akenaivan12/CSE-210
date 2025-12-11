using System;

namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points) : base(name, description, points)
        {
        }

        public override bool IsComplete => false;

        public override int RecordEvent()
        {
            // Always award points
            return _points;
        }

        public override string Display()
        {
            return $"[~] {Name} ({Description}) - {Points} pts each time";
        }

        public override string Serialize()
        {
            // EternalGoal|name|description|points
            return $"EternalGoal|{Escape(Name)}|{Escape(Description)}|{Points}";
        }

        private string Escape(string s) => s.Replace("|", "\\|");
        public static EternalGoal Deserialize(string[] parts)
        {
            var name = parts[1].Replace("\\|", "|");
            var desc = parts[2].Replace("\\|", "|");
            int pts = int.Parse(parts[3]);
            return new EternalGoal(name, desc, pts);
        }
    }
}
