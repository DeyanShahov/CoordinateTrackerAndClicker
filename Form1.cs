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
        private PrintText printer;
        private Printer _printer;
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

            _printer = new Printer((message, fontSize) => 
            {
                StatusLabel.Text = message;
                textBoxLogInfo.Text = message;
                //if (fontSize.HasValue) StatusLabel.Font.Size = fontSize.Value;            
            });

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
                _printer.Print("Отчетени нови кординати");
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
            _printer.Print("Следене на кординатите в процес ...");
            //_printer.Print("🐇");
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            buttonHandler.ClickButtonMechanicsExecute(sender);
            SaveLastValidCoordinate();
            isRecording = false;
            isRecordingOn = false;
            _printer.Print(clickHistory.Any() ? "Заредени кординати за действие" : "Няма записани кординати");
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
                _printer.Print("Няма записани кординати в полетата");
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
                _printer.Print("Няма Действия в списъка");
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
            if (lstMacros.Items.Count == 0)
            {
                _printer.Print("Няма Макрота в списъка");
                return;
            }

            buttonHandler.ClickButtonMechanicsExecute(sender);

            // Създаване на AutoClicker и абониране за събитието
            autoClickTimer = new Timer();
            macroService.TimerStopped += AutoClicker_TimerStopped;

            int currentSelectedIndex = lstMacros.SelectedIndex;
            if (currentSelectedIndex == -1) { lstMacros.SelectedIndex = 0; currentSelectedIndex = 0; }

            macroService.ExecuteMacro(autoClickTimer, currentSelectedIndex, (int)countMacroRepeat.Value);

            _printer.Print("Автоматично кликане в прогрес...");
        }

        private void AutoClicker_TimerStopped(object sender, EventArgs e)
        {
            // Актуализиране на UI
            Invoke(new Action(() =>
            {
                _printer.Print("Автоматичното кликане приключи.");
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
            _printer.Print("Пауза ...");
        }

        private void btnContinueMacro_Click(object sender, EventArgs e)
        {
            macroService.OnContinueClick();
            buttonHandler.ClickButtonMechanicsExecute(sender);
            _printer.Print("Автоматично кликане в прогрес...");
        }

        private void btnStopMacro_Click(object sender, EventArgs e)
        {
            macroService.OnStopClick(autoClickTimer);
            buttonHandler.ClickButtonMechanicsExecute(sender);
            _printer.Print("Автоматичното кликане беше спряно.");
        }       
    }
}
