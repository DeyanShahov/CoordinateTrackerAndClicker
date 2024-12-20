using System.Threading;
using System.Threading.Tasks;

namespace CoordinateTrackerAndClicker.Core.Models
{
    internal interface IMouseActionExecutor
    {
        //Task Execute(MouseAction action, CancellationToken cancellationToken, ManualResetEvent pauseEvent);
        Task Execute(MouseAction action, CancellationToken cancellationToken);
        void SimulateSingleClick();
        void SimulateDoubleClick();
        void SimulateScroll(int dwData = 520);
        void SimulateRightClick();
    }
}
