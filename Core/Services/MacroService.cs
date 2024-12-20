using CoordinateTrackerAndClicker.Core.Models;
using CoordinateTrackerAndClicker.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoordinateTrackerAndClicker.Core.Services
{
    internal class MacroService //: IMacroService
    {
        private readonly MouseActionExecutor actionExecutor;
        public List<Macro> macrosList;
        public List<MouseAction> currentActionsList;
        public List<KeyValuePair<string, int>> macrosNameToExecute;
        private Macro currentMacro;

        private CancellationTokenSource _cancellationTokenSource;

        private bool isAllMacrosFromListToExecution = false;
        private int currentAllMacroIndex = 0;
     
        public MacroService()
        {
            macrosList = new List<Macro>();
            currentActionsList = new List<MouseAction>();
            actionExecutor = new MouseActionExecutor();
            macrosNameToExecute = new List<KeyValuePair<string, int>>();
            _cancellationTokenSource = new CancellationTokenSource();
        }


        public void CreateMacro(string macroName)
        {
            if (macrosList.Any(m => m.Name == macroName))
            {
                throw new CustomException("Макро с такова име вече съществува!");
            }

            currentMacro = new Macro 
            {
                Name = macroName,
                Actions = currentActionsList
            };
            macrosList.Add(currentMacro.Clone());

            currentActionsList.Clear();
            currentMacro = new Macro();
        }

        public void AddAction(string textBoxActionName, Point lastCoordinate, MouseActionType actionType,
            int numericDelayAfter, int numericDelayBefore, bool chkReturnToOriginal, 
            int FrequencyInput, int DurationInput, int CountInput)
        {
            var action = new MouseAction
            {
                Name = textBoxActionName,
                Coordinates = lastCoordinate,
                ActionType = actionType,
                DelayAfter = numericDelayAfter,
                DelayBefore = numericDelayBefore,
                ReturnToOriginal = chkReturnToOriginal,
                Frequency = FrequencyInput,
                Duration = DurationInput,
                RepeatCount = CountInput
            };

            currentActionsList.Add(action);
        }

        public void RemoveAction(int actionIndex)
        {
            currentActionsList.RemoveAt(actionIndex);
        }

        public void ChangeActionPosition(int index, bool isMoveUp)
        {
            var temp = currentActionsList[index];
            int targetElementIndexToSwap = index + (isMoveUp ? -1 : +1);
            currentActionsList[index] = currentActionsList[targetElementIndexToSwap];
            currentActionsList[targetElementIndexToSwap] = temp;
        }

        //public void ExecuteMacro(Timer autoClickTimer, string macroName, int macroRepeatCount = 1, int macroAllRepeatCount = 1)
        //{
        //    macroToExecute = macrosList.FirstOrDefault(m => m.Name == macroName);
        //    macroToExecute.RepeatCount = macroRepeatCount;

        //    endTime = DateTime.Now.AddMinutes(macroToExecute.Actions[currentActionIndex].Duration);
        //    countActionRepeat = macroToExecute.Actions[currentActionIndex].RepeatCount; 
        //    currentMacroRepeatCount = macroRepeatCount;

        //    countAllMacroRepeatCount = macroAllRepeatCount;

        //    autoClickTimer.Interval = macroToExecute.Actions[currentActionIndex].Frequency * 1000; // Convert to milliseconds
        //    autoClickTimer.Tick += AutoClickTimer_Tick;
        //    autoClickTimer.Start();
        //}

        //public void ExecuteMacro(Timer autoClickTimer, List<KeyValuePair<string, int>> macrosNameRepeatList, int macroAllRepeatCount = 1)
        //{
        //    currentAllMacroIndex = 0;
        //    macrosNameToExecute = macrosNameRepeatList;
        //    //macroToExecute = macrosList.FirstOrDefault(m => m.Name == macrosNameToExecute[currentAllMacroIndex].Key);
        //    macroToExecute = macrosList.FirstOrDefault(m => m.Name == macrosNameToExecute[currentAllMacroIndex].Key);
        //    macroToExecute.RepeatCount = macrosNameToExecute[currentAllMacroIndex].Value;

        //    endTime = DateTime.Now.AddMinutes(macroToExecute.Actions[currentActionIndex].Duration);
        //    countActionRepeat = macroToExecute.Actions[currentActionIndex].RepeatCount;
        //    currentMacroRepeatCount = macroToExecute.RepeatCount;

        //    countAllMacroRepeatCount = macroAllRepeatCount;

        //    autoClickTimer.Interval = macroToExecute.Actions[currentActionIndex].Frequency * 1000; // Convert to milliseconds
        //    autoClickTimer.Tick += AutoClickTimer_Tick;
        //    autoClickTimer.Start();
        //}

        public void ResetCancellationToken()
        {
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public async Task ExecuteMacroAsync(Printer _printer, string macroName, int macroRepeatCount = 1, int macroAllRepeatCount = 1)
        {
            ResetCancellationToken();

            Macro macro = macrosList.FirstOrDefault(m => m.Name == macroName);
            int totalActions = macro.Actions.Sum(action => action.RepeatCount) * macroRepeatCount * macroAllRepeatCount;
            int completedActions = 0;
            int totalDurationMs = macro.Actions.Sum(action
                => action.Duration * 60 * 1000)
                * macroRepeatCount
                * macroAllRepeatCount;
            int estemidateTimeToExecute = macro.Actions.Sum(action
                => action.RepeatCount * (action.Frequency * 1000 + action.DelayBefore + action.DelayAfter))
                * macroRepeatCount
                * macroAllRepeatCount;

            _printer.Print($"Повторения: {totalActions} - " +
                $"Продължителност: {TimeSpan.FromMilliseconds(totalDurationMs):hh\\:mm\\:ss} - " +
                $"Очаквана продалжителност: {TimeSpan.FromMilliseconds(estemidateTimeToExecute):hh\\:mm\\:ss}", LogLevel.Info);

            Stopwatch stopwatch = Stopwatch.StartNew();

            try
            {
                for (int macroAllRepeat = 0; macroAllRepeat < macroAllRepeatCount; macroAllRepeat++)
                {
                    for (int macroRepeat = 0; macroRepeat < macroRepeatCount; macroRepeat++)
                    {
                        foreach (var action in macro.Actions)
                        {
                            for (int actionRepeat = 0; actionRepeat < action.RepeatCount; actionRepeat++)
                            {
                                _cancellationTokenSource.Token.ThrowIfCancellationRequested();


                                await Task.Delay(action.Frequency * 1000, _cancellationTokenSource.Token);
                                await actionExecutor.Execute(action, _cancellationTokenSource.Token);
                                completedActions++;

                                double progressPercentage = (completedActions / (double)totalActions) * 100;
                                int elapsedMs = (int)stopwatch.Elapsed.TotalMilliseconds;
                                int remainingMsDuration = totalDurationMs - elapsedMs;
                                int remainingMsToExecute = estemidateTimeToExecute - elapsedMs;

                                _printer.Print($"Прогрес: {completedActions}/{totalActions} ({progressPercentage:F2}%) - " +
                                    $"Оставащо време: {TimeSpan.FromMilliseconds(remainingMsDuration):hh\\:mm\\:ss} - " +
                                    $"Край след: {TimeSpan.FromMilliseconds(remainingMsToExecute):hh\\:mm\\:ss}", LogLevel.Info);
                            }
                        }
                    }
                }

                stopwatch.Stop();
                _printer.Print("Макросът е завършен!");
            }
            catch (OperationCanceledException)
            {
                stopwatch.Stop();
                _printer.Print("Макросът беше прекъснат!");
            }
        }

        public Macro LoadMacro(string name)
        {
            return new Macro();
        }

        public void SaveMacro(Macro macro)
        {
            throw new NotImplementedException();
        }

        //private void AutoClickTimer_Tick(object sender, EventArgs e)
        //{
        //    if (isPauseMacroExecution) return; // Ако паузата е натисната да не прави лоопа

        //    if (DateTime.Now >= endTime || countActionRepeat <= 0)
        //    {
        //        currentActionIndex++;

        //        if (macroToExecute.Actions.Count <= currentActionIndex)
        //        {
        //            macroToExecute.RepeatCount--;
        //            currentActionIndex = 0;

        //            if (macroToExecute.RepeatCount <= 0)
        //            {

        //                if (isAllMacrosFromListToExecution)
        //                {
        //                    currentAllMacroIndex++;

        //                    if (currentAllMacroIndex >= macrosNameToExecute.Count)
        //                    {
        //                        countAllMacroRepeatCount--;

        //                        if (countAllMacroRepeatCount <= 0)
        //                        {
        //                            StopCurrentMacroExecution((Timer)sender);

        //                            // Изпращане на уведомление 
        //                            OnTimerStopped();
        //                            return;
        //                        }

        //                        macroToExecute.RepeatCount = currentMacroRepeatCount;
        //                        currentAllMacroIndex = 0;
        //                    }

        //                    macroToExecute = macrosList.FirstOrDefault(m => m.Name == macrosNameToExecute[currentAllMacroIndex].Key);
        //                    macroToExecute.RepeatCount = macrosNameToExecute[currentAllMacroIndex].Value;

        //                    endTime = DateTime.Now.AddMinutes(macroToExecute.Actions[currentActionIndex].Duration);
        //                    countActionRepeat = macroToExecute.Actions[currentActionIndex].RepeatCount;
        //                    currentMacroRepeatCount = macroToExecute.RepeatCount;

        //                    ((Timer)sender).Interval = macroToExecute.Actions[currentActionIndex].Frequency * 1000;
        //                }
        //                else
        //                {
        //                    countAllMacroRepeatCount--;

        //                    if (countAllMacroRepeatCount <= 0)
        //                    {
        //                        StopCurrentMacroExecution((Timer)sender);

        //                        // Изпращане на уведомление 
        //                        OnTimerStopped();
        //                        return;
        //                    }

        //                    macroToExecute.RepeatCount = currentMacroRepeatCount;
        //                }                                            
        //            }
        //        }

        //        endTime = DateTime.Now.AddMinutes(macroToExecute.Actions[currentActionIndex].Duration);
        //        countActionRepeat = macroToExecute.Actions[currentActionIndex].RepeatCount;
        //        ((Timer)sender).Interval = macroToExecute.Actions[currentActionIndex].Frequency * 1000;
        //    }

        //    // Избор на крайно дейстрие          
        //    actionExecutor.Execute(macroToExecute.Actions[currentActionIndex]);

        //    // Намаля максималния брои на повторения
        //    countActionRepeat--;
        //}



        public void OnStopClick2() => StopExecution();

        public void StopExecution() => _cancellationTokenSource.Cancel();

        public void OnAllMacroToExecuteClick() => isAllMacrosFromListToExecution = !isAllMacrosFromListToExecution;
    }
}
