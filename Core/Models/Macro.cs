using System.Collections.Generic;
using System.Linq;

namespace CoordinateTrackerAndClicker.Core.Models
{
    public class Macro
    {
        public string Name { get; set; }
        public List<MouseAction> Actions { get; set; } = new List<MouseAction>();
        public int RepeatCount { get; set; }

        public Macro Clone()
        {
            // Създаване на нов обект Macro
            Macro clone = new Macro
            {
                Name = this.Name,
                RepeatCount = this.RepeatCount
            };

            // Копиране на списъка от действия (дълбоко копие)
            clone.Actions = this.Actions.Select(action => action.Clone()).ToList();

            return clone;
        }
    }
}
