using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoordinateTrackerAndClicker
{
    public class Macro
    {
        public string Name { get; set; }
        public List<MouseAction> Actions { get; set; } = new List<MouseAction>();
        //public int Frequency { get; set; } // How often to run the command 
        //public int Duration { get; set; } // How long to run the command, before stop  
        //public int RepeatCount { get; set; }  // How many times to repeat this macro
    }
}
