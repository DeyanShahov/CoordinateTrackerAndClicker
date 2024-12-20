using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CoordinateTrackerAndClicker.Core.Models
{
    internal interface IMacroService
    {
        void CreateMacro(string name);
        void AddAction(string textBoxActionName, Point lastCoordinate, MouseActionType actionType,
            int numericDelayAfter, int numericDelayBefore, bool chkReturnToOriginal,
            int FrequencyInput, int DurationInput, int CountInput);
        void RemoveAction(int actionIndex);
        void SaveMacro(Macro macro);
        Macro LoadMacro(string name);
        void ExecuteMacro(Timer autoClickTimer, string macroName, int macroRepeatCount, int macroAllRepeatCount);
        void ExecuteMacro(Timer autoClickTimer, List<KeyValuePair<string, int>> macrosNameRepeatList, int macroAllRepeatCount);
    }
}
