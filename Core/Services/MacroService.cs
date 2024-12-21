using CoordinateTrackerAndClicker.Core.Models;
using CoordinateTrackerAndClicker.Db_Json;
using CoordinateTrackerAndClicker.Utils;
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
        public List<MouseAction> currentActionsList;
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
            _storageStrategy = new JsonDataStorage();
            //Инициялизиране на записващия мениджер
            macroStorageManager = new MacroStorageManager(_storageStrategy);
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

        public void RemoveMacro(int macroIndex)
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

        public async Task ExecuteMacroAsync(Printer _printer, List<KeyValuePair<string, int>> macrosNameList, int macroAllRepeatCount = 1)
        {
            ResetCancellationToken();
            int totalActions = 0;
            int totalDurationMs = 0;
            int estemidateTimeToExecute = 0;
            int completedActions = 0;

            List<Macro> macros = new List<Macro>();

            foreach (var element in macrosNameList)
            {
                Macro macro = macrosList.FirstOrDefault(m => m.Name == element.Key);
                macro.RepeatCount = element.Value;
                macros.Add(macro);

                totalActions += macro.Actions.Sum(action => action.RepeatCount) * macro.RepeatCount * macroAllRepeatCount;
                totalDurationMs += macro.Actions.Sum(action
                    => action.Duration * 60 * 1000)
                    * element.Value
                    * macroAllRepeatCount;
                estemidateTimeToExecute += macro.Actions.Sum(action
                    => action.RepeatCount * (action.Frequency * 1000 + action.DelayBefore + action.DelayAfter))
                    * element.Value
                    * macroAllRepeatCount;
            }          

            _printer.Print($"Повторения: {totalActions} - " +
                $"Продължителност: {TimeSpan.FromMilliseconds(totalDurationMs):hh\\:mm\\:ss} - " +
                $"Очаквана продалжителност: {TimeSpan.FromMilliseconds(estemidateTimeToExecute):hh\\:mm\\:ss}", LogLevel.Info);

            Stopwatch stopwatch = Stopwatch.StartNew();

            try
            {
                for (int macroAllRepeat = 0; macroAllRepeat < macroAllRepeatCount; macroAllRepeat++)
                {
                    foreach (var macro in macros)
                    {
                        for (int macroRepeat = 0; macroRepeat < macro.RepeatCount; macroRepeat++)
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
    }
}
