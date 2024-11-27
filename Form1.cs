using CoordinateTrackerAndClicker.Core.Models;
using CoordinateTrackerAndClicker.Core.Services;
using CoordinateTrackerAndClicker.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace CoordinateTrackerAndClicker
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out Point lpPoint);

        private bool isRecording = false;
        private Point currentCoordinate = new Point();
        private Timer mouseTrackTimer;
        private List<Point> clickHistory = new List<Point>();
        private List<Point> savedPoints = new List<Point>();
        private Point lastCoordinate = new Point();

        // Нови променливи за автоматично кликане
        public Timer autoClickTimer;
        //private DateTime endTime;
        //private int countActionRepeat;
        //private int countMacRepeat;

        //private List<Macro> macros = new List<Macro>();
        //private Macro currentMacro = new Macro();
        //private Macro macroToExecute;
        //private int currentActionIndex = 0;

        //private MouseActionExecutor mouseActionExecutor;
        private MacroService macroService;
        private PrintText printer;

        public Form1()
        {
            //mouseActionExecutor = new MouseActionExecutor();
            macroService = new MacroService();
            printer = new PrintText();


            InitializeComponent();
            cmbActionType.SelectedIndex = 0;

            SetupForm();
            SetupMouseTracking();
        }

        private void SetupForm()
        {
            this.KeyPreview = true;
            this.KeyDown += MainForm_KeyDown;
            SetupGlobalMouseHook();
        }

        private void SetupMouseTracking()
        {
            mouseTrackTimer = new Timer();
            mouseTrackTimer.Interval = 50;
            mouseTrackTimer.Tick += MouseTrackTimer_Tick;
            mouseTrackTimer.Start();
        }

        private void MouseTrackTimer_Tick(object sender, EventArgs e)
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
            isRecording = true;
            btnExecuteMacro.Enabled = false;
            StopButton.Enabled = true;
            clickHistory.Clear();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            SaveLastValidCoordinate();
            isRecording = false;
            btnExecuteMacro.Enabled = true;
            StopButton.Enabled = false;
            clickHistory.Clear();
        }

        // UI ... 
        private void ResetButton_Click(object sender, EventArgs e)
        {
            isRecording = false;
            currentCoordinate = new Point();
            //StartButton.Enabled = true;
            StopButton.Enabled = false;
            clickHistory.Clear();
            CurrentPositionLabel.Text = "Текуща позиция: ";
            StatusLabel.Text = "";
        }

      
        // UI
        private void UpdateCurrentPositionLabel(Point point)
        {
            CurrentPositionLabel.Text = $"Текуща позиция: X={point.X}, Y={point.Y}";
        }

        // SERVICE
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Space && isRecording)
            {
                SaveLastValidCoordinate();
            }
        }     

        // UI 
        #region Global Mouse Hook

        private const int WH_MOUSE_LL = 14;
        private const int WM_LBUTTONDOWN = 0x0201;
        private static IntPtr hookHandle = IntPtr.Zero;
        private static MouseHookHandler hookHandler;

        private delegate IntPtr MouseHookHandler(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, MouseHookHandler lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll")]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [StructLayout(LayoutKind.Sequential)]
        private struct MSLLHOOKSTRUCT
        {
            public Point pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        private void SetupGlobalMouseHook()
        {
            hookHandler = new MouseHookHandler(MouseHookProc);
            hookHandle = SetWindowsHookEx(WH_MOUSE_LL, hookHandler, IntPtr.Zero, 0);
        }

        private IntPtr MouseHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam.ToInt32() == WM_LBUTTONDOWN)
            {
                MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                OnGlobalMouseClick(hookStruct.pt);
            }
            return CallNextHookEx(hookHandle, nCode, wParam, lParam);
        }

        #endregion

        private void btnAddAction_Click(object sender, EventArgs e)
        {          
            // Add to the macro's action list 
            macroService.AddAction(textBoxActionName.Text, lastCoordinate, (MouseActionType)cmbActionType.SelectedIndex,
                Convert.ToInt32(numericDelay.Value), Convert.ToInt32(numericDelayBefore.Value), chkReturnToOriginal.Checked,
                Convert.ToInt32(FrequencyInput.Value), Convert.ToInt32(DurationInput.Value), Convert.ToInt32(CountInput.Value));

            // Refresh the UI to show the new action
            lstActions.Items.Add(textBoxActionName.Text); 
        }       

        private void btnCreateMacro_Click(object sender, EventArgs e)
        {
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

            // Създаване на AutoClicker и абониране за събитието
            autoClickTimer = new Timer();
            macroService.TimerStopped += AutoClicker_TimerStopped;

            int currentSelectedIndex = lstMacros.SelectedIndex;
            if (currentSelectedIndex == -1) { lstMacros.SelectedIndex = 0; currentSelectedIndex = 0; }

            macroService.ExecuteMacro(autoClickTimer, currentSelectedIndex, (int)countMacroRepeat.Value);

            btnExecuteMacro.Enabled = false;
            StatusLabel.Text = "Автоматично кликане в прогрес...";                
        }

        private void AutoClicker_TimerStopped(object sender, EventArgs e)
        {
            // Актуализиране на UI
            Invoke(new Action(() => {
                StatusLabel.Text = "Автоматичното кликане приключи.";
                btnExecuteMacro.Enabled = true;   
            }));
        }
    }
}
