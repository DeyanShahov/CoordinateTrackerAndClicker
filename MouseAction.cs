using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoordinateTrackerAndClicker
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
    }

    public enum MouseActionType
    {
        SingleClick,
        DoubleClick,
        Scroll
    }
}
