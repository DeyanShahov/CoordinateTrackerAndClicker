using System.Drawing;

namespace CoordinateTrackerAndClicker.Core.Models
{
    public class MouseAction
    {
        public string Name {  get; set; }
        public Point Coordinates { get; set; }
        public MouseActionType ActionType { get; set; }
        public int DelayAfter { get; set; }  // In milliseconds
        public int DelayBefore { get; set; } // In milliseconds
        public bool ReturnToOriginal { get; set; }
        public int Frequency { get; set; } // How often to run the action 
        public int Duration { get; set; } // How long to run the action, before stop  
        public int RepeatCount { get; set; }  // How many times to repeat this action

        // Метод за дълбоко копие
        public MouseAction Clone()
        {
            return new MouseAction
            {
                Name = this.Name,
                Coordinates = this.Coordinates, // Point е структура, така че е безопасно
                ActionType = this.ActionType,
                DelayAfter = this.DelayAfter,
                DelayBefore = this.DelayBefore,
                ReturnToOriginal = this.ReturnToOriginal,
                Frequency = this.Frequency,
                Duration = this.Duration,
                RepeatCount = this.RepeatCount
            };
        }
    }

    public enum MouseActionType
    {
        SingleClick,
        DoubleClick,
        Scroll,
        RightClick
    }
}
