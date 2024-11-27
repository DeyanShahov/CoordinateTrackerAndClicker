using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CoordinateTrackerAndClicker.Utils
{
    internal class MouseTracker : IDisposable
    {
        private Timer _timer;
        public Point CurrentPosition { get; private set; }

        public delegate void PositionChangedHandler(Point newPosition);
        public event PositionChangedHandler OnPositionChanged;

        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out Point lpPoint);
       
        public MouseTracker(int interval = 50)
        {
            _timer = new Timer { Interval = interval };
            _timer.Tick += (s, e) => TrackMouse();
        }

        public void StartTracking() => _timer.Start();

        public void StopTracking() => _timer.Stop();


        private void TrackMouse()
        {
            if (GetCursorPos(out Point point))
            {
                var newPosition = new Point(point.X, point.Y);
                if (newPosition != CurrentPosition)
                {
                    CurrentPosition = newPosition;
                    OnPositionChanged?.Invoke(CurrentPosition);
                }
            }
        }

        public void Dispose()
        {
            if (_timer != null)
            {
                _timer.Stop();
                _timer.Dispose();
            }
        }
    }
}
