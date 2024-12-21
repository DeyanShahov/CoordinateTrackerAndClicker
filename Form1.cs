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
        private readonly List<Point> clickHistory = new List<Point>();
        private Point lastCoordinate = new Point();
        private bool isSommeCommandIsActive = false;

        private readonly MouseHook _mouseHook;
        private readonly MouseTracker _mouseTracker;

        private readonly MacroService macroService;
        private readonly PrintText printer;
        private readonly Printer _printer;
        private readonly ButtonHandler buttonHandler;

        private readonly List<NumericUpDown> numericUpDownsForMacrosToExecute = new List<NumericUpDown>();

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

            LoadSavedMacros();
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
            if (clickPoint == null) return;

            if (isRecording && isRecordingOn)
            {
                clickHistory.Add(clickPoint);
                currentCoordinate = clickPoint;
                UpdateCurrentPositionLabel(clickPoint);
                UpdateLastClickLabel();
                _printer.Print("Отчетени нови кординати", LogLevel.Info);
            }
        }

        private void UpdateLastClickLabel()
        {          
            if (clickHistory.Count <= 0) return;
           
            int clickCounts = clickHistory.Count;
            lastCoordinate = clickHistory[clickCounts - 1];
            LastClickLabel.Text = $"Последно кликане: X : {lastCoordinate.X}  Y = {lastCoordinate.Y}";           
        }

        private void SaveLastValidCoordinate()
        {
            if (clickHistory.Count <= 0) return;
                         
            int clickCounts = clickHistory.Count;
            lastCoordinate = clickHistory[clickCounts - 1];

            UpdateCoordinatesBoxes(lastCoordinate);
            UpdateLastClickLabel();         
        }

        private void UpdateCoordinatesBoxes(Point lastClick)
        {
            if (lastClick == null) return;

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

        private void UpdateCurrentPositionLabel(Point point)
        {
            if (point == null) return;

            CurrentPositionLabel.Text = $"Текуща позиция: X={point.X}, Y={point.Y}";
        }

        private void BtnAddAction_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtX.Text)|| String.IsNullOrEmpty(txtY.Text))
            {
                _printer.Print("Няма записани кординати в полетата", LogLevel.Error);
                return;
            }         

            if (IsNameInvalid(textBoxActionName.Text)) return;

            buttonHandler.ClickButtonMechanicsExecute(sender);

            // Add to the macro's action list 
            macroService.AddAction(textBoxActionName.Text, lastCoordinate, (MouseActionType)cmbActionType.SelectedIndex,
                Convert.ToInt32(numericDelay.Value), Convert.ToInt32(numericDelayBefore.Value), chkReturnMouseToOriginal.Checked,
                Convert.ToInt32(FrequencyInput.Value), Convert.ToInt32(DurationInput.Value), Convert.ToInt32(CountInput.Value));

            // Refresh the UI to show the new action
            lstAvailableActions.Items.Add(textBoxActionName.Text);
            lstAvailableActions.TopIndex = lstAvailableActions.Items.Count - 1; // Скрол до последния елемент
            ClearAllVisualMessages();

            _printer.Print("Успешно добавяне към списъка с действия.", LogLevel.Success);
        }

        private void BtnCreateMacro_Click(object sender, EventArgs e)
        {
            // Спира изпълнението       
            if (IsListEmpty(lstAvailableActions) || IsNameInvalid(textBoxMacroName.Text)) return;
          
            try
            {
                macroService.CreateMacro(textBoxMacroName.Text);

                buttonHandler.ClickButtonMechanicsExecute(sender);

                lstAvailableMacros.Items.Add("🗷 - " + textBoxMacroName.Text); // Refresh the macro list display

                lstAvailableActions.Items.Clear(); // Clear the work action list after macro create

                lstAvailableMacros.TopIndex = lstAvailableMacros.Items.Count - 1; // Scroll to bottom of list if is necessary 

                _printer.Print("Успешно добавяне към наличните макрота.", LogLevel.Success);
            }
            catch (Exception ex)
            {
                _printer.Print(ex.Message, LogLevel.Error);
            }
        }

        private void LstAvailableMacros_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!isSommeCommandIsActive)
            {
                if (IsListEmpty(lstAvailableMacros) || IsIndexNegative(lstAvailableMacros)) return;

                textBoxDisplayMacroInfo.Text = printer.DisplayMacroInfo(
                    macroService.macrosList[lstAvailableMacros.SelectedIndex],
                    lstAvailableMacros.SelectedItem.ToString().Contains("🗹"));

                btnExecuteMacro.Enabled = true;
            }
            isSommeCommandIsActive = false;        
        }       

        private void LstMacrosForExecute_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CheckForIncorrectCountOrIndex(lstMacrosForExecute)) return;

            buttonHandler.ClickButtonMechanicsExecute(sender);
        }

        private void LstAvailableMacros_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (CheckForIncorrectCountOrIndex(lstAvailableMacros)) return;

            // Проверка за максималния брои на елементи в списъка
            int maxMacrosInList = lstMacrosForExecute.Height / lstMacrosForExecute.ItemHeight;
            int currentMacrosInList = lstMacrosForExecute.Items.Count;

            if(maxMacrosInList <= currentMacrosInList)
            {
                _printer.Print("Списъка с макрота е пълен.", LogLevel.Error);
                return;
            }

            lstMacrosForExecute.Items.Add(lstAvailableMacros.SelectedItem.ToString().Remove(0,5));
            AddNumericUpDown(lstMacrosForExecute.Items.Count - 1);
            lstMacrosForExecute.TopIndex = lstMacrosForExecute.Items.Count - 1; // Scroll to bottom of list if is necessary
        }

        private void LstActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CheckForIncorrectCountOrIndex(lstAvailableActions)) return;

            labelDisplayActionInfo.Text = printer.DisplayActionInfo(macroService.currentActionsList[lstAvailableActions.SelectedIndex]);
            buttonHandler.ClickButtonMechanicsExecute(sender);
        }

        private async void BtnExecuteMacro_Click(object sender, EventArgs e)
        {
            // Спира изпълнението ако няма добавени макрота
            if (IsListEmpty(lstAvailableMacros)) return;

            // Ако няма избрарно макро от списъка с налични макрота, автоматично маркирва и избира първото ( индекс 0 )
            int currentSelectedIndex1 = lstAvailableMacros.SelectedIndex;
            if (currentSelectedIndex1 == -1) { lstAvailableMacros.SelectedIndex = 0; currentSelectedIndex1 = 0; }
            

            // Ако няам добаевно макро за изпълнение добавя маркираното макро от списъка с макрота
            if (lstMacrosForExecute.Items.Count == 0)
            {
                lstMacrosForExecute.Items.Add(lstAvailableMacros.SelectedItem.ToString().Remove(0,5));
            }
            // Ако няма избрарно макро от списъка за изпълнения на макрота, автоматично маркирва и избира първото ( индекс 0 )
            //int currentSelectedMacroToExecuteIndex = lstMacrosForExecute.SelectedIndex;
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
                //currentSelectedMacroToExecuteIndex = 0;
                AddNumericUpDown(0);
            }

            try
            {
                // Стартиране механика на бутона
                buttonHandler.ClickButtonMechanicsExecute(sender);

                _printer.Print("Автоматично кликане в прогрес...", LogLevel.Info);
                _printer.Print($"Стартирано е макро: {lstMacrosForExecute.SelectedItem}");

                List<KeyValuePair<string, int>> macrosNameRepeatList = new List<KeyValuePair<string, int>>();

                if (chkAllMacrosToExecute.Checked)
                {
                    for (int i = 0; i < lstMacrosForExecute.Items.Count; i++)
                    {
                        macrosNameRepeatList.Add(new KeyValuePair<string, int>(
                            (string)lstMacrosForExecute.Items[i],
                            (int)numericUpDownsForMacrosToExecute[i].Value));
                    }
                }
                else
                {
                    macrosNameRepeatList.Add(new KeyValuePair<string, int>(
                            (string)lstMacrosForExecute.SelectedItem,
                            (int)numericUpDownsForMacrosToExecute[lstMacrosForExecute.SelectedIndex].Value));
                }

                await macroService.ExecuteMacroAsync(
                    _printer,
                    macrosNameRepeatList,
                    (int)countAllMacroRepeat.Value);
            }
            catch (Exception ex)
            {
                BtnStopMacro_Click(btnStopMacro, null);
                _printer.Print("Няма такова Макро за изпълнение!!!", LogLevel.Error);
                _printer.Print(ex.Message, LogLevel.Error);
            }

            _printer.Print("Автоматичното кликане приключи.", LogLevel.Info);
            buttonHandler.ClickButtonMechanicsExecute(btnStopMacro);
        }

        private void ClearAllVisualMessages()
        {
            CurrentPositionLabel.Text = "Текуща позиция: ";
            LastClickLabel.Text = "Последно кликане: ";
            txtX.Text = string.Empty;
            txtY.Text = string.Empty;
        }           

        private void BtnStopMacro_Click(object sender, EventArgs e)
        {
            macroService.OnStopClick2();

            buttonHandler.ClickButtonMechanicsExecute(sender);
            _printer.Print("Автоматичното кликане беше спряно.", LogLevel.Info);
        }

        private void BtnActionDelete_Click(object sender, EventArgs e)
        {
            if (IsListEmpty(lstAvailableActions) || IsIndexNegative(lstAvailableActions)) return;        

            int index = lstAvailableActions.SelectedIndex; // Индекс на маркираното действие
            lstAvailableActions.SelectedItems.Clear(); // Демаркирване на избрания елемент от списъка
            macroService.RemoveAction(index); // Премахване на елемент със същия индекс от работната колекция
            lstAvailableActions.Items.RemoveAt(index); // Премахване на визуалния елемент от списъка
            btnActionDelete.Enabled = false; // Деактивирване на бутона за триене

            _printer.Print("Премахнато Дейаствие от списъка за добавяне.", LogLevel.Success);
        }

        private void BtnMacroForExecuteDelete_Click(object sender, EventArgs e)
        {
            if (IsListEmpty(lstMacrosForExecute) || IsIndexNegative(lstMacrosForExecute)) return;

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
                    lstMacrosForExecute.Top + (i * lstMacrosForExecute.ItemHeight) + 2);
            }

            _printer.Print("Премахнато Макро от списъка за изпълнение.", LogLevel.Success);
        }

        private void BtnMoveUpAction_Click(object sender, EventArgs e)
        {          
            if (lstAvailableActions.SelectedIndex == 0 || CheckForIncorrectCountOrIndex(lstAvailableActions)) return;

            SwapElementsInListBox(lstAvailableActions, lstAvailableActions.SelectedIndex, true);
            macroService.ChangeActionPosition(lstAvailableActions.SelectedIndex, true);
            lstAvailableActions.SelectedIndex --;
        }

        private void BtnMoveDownAction_Click(object sender, EventArgs e)
        {
            if (lstAvailableActions.SelectedIndex == lstAvailableActions.Items.Count - 1 || CheckForIncorrectCountOrIndex(lstAvailableActions)) return;

            SwapElementsInListBox(lstAvailableActions, lstAvailableActions.SelectedIndex, false);
            macroService.ChangeActionPosition(lstAvailableActions.SelectedIndex, false);
            lstAvailableActions.SelectedIndex ++;
        }      

        private void BtnMoveUpMacro_Click(object sender, EventArgs e)
        {
            if (lstMacrosForExecute.SelectedIndex == 0 || CheckForIncorrectCountOrIndex(lstMacrosForExecute)) return;

            SwapElementsInListBox(lstMacrosForExecute, lstMacrosForExecute.SelectedIndex, true);
            SwapNumericUpDown(lstMacrosForExecute, lstMacrosForExecute.SelectedIndex, true);
            lstMacrosForExecute.SelectedIndex--;
        }

        private void BtnMoveDownMacro_Click(object sender, EventArgs e)
        {
            if (lstMacrosForExecute.SelectedIndex == lstMacrosForExecute.Items.Count - 1 || CheckForIncorrectCountOrIndex(lstMacrosForExecute)) return;

            SwapElementsInListBox(lstMacrosForExecute, lstMacrosForExecute.SelectedIndex, false);
            SwapNumericUpDown(lstMacrosForExecute, lstMacrosForExecute.SelectedIndex, false);
            lstMacrosForExecute.SelectedIndex++;
        }

        private void ChkAllMacrosToExecute_CheckedChanged(object sender, EventArgs e)
        {
            macroService.OnAllMacroToExecuteClick();
            _printer.Print(
                chkAllMacrosToExecute.Checked ? "Всички Макрота от списъка са за изпълнение." : "Само избраното макро ще баде изпалнено.",
                LogLevel.Info);
        }


        //------------------------------------------------------
        private bool IsNameInvalid(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                _printer.Print("Невалидно име.", LogLevel.Error);
                return true;
            }

            return false;
        }

        private bool IsListEmpty(ListBox list)
        {
            if (list == null) return true;

            if (list.Items.Count == 0)
            {
                _printer.Print("Няма елементи в списъка.", LogLevel.Error);
                return true;
            }

            return false;
        }

        private bool CheckForIncorrectCountOrIndex(ListBox list)
        {
            if (list == null || list.Items.Count == 0 || list.SelectedIndex == -1 || list.SelectedIndex > list.Items.Count - 1) return true;

            return false;
        }

        private bool IsIndexNegative(ListBox list)
        {
            if (list.SelectedIndex == -1)
            {
                _printer.Print("Няма избран елемент за премахване от списъка.", LogLevel.Error);
                return true;
            }

            return false;
        }

        private void AddNumericUpDown(int index)
        {
            NumericUpDown numericUpDown = new NumericUpDown
            {
                Minimum = 1,
                Maximum = 100,
                Value = 1,
                Width = 50,
                Location = new Point(
                lstMacrosForExecute.Right + 10,
                lstMacrosForExecute.Top + (index * lstMacrosForExecute.ItemHeight) + 2)
            };
            numericUpDownsForMacrosToExecute.Add(numericUpDown);
            this.Controls.Add(numericUpDown);
        }

        private void SwapElementsInListBox(ListBox list, int index, bool isMoveUp)
        {
            if (list.Items.Count < 2 || index < 0 || index > list.Items.Count - 1) return;

            int targetElementIndexToSwap = index + (isMoveUp ? -1 : +1);

            var temp = list.Items[index];
            list.Items[index] = list.Items[targetElementIndexToSwap];
            list.Items[targetElementIndexToSwap] = temp;
        }

        private void SwapNumericUpDown(ListBox list, int index, bool isMoveUp)
        {
            if (list.Items.Count < 2 || index < 0 || index > list.Items.Count - 1) return;

            int targetElementIndexToSwap = index + (isMoveUp ? -1 : +1);

            // Разменяне на NumericUpDown контролите
            NumericUpDown tempNumericUpDown = numericUpDownsForMacrosToExecute[index];
            numericUpDownsForMacrosToExecute[index] = numericUpDownsForMacrosToExecute[targetElementIndexToSwap];
            numericUpDownsForMacrosToExecute[targetElementIndexToSwap] = tempNumericUpDown;

            // Препозициониране на NaumericUpDown контролите
            numericUpDownsForMacrosToExecute[index].Location = new Point(
                list.Right + 10,
                list.Top + (index * list.ItemHeight) + 2);
            numericUpDownsForMacrosToExecute[targetElementIndexToSwap].Location = new Point(
                list.Right + 10,
                list.Top + (targetElementIndexToSwap * list.ItemHeight) + 2);
        }    

        //--------------------------------------------------------

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

        private void InitializeButtonsBehavior()
        {
            try
            {
                buttonHandler.AddNewButton(btnStartRecording, new Button[] { btnStartRecording }, new Button[] { btnStopRecording });
                buttonHandler.AddNewButton(btnStopRecording, new Button[] { btnStopRecording }, new Button[] { btnStartRecording, btnAddAction });
                buttonHandler.AddNewButton(btnAddAction, new Button[] { btnAddAction }, new Button[] { btnCreateMacro });
                buttonHandler.AddNewButton(btnCreateMacro, new Button[] { btnCreateMacro, btnActionDelete }, new Button[] { btnExecuteMacro });
                buttonHandler.AddNewButton(btnExecuteMacro, new Button[] { btnExecuteMacro, btnMoveUpMacro, btnMoveDownMacro, btnMacroForExecuteDelete, btnMacroDelete }, new Button[] { btnStopMacro });   
                buttonHandler.AddNewButton(btnStopMacro, new Button[] { btnStopMacro }, new Button[] { btnExecuteMacro, btnMoveUpMacro, btnMoveDownMacro, btnMacroForExecuteDelete, btnMacroDelete });
                buttonHandler.AddNewButton(lstAvailableActions, new Button[] { }, new Button[] { btnActionDelete });
                buttonHandler.AddNewButton(lstMacrosForExecute, new Button[] { }, new Button[] { btnMacroForExecuteDelete });
            }
            catch (Exception ex)
            {
                _printer.Print("Грешка при добавяне на поведение към бутоните. " + ex.Message, LogLevel.Error);
            }
        }

        private async void LoadSavedMacros()
        {
            _printer.Print("Зареждане на макрота ...");
            var loadedMacrosName = await macroService.LoadMacroFromDBAsync();
            loadedMacrosName.ForEach(m => lstAvailableMacros.Items.Add("🗹 - " + m));
            _printer.Print(String.Join(", ", loadedMacrosName));
            _printer.Print("Макротата са заредени!");
        }

        private async void BtnMacroSave_Click(object sender, EventArgs e)
        {
            if (lstAvailableMacros.SelectedIndex == -1)
            {
                _printer.Print("Няма избрано Макро", LogLevel.Error);
                return;
            }

            var result = await macroService.SaveMacroToDBAsync(macroService.macrosList[lstAvailableMacros.SelectedIndex]);

            if (result)
            {
                isSommeCommandIsActive = true;
                string test = lstAvailableMacros.Items[lstAvailableMacros.SelectedIndex].ToString();
                lstAvailableMacros.Items[lstAvailableMacros.SelectedIndex] = test.Replace("🗷", "🗹");
                _printer.Print("Успешен запис в архива.", LogLevel.Success);
            }
            else
                _printer.Print("Има такова Макро в архива или Възникна грешка при записа.", LogLevel.Error);

            isSommeCommandIsActive = false;
        }     

        private async void BtnMacroDelete_Click(object sender, EventArgs e)
        {
            if (lstAvailableMacros.SelectedIndex == -1)
            {
                _printer.Print("Няма избрано Макро", LogLevel.Error);
                return;
            }

            var result = await macroService.DeleteMacroFromDBAsync(lstAvailableMacros.SelectedItem.ToString().Remove(0,5));

            if (result)
            {
                if (IsListEmpty(lstAvailableMacros) || IsIndexNegative(lstAvailableMacros)) return;

                string test = lstAvailableMacros.SelectedItem.ToString().Remove(0, 5);
                for (int i = 0; i < lstMacrosForExecute.Items.Count; i++)
                {
                    if (lstMacrosForExecute.Items[i].ToString() == test)
                    {
                        lstMacrosForExecute.Items.RemoveAt(i); // Премахване на визуалния елемент от списъка

                        // Изтриване на съответния NumericUpDown
                        NumericUpDown numericUpDownToRemove = numericUpDownsForMacrosToExecute[i];
                        this.Controls.Remove(numericUpDownToRemove);
                        numericUpDownsForMacrosToExecute.RemoveAt(i);

                        btnMacroForExecuteDelete.Enabled = false; // Деактивирване на бутона за триене

                        // Препозициониране на останалите NumericUpDown контроли
                        for (int x = i; x < numericUpDownsForMacrosToExecute.Count; x++)
                        {
                            numericUpDownsForMacrosToExecute[x].Location = new Point(
                                lstMacrosForExecute.Right + 10,
                                lstMacrosForExecute.Top + (x * lstMacrosForExecute.ItemHeight) + 5);
                        }

                        // При триене в работещ цикъл, се връща един индекс назад инак се оплита индексацията
                        i--;
                    }
                }

                // Стартира флага за команда
                isSommeCommandIsActive = true;

                int index = lstAvailableMacros.SelectedIndex; // Индекс на маркираното действие
                lstAvailableMacros.SelectedItems.Clear(); // Демаркирване на избрания елемент от списъка
                lstAvailableMacros.Items.RemoveAt(index); // Премахване на визуалния елемент от списъка
                textBoxDisplayMacroInfo.Clear(); // Изчиства инфото за изтритото макро
                macroService.RemoveMacro(index); // Премахване на елемент със същия индекс от работната колекция

                _printer.Print("Uspeshen delete", LogLevel.Success);
            }        
            else
                _printer.Print("Neuspeshna zaqwka", LogLevel.Error);

            // Спира флага на команда
            isSommeCommandIsActive = false;
            // Спира бутона за изпълнение ако няма записи в листа с възможните макрота
            if(lstAvailableMacros.Items.Count == 0) btnExecuteMacro.Enabled = false;
        }
    }
}
