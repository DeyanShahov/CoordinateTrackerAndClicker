using CoordinateTrackerAndClicker.Core.Models;
using CoordinateTrackerAndClicker.Core.Services;
using CoordinateTrackerAndClicker.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CoordinateTrackerAndClicker
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out Point lpPoint);

        private bool isRecording = false;
        private Point currentCoordinate = new Point();
        private List<Point> clickHistory = new List<Point>();
        private Point lastCoordinate = new Point();

        private readonly MouseHook _mouseHook;
        private readonly MouseTracker _mouseTracker;

        public Timer autoClickTimer;

        private MacroService macroService;
        private PrintText printer;
        private ButtonHandler buttonHandler;

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

            buttonHandler.AddNewButton(btnStartRecording, new Button[] { btnStartRecording }, new Button[] { btnStopRecording });
            buttonHandler.AddNewButton(btnStopRecording, new Button[] { btnStopRecording }, new Button[] { btnStartRecording, btnAddAction });
            buttonHandler.AddNewButton(btnAddAction, new Button[] { btnAddAction }, new Button[] { btnCreateMacro });       
            buttonHandler.AddNewButton(btnCreateMacro, new Button[] { btnCreateMacro }, new Button[] { btnExecuteMacro });
            buttonHandler.AddNewButton(btnExecuteMacro, new Button[] { btnExecuteMacro }, new Button[] { btnPauseMacro, btnStopMacro });
            buttonHandler.AddNewButton(btnPauseMacro, new Button[] { btnPauseMacro }, new Button[] { btnContinueMacro });
            buttonHandler.AddNewButton(btnContinueMacro, new Button[] { btnContinueMacro }, new Button[] { btnPauseMacro });
            buttonHandler.AddNewButton(btnStopMacro, new Button[] { btnStopMacro, btnPauseMacro, btnContinueMacro }, new Button[] { btnExecuteMacro });
            
            cmbActionType.SelectedIndex = 0;
        }

        private void MouseTrackTimer_Tick(Point mousePoint)
        {
            if (isRecording)
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
            if (isRecording)
            {
                clickHistory.Add(clickPoint);
                currentCoordinate = clickPoint;
                UpdateCurrentPositionLabel(clickPoint);
                UpdateLastClickLabel(true);
            }
        }

        private void UpdateLastClickLabel(bool fromMouseClick)
        {
            if (clickHistory.Count == 0)
            {
                StatusLabel.Text = "Няма записани кординати";
                return;
            }

            if (clickHistory.Count > 0) 
            {
                int clickCounts = clickHistory.Count;
                lastCoordinate = clickHistory[clickCounts - (fromMouseClick ? 1 : 2)];
                LastClickLabel.Text = $"Последно кликане: X : {lastCoordinate.X}  Y = {lastCoordinate.Y}";
            }    
        }

        private void SaveLastValidCoordinate()
        {
            if (clickHistory.Count > 0)
            {
                int clickCounts = clickHistory.Count;
                lastCoordinate = clickHistory.Count == 1 ? clickHistory[clickCounts - 1] : clickHistory[clickCounts - 2];              

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
            clickHistory.Clear();
            _mouseTracker.StartTracking();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            buttonHandler.ClickButtonMechanicsExecute(sender);
            SaveLastValidCoordinate();
            isRecording = false;           
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
            StatusLabel.Text = string.Empty;
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
                StatusLabel.Text = "Няма записани кординати в полетата";
                return;
            }

            buttonHandler.ClickButtonMechanicsExecute(sender);

            // Add to the macro's action list 
            macroService.AddAction(textBoxActionName.Text, lastCoordinate, (MouseActionType)cmbActionType.SelectedIndex,
                Convert.ToInt32(numericDelay.Value), Convert.ToInt32(numericDelayBefore.Value), chkReturnToOriginal.Checked,
                Convert.ToInt32(FrequencyInput.Value), Convert.ToInt32(DurationInput.Value), Convert.ToInt32(CountInput.Value));

            // Refresh the UI to show the new action
            lstActions.Items.Add(textBoxActionName.Text);
            ClearAllVisualMessages();
        }

        private void btnCreateMacro_Click(object sender, EventArgs e)
        {
            // Спира изпълнението ако няма добавени действия
            if (lstActions.Items.Count == 0)
            {
                StatusLabel.Text = "Няма Действия в списъка";
                return;
            }

            buttonHandler.ClickButtonMechanicsExecute(sender);

            string macroName = macroService.CreateMacro(textBoxMacroName.Text);
            lstMacros.Items.Add(macroName); // Refresh the macro list display

            lstActions.Items.Clear(); // Clear the work action list after macro create
        }

        private void lstMacros_SelectedIndexChanged(object sender, EventArgs e)
            => textBoxDisplayInfo.Text = printer.DisplayMacroInfo(macroService.macrosList[lstMacros.SelectedIndex]);

        private void lstActions_SelectedIndexChanged(object sender, EventArgs e)
            => labelTest.Text = printer.DisplayActionInfo(macroService.currentActionsList[lstActions.SelectedIndex]);

        private void btnExecuteMacro_Click(object sender, EventArgs e)
        {
            // Спира изпълнението ако няма добавени макрота
            if(lstMacros.Items.Count == 0)
            {
                StatusLabel.Text = "Няма Макрота в списъка";
                return;
            }

            buttonHandler.ClickButtonMechanicsExecute(sender);

            // Създаване на AutoClicker и абониране за събитието
            autoClickTimer = new Timer();
            macroService.TimerStopped += AutoClicker_TimerStopped;

            int currentSelectedIndex = lstMacros.SelectedIndex;
            if (currentSelectedIndex == -1) { lstMacros.SelectedIndex = 0; currentSelectedIndex = 0; }

            macroService.ExecuteMacro(autoClickTimer, currentSelectedIndex, (int)countMacroRepeat.Value);
         
            StatusLabel.Text = "Автоматично кликане в прогрес...";                
        }

        private void AutoClicker_TimerStopped(object sender, EventArgs e)
        {
            // Актуализиране на UI
            Invoke(new Action(() => {
                StatusLabel.Text = "Автоматичното кликане приключи.";
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
            StatusLabel.Text = "Пауза ...";
        }

        private void btnContinueMacro_Click(object sender, EventArgs e)
        {
            macroService.OnContinueClick();
            buttonHandler.ClickButtonMechanicsExecute(sender);
            StatusLabel.Text = "Автоматично кликане в прогрес...";
        }

        private void btnStopMacro_Click(object sender, EventArgs e)
        {
            macroService.OnStopClick(autoClickTimer);
            buttonHandler.ClickButtonMechanicsExecute(sender);
            StatusLabel.Text = "Автоматичното кликане беше спряно.";
        }
    }
}
