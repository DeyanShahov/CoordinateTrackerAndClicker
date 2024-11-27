using CoordinateTrackerAndClicker.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoordinateTrackerAndClicker.Utils
{
    internal class PrintText
    {
        public string DisplayActionInfo(MouseAction action)
        {
            return $"Име: {action.Name}" +
                            $"\nКординати: {action.Coordinates.X} : {action.Coordinates.Y}" +
                            $"\nДействие: {action.ActionType}" +
                            $"\nЗабавяне преди: {action.DelayBefore}" +
                            $"\nЗабавяне след: {action.DelayAfter}" +
                            $"\nЧестота: {action.Frequency}" +
                            $"\nПродължителност: {action.Duration}" +
                            $"\nПовторения: {action.RepeatCount}" +
                            $"\nОригинална позиция: {action.ReturnToOriginal}";
        }

        public string DisplayActionInfo1(MouseAction action)
        {
            var textResult = new StringBuilder();
            textResult.AppendLine($"     {action.Name}");
            textResult.AppendLine($"     {action.Coordinates.ToString()}");
            textResult.AppendLine($"     {action.ActionType.ToString()}");
            textResult.AppendLine($"     {action.DelayBefore.ToString()}");
            textResult.AppendLine($"     {action.DelayAfter.ToString()}");
            textResult.AppendLine($"     {action.ReturnToOriginal.ToString()}");
            textResult.AppendLine($"     {action.Frequency.ToString()}");
            textResult.AppendLine($"     {action.Duration.ToString()}");
            textResult.AppendLine($"     {action.RepeatCount.ToString()}");

            return textResult.ToString();
        }

        public string DisplayMacroInfo(Macro macro)
        {
            var textToPrint = new StringBuilder();
            textToPrint.AppendLine(macro.Name);

            macro.Actions.ForEach(action => textToPrint.AppendLine(DisplayActionInfo1(action)));

            return textToPrint.ToString();
        }
    }
}
