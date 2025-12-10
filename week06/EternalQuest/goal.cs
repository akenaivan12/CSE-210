using System;

namespace EternalQuest
{
    public abstract class Goal
    {
        protected string _name;
        protected string _description;
        protected int _points;

        public Goal(string name, string description, int points)
        {
            _name = name;
            _description = description;
            _points = points;
        }

        public string Name => _name;
        public string Description => _description;
        public int Points => _points;

        // Whether the goal is finished (for eternal goals always false)
        public abstract bool IsComplete { get; }

        // Record an event for this goal: returns points earned
        public abstract int RecordEvent();

        // Display-friendly representation
        public abstract string Display();

        // Serialization: returns a single-line `type|field1|field2|...`
        public abstract string Serialize();
    }
}
