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
            textResult.AppendLine($"     Кординати: X {action.Coordinates.X} : Y {action.Coordinates.Y}");
            textResult.AppendLine($"     Действие: {action.ActionType}");
            textResult.AppendLine($"     Забавяне преди: {action.DelayBefore}");
            textResult.AppendLine($"     Забавяне след: {action.DelayAfter}");
            textResult.AppendLine($"     Честота: {action.Frequency}");
            textResult.AppendLine($"     Продължителност: {action.Duration}");
            textResult.AppendLine($"     Повторения: {action.RepeatCount}");
            textResult.AppendLine($"     Оригинална позиция: {action.ReturnToOriginal}");

            return textResult.ToString();
        }

        public string DisplayMacroInfo(Macro macro, bool isSavedToDB)
        {
            var textToPrint = new StringBuilder();
            textToPrint.AppendLine(macro.Name);
            if (isSavedToDB) textToPrint.AppendLine($"  ЗАПАМЕТЕН В ДБ.");
            else textToPrint.AppendLine($"  . . . . .");

            macro.Actions.ForEach(action => textToPrint.AppendLine(DisplayActionInfo(action)));

            return textToPrint.ToString();
        }
    }
}
