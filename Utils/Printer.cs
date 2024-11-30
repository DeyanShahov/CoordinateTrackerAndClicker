using System;

namespace CoordinateTrackerAndClicker.Utils
{
    internal class Printer
    {
        private Action<string, double?> _logAction;

        public Printer(Action<string, double?> logAction)
        {
            _logAction = logAction;
        }

        public void Print(string message, double? fontSize = null) 
        {
            _logAction?.Invoke(message, fontSize);        
        }
    }
}
