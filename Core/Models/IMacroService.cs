using System.Drawing;
using System.Windows.Forms;

namespace CoordinateTrackerAndClicker.Core.Models
{
    internal interface IMacroService
    {
        string CreateMacro(string name);
        void AddAction(string textBoxActionName, Point lastCoordinate, MouseActionType actionType,
            int numericDelayAfter, int numericDelayBefore, bool chkReturnToOriginal,
            int FrequencyInput, int DurationInput, int CountInput);
        void RemoveAction(MouseAction action);
        void SaveMacro(Macro macro);
        Macro LoadMacro(string name);
        void ExecuteMacro(Timer autoClickTimer, int macroIndex, int macroRepeatCount);
    }
}
