﻿using CoordinateTrackerAndClicker.Utils;
using MaterialSkin.Controls;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace CoordinateTrackerAndClicker.Core.Models
{
    internal interface IMacroService
    {
        void AddAction(string textBoxActionName, Point lastCoordinate, MouseActionType actionType,
            int numericDelayAfter, int numericDelayBefore, bool chkReturnToOriginal,
            int FrequencyInput, int DurationInput, int CountInput);
        void RemoveActionByIndex(int actionIndex);
        void CreateMacro(string name);
        Task<bool> SaveMacroToDBAsync(Macro macro);
        Task<List<string>> LoadMacroFromDBAsync();
        Task<bool> DeleteMacroFromDBAsync(string macroName);
        Task ExecuteMacroAsync(Printer _printer, MaterialProgressBar progressBar, List<KeyValuePair<string, int>> macrosNameRepeatList, int macroAllRepeatCount);
    }
}
