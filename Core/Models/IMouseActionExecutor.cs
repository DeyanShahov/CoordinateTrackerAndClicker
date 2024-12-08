namespace CoordinateTrackerAndClicker.Core.Models
{
    internal interface IMouseActionExecutor
    {
        void Execute(MouseAction action);
        void SimulateSingleClick();
        void SimulateDoubleClick();
        void SimulateScroll(int dwData = 520);
        void SimulateRightClick();
    }
}
