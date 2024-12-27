using MaterialSkin;
using MaterialSkin.Controls;
using CoordinateTrackerAndClicker.Core.Models;
using CoordinateTrackerAndClicker.Core.Services;
using CoordinateTrackerAndClicker.Db_Json;
using CoordinateTrackerAndClicker.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CoordinateTrackerAndClicker.UI;


namespace CoordinateTrackerAndClicker
{
    public partial class Form2 : MaterialForm
    {
        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out Point lpPoint);

        private bool isRecording = false;
        private bool isRecordingOn = false;
        private Point currentCoordinate = new Point();
        private readonly List<Point> clickHistory = new List<Point>();
        private Point lastCoordinate = new Point();
        private bool isSommeCommandIsActive = false;
        private bool modalAlertOn = false;

        private readonly MouseHook _mouseHook;
        private readonly MouseTracker _mouseTracker;

        private readonly MacroService macroService;
        private readonly PrintText printer;
        private readonly Printer _printer;
        private readonly ButtonHandler buttonHandler;

        private readonly SettingsCommand settingsCommand;
        private readonly MaterialSkinManager materialSkinManager;

        public Form2()
        {
            macroService = new MacroService();
            printer = new PrintText();
            buttonHandler = new ButtonHandler();

            _mouseHook = new MouseHook();
            _mouseTracker = new MouseTracker();

            settingsCommand = new SettingsCommand();

            _mouseHook.OnMouseClick += OnGlobalMouseClick;
            _mouseTracker.OnPositionChanged += MouseTrackTimer_Tick;

            InitializeComponent();

            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Cyan800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            _printer = new Printer((message, fontSize, logLevel) =>
            {
                StatusLabel.Text = message;
                StatusLabel2.Text = message;
                LogMessagePrint(message, logLevel);
                if (modalAlertOn) Alert(message, logLevel);
            });


            InitializeButtonsBehavior();
            buttonHandler.ClickButtonMechanicsExecute(this);

            LoadSavedMacros();

            RemoveFocusOnTextBox(new MaterialMultiLineTextBox[] { StatusLabel2, textBoxDisplayMacroInfo, StatusLabel, richTextBoxLogInfo, TextBoxlabelDisplayActionInfo });

            RemoveFocusFromCoordinateFields(new MaterialTextBox2[] { txtX, txtY});
        }

        private void RemoveFocusFromCoordinateFields(MaterialTextBox2[] textFields)
        {
            foreach (var field in textFields)
            {
                field.GotFocus += (s, e) => this.ActiveControl = null;
                field.MouseDown += (s, e) => field.Parent.Focus();
            }            
        }

        private void RemoveFocusOnTextBox(MaterialMultiLineTextBox[] textBoxes)
        {
            foreach (var box in textBoxes)
            {
                box.GotFocus += (s, e) => this.ActiveControl = null;
                box.MouseDown += (s, e) => box.Parent.Focus();
            }       
        }

        private void MouseTrackTimer_Tick(Point mousePoint)
        {
            if (isRecordingOn)
            {
                btnStopRecording.MouseEnter += (s, e) => isRecording = false;
                btnStopRecording.MouseLeave += (s, e) => isRecording = true;
            }
            
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
            ClearAllVisualMessages();
            _mouseTracker.StartTracking();
            _printer.Print("Следене на кординатите в процес ...", LogLevel.Info);
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            if (!clickHistory.Any())
            {
                _printer.Print("Няма записани кординати", LogLevel.Error);
                return;
            }

            buttonHandler.ClickButtonMechanicsExecute(sender);
            SaveLastValidCoordinate();
            isRecording = false;
            isRecordingOn = false;
            _printer.Print("Заредени кординати за действие", LogLevel.Info);
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
            if (String.IsNullOrEmpty(txtX.Text) || String.IsNullOrEmpty(txtY.Text))
            {
                _printer.Print("Няма записани кординати в полетата", LogLevel.Error);
                return;
            }

            if (IsNameInvalid(textBoxActionName.Text)) return;

            buttonHandler.ClickButtonMechanicsExecute(sender);

            // Add to the macro's action list 
            macroService.AddAction(textBoxActionName.Text, lastCoordinate, (MouseActionType)cmbActionType.SelectedIndex,
                numericDelaySlider.Value, numericDelayBeforeSlider.Value, chkReturnMouseToOriginal.Checked,
                FrequencyInputSlider.Value, DurationInputSlider.Value, CountInputSlider.Value);            

            // Refresh the UI to show the new action
            lstAvailableActions.AddItem(textBoxActionName.Text);

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

                lstAvailableMacros.AddItem("🗷 - " + textBoxMacroName.Text); // Refresh the macro list display

                lstAvailableActions.Items.Clear(); // Clear the work action list after macro create

                _printer.Print("Успешно добавяне към наличните макрота.", LogLevel.Success);
            }
            catch (Exception ex)
            {
                _printer.Print(ex.Message, LogLevel.Error);
            }
        }

        private void LstAvailableMacros_SelectedIndexChanged(object sender, MaterialListBoxItem selectedItem)           
        {
            if (!isSommeCommandIsActive)
            {
                if (IsListEmpty(lstAvailableMacros) || IsIndexNegative(lstAvailableMacros)) return;

                textBoxDisplayMacroInfo.Text = printer.DisplayMacroInfo(
                    macroService.macrosList[lstAvailableMacros.SelectedIndex],
                    lstAvailableMacros.SelectedItem.Text.Contains("🗹"));

                btnExecuteMacro.Enabled = true;
            }
            isSommeCommandIsActive = false;
        }

        private void LstMacrosForExecute_SelectedIndexChanged(object sender, MaterialListBoxItem selectedItem)
        {
            if (CheckForIncorrectCountOrIndex(lstMacrosForExecute)) return;

            buttonHandler.ClickButtonMechanicsExecute(sender);
        }

        private void LstAvailableMacros_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (CheckForIncorrectCountOrIndex(lstAvailableMacros)) return;

            // Проверка за максималния брои на елементи в списъка
            int maxMacrosInList = 4; 
            int currentMacrosInList = lstMacrosForExecute.Items.Count;

            if (maxMacrosInList <= currentMacrosInList)
            {
                _printer.Print("Списъка с макрота е пълен.", LogLevel.Error);
                return;
            }

            string macroNameToAdd = lstAvailableMacros.SelectedItem.Text.Remove(0, 5);
            lstMacrosForExecute.AddItem(macroNameToAdd);
            ActivateSliderForAddedMacro(lstMacrosForExecute.Count - 1);          
        }

        private void ActivateSliderForAddedMacro(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    SliderMacroForExecuteSlot1.Visible = true;
                    SliderMacroForExecuteSlot1.Enabled = true;
                    SliderMacroForExecuteSlot1.Value = 1;
                    break;
                case 1:
                    SliderMacroForExecuteSlot2.Visible = true;
                    SliderMacroForExecuteSlot2.Enabled = true;
                    SliderMacroForExecuteSlot2.Value = 1;
                    break;
                case 2:
                    SliderMacroForExecuteSlot3.Visible = true;
                    SliderMacroForExecuteSlot3.Enabled = true;
                    SliderMacroForExecuteSlot3.Value = 1;
                    break;
                case 3:
                    SliderMacroForExecuteSlot4.Visible = true;
                    SliderMacroForExecuteSlot4.Enabled = true;
                    SliderMacroForExecuteSlot4.Value = 1;
                    break;
                default:
                    //?????/
                    break;
            }
        }

        private void lstAvailableActions_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (CheckForIncorrectCountOrIndex(lstAvailableActions) || isRecordingOn) return;

            TextBoxlabelDisplayActionInfo.Text = printer.DisplayActionInfo(macroService.currentActionsList[lstAvailableActions.SelectedIndex]);
            groupBoxActionInfo.Visible = true;
        }

        private void lstAvailableActions_SelectedIndexChanged(object sender, MaterialListBoxItem selectedItem)
        {
            if (CheckForIncorrectCountOrIndex(lstAvailableActions) || isRecordingOn || TextBoxlabelDisplayActionInfo.Visible == false) return;

            TextBoxlabelDisplayActionInfo.Text = printer.DisplayActionInfo(macroService.currentActionsList[lstAvailableActions.SelectedIndex]);
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
                lstMacrosForExecute.AddItem(lstAvailableMacros.SelectedItem.Text.Remove(0, 5));
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
                //(0);
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
                            lstMacrosForExecute.Items[i].Text,
                            GetSliderBarMacroExecution(i).Value));
                }
                }
                else
                {
                    macrosNameRepeatList.Add(new KeyValuePair<string, int>(
                            lstMacrosForExecute.SelectedItem.Text,
                            GetSliderBarMacroExecution(lstMacrosForExecute.SelectedIndex).Value));
                }

                await macroService.ExecuteMacroAsync(
                    _printer,
                    ProgressBarExecuteMacros,
                    macrosNameRepeatList,
                    countAllMacroRepeatSlider.Value);
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
            buttonHandler.ClickButtonMechanicsExecute(sender);
            if (IsListEmpty(lstAvailableActions)) btnCreateMacro.Enabled = false;
            _printer.Print("Премахнато Дейаствие от списъка за добавяне.", LogLevel.Success);
        }

        private void BtnMacroForExecuteDelete_Click(object sender, EventArgs e)
        {
            if (IsListEmpty(lstMacrosForExecute) || IsIndexNegative(lstMacrosForExecute)) return;

            int selectedMacroIndex = lstMacrosForExecute.SelectedIndex; // Индекс на маркираното макро
            lstMacrosForExecute.Items.RemoveAt(selectedMacroIndex); // Премахване на визуалния елемент от списъка
              
            RemoveSliderBarForDeleteteMacro(selectedMacroIndex);

            _printer.Print("Премахнато Макро от списъка за изпълнение.", LogLevel.Success);
        }

        private void RemoveSliderBarForDeleteteMacro(int index)
        {
            if (index < 0 || index > 3) return;

            for (int i = index; i < 3; i++)
            {
                var currentSlider = GetSliderBarMacroExecution(i);
                var nextSlider = GetSliderBarMacroExecution(i + 1);

                if(nextSlider != null && currentSlider != null)
                {
                    currentSlider.Value = nextSlider.Value;
                    currentSlider.Visible = nextSlider.Visible;
                    currentSlider.Enabled = nextSlider.Enabled;
                }
            }

            var lastSlider = GetSliderBarMacroExecution(3);
            if(lastSlider != null)
            {
                lastSlider.Visible = false;
                lastSlider.Enabled = false;
                lastSlider.Value = 1;
            }
        }

        private MaterialSlider GetSliderBarMacroExecution(int index)
        {
            switch (index)
            {
                case 0: return SliderMacroForExecuteSlot1;
                case 1: return SliderMacroForExecuteSlot2;
                case 2: return SliderMacroForExecuteSlot3;
                case 3: return SliderMacroForExecuteSlot4;
                default: return null;
            }
        }

        private void BtnMoveUpAction_Click(object sender, EventArgs e)
        {
            if (lstAvailableActions.SelectedIndex == 0 || CheckForIncorrectCountOrIndex(lstAvailableActions)) return;

            SwapElementsInListBox(lstAvailableActions, lstAvailableActions.SelectedIndex, true);
            macroService.ChangeActionPosition(lstAvailableActions.SelectedIndex, true);
            lstAvailableActions.SelectedIndex--;
        }

        private void BtnMoveDownAction_Click(object sender, EventArgs e)
        {
            if (lstAvailableActions.SelectedIndex == lstAvailableActions.Items.Count - 1 || CheckForIncorrectCountOrIndex(lstAvailableActions)) return;

            SwapElementsInListBox(lstAvailableActions, lstAvailableActions.SelectedIndex, false);
            macroService.ChangeActionPosition(lstAvailableActions.SelectedIndex, false);
            lstAvailableActions.SelectedIndex++;
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

        private bool IsListEmpty(MaterialListBox list)
        {
            if (list == null) return true;

            if (list.Items.Count == 0)
            {
                _printer.Print("Няма елементи в списъка.", LogLevel.Error);
                return true;
            }

            return false;
        }

        private bool CheckForIncorrectCountOrIndex(MaterialListBox list)
        {
            if (list == null || list.Items.Count == 0 || list.SelectedIndex == -1 || list.SelectedIndex > list.Items.Count - 1) return true;

            return false;
        }

        private bool IsIndexNegative(MaterialListBox list)
        {
            if (list.SelectedIndex == -1)
            {
                _printer.Print("Няма избран елемент за премахване от списъка.", LogLevel.Error);
                return true;
            }

            return false;
        }

        private void SwapElementsInListBox(MaterialListBox list, int index, bool isMoveUp)
        {
            if (list.Items.Count < 2 || index < 0 || index > list.Items.Count - 1) return;

            int targetElementIndexToSwap = index + (isMoveUp ? -1 : +1);

            var temp = list.Items[index];
            list.Items[index] = list.Items[targetElementIndexToSwap];
            list.Items[targetElementIndexToSwap] = temp;
        }

        //--------------------------------------------------------
        private void LogMessagePrint(string message, LogLevel logLevel)
        {
            Color color;
            switch (logLevel)
            {
                case LogLevel.Info:
                    color = materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? Color.WhiteSmoke : Color.Black;
                    break;
                case LogLevel.Success:
                    //color = Color.Green;
                    color = Color.LimeGreen;
                    break;
                case LogLevel.Error:
                    color = Color.Red;
                    break;
                default:
                    color = materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? Color.WhiteSmoke : Color.Black;
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
                buttonHandler.AddNewButton(this,
                    new Button[] { btnStopRecording, btnAddAction, btnMoveUpAction, btnMoveDownAction, btnActionDelete, btnCreateMacro },
                    new Button[] { });
                buttonHandler.AddNewButton(btnStartRecording, 
                    new Button[] { btnStartRecording, btnAddAction, btnMoveUpAction, btnMoveDownAction, btnActionDelete, btnCreateMacro },
                    new Button[] { btnStopRecording });
                buttonHandler.AddNewButton(btnStopRecording,
                    new Button[] { btnStopRecording },
                    new Button[] { btnStartRecording, btnAddAction });
                buttonHandler.AddNewButton(btnAddAction,
                    new Button[] { btnAddAction },
                    new Button[] { btnMoveUpAction, btnMoveDownAction, btnActionDelete, btnCreateMacro });
                buttonHandler.AddNewButton(btnActionDelete,
                    new Button[] {btnActionDelete, btnMoveUpAction, btnMoveDownAction },
                    new Button[] { });
                buttonHandler.AddNewButton(btnCreateMacro,
                    new Button[] { btnCreateMacro, btnActionDelete },
                    new Button[] { btnExecuteMacro });
                buttonHandler.AddNewButton(btnExecuteMacro,
                    new Button[] { btnExecuteMacro, btnMacroForExecuteDelete, btnMacroDelete },
                    new Button[] { btnStopMacro });
                buttonHandler.AddNewButton(btnStopMacro,
                    new Button[] { btnStopMacro },
                    new Button[] { btnExecuteMacro, btnMacroForExecuteDelete, btnMacroDelete });
                buttonHandler.AddNewButton(lstAvailableActions,
                    new Button[] { },
                    new Button[] { btnMoveUpAction, btnMoveDownAction, btnActionDelete });
                buttonHandler.AddNewButton(lstMacrosForExecute,
                    new Button[] { },
                    new Button[] { btnMacroForExecuteDelete });
            }
            catch (Exception ex)
            {
                _printer.Print("Грешка при добавяне на поведение към бутоните. " + ex.Message, LogLevel.Error);
            }
        }

        private async void LoadSavedMacros()
        {
            _printer.Print("Базова директория на приложението: " + AppDomain.CurrentDomain.BaseDirectory);
            _printer.Print("Път до файла със записите: " + JsonDataStorageManualSelect.SaveFilePath);

            var loadedMacrosName = await macroService.LoadMacroFromDBAsync();
            if (loadedMacrosName.Any())
            {
                _printer.Print("Зареждане на макрота ...");
                loadedMacrosName.ForEach(m => lstAvailableMacros.AddItem("🗹 - " + m));
                _printer.Print(String.Join(", ", loadedMacrosName), LogLevel.Success);
                _printer.Print("Макротата са заредени!");
            }
            else
                _printer.Print("Списъка е празен и няма запаметени макрота.", LogLevel.Error);
        }

        private async void BtnMacroSaveToDB_Click(object sender, EventArgs e)
        {
            if (lstAvailableMacros.SelectedIndex == -1)
            {
                _printer.Print("Няма избрано Макро", LogLevel.Error);
                return;
            }

            if (!macroService.CheckPathFile())
            {
                _printer.Print("Проблем с директорията или файла за запаметяване.", LogLevel.Error);
                return;
            }

            var result = await macroService.SaveMacroToDBAsync(macroService.macrosList[lstAvailableMacros.SelectedIndex]);

            if (result)
            {
                isSommeCommandIsActive = true;
                string test = lstAvailableMacros.Items[lstAvailableMacros.SelectedIndex].Text;
                lstAvailableMacros.Items[lstAvailableMacros.SelectedIndex] = new MaterialListBoxItem { Text = test.Replace("🗷", "🗹") };

                textBoxDisplayMacroInfo.Text = printer.DisplayMacroInfo(
                    macroService.macrosList[lstAvailableMacros.SelectedIndex],
                    lstAvailableMacros.Items[lstAvailableMacros.SelectedIndex].Text.Contains("🗹"));

                _printer.Print("Успешен запис в архива.", LogLevel.Success);
            }
            else
                _printer.Print("Има такова Макро в архива или Възникна грешка при записа.", LogLevel.Error);

            isSommeCommandIsActive = false;
        }

        private async void BtnMacroDeleteFromDB_Click(object sender, EventArgs e)
        {
            if (lstAvailableMacros.SelectedIndex == -1)
            {
                _printer.Print("Няма избрано Макро", LogLevel.Error);
                return;
            }

            if (!macroService.CheckPathFile())
            {
                _printer.Print("Проблем с директорията или файла за запаметяване.", LogLevel.Error);
                return;
            }
            
            var result = await macroService.DeleteMacroFromDBAsync(lstAvailableMacros.SelectedItem.Text.Remove(0, 5));

            if (result)
            {
                if (IsListEmpty(lstAvailableMacros) || IsIndexNegative(lstAvailableMacros)) return;

                string test = lstAvailableMacros.SelectedItem.Text.Remove(0, 5);
                for (int i = 0; i < lstMacrosForExecute.Items.Count; i++)
                {
                    if (lstMacrosForExecute.Items[i].Text == test)
                    {
                        lstMacrosForExecute.Items.RemoveAt(i); // Премахване на визуалния елемент от списъка

                        RemoveSliderBarForDeleteteMacro(i);

                        btnMacroForExecuteDelete.Enabled = false; // Деактивирване на бутона за триене

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
            if (lstAvailableMacros.Items.Count == 0) btnExecuteMacro.Enabled = false;
        }

        private void BtnNewSavePath_Click(object sender, EventArgs e)
        {
            macroService.ChangeSavePath();
        }

        private void NumericDelayBeforeSlider_MouseUp(object sender, MouseEventArgs e)
        {
            SetSliderCustomStep(sender as MaterialSlider, 100);
        }

        private void numericDelaySlider_MouseUp(object sender, MouseEventArgs e)
        {
            SetSliderCustomStep(sender as MaterialSlider, 100);
        }

        private static void SetSliderCustomStep(MaterialSlider slider, int step)
        {
            if (slider != null) slider.Value = (slider.Value / step) * step;
        }


        //--------------------------------- SETTINGS --------------------------------------------------

        #region SETTINGS

        #region COLOR and THEME
        private void BtnSwitchTheme_CheckedChanged(object sender, EventArgs e)
        {
            settingsCommand.ChangeThemes(materialSkinManager, btnSwitchTheme.Checked);
        }

        private void RadioButtonOrange_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButtonOrange.Checked)
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Orange800, Primary.Orange900, Primary.Orange500, Accent.Orange200, TextShade.WHITE);
        }

        private void RadioButtonGreen_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButtonGreen.Checked)
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Green800, Primary.Green900, Primary.Green500, Accent.Green200, TextShade.WHITE);
        }

        private void RadioButtonBlue_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButtonBlue.Checked)
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue800, Primary.Blue900, Primary.Blue500, Accent.Blue200, TextShade.WHITE);
        }


        private void RadioButtonBase_CheckedChanged(object sender, EventArgs e)
        {
            if(RadioButtonBase.Checked)
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Cyan800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }
        #endregion


        #region MODAL ALERT
        private void BtnSwitchModalAlert_CheckedChanged(object sender, EventArgs e)
        {
            modalAlertOn = BtnSwitchModalAlert.Checked;
            CheckboxError.Checked = true;
            CheckboxSuccess.Checked = true;
        }

        public void Alert(string msg, LogLevel logLevel)
        {      
            FormAlert.enmType type = FormAlert.enmType.Empty; 

            switch (logLevel)
            {
                case LogLevel.Info:
                    if (CheckboxInfo.Checked) type = FormAlert.enmType.Info;
                    break;
                case LogLevel.Success:
                    if (CheckboxSuccess.Checked) type = FormAlert.enmType.Success;
                    break;
                case LogLevel.Error:
                    if (CheckboxError.Checked) type = FormAlert.enmType.Error;
                    break;
                default:
                    type = FormAlert.enmType.Empty;
                    break;
            }

            if (type == FormAlert.enmType.Empty) return;

            FormAlert frm = new FormAlert();
            frm.showAlert(msg, type);     
        }

        #endregion

        #endregion


        // ----------------------- SLIDERS MINIMUM VALUES -----------------------------------------
        private void FrequencyInputSlider_onValueChanged(object sender, int newValue)
            => SetMinValueSelectToOne(sender, newValue, 1);

        private void DurationInputSlider_onValueChanged(object sender, int newValue) 
            => SetMinValueSelectToOne(sender, newValue, 1);

        private void CountInputSlider_onValueChanged(object sender, int newValue)
           => SetMinValueSelectToOne(sender, newValue, 1);

        private void numericDelayBeforeSlider_onValueChanged(object sender, int newValue)
            => SetMinValueSelectToOne(sender, newValue, 1000);

        private void numericDelaySlider_onValueChanged(object sender, int newValue)
            => SetMinValueSelectToOne(sender, newValue, 1000);

        private void countAllMacroRepeatSlider_onValueChanged(object sender, int newValue)
            => SetMinValueSelectToOne(sender, newValue, 1);

        private void SliderMacroForExecuteSlot1_onValueChanged(object sender, int newValue)
             => SetMinValueSelectToOne(sender, newValue, 1);

        private void SliderMacroForExecuteSlot2_onValueChanged(object sender, int newValue)
             => SetMinValueSelectToOne(sender, newValue, 1);

        private void SliderMacroForExecuteSlot3_onValueChanged(object sender, int newValue)
             => SetMinValueSelectToOne(sender, newValue, 1);

        private void SliderMacroForExecuteSlot4_onValueChanged(object sender, int newValue)
             => SetMinValueSelectToOne(sender, newValue, 1);
        private static void SetMinValueSelectToOne(object sender, int newValue, int targetValue)
        {
            if (newValue <= 0) (sender as MaterialSlider).Value = targetValue;
        }

        private void BtnCloseCardActionInfo_Click(object sender, EventArgs e)
        {
            //materialCardActionInfo.Visible = false;
            groupBoxActionInfo.Visible = false;
        }

        // -------------------------------------------------------------------------------

    }
}
