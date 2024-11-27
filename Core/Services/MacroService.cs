using CoordinateTrackerAndClicker.Core.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace CoordinateTrackerAndClicker.Core.Services
{
    internal class MacroService : IMacroService
    {
        public event EventHandler TimerStopped;// Събитие, което уведомява за спиране

        private readonly MouseActionExecutor actionExecutor;
        public List<Macro> macrosList;
        public List<MouseAction> currentActionsList;
        private Macro currentMacro;

        private DateTime endTime;
        private int currentActionIndex = 0;
        private int countActionRepeat;

        private Macro macroToExecute;

        public MacroService()
        {
            macrosList = new List<Macro>();
            currentActionsList = new List<MouseAction>();
            actionExecutor = new MouseActionExecutor();
        }


        public string CreateMacro(string macroName)
        {
            currentMacro = new Macro 
            {
                Name = macroName,
                Actions = currentActionsList
            };
            macrosList.Add(currentMacro.Clone());

            currentActionsList.Clear();
            currentMacro = new Macro();

            return macroName;
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

        public void RemoveAction(MouseAction action)
        {
            throw new NotImplementedException();
        }

        public void ExecuteMacro(Timer autoClickTimer,int macroIndex, int macroRepeatCount = 1)
        {           
            macroToExecute = macrosList[macroIndex];
            macroToExecute.RepeatCount = macroRepeatCount;

            endTime = DateTime.Now.AddMinutes(macroToExecute.Actions[currentActionIndex].Duration);
            countActionRepeat = macroToExecute.Actions[currentActionIndex].RepeatCount;

            autoClickTimer.Interval = macroToExecute.Actions[currentActionIndex].Frequency * 1000; // Convert to milliseconds
            autoClickTimer.Tick += AutoClickTimer_Tick;
            autoClickTimer.Start();
        }

        public Macro LoadMacro(string name)
        {
            return new Macro();
        }

        public void SaveMacro(Macro macro)
        {
            throw new NotImplementedException();
        }

        private void AutoClickTimer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now >= endTime || countActionRepeat <= 0)
            {
                currentActionIndex++;

                if (macroToExecute.Actions.Count <= currentActionIndex)
                {
                    macroToExecute.RepeatCount--;
                    currentActionIndex = 0;

                    if (macroToExecute.RepeatCount <= 0)
                    {
                        ((Timer)sender).Stop();
                        
                        // Изпращане на уведомление
                        OnTimerStopped();
                        
                        return;
                    }
                }

                endTime = DateTime.Now.AddMinutes(macroToExecute.Actions[currentActionIndex].Duration);
                countActionRepeat = macroToExecute.Actions[currentActionIndex].RepeatCount;
                //autoClickTimer.Interval = macroToExecute.Actions[currentActionIndex].Frequency * 1000;
            }

            // Избор на крайно дейстрие          
            actionExecutor.Execute(macroToExecute.Actions[currentActionIndex]);

            // Намаля максималния брои на повторения
            countActionRepeat--;
        }

        protected virtual void OnTimerStopped()
        {
            // Проверка дали има абонирани слушатели
            TimerStopped?.Invoke(this, EventArgs.Empty);
        }
    }
}
