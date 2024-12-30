using CoordinateTrackerAndClicker.Core.Models;
using CoordinateTrackerAndClicker.Core.Services;
using CoordinateTrackerAndClicker.Db_Json;
using CoordinateTrackerAndClicker.UI;
using CoordinateTrackerAndClicker.Utils;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;


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
        private bool isSommeCommandIsActive = false; // ???? ТОВА МАЙ ВЕЧЕ Е БЕЗПОЛЕЗНО ....
        private bool modalAlertOn = false;
        private bool isMacroNotActive = true;

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

            RadioButtonLanguageEN.Select(); // Поставя определен език за стартов при началото на програмата ( EN в случая )

            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Cyan800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            _printer = new Printer((message, fontSize, logLevel) =>
            {
                string testMessages = LanguageManager.GetString(message);
                if (testMessages != null) message = testMessages;

                StatusLabel.Text =  message;
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
                    CurrentPositionLabel.Text = $"{LanguageManager.GetString(CurrentPositionLabel.Name)} X : {currentCoordinate.X} Y : {currentCoordinate.Y}";
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
                //UpdateCurrentPositionLabel(clickPoint);
                UpdateLastClickLabel();
                _printer.Print(SAM.ON_GLOBAL_MOUSE_CLICK, LogLevel.Info);
            }
        }

        private void UpdateLastClickLabel()
        {
            if (clickHistory.Count <= 0) return;

            int clickCounts = clickHistory.Count;
            lastCoordinate = clickHistory[clickCounts - 1];
            LastClickLabel.Text = $"{LanguageManager.GetString(LastClickLabel.Name)} X : {lastCoordinate.X}  Y = {lastCoordinate.Y}";
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
            _printer.Print(SAM.START_BUTTON_OK, LogLevel.Info);
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            if (!clickHistory.Any())
            {
                _printer.Print(SAM.STOP_BUTTON_NO_RECORD, LogLevel.Error);
                return;
            }

            buttonHandler.ClickButtonMechanicsExecute(sender);
            SaveLastValidCoordinate();
            isRecording = false;
            isRecordingOn = false;
            _printer.Print(SAM.STOP_BUTTON_OK_RECORD, LogLevel.Info);
            clickHistory.Clear();
            _mouseTracker.StopTracking();
        }

        //private void UpdateCurrentPositionLabel(Point point)
        //{
        //    if (point == null) return;
        //    //LanguageManager.GetString(CurrentPositionLabel.Name);
        //    //CurrentPositionLabel.Text = $"Текуща позиция: X={point.X}, Y={point.Y}";
        //    //CurrentPositionLabel.Text = $"{LanguageManager.GetString(CurrentPositionLabel.Name)} X={point.X}, Y={point.Y}";
        //}

        private void BtnAddAction_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtX.Text) || String.IsNullOrEmpty(txtY.Text))
            {
                _printer.Print(SAM.BTN_ADD_ACTION_NO_RECORD, LogLevel.Error);
                return;
            }

            if (IsNameInvalid(textBoxActionName.Text)) return;

            buttonHandler.ClickButtonMechanicsExecute(sender);

            // Add to the macro's action list 
            macroService.AddAction(textBoxActionName.Text, lastCoordinate, (MouseActionType)cmbActionType.SelectedIndex,
                numericDelaySlider.Value, numericDelayBeforeSlider.Value, chkReturnMouseToOriginal.Checked,
                FrequencyInputSlider.Value, DurationInputSlider.Value, CountInputSlider.Value);

            // Refresh the UI to show the new action
            lstAvailableActions.Clear();
            lstAvailableActions.AddItems(macroService.LoadActionsNames());
            // Решение на проблема: MaterialListBox визуализацията на последния елемент, ако е извън прозореца
            // Добавям нов последен елемент само към визуалния списък и не засяга реалния списък с действия
            if (lstAvailableActions.Count > 5) lstAvailableActions.AddItem("");

            ClearAllVisualMessages();

            _printer.Print(SAM.BTN_ADD_ACTION_OK, LogLevel.Success);
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

                groupBoxActionInfo.Visible = false;

                _printer.Print(SAM.BTN_CREATE_MACRO_OK, LogLevel.Success);
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
                if (IsListEmpty(lstAvailableMacros) || IsNotingSelectedInList(lstAvailableMacros)) return;

                textBoxDisplayMacroInfo.Text = printer.DisplayMacroInfo(
                    macroService.macrosList[lstAvailableMacros.SelectedIndex],
                    lstAvailableMacros.SelectedItem.Text.Contains("🗹"));             
            }

            if (!isSommeCommandIsActive && isMacroNotActive)
            {
                btnMacroSave.Enabled = true;
                btnMacroDelete.Enabled = true;
            }

            isSommeCommandIsActive = false;           
        }

        private void LstMacrosForExecute_SelectedIndexChanged(object sender, MaterialListBoxItem selectedItem)
        {
            if (CheckForIncorrectCountOrIndex(lstMacrosForExecute) || !isMacroNotActive) return;

            buttonHandler.ClickButtonMechanicsExecute(sender);
        }

        private void LstAvailableMacros_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (CheckForIncorrectCountOrIndex(lstAvailableMacros) || !isMacroNotActive) return;

            // Проверка за максималния брои на елементи в списъка
            int maxMacrosInList = 4; 
            int currentMacrosInList = lstMacrosForExecute.Items.Count;

            if (maxMacrosInList <= currentMacrosInList)
            {
                _printer.Print(SAM.LST_AVEILABLE_MACROS_FULL, LogLevel.Error);
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
            TextBoxlabelDisplayActionInfo.Text = printer.DisplayActionInfo(macroService.LoadActionByIndex(lstAvailableActions.SelectedIndex));
            groupBoxActionInfo.Visible = true;
        }

        private void lstAvailableActions_MouseClick(object sender, MouseEventArgs e)
        {
            if (CheckForIncorrectCountOrIndex(lstAvailableActions) || isRecordingOn) return;
            btnMoveUpAction.Enabled = true;
            btnMoveDownAction.Enabled = true;
            btnActionDelete.Enabled = true;
        }

        private void lstAvailableActions_SelectedIndexChanged(object sender, MaterialListBoxItem selectedItem)
        {
            if (CheckForIncorrectCountOrIndex(lstAvailableActions) || isRecordingOn || TextBoxlabelDisplayActionInfo.Visible == false) return;       
            TextBoxlabelDisplayActionInfo.Text = printer.DisplayActionInfo(macroService.LoadActionByIndex(lstAvailableActions.SelectedIndex));                  
        }
      
        private async void BtnExecuteMacro_Click(object sender, EventArgs e)
        {
            // Спира изпълнението ако няма добавени макрота
            if (IsListEmpty(lstAvailableMacros) || IsNotingSelectedInList(lstMacrosForExecute)) return;

            try
            {
                // Стартиране механика на бутона
                buttonHandler.ClickButtonMechanicsExecute(sender);

                _printer.Print(SAM.BTN_EXECUTE_MACRO_START, LogLevel.Info);

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

                isMacroNotActive = false;

                await macroService.ExecuteMacroAsync(
                    _printer,
                    ProgressBarExecuteMacros,
                    macrosNameRepeatList,
                    countAllMacroRepeatSlider.Value);

                
            }
            catch (Exception ex)
            {
                BtnStopMacro_Click(btnStopMacro, null);
                _printer.Print(SAM.BTN_EXECUTE_MACRO_MISSING_MACRO, LogLevel.Error);
                _printer.Print(ex.Message, LogLevel.Error);
                isMacroNotActive = true;
            }

            _printer.Print(SAM.BTN_EXECUTE_MACRO_FINISH, LogLevel.Success);
            buttonHandler.ClickButtonMechanicsExecute(btnStopMacro);
            isMacroNotActive = true;
        }

        private void ClearAllVisualMessages()
        {
            CurrentPositionLabel.Text = LanguageManager.GetString(CurrentPositionLabel.Name);
            LastClickLabel.Text = LanguageManager.GetString(LastClickLabel.Name);
            txtX.Text = string.Empty;
            txtY.Text = string.Empty;
        }

        private void BtnStopMacro_Click(object sender, EventArgs e)
        {
            macroService.OnStopClick2();

            buttonHandler.ClickButtonMechanicsExecute(sender);
            _printer.Print(SAM.BTN_STOP_MACRO, LogLevel.Info);
        }

        private void BtnActionDelete_Click(object sender, EventArgs e)
        {
            if (IsListEmpty(lstAvailableActions) || IsNotingSelectedInList(lstAvailableActions)) return;

            int index = lstAvailableActions.SelectedIndex; // Индекс на маркираното действие
            lstAvailableActions.SelectedItems.Clear(); // Демаркирване на избрания елемент от списъка
            lstAvailableActions.SelectedIndex = -1; // Задаване на колекцията че няма избран елемент
            macroService.RemoveActionByIndex(index); // Премахване на елемент със същия индекс от работната колекция
            lstAvailableActions.Items.RemoveAt(index); // Премахване на визуалния елемент от списъка
            buttonHandler.ClickButtonMechanicsExecute(sender);
            if (IsListEmpty(lstAvailableActions)) btnCreateMacro.Enabled = false;
            groupBoxActionInfo.Visible = false;
            _printer.Print(SAM.BTN_ACTION_DELETE_OK_REMOVE, LogLevel.Success);
        }

        private void BtnMacroForExecuteDelete_Click(object sender, EventArgs e)
        {
            if (IsListEmpty(lstMacrosForExecute) || IsNotingSelectedInList(lstMacrosForExecute)) return;

            int selectedMacroIndex = lstMacrosForExecute.SelectedIndex; // Индекс на маркираното макро
            lstMacrosForExecute.Items.RemoveAt(selectedMacroIndex); // Премахване на визуалния елемент от списъка
            lstMacrosForExecute.SelectedIndex = -1;
              
            RemoveSliderBarForDeletedMacro(selectedMacroIndex);

            buttonHandler.ClickButtonMechanicsExecute(sender);

            _printer.Print(SAM.BTN_MACRO_FOR_EXECUTE_DELETE_OK_REMOVE, LogLevel.Success);
        }

        private void RemoveSliderBarForDeletedMacro(int index)
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
                chkAllMacrosToExecute.Checked ? SAM.CHK_ALL_MACROS_TO_EXECUTE_ALL : SAM.CHK_ALL_MACROS_TO_EXECUTE_SINGLE,
                LogLevel.Info);
        }


        //------------------------------------------------------
        private bool IsNameInvalid(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                _printer.Print(SAM.IS_NAME_INVALID, LogLevel.Error);
                return true;
            }

            return false;
        }

        private bool IsListEmpty(MaterialListBox list)
        {
            if (list == null) return true;

            if (list.Items.Count == 0)
            {
                _printer.Print(SAM.IS_LIST_EMPTY, LogLevel.Error);
                return true;
            }

            return false;
        }

        private bool CheckForIncorrectCountOrIndex(MaterialListBox list)
        {
            if (list == null || list.Items.Count == 0 || list.SelectedIndex == -1 || list.SelectedIndex > list.Items.Count - 1) return true;

            return false;
        }

        private bool IsNotingSelectedInList(MaterialListBox list)
        {
            if (list.SelectedIndex == -1)
            {
                _printer.Print(SAM.IS_NOTING_SELECTED_IN_LIST, LogLevel.Error);
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
                    formattedMessage = $"{LanguageManager.GetString(LogLevel.Info.ToString())}: {message}";
                    break;
                case LogLevel.Success:
                    formattedMessage = $"{LanguageManager.GetString(LogLevel.Success.ToString())}: {message}";
                    break;
                case LogLevel.Error:
                    formattedMessage = $"{LanguageManager.GetString(LogLevel.Error.ToString())}: {message}";
                    break;
                default:
                    formattedMessage = $"{LanguageManager.GetString(LogLevel.Info.ToString())}: {message}";
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
                    new Button[] { btnStopRecording, btnAddAction, btnMoveUpAction, btnMoveDownAction, btnActionDelete, btnCreateMacro,
                                   btnMacroForExecuteDelete, btnExecuteMacro, btnStopMacro },
                    new Button[] { });
                buttonHandler.AddNewButton(btnStartRecording, 
                    new Button[] { btnStartRecording, btnAddAction, btnMoveUpAction, btnMoveDownAction, btnActionDelete, btnCreateMacro },
                    new Button[] { btnStopRecording });
                buttonHandler.AddNewButton(btnStopRecording,
                    new Button[] { btnStopRecording },
                    new Button[] { btnStartRecording, btnAddAction });
                buttonHandler.AddNewButton(btnAddAction,
                    new Button[] { btnAddAction },
                    new Button[] { btnCreateMacro });
                buttonHandler.AddNewButton(btnActionDelete,
                    new Button[] {btnActionDelete, btnMoveUpAction, btnMoveDownAction },
                    new Button[] { });
                buttonHandler.AddNewButton(btnCreateMacro,
                    new Button[] { btnCreateMacro, btnActionDelete, btnMoveUpAction, btnMoveDownAction },
                    new Button[] { });
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
                    new Button[] { btnExecuteMacro, btnMacroForExecuteDelete });
                buttonHandler.AddNewButton(btnMacroForExecuteDelete,
                    new Button[] { btnMacroForExecuteDelete, btnExecuteMacro },
                    new Button[] { });
            }
            catch (Exception ex)
            {
                _printer.Print($"{LanguageManager.GetString(SAM.INITIALIZE_BUTTONS_BEHAVIOR_ERROR)} " + ex.Message, LogLevel.Error);
            }
        }

        private async void LoadSavedMacros()
        {
            _printer.Print($"{LanguageManager.GetString(SAM.LOAD_SAVED_MACROS_BASE_DIRECTORY)}: " + AppDomain.CurrentDomain.BaseDirectory);
            _printer.Print($"{LanguageManager.GetString(SAM.LOAD_SAVED_MACROS_PATH_TO_SAVE)}: " + JsonDataStorageManualSelect.SaveFilePath);

            var loadedMacrosName = await macroService.LoadMacroFromDBAsync();
            if (loadedMacrosName.Any())
            {
                _printer.Print(SAM.LOAD_SAVED_MACROS_LOADING);
                loadedMacrosName.ForEach(m => lstAvailableMacros.AddItem("🗹 - " + m));
                _printer.Print(String.Join(", ", loadedMacrosName), LogLevel.Success);
                _printer.Print(SAM.LOAD_SAVED_MACROS_LOADED);
            }
            else
            {
                btnMacroSave.Enabled = false;
                btnMacroDelete.Enabled = false;
                _printer.Print(SAM.LOAD_SAVED_MACROS_LIST_EMPTY, LogLevel.Error);
            }
                
        }

        private async void BtnMacroSaveToDB_Click(object sender, EventArgs e)
        {
            if (lstAvailableMacros.SelectedIndex == -1)
            {
                _printer.Print(SAM.BTN_MACRO_SAVE_TO_DB_NO_SELECTED, LogLevel.Error);
                return;
            }

            if (!macroService.CheckPathFile())
            {
                _printer.Print(SAM.BTN_MACRO_SAVE_TO_DB_ERROR_DIR_OR_FILE, LogLevel.Error);
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

                _printer.Print(SAM.BTN_MACRO_SAVE_TO_DB_OK, LogLevel.Success);
            }
            else
                _printer.Print(SAM.BTN_MACRO_SAVE_TO_DB_M_EXISTS_OR_ERROR, LogLevel.Error);

            isSommeCommandIsActive = false;
        }

        private async void BtnMacroDeleteFromDB_Click(object sender, EventArgs e)
        {
            if (lstAvailableMacros.SelectedIndex == -1)
            {
                _printer.Print(SAM.BTN_MACRO_DELETE_FROM_DB_NO_SELECTED, LogLevel.Error);
                return;
            }

            if (!macroService.CheckPathFile())
            {
                _printer.Print(SAM.BTN_MACRO_DELETE_FROM_DB_ERROR_DIR_OR_FILE, LogLevel.Error);
                return;
            }
            
            var result = await macroService.DeleteMacroFromDBAsync(lstAvailableMacros.SelectedItem.Text.Remove(0, 5));

            if (!result && lstAvailableMacros.Count == 0)
            {
                _printer.Print(SAM.BTN_MACRO_DELETE_FROM_DB_ERROR_REQUEST, LogLevel.Error);
                return;
            }        

            if (IsListEmpty(lstAvailableMacros) || IsNotingSelectedInList(lstAvailableMacros)) return;

            string test = lstAvailableMacros.SelectedItem.Text.Remove(0, 5);
            for (int i = 0; i < lstMacrosForExecute.Items.Count; i++)
            {
                if (lstMacrosForExecute.Items[i].Text == test)
                {
                    lstMacrosForExecute.Items.RemoveAt(i); // Премахване на визуалния елемент от списъка

                    RemoveSliderBarForDeletedMacro(i);

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
            lstAvailableMacros.SelectedIndex = -1;
            macroService.RemoveMacroByIndex(index); // Премахване на елемент със същия индекс от работната колекция

            if (lstAvailableMacros.Count == 0)
            {
                btnMacroSave.Enabled = false;
                btnMacroDelete.Enabled = false;
            }

            _printer.Print(SAM.BTN_MACRO_DELETE_FROM_DB_OK, LogLevel.Success);

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

        //----------------------------- COLOR AND THEME ------------------------------------------

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

        //------------------------------ MODAL ALLERT --------------------------------------------

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


        // ----------------------- SLIDERS MINIMUM VALUES ----------------------------------------
        private void FrequencyInputSlider_onValueChanged(object sender, int newValue)
            => SetMinValueSelectToOne(sender, newValue, 1);

        private void DurationInputSlider_onValueChanged(object sender, int newValue) 
            => SetMinValueSelectToOne(sender, newValue, 1);

        private void CountInputSlider_onValueChanged(object sender, int newValue)
           => SetMinValueSelectToOne(sender, newValue, 1);

        private void numericDelayBeforeSlider_onValueChanged(object sender, int newValue)
            => SetMinValueSelectToOne(sender, newValue, 100);

        private void numericDelaySlider_onValueChanged(object sender, int newValue)
            => SetMinValueSelectToOne(sender, newValue, 100);

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
        // -------------------------------------------------------------------------------


        private void BtnCloseCardActionInfo_Click(object sender, EventArgs e)
         => groupBoxActionInfo.Visible = false;


        //--------------------------------- LANGUAGE CHANGE -------------------------------

        #region LANGUAGE CHANGE

        private void RadioButtonLanguageEN_CheckedChanged(object sender, EventArgs e)
            => LanguageChanger(SupportedLanguages.en);

        private void RadioButtonLanguageBG_CheckedChanged(object sender, EventArgs e)
            => LanguageChanger(SupportedLanguages.bg);

        private void RadioButtonLanguageDeutsch_CheckedChanged(object sender, EventArgs e)
            => LanguageChanger(SupportedLanguages.de);

        private void RadioButtonLanguageFrench_CheckedChanged(object sender, EventArgs e)
            => LanguageChanger(SupportedLanguages.fr);

        private void LanguageChanger(SupportedLanguages language)
        {
            LanguageManager.SetLanguage(language.ToString());
            ApplyLocalization();
        }

        private enum SupportedLanguages
        {
            en,
            bg,
            de,
            fr
        }

        private void ApplyLocalization()
        {
            this.Text = LanguageManager.GetString(this.Name);
            tabPage1.Text = LanguageManager.GetString(tabPage1.Name);
            tabPage2.Text = LanguageManager.GetString(tabPage2.Name);
            tabPage3.Text = LanguageManager.GetString(tabPage3.Name);
            tabPage4.Text = LanguageManager.GetString(tabPage4.Name);

            btnStartRecording.Text = LanguageManager.GetString(btnStartRecording.Name);
            btnStopRecording.Text = LanguageManager.GetString(btnStopRecording.Name);
            CurrentPositionLabel.Text = LanguageManager.GetString(CurrentPositionLabel.Name);
            LastClickLabel.Text = LanguageManager.GetString(LastClickLabel.Name);
            txtX.Hint = LanguageManager.GetString(txtX.Name);
            txtY.Hint = LanguageManager.GetString(txtY.Name);

            string cmbActionTypeText = LanguageManager.GetString(cmbActionType.Name);
            List<string> result = cmbActionTypeText.Split(',').ToList();
            cmbActionType.Items.Clear();
            foreach (var item in result)
            {
                cmbActionType.Items.Add(item);
            }
            cmbActionType.SelectedIndex = 0;

            chkReturnMouseToOriginal.Text = LanguageManager.GetString(chkReturnMouseToOriginal.Name);
            FrequencyInputSliderLabel.Text = LanguageManager.GetString(FrequencyInputSliderLabel.Name);
            DurationInputSliderLabel.Text = LanguageManager.GetString(DurationInputSliderLabel.Name);
            CountInputSliderLabel.Text = LanguageManager.GetString(CountInputSliderLabel.Name);

            textBoxMacroName.Hint = LanguageManager.GetString(textBoxMacroName.Name + "Hint");
            textBoxMacroName.Text = LanguageManager.GetString(textBoxMacroName.Name + "Text");

            textBoxActionName.Hint = LanguageManager.GetString(textBoxActionName.Name + "Hint");
            textBoxActionName.Text = LanguageManager.GetString(textBoxActionName.Name + "Text");

            numericDelayBeforeSliderLabel.Text = LanguageManager.GetString(numericDelayBeforeSliderLabel.Name);
            numericDelaySliderLabel.Text = LanguageManager.GetString(numericDelaySliderLabel.Name);
            btnAddAction.Text = LanguageManager.GetString(btnAddAction.Name);
            btnCreateMacro.Text = LanguageManager.GetString(btnCreateMacro.Name);

            btnMacroSave.Text = LanguageManager.GetString(btnMacroSave.Name);
            btnMacroDelete.Text = LanguageManager.GetString(btnMacroDelete.Name);
            btnNewSavePath.Text = LanguageManager.GetString(btnNewSavePath.Name);
            textBoxDisplayMacroInfo.Text = LanguageManager.GetString(textBoxDisplayMacroInfo.Name);

            countAllMacroRepeatSliderLabel.Text = LanguageManager.GetString(countAllMacroRepeatSliderLabel.Name);
            chkAllMacrosToExecute.Text = LanguageManager.GetString(chkAllMacrosToExecute.Name);
            btnExecuteMacro.Text = LanguageManager.GetString(btnExecuteMacro.Name);
            btnStopMacro.Text = LanguageManager.GetString(btnStopMacro.Name);
            richTextBoxLogInfo.Text = LanguageManager.GetString(richTextBoxLogInfo.Name);

            groupBoxTheme.Text = LanguageManager.GetString(groupBoxTheme.Name);
            materialLabelTheme.Text = LanguageManager.GetString(materialLabelTheme.Name);
            btnSwitchTheme.Text = LanguageManager.GetString(btnSwitchTheme.Name);

            groupBoxCollors.Text = LanguageManager.GetString(groupBoxCollors.Name);
            RadioButtonOrange.Text = LanguageManager.GetString(RadioButtonOrange.Name);
            RadioButtonGreen.Text = LanguageManager.GetString(RadioButtonGreen.Name);
            RadioButtonBlue.Text = LanguageManager.GetString(RadioButtonBlue.Name);
            RadioButtonBase.Text = LanguageManager.GetString(RadioButtonBase.Name);

            groupBoxLanguages.Text = LanguageManager.GetString(groupBoxLanguages.Name);
            RadioButtonLanguageBG.Text = LanguageManager.GetString(RadioButtonLanguageBG.Name);
            RadioButtonLanguageEN.Text = LanguageManager.GetString(RadioButtonLanguageEN.Name);
            RadioButtonLanguageDE.Text = LanguageManager.GetString(RadioButtonLanguageDE.Name);
            RadioButtonLanguageFR.Text = LanguageManager.GetString(RadioButtonLanguageFR.Name);

            groupBoxAllert.Text = LanguageManager.GetString(groupBoxAllert.Name);
            materialLabelAllert.Text = LanguageManager.GetString(materialLabelAllert.Name);
            BtnSwitchModalAlert.Text = LanguageManager.GetString(BtnSwitchModalAlert.Name);
            CheckboxError.Text = LanguageManager.GetString(CheckboxError.Name);
            CheckboxSuccess.Text = LanguageManager.GetString(CheckboxSuccess.Name);
            CheckboxInfo.Text = LanguageManager.GetString(CheckboxInfo.Name);
        }

        #endregion

        //---------------------------------------------------------------------------------
    }
}
