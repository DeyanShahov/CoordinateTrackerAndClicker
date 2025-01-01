using System;

namespace CoordinateTrackerAndClicker.Utils
{
    internal class Printer
    {
        private Action<string, bool, LogLevel> _logAction;

        public Printer(Action<string, bool, LogLevel> logAction)
        {
            _logAction = logAction;
        }

        public void Print(string message, LogLevel logLevel = LogLevel.Info , bool show = true) 
        {
            _logAction?.Invoke(message, show, logLevel);
        }     
    }

    public enum LogLevel
    {
        Info,
        Success,
        Error
    }
}
