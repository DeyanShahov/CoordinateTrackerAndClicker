using CoordinateTrackerAndClicker.Utils;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

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
        Task ExecuteMacroAsync(Printer _printer, List<KeyValuePair<string, int>> macrosNameRepeatList, int macroAllRepeatCount);
    }
}
