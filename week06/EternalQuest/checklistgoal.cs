using System;

namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _required;
        private int _completedCount;
        private int _bonus;

        public ChecklistGoal(string name, string description, int pointsPerEvent, int required, int bonus) : base(name, description, pointsPerEvent)
        {
            _required = required;
            _completedCount = 0;
            _bonus = bonus;
        }

        public override bool IsComplete => _completedCount >= _required;

        public override int RecordEvent()
        {
            if (IsComplete) return 0;
            _completedCount++;
            var earned = _points;
            if (_completedCount >= _required)
            {
                earned += _bonus; // award the bonus when finishing
            }
            return earned;
        }

        public override string Display()
        {
            return $"[{(IsComplete ? 'X' : ' ')}] {Name} ({Description}) - {Points} pts each ({_completedCount}/{_required}) Bonus: {_bonus}";
        }

        public override string Serialize()
        {
            // ChecklistGoal|name|description|points|required|completedCount|bonus
            return $"ChecklistGoal|{Escape(Name)}|{Escape(Description)}|{Points}|{_required}|{_completedCount}|{_bonus}";
        }

        private string Escape(string s) => s.Replace("|", "\\|");
        public static ChecklistGoal Deserialize(string[] parts)
        {
            var name = parts[1].Replace("\\|", "|");
            var desc = parts[2].Replace("\\|", "|");
            int points = int.Parse(parts[3]);
            int required = int.Parse(parts[4]);
            int completed = int.Parse(parts[5]);
            int bonus = int.Parse(parts[6]);
            var g = new ChecklistGoal(name, desc, points, required, bonus);
            g._completedCount = completed;
            return g;
        }
    }
}
