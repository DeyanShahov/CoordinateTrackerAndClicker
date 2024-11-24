using System.Collections.Generic;

namespace CoordinateTrackerAndClicker
{
    public class Macro
    {
        public string Name { get; set; }
        public List<MouseAction> Actions { get; set; } = new List<MouseAction>();
        public int RepeatCount { get; set; } 
    }
}
