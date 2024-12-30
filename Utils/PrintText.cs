using CoordinateTrackerAndClicker.Core.Models;
using System.Text;

namespace CoordinateTrackerAndClicker.Utils
{
    internal class PrintText
    {  
        public string DisplayActionInfo(MouseAction action)
        {
            var textResult = new StringBuilder();
            textResult.AppendLine($"    {action.Name}");
            textResult.AppendLine($"     {LanguageManager.GetString(SAM.DISPLAY_ACTION_INFO_CORDINATES)}: X {action.Coordinates.X} : Y {action.Coordinates.Y}");
            textResult.AppendLine($"     {LanguageManager.GetString(SAM.DISPLAY_ACTION_INFO_ACTION)}: {action.ActionType}");
            textResult.AppendLine($"     {LanguageManager.GetString(SAM.DISPLAY_ACTION_INFO_BEFORE)}: {action.DelayBefore}");
            textResult.AppendLine($"     {LanguageManager.GetString(SAM.DISPLAY_ACTION_INFO_AFTER)}: {action.DelayAfter}");
            textResult.AppendLine($"     {LanguageManager.GetString(SAM.DISPLAY_ACTION_INFO_FREQUENCY)}: {action.Frequency}");
            textResult.AppendLine($"     {LanguageManager.GetString(SAM.EXECUTE_MACRO_ASYNC_DURATION)}: {action.Duration}");
            textResult.AppendLine($"     {LanguageManager.GetString(SAM.EXECUTE_MACRO_ASYNC_REPETITIONS)}: {action.RepeatCount}");
            textResult.AppendLine($"     {LanguageManager.GetString(SAM.DISPLAY_ACTION_INFO_ORIGINAL_POSITION)}: {action.ReturnToOriginal}");

            return textResult.ToString();
        }

        public string DisplayMacroInfo(Macro macro, bool isSavedToDB)
        {
            var textToPrint = new StringBuilder();
            textToPrint.AppendLine(macro.Name);
            if (isSavedToDB) textToPrint.AppendLine($"  {LanguageManager.GetString(SAM.DISPLAY_MACRO_INFO)}");
            else textToPrint.AppendLine($"  . . . . .");

            macro.Actions.ForEach(action => textToPrint.AppendLine(DisplayActionInfo(action)));

            return textToPrint.ToString();
        }
    }
}
