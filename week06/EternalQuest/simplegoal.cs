using System;

namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        private bool _completed;

        public SimpleGoal(string name, string description, int points) : base(name, description, points)
        {
            _completed = false;
        }

        public override bool IsComplete => _completed;

        public override int RecordEvent()
        {
            if (!_completed)
            {
                _completed = true;
                return _points;
            }
            return 0; // no points if already completed
        }

        public override string Display()
        {
            return $"[{(_completed ? 'X' : ' ')}] {Name} ({Description}) - {Points} pts";
        }

        public override string Serialize()
        {
            // SimpleGoal|name|description|points|completed
            return $"SimpleGoal|{Escape(Name)}|{Escape(Description)}|{Points}|{_completed}";
        }

        private string Escape(string s) => s.Replace("|", "\\|");
        public static SimpleGoal Deserialize(string[] parts)
        {
            // parts: [type, name, description, points, completed]
            var name = parts[1].Replace("\\|", "|");
            var desc = parts[2].Replace("\\|", "|");
            int pts = int.Parse(parts[3]);
            bool done = bool.Parse(parts[4]);
            var g = new SimpleGoal(name, desc, pts);
            if (done) g._completed = true; // set without awarding points
            return g;
        }
    }
}
