using System;

namespace CoordinateTrackerAndClicker.Utils
{
    internal class CustomException : Exception
    {
        public CustomException(string message) : base(message) { }
    }
}
