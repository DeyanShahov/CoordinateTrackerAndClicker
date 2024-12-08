using System;

namespace CoordinateTrackerAndClicker.Utils
{
    internal class Printer
    {
        private Action<string, double?, LogLevel> _logAction;

        public Printer(Action<string, double?, LogLevel> logAction)
        {
            _logAction = logAction;
        }

        public void Print(string message, LogLevel logLevel = LogLevel.Info , double? fontSize = null) 
        {
            _logAction?.Invoke(message, fontSize, logLevel);
        }     
    }

    public enum LogLevel
    {
        Info,
        Success,
        Error
    }
}
