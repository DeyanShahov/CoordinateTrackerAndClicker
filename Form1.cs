using CoordinateTrackerAndClicker.Core.Models;
using CoordinateTrackerAndClicker.Core.Services;
using CoordinateTrackerAndClicker.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CoordinateTrackerAndClicker
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out Point lpPoint);

        private bool isRecording = false;
        private bool isRecordingOn = false;
        private Point currentCoordinate = new Point();
        private List<Point> clickHistory = new List<Point>();
        private Point lastCoordinate = new Point();

        private readonly MouseHook _mouseHook;
        private readonly MouseTracker _mouseTracker;

        public Timer autoClickTimer;

        private MacroService macroService;
        private readonly PrintText printer;
        private readonly Printer _printer;
        private readonly ButtonHandler buttonHandler;

        private List<NumericUpDown> numericUpDownsForMacrosToExecute = new List<NumericUpDown>();

        public Form1()
        {
            macroService = new MacroService();
            printer = new PrintText();
            buttonHandler = new ButtonHandler();

            _mouseHook = new MouseHook();
            _mouseTracker = new MouseTracker();

            _mouseHook.OnMouseClick += OnGlobalMouseClick;
            _mouseTracker.OnPositionChanged += MouseTrackTimer_Tick;

            InitializeComponent();

            _printer = new Printer((message, fontSize, logLevel) =>
            {
                StatusLabel.Text = message;
                LogMessagePrint(message, logLevel);
            });

            InitializeButtonsBehavior();

            cmbActionType.SelectedIndex = 0;
        }

        private void LogMessagePrint(string message, LogLevel logLevel)
        {
            Color color;
            switch (logLevel)
            {
                case LogLevel.Info:
                    color = Color.Black;
                    break;
                case LogLevel.Success:
                    color = Color.Green;
                    break;
                case LogLevel.Error:
                    color = Color.Red;
                    break;
                default:
                    color = Color.Black;
                    break;
            };

            richTextBoxLogInfo.SelectionStart = richTextBoxLogInfo.Text.Length;
            richTextBoxLogInfo.SelectionLength = 0;
            richTextBoxLogInfo.SelectionColor = color;

            string formattedMessage;
            switch (logLevel)
            {
                case LogLevel.Info:
                    formattedMessage = $"Info: {message}";
                    break;
                case LogLevel.Success:
                    formattedMessage = $"Success: {message}";
                    break;
                case LogLevel.Error:
                    formattedMessage = $"Error: {message}";
                    break;
                default:
                    formattedMessage = $"Info: {message}";
                    break;
            };


            richTextBoxLogInfo.AppendText(Environment.NewLine + formattedMessage);
            richTextBoxLogInfo.SelectionColor = richTextBoxLogInfo.ForeColor;

            richTextBoxLogInfo.ScrollToCaret();
        }

        private void AddLogMessage(string message, Color color)
        {
            richTextBoxLogInfo.SelectionStart = richTextBoxLogInfo.Text.Length;
            richTextBoxLogInfo.SelectionLength = 0;
            richTextBoxLogInfo.SelectionColor = color;
            richTextBoxLogInfo.AppendText(message + Environment.NewLine);
            richTextBoxLogInfo.SelectionColor = richTextBoxLogInfo.ForeColor;
        }

        private void InitializeButtonsBehavior()
        {
            try
            {
                buttonHandler.AddNewButton(btnStartRecording, new Button[] { btnStartRecording }, new Button[] { btnStopRecording });
                buttonHandler.AddNewButton(btnStopRecording, new Button[] { btnStopRecording }, new Button[] { btnStartRecording, btnAddAction });
                buttonHandler.AddNewButton(btnAddAction, new Button[] { btnAddAction }, new Button[] { btnCreateMacro });
                buttonHandler.AddNewButton(btnCreateMacro, new Button[] { btnCreateMacro, btnActionDelete }, new Button[] { btnExecuteMacro });
                buttonHandler.AddNewButton(btnExecuteMacro, new Button[] { btnExecuteMacro }, new Button[] { btnPauseMacro, btnStopMacro });
                buttonHandler.AddNewButton(btnPauseMacro, new Button[] { btnPauseMacro }, new Button[] { btnContinueMacro });
                buttonHandler.AddNewButton(btnContinueMacro, new Button[] { btnContinueMacro }, new Button[] { btnPauseMacro });
                buttonHandler.AddNewButton(btnStopMacro, new Button[] { btnStopMacro, btnPauseMacro, btnContinueMacro }, new Button[] { btnExecuteMacro });
                buttonHandler.AddNewButton(lstAvailableActions, new Button[] { }, new Button[] { btnActionDelete });
                buttonHandler.AddNewButton(lstMacrosForExecute, new Button[] { }, new Button[] { btnMacroForExecuteDelete });
            }
            catch (Exception ex)
            {
                _printer.Print("Грешка при добавяне на поведение към бутоните. " + ex.Message, LogLevel.Error);
            }          
        }

        private void MouseTrackTimer_Tick(Point mousePoint)
        {
            btnStopRecording.MouseEnter += (s, e) => isRecording = false;
            btnStopRecording.MouseLeave += (s, e) => isRecording = true;

            if (isRecording && isRecordingOn)
            {
                Point point;
                if (GetCursorPos(out point))
                {
                    currentCoordinate = new Point(point.X, point.Y);
                    CurrentPositionLabel.Text = $"Текуща позиция: X : {currentCoordinate.X} Y : {currentCoordinate.Y}";
                }
            }
        }


        private void OnGlobalMouseClick(Point clickPoint)
        {                   
            if (isRecording && isRecordingOn)
            {
                clickHistory.Add(clickPoint);
                currentCoordinate = clickPoint;
                UpdateCurrentPositionLabel(clickPoint);
                UpdateLastClickLabel(true);
                _printer.Print("Отчетени нови кординати", LogLevel.Info);
            }
        }

        private void UpdateLastClickLabel(bool fromMouseClick)
        {          
            if (clickHistory.Count > 0)
            {
                int clickCounts = clickHistory.Count;
                lastCoordinate = clickHistory[clickCounts - 1];
                LastClickLabel.Text = $"Последно кликане: X : {lastCoordinate.X}  Y = {lastCoordinate.Y}";
            }
        }

        private void SaveLastValidCoordinate()
        {
            if (clickHistory.Count > 0)
            {               
                int clickCounts = clickHistory.Count;
                lastCoordinate = clickHistory[clickCounts - 1];

                UpdateCoordinatesBoxes(lastCoordinate);
                UpdateLastClickLabel(false);
            }
        }

        private void UpdateCoordinatesBoxes(Point lastClick)
        {
            txtX.Text = lastClick.X.ToString();
            txtY.Text = lastClick.Y.ToString();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            buttonHandler.ClickButtonMechanicsExecute(sender);
            isRecording = true;
            isRecordingOn = true;
            clickHistory.Clear();
            _mouseTracker.StartTracking();
            _printer.Print("Следене на кординатите в процес ...", LogLevel.Info);
            //_printer.Print("🐇");
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            buttonHandler.ClickButtonMechanicsExecute(sender);
            SaveLastValidCoordinate();
            isRecording = false;
            isRecordingOn = false;
            _printer.Print(
                clickHistory.Any() ? "Заредени кординати за действие" : "Няма записани кординати",
                clickHistory.Any() ? LogLevel.Info : LogLevel.Error);
            clickHistory.Clear();
            _mouseTracker.StopTracking();
        }

        // UI ... 
        private void ResetButton_Click(object sender, EventArgs e)
        {
            isRecording = false;
            currentCoordinate = new Point();
            //StartButton.Enabled = true;
            btnStopRecording.Enabled = false;
            clickHistory.Clear();
            CurrentPositionLabel.Text = "Текуща позиция: ";
            _printer.Print(string.Empty);
        }

        // UI
        private void UpdateCurrentPositionLabel(Point point)
        {
            CurrentPositionLabel.Text = $"Текуща позиция: X={point.X}, Y={point.Y}";
        }

        private void btnAddAction_Click(object sender, EventArgs e)
        {
            if (txtX.Text == string.Empty || txtY.Text == string.Empty)
            {
                _printer.Print("Няма записани кординати в полетата", LogLevel.Error);
                return;
            }

            if (String.IsNullOrWhiteSpace(textBoxActionName.Text))
            {
                _printer.Print("Няма въведено име за Дайствието", LogLevel.Error);
                return;
            }

            buttonHandler.ClickButtonMechanicsExecute(sender);

            // Add to the macro's action list 
            macroService.AddAction(textBoxActionName.Text, lastCoordinate, (MouseActionType)cmbActionType.SelectedIndex,
                Convert.ToInt32(numericDelay.Value), Convert.ToInt32(numericDelayBefore.Value), chkReturnMouseToOriginal.Checked,
                Convert.ToInt32(FrequencyInput.Value), Convert.ToInt32(DurationInput.Value), Convert.ToInt32(CountInput.Value));

            // Refresh the UI to show the new action
            lstAvailableActions.Items.Add(textBoxActionName.Text);
            ClearAllVisualMessages();

            _printer.Print("Успешно добавяне към списъка с действия.", LogLevel.Success);
        }

        private void btnCreateMacro_Click(object sender, EventArgs e)
        {
            // Спира изпълнението ако няма добавени действия
            if (lstAvailableActions.Items.Count == 0)
            {
                _printer.Print("Няма Действия в списъка.", LogLevel.Error);
                return;
            }

            if (String.IsNullOrWhiteSpace(textBoxMacroName.Text) || String.IsNullOrEmpty(textBoxMacroName.Text))
            {
                _printer.Print("Името на Макрото е невалидно.", LogLevel.Error);
                return;
            }

            try
            {
                string macroName = macroService.CreateMacro(textBoxMacroName.Text);

                buttonHandler.ClickButtonMechanicsExecute(sender);

                lstAvailableMacros.Items.Add(macroName); // Refresh the macro list display

                lstAvailableActions.Items.Clear(); // Clear the work action list after macro create

                lstAvailableMacros.TopIndex = lstAvailableMacros.Items.Count - 1; // Scroll to bottom of list if is necessary 

                _printer.Print("Успешно добавяне към наличните макрота.", LogLevel.Success);
            }
            catch (Exception ex)
            {
                _printer.Print(ex.Message, LogLevel.Error);
            }         
        }

        private void lstMacros_SelectedIndexChanged(object sender, EventArgs e)
            => textBoxDisplayMacroInfo.Text = printer.DisplayMacroInfo(macroService.macrosList[lstAvailableMacros.SelectedIndex]);


        private void lstMacrosForExecute_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMacrosForExecute.Items.Count == 0 || lstMacrosForExecute.SelectedIndex == -1) return;

            buttonHandler.ClickButtonMechanicsExecute(sender);
        }

        private void lstAvailableMacros_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            lstMacrosForExecute.Items.Add((string)lstAvailableMacros.SelectedItem);
            AddNumericUpDown(lstMacrosForExecute.Items.Count - 1);
            lstMacrosForExecute.TopIndex = lstMacrosForExecute.Items.Count - 1; // Scroll to bottom of list if is necessary
        }

        private void AddNumericUpDown(int index)
        {
            NumericUpDown numericUpDown = new NumericUpDown();
            numericUpDown.Minimum = 1;
            numericUpDown.Maximum = 100;
            numericUpDown.Value = 1;
            numericUpDown.Width = 50;
            numericUpDown.Location = new Point(
                lstMacrosForExecute.Right + 10,
                lstMacrosForExecute.Top + (index * lstMacrosForExecute.ItemHeight) + 5);
            numericUpDownsForMacrosToExecute.Add(numericUpDown);
            this.Controls.Add(numericUpDown);
        }

        private void lstActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAvailableActions.Items.Count == 0 || lstAvailableActions.SelectedIndex == -1) return;

            labelDisplayActionInfo.Text = printer.DisplayActionInfo(macroService.currentActionsList[lstAvailableActions.SelectedIndex]);
            buttonHandler.ClickButtonMechanicsExecute(sender);
        }

        private void btnExecuteMacro_Click(object sender, EventArgs e)
        {
            // Спира изпълнението ако няма добавени макрота
            if (lstAvailableMacros.Items.Count == 0)
            {
                _printer.Print("Няма Макро в списъка", LogLevel.Error);
                return;
            }

            // Ако няма избрарно макро от списъка с налични макрота, автоматично маркирва и избира първото ( индекс 0 )
            int currentSelectedIndex1 = lstAvailableMacros.SelectedIndex;
            if (currentSelectedIndex1 == -1) { lstAvailableMacros.SelectedIndex = 0; currentSelectedIndex1 = 0; }
            

            // Ако няам добаевно макро за изпълнение добавя маркираното макро от списъка с макрота
            if (lstMacrosForExecute.Items.Count == 0)
            {
                lstMacrosForExecute.Items.Add((string)lstAvailableMacros.SelectedItem);
            }
            // Ако няма избрарно макро от списъка за изпълнения на макрота, автоматично маркирва и избира първото ( индекс 0 )
            int currentSelectedMacroToExecuteIndex = lstMacrosForExecute.SelectedIndex;
            //if (currentSelectedMacroToExecuteIndex == -1) { lstMacrosForExecute.SelectedIndex = 0; currentSelectedMacroToExecuteIndex = 0; }
            if (lstMacrosForExecute.SelectedIndex == -1) 
            {
                if (lstAvailableMacros.SelectedIndex == -1)
                {
                    lstMacrosForExecute.SelectedIndex = 0;
                }
                else
                {
                    //lstMacrosForExecute.SelectedIndex = 
                }

                lstMacrosForExecute.SelectedIndex = 0; 
                currentSelectedMacroToExecuteIndex = 0;
            }

            try
            {              
                // Създаване на AutoClicker и абониране за събитието
                autoClickTimer = new Timer();
                macroService.TimerStopped += AutoClicker_TimerStopped;

                if (chkAllMacrosToExecute.Checked)
                {
                    List<KeyValuePair<string, int>> macrosNameRepeatList = new List<KeyValuePair<string, int>>();

                    for (int i = 0; i < lstMacrosForExecute.Items.Count; i++)
                    {
                        macrosNameRepeatList.Add(new KeyValuePair<string, int>(
                            (string)lstMacrosForExecute.Items[i],
                            (int)numericUpDownsForMacrosToExecute[i].Value));
                    }

                    macroService.ExecuteMacro(
                        autoClickTimer,
                        macrosNameRepeatList,
                        (int)countAllMacroRepeat.Value);
                }
                else 
                {
                    macroService.ExecuteMacro(
                        autoClickTimer,
                        (string)lstMacrosForExecute.SelectedItem,
                        (int)numericUpDownsForMacrosToExecute[lstMacrosForExecute.SelectedIndex].Value,
                        (int)countAllMacroRepeat.Value);
                }            

                // Стартиране механика на бутона
                buttonHandler.ClickButtonMechanicsExecute(sender);

                _printer.Print("Автоматично кликане в прогрес...", LogLevel.Info);
            }
            catch (Exception)
            {
                _printer.Print("Няма такова Макро за изпълнение!!!", LogLevel.Error);
            }           
        }

        private void AutoClicker_TimerStopped(object sender, EventArgs e)
        {
            // Актуализиране на UI
            Invoke(new Action(() =>
            {
                _printer.Print("Автоматичното кликане приключи.", LogLevel.Info);
                buttonHandler.ClickButtonMechanicsExecute(btnStopMacro);
            }));
        }

        private void ClearAllVisualMessages()
        {
            CurrentPositionLabel.Text = "Текуща позиция: ";
            LastClickLabel.Text = "Последно кликане: ";
            txtX.Text = string.Empty;
            txtY.Text = string.Empty;
        }

        private void btnPauseMacro_Click(object sender, EventArgs e)
        {
            macroService.OnPauseClick();
            buttonHandler.ClickButtonMechanicsExecute(sender);
            _printer.Print("Пауза ...", LogLevel.Info);
        }

        private void btnContinueMacro_Click(object sender, EventArgs e)
        {
            macroService.OnContinueClick();
            buttonHandler.ClickButtonMechanicsExecute(sender);
            _printer.Print("Автоматично кликане в прогрес ...", LogLevel.Info);
        }

        private void btnStopMacro_Click(object sender, EventArgs e)
        {
            macroService.OnStopClick(autoClickTimer);
            buttonHandler.ClickButtonMechanicsExecute(sender);
            _printer.Print("Автоматичното кликане беше спряно.", LogLevel.Info);
        }

        private void btnActionDelete_Click(object sender, EventArgs e)
        {
            if (lstAvailableActions.Items.Count <= 0)
            {
                _printer.Print("Списъка с Действия е празен, няма елементи за премахване.", LogLevel.Error);
                return;
            }

            if(lstAvailableActions.SelectedIndex == - 1)
            {
                _printer.Print("Няма избрано Действие за премахване от списъка.", LogLevel.Error);
                return;
            }

            int index = lstAvailableActions.SelectedIndex; // Индекс на маркираното действие
            lstAvailableActions.SelectedItems.Clear(); // Демаркирване на избрания елемент от списъка
            macroService.RemoveAction(index); // Премахване на елемент със същия индекс от работната колекция
            lstAvailableActions.Items.RemoveAt(index); // Премахване на визуалния елемент от списъка
            btnActionDelete.Enabled = false; // Деактивирване на бутона за триене

            _printer.Print("Премахнато Дейаствие от списъка за добавяне.", LogLevel.Success);
        }

        private void btnMacroForExecuteDelete_Click(object sender, EventArgs e)
        {
            if (lstMacrosForExecute.Items.Count <= 0)
            {
                _printer.Print("Списъка с Макрота е празен, няма елементи за премахване.", LogLevel.Error);
                return;
            }

            if (lstMacrosForExecute.SelectedIndex == -1)
            {
                _printer.Print("Няма избрано Макро за премахване от списъка.", LogLevel.Error);
                return;
            }

            int selectedMacroIndex = lstMacrosForExecute.SelectedIndex; // Индекс на маркираното макро
            lstMacrosForExecute.Items.RemoveAt(selectedMacroIndex); // Премахване на визуалния елемент от списъка

            // Изтриване на съответния NumericUpDown
            NumericUpDown numericUpDownToRemove = numericUpDownsForMacrosToExecute[selectedMacroIndex];
            this.Controls.Remove(numericUpDownToRemove);
            numericUpDownsForMacrosToExecute.RemoveAt(selectedMacroIndex);

            btnMacroForExecuteDelete.Enabled = false; //Деактивирване на бутона за триене

            // Препозициониране на останалите NumericUpDown контроли
            for (int i = selectedMacroIndex; i < numericUpDownsForMacrosToExecute.Count; i++)
            {
                numericUpDownsForMacrosToExecute[i].Location = new Point(
                    lstMacrosForExecute.Right + 10,
                    lstMacrosForExecute.Top + (i * lstMacrosForExecute.ItemHeight) + 5);
            }

            _printer.Print("Премахнато Макро от списъка за изпълнение.", LogLevel.Success);
        }

        private void btnMoveUpAction_Click(object sender, EventArgs e)
        {
            if (lstAvailableActions.SelectedIndex == 0 || lstAvailableActions.Items.Count == 0 || lstAvailableActions.SelectedIndex == -1) return;

            SwapElementsInListBox(lstAvailableActions, lstAvailableActions.SelectedIndex, true);
            macroService.ChangeActionPosition(lstAvailableActions.SelectedIndex, true);
            lstAvailableActions.SelectedIndex --;

        }

        private void btnMoveDownAction_Click(object sender, EventArgs e)
        {
            if (lstAvailableActions.SelectedIndex == lstAvailableActions.Items.Count - 1 || lstAvailableActions.Items.Count == 0 || lstAvailableActions.SelectedIndex == -1) return;

            SwapElementsInListBox(lstAvailableActions, lstAvailableActions.SelectedIndex, false);
            macroService.ChangeActionPosition(lstAvailableActions.SelectedIndex, false);
            lstAvailableActions.SelectedIndex ++;
        }

        private static void SwapElementsInListBox(ListBox list, int index, bool isMoveUp)
        {
            var temp = list.Items[index];
            int targetElementIndexToSwap = index + (isMoveUp ? -1 : +1);
            list.Items[index] = list.Items[targetElementIndexToSwap];
            list.Items[targetElementIndexToSwap] = temp;
        }

        private void SwapNumericUpDown(ListBox list, int index, bool isMoveUp)
        {
            int targetElementIndexToSwap = index + (isMoveUp ? -1 : +1);

            // Разменяне на NumericUpDown контролите
            var tempNumericUpDown = numericUpDownsForMacrosToExecute[index];
            numericUpDownsForMacrosToExecute[index] = numericUpDownsForMacrosToExecute[targetElementIndexToSwap];
            numericUpDownsForMacrosToExecute[targetElementIndexToSwap] = tempNumericUpDown;

            // Препозициониране на NaumericUpDown контролите
            numericUpDownsForMacrosToExecute[index].Location = new Point(
                list.Right + 10,
                list.Top + (index * list.ItemHeight) + 5);
            numericUpDownsForMacrosToExecute[targetElementIndexToSwap].Location = new Point(
                list.Right + 10,
                list.Top + (targetElementIndexToSwap * list.ItemHeight) + 5);
        }

        private void btnMoveUpMacro_Click(object sender, EventArgs e)
        {
            if (lstMacrosForExecute.SelectedIndex == 0 || lstMacrosForExecute.Items.Count == 0 || lstMacrosForExecute.SelectedIndex == -1) return;

            SwapElementsInListBox(lstMacrosForExecute, lstMacrosForExecute.SelectedIndex, true);
            SwapNumericUpDown(lstMacrosForExecute, lstMacrosForExecute.SelectedIndex, true);
            lstMacrosForExecute.SelectedIndex--;
        }

        private void btnMoveDownMacro_Click(object sender, EventArgs e)
        {
            if (lstMacrosForExecute.SelectedIndex == lstMacrosForExecute.Items.Count - 1 || lstMacrosForExecute.Items.Count == 0 || lstMacrosForExecute.SelectedIndex == -1) return;

            SwapElementsInListBox(lstMacrosForExecute, lstMacrosForExecute.SelectedIndex, false);
            SwapNumericUpDown(lstMacrosForExecute, lstMacrosForExecute.SelectedIndex, false);
            lstMacrosForExecute.SelectedIndex++;
        }

        private void chkAllMacrosToExecute_CheckedChanged(object sender, EventArgs e)
        {
            macroService.OnAllMacroToExecuteClick();
            _printer.Print(
                chkAllMacrosToExecute.Checked ? "Всички Макрота от списъка са за изпълнение." : "Само избраното макро ще баде изпалнено.",
                LogLevel.Info);
        }
    }
}
