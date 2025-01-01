using CoordinateTrackerAndClicker.Core.Models;
using CoordinateTrackerAndClicker.Db_Json;
using CoordinateTrackerAndClicker.Utils;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CoordinateTrackerAndClicker.Core.Services
{
    internal class MacroService : IMacroService
    {
        private readonly MouseActionExecutor actionExecutor;
        public List<Macro> macrosList;
        private readonly List<MouseAction> currentActionsList;
        private Macro currentMacro;

        private CancellationTokenSource _cancellationTokenSource;
        private bool isAllMacrosFromListToExecution = false;

        private readonly IDataStorageStrategy _storageStrategy;
        private readonly MacroStorageManager macroStorageManager;

        public MacroService()
        {
            macrosList = new List<Macro>();
            currentActionsList = new List<MouseAction>();
            actionExecutor = new MouseActionExecutor();
            _cancellationTokenSource = new CancellationTokenSource();

            //Избиране на стратегия за запаметяване на информацията - JSON
            _storageStrategy = new JsonDataStorageManualSelect();
            //Инициялизиране на записващия мениджер
            macroStorageManager = new MacroStorageManager(_storageStrategy);
        }


        public void CreateMacro(string macroName)
        {
            if (macrosList.Any(m => m.Name == macroName))
            {
                throw new CustomException(SAM.CREATE_MACRO_NAME_EXIST);
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

        public string[] LoadActionsNames()
        {
            return currentActionsList.Select(action => action.Name).ToArray();
        }

        public MouseAction LoadActionByIndex(int index)
        {
            return currentActionsList[index];
        }

        public void RemoveActionByIndex(int actionIndex)
        {
            currentActionsList.RemoveAt(actionIndex);
        }

        public void RemoveMacroByIndex(int macroIndex)
        {
            macrosList.RemoveAt(macroIndex);
        }

        public void ChangeActionPosition(int index, bool isMoveUp)
        {
            var temp = currentActionsList[index];
            int targetElementIndexToSwap = index + (isMoveUp ? -1 : +1);
            currentActionsList[index] = currentActionsList[targetElementIndexToSwap];
            currentActionsList[targetElementIndexToSwap] = temp;
        }

        public async Task ExecuteMacroAsync(Printer _printer, MaterialProgressBar progressBar, List<KeyValuePair<string, int>> macrosNameList, int macroAllRepeatCount = 1)
        {
            ResetCancellationToken();
            int totalMacros = 0;
            int totalActions = 0;
            int totalDurationMs = 0;
            int estemidateTimeToExecute = 0;
            int completedActions = 0;
            int completedMacros = 0;

            List<Macro> macros = new List<Macro>();

            foreach (var element in macrosNameList)
            {
                Macro macro = macrosList.FirstOrDefault(m => m.Name == element.Key);
                macro.RepeatCount = element.Value;
                macros.Add(macro);

                totalMacros += macro.RepeatCount * macroAllRepeatCount;

                int macroActionSum = 0;
                foreach (var action in macro.Actions)
                {
                    macroActionSum += action.RepeatCount;
                }

                totalActions += (macroActionSum == 0 ? 1 : macroActionSum) * macro.RepeatCount * macroAllRepeatCount;
                totalDurationMs += macro.Actions.Sum(action
                    => action.Duration * 60 * 1000)
                    * element.Value
                    * macroAllRepeatCount;
                estemidateTimeToExecute += macro.Actions.Sum(action
                    => action.RepeatCount * (action.Frequency * 1000 + action.DelayBefore + action.DelayAfter))
                    * element.Value
                    * macroAllRepeatCount;
            }          

            _printer.Print($"\n" +
                $"      {LanguageManager.GetString(SAM.EXECUTE_MACRO_ASYNC_REPETITIONS)}: {totalActions}\n" +
                $"      {LanguageManager.GetString(SAM.EXECUTE_MACRO_ASYNC_DURATION)}: {TimeSpan.FromMilliseconds(totalDurationMs):hh\\:mm\\:ss}\n" +
                $"      {LanguageManager.GetString(SAM.EXECUTE_MACRO_ASYNC_EXPECTED_DURATION)}: {TimeSpan.FromMilliseconds(estemidateTimeToExecute):hh\\:mm\\:ss}", LogLevel.Info, false);

            Stopwatch stopwatch = Stopwatch.StartNew();

            try
            {
                for (int macroAllRepeat = 0; macroAllRepeat < macroAllRepeatCount; macroAllRepeat++)
                {
                    _printer.Print($"{LanguageManager.GetString(SAM.EXECUTE_MACRO_ASYNC_REPETITION)}: {macroAllRepeat + 1}/{macroAllRepeatCount}", LogLevel.Success);
                    foreach (var macro in macros)
                    {
                        _printer.Print($"{LanguageManager.GetString(SAM.EXECUTE_MACRO_ASYNC_STARTED)}: {macro.Name}", LogLevel.Success);
                        for (int macroRepeat = 0; macroRepeat < macro.RepeatCount; macroRepeat++)
                        {
                            _printer.Print($"{LanguageManager.GetString(SAM.EXECUTE_MACRO_ASYNC_MACRO_REPETITION)}: {macroRepeat + 1}/{macro.RepeatCount}", LogLevel.Success);
                            string message = "";
                            foreach (var action in macro.Actions)
                            {
                                _printer.Print($"{LanguageManager.GetString(SAM.EXECUTE_MACRO_ASYNC_ACTION_STARTED)}: {action.Name}", LogLevel.Success);
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

                                    progressBar.Value = (int)progressPercentage;

                                    _printer.Print($"{LanguageManager.GetString(SAM.EXECUTE_MACRO_ASYNC_ACTION_REPETITION)}: {actionRepeat + 1}/{action.RepeatCount}", LogLevel.Success);
                                    
                                    message = $"\n  {LanguageManager.GetString(SAM.EXECUTE_MACRO_ASYNC_REMAIN_TIME)}: {TimeSpan.FromMilliseconds(remainingMsDuration):hh\\:mm\\:ss}\n" +
                                      $"  {LanguageManager.GetString(SAM.EXECUTE_MACRO_ASYNC_END_AFTER)}: {TimeSpan.FromMilliseconds(remainingMsToExecute):hh\\:mm\\:ss}\n" +
                                      $"  {LanguageManager.GetString(SAM.EXECUTE_MACRO_ASYNC_ACTION_PROGRESS)}: {completedActions}/{totalActions} ({progressPercentage:F2}%)";

                                    if (actionRepeat != action.RepeatCount - 1)
                                    {                                     
                                        if (actionRepeat != action.RepeatCount) message += $"\n  {LanguageManager.GetString(SAM.EXECUTE_MACRO_ASYNC_MACRO_PROGRESS)}: {completedMacros}/{totalMacros} ({((completedMacros / (double)totalMacros) * 100):F2}%)";
                                        _printer.Print(message, LogLevel.Info, false);
                                    }                                               
                                }
                            }
                            completedMacros++;
                            message += $"\n  {LanguageManager.GetString(SAM.EXECUTE_MACRO_ASYNC_ACTION_PROGRESS)}: {completedMacros}/{totalMacros} ({((completedMacros / (double)totalMacros) * 100):F2}%)";
                            _printer.Print(message, LogLevel.Info, false);
                        }
                    }                  
                }

                stopwatch.Stop();
                _printer.Print(SAM.EXECUTE_MACRO_ASYNC_MACRO_COMPLETED);
            }
            catch (OperationCanceledException)
            {
                stopwatch.Stop();
                _printer.Print(SAM.EXECUTE_MACRO_ASYNC_MACRO_INTERRUPTED);
            }
        }
       
        public async Task<List<string>> LoadMacroFromDBAsync()
        {
            //List<Macro> macros = macroStorageManager.LoadMacros();
            List<Macro> macros = await macroStorageManager.LoadMacroAsync();

            // Добавяне към реялния списък с всички макрота готови за употреба
            macros.ForEach(macro => macrosList.Add(macro));

            return macros.Select(m => m.Name).ToList();
        }

        public async Task<bool> SaveMacroToDBAsync(Macro macro)
        {
            // Зареждане на текущия списък с макрота
            List<Macro> macros = await macroStorageManager.LoadMacroAsync();

            // Проверка дали вече макрото не съществува в записите
            Macro macroToCheck = macros.Find(m => m.Name == macro.Name);

            if (macroToCheck != null) return false;

            // Добавяне на новото макро към стария списък от Jsona
            macros.Add(macro);

            // запазване на макротата в Json списъка
            return await macroStorageManager.SaveMacros(macros);
        }

        public async Task<bool> DeleteMacroFromDBAsync(string macroName)
        {
            // Зареждане на текущия списък с макрота
            List<Macro> macros = await macroStorageManager.LoadMacroAsync();         

            // Проверка дали макрото въобще съществува в записите
            Macro macroForDelete = macros.Find(m => m.Name == macroName);

            if (macroForDelete == null) return false;

            // Изтриване на макрото от Json списъка
            return await macroStorageManager.DeleteMacro(macroForDelete);
        }

        public void ResetCancellationToken()
        {
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public void OnStopClick2() => StopExecution();

        public void StopExecution() => _cancellationTokenSource.Cancel();

        public void OnAllMacroToExecuteClick() => isAllMacrosFromListToExecution = !isAllMacrosFromListToExecution;  
        
        public void ChangeSavePath()
        {
            macroStorageManager.SetNewSavePath();
        }

        public bool CheckPathFile()
        {
            return macroStorageManager.CheckValidPath();
        }
    }
}
