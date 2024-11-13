using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace CoordinateTrackerAndClicker
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out POINT lpPoint);

        // Импортираме функцията от user32.dll
        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        private const int MOUSEEVENTF_WHEEL = 0x0800;

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int X;
            public int Y;
        }

        private bool isRecording = false;
        private Point currentCoordinate = new Point();
        private Point firstSavedCoordinate = new Point();
        private Point secondSavedCoordinate = new Point();
        private bool isFirstCoordinateSet = false;
        private Timer mouseTrackTimer;
        private List<Point> clickHistory = new List<Point>();
        private List<POINT> savedPoints = new List<POINT>();
        private Point lastCoordinate = new Point();
        //private Rectangle formBounds;

        // Нови променливи за автоматично кликане
        private Timer autoClickTimer;
        private DateTime endTime;
        private int countActionRepeat;
        private int countMacRepeat;

        private bool isSingleClick = true;
        private bool isDoubleClick = false;
        private bool isMacroCommand = false;

        private List<Macro> macros = new List<Macro>();
        private Macro currentMacro = new Macro();
        private int currentActionIndex = 0;

        public Form1()
        {
            InitializeComponent();
            cmbActionType.SelectedIndex = 0;

            SetupForm();
            SetupMouseTracking();

            setTestText();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SetupForm()
        {
            this.KeyPreview = true;
            this.KeyDown += MainForm_KeyDown;
            //this.Shown += MainForm_Shown;
            SetupGlobalMouseHook();
        }

        //private void MainForm_Shown(object sender, EventArgs e)
        //{
        //    formBounds = new Rectangle(this.Location, this.Size);
        //}

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
                POINT point;
                if (GetCursorPos(out point))
                {
                    currentCoordinate = new Point(point.X, point.Y);
                    CurrentPositionLabel.Text = $"Текуща позиция: X : {currentCoordinate.X} Y : {currentCoordinate.Y}";                
                }
            }
        }

        private void OnGlobalMouseClick(Point clickPoint)
        {
            if (isRecording)// && !IsClickInFormBounds(clickPoint))
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

        //private bool IsClickInFormBounds(Point clickPoint)
        //{
        //    return formBounds.Contains(clickPoint);
        //}

        private void SaveLastValidCoordinate()
        {
            if (clickHistory.Count > 0)
            {
                int clickCounts = clickHistory.Count;
                lastCoordinate = clickHistory.Count == 1 ? clickHistory[clickCounts - 1] : clickHistory[clickCounts - 2];
                Point lastClick = lastCoordinate;

                if (!isFirstCoordinateSet)
                {
                    firstSavedCoordinate = lastClick;
                    isFirstCoordinateSet = true;
                }
                else
                {
                    secondSavedCoordinate = lastClick;
                }

                //UpdateCoordinatesLabel();
                UpdateCoordinatesBoxes(lastCoordinate);
                UpdateLastClickLabel(false);
                //LastClickLabel.Text = $"Последно кликане: X : {lastCoordinate.X}  Y = {lastCoordinate.Y}";
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
            StartButton.Enabled = false;
            StopButton.Enabled = true;
            clickHistory.Clear();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            SaveLastValidCoordinate();
            isRecording = false;
            StartButton.Enabled = true;
            StopButton.Enabled = false;
            clickHistory.Clear();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            isRecording = false;
            isFirstCoordinateSet = false;
            firstSavedCoordinate = new Point();
            secondSavedCoordinate = new Point();
            currentCoordinate = new Point();
            StartButton.Enabled = true;
            StopButton.Enabled = false;
            clickHistory.Clear();
            //UpdateCoordinatesLabel();
            CurrentPositionLabel.Text = "Текуща позиция: ";
            StatusLabel.Text = "";
        }

      

        private void UpdateCurrentPositionLabel(Point point)
        {
            CurrentPositionLabel.Text = $"Текуща позиция: X={point.X}, Y={point.Y}";
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Space && isRecording)
            {
                SaveLastValidCoordinate();
            }
        }

        // Нова функционалност за автоматично кликане
        private void StartClickingButton_Click(object sender, EventArgs e)
        {
            if (firstSavedCoordinate.IsEmpty)
            {
                MessageBox.Show("Моля, запазете поне една координата преди да започнете автоматичното кликане.");
                return;
            }

            int frequency = (int)FrequencyInput.Value;
            int duration = (int)DurationInput.Value;
            int count = (int)CountInput.Value;

            StartClickingButton.Enabled = false;
            StatusLabel.Text = "Автоматично кликане в прогрес...";

            endTime = DateTime.Now.AddMinutes(duration);
            countActionRepeat = count;

            autoClickTimer = new Timer();
            autoClickTimer.Interval = frequency * 1000; // Convert to milliseconds
            autoClickTimer.Tick += AutoClickTimer_Tick;
            autoClickTimer.Start();
        }

        private void AutoClickTimer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now >= endTime || countActionRepeat <= 0)
            {
                currentActionIndex++;

                if (currentMacro.Actions.Count <= currentActionIndex)
                {
                    currentMacro.RepeatCount--;
                    currentActionIndex = 0;

                    if (currentMacro.RepeatCount <= 0)
                    {
                        autoClickTimer.Stop();
                        StartClickingButton.Enabled = true;                
                        StatusLabel.Text = "Автоматичното кликане приключи.";
                        return;
                    } 
                    
                    
                }

                endTime = DateTime.Now.AddMinutes(currentMacro.Actions[currentActionIndex].Duration);
                countActionRepeat = currentMacro.Actions[currentActionIndex].RepeatCount;
                autoClickTimer.Interval = currentMacro.Actions[currentActionIndex].Frequency * 1000;
            }

            // Избор на крайно дейстрие
            ExecuteAction(currentMacro.Actions[currentActionIndex]);

            // Намаля максималния брои на повторения
            countActionRepeat--;
        }

        private void SimulateClick(int x, int y)
        {
            // Запазваме текущата позиция на курсора
            POINT originalPos;
            GetCursorPos(out originalPos);

            // Преместваме курсора на желаните координати
            SetCursorPos(x, y);

            // Изчакваме малко, за да симулираме нормалната пауза между кликванията
            System.Threading.Thread.Sleep(100);

            // Симулираме първия клик (натискане и освобождаване на левия бутон)
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);



            // Симулираме завъртане на колелото на мишката (нагоре или надолу)
            // dwData: положителна стойност за завъртане нагоре, отрицателна за надолу
            //mouse_event(MOUSEEVENTF_WHEEL, 0, 0, 520, 0); // Завъртане нагоре (120 е една стъпка)
            //System.Threading.Thread.Sleep(500); // Изчакване за ефекта
            //mouse_event(MOUSEEVENTF_WHEEL, 0, 0, -720, 0); // Завъртане надолу

            // Връщаме курсора на първоначалната позиция
            SetCursorPos(originalPos.X, originalPos.Y);
        }

        private void SimulateDoubleClick(int x, int y)
        {
            // Запазваме текущата позиция на курсора
            POINT originalPos;
            GetCursorPos(out originalPos);

            // Преместваме курсора на желаните координати
            SetCursorPos(x, y);

            // Симулираме първия клик (натискане и освобождаване на левия бутон)
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

            // Изчакваме малко, за да симулираме нормалната пауза между кликванията
            System.Threading.Thread.Sleep(100);

            // Симулираме втория клик за двойния клик
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

            // Връщаме курсора на първоначалната позиция
            SetCursorPos(originalPos.X, originalPos.Y);
        }

        private void SimulateTwoActionsClick()
        {
            // Запазваме текущата позиция на курсора
            POINT originalPos;
            GetCursorPos(out originalPos);

            // Преместваме курсора на желаните координати
            SetCursorPos(firstSavedCoordinate.X, firstSavedCoordinate.Y);

            // Изчакваме, за да осъществи командата
            System.Threading.Thread.Sleep(1000);

            // Симулираме клик (натискане и освобождаване на левия бутон)
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

            // Изчакваме, за да осъществи командата
            System.Threading.Thread.Sleep(7000);

            // Преместваме курсора на желаните координати
            SetCursorPos(secondSavedCoordinate.X, secondSavedCoordinate.Y);

            // Изчакваме, за да осъществи командата
            System.Threading.Thread.Sleep(1000);

            // Симулираме клик (натискане и освобождаване на левия бутон)
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

            // Изчакваме, за да осъществи командата
            System.Threading.Thread.Sleep(1000);

            // Връщаме курсора на първоначалната позиция
            SetCursorPos(originalPos.X, originalPos.Y);
        }


        private void setTestText()
        {
            labelTest.Text = isSingleClick + " | " + isDoubleClick + " | " + isMacroCommand;
        }


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
            var action = new MouseAction();

            action.Name = textBoxActionName.Text;
            action.Coordinates = lastCoordinate;
            action.ActionType = SetActionType();
            action.DelayAfter = Convert.ToInt32(numericDelay.Value);
            action.DelayBefore = Convert.ToInt32(numericDelayBefore.Value);
            action.ReturnToOriginal = chkReturnToOriginal.Checked;
            action.Frequency = Convert.ToInt32(FrequencyInput.Value);
            action.Duration = Convert.ToInt32(DurationInput.Value);
            action.RepeatCount = Convert.ToInt32(CountInput.Value);

            // Add to the macro's action list
            currentMacro.Actions.Add(action);
            // Refresh the UI to show the new action
            lstActions.Items.Add(action.Name);
        }

        private MouseActionType SetActionType()
        {
            // Избор на крайно дейстрие
            if (isSingleClick) return MouseActionType.SingleClick;// SimulateClick(firstSavedCoordinate.X, firstSavedCoordinate.Y);
            else if (isDoubleClick) return MouseActionType.DoubleClick;// SimulateDoubleClick(firstSavedCoordinate.X, firstSavedCoordinate.Y);
            else if (isMacroCommand) return MouseActionType.Scroll;// SimulateTwoActionsClick();

            return (MouseActionType)cmbActionType.SelectedIndex;
        }


        private void ExecuteAction(MouseAction action)
        {
            SetCursorPos(action.Coordinates.X, action.Coordinates.Y);

            System.Threading.Thread.Sleep(action.DelayBefore);

            // Perform the action
            if (action.ActionType == MouseActionType.SingleClick)
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            }
            else if (action.ActionType == MouseActionType.DoubleClick)
            {
                // Double click logic
            }
            else if (action.ActionType == MouseActionType.Scroll)
            {
                // Scroll logic
            }

            System.Threading.Thread.Sleep(action.DelayAfter);
       
        }

        private void btnSaveMacro_Click(object sender, EventArgs e)
        {
            currentMacro.Name = textBoxMacroName.Text;     
            macros.Add(currentMacro);
            lstMacros.Items.Add(currentMacro.Name); // Refresh the macro list display

            currentMacro = new Macro();
            lstActions.Items.Clear();
        }

        private void lstMacros_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedMacros = macros[lstMacros.SelectedIndex];
            var textToPrint = new StringBuilder();
            textToPrint.AppendLine(selectedMacros.Name);

            selectedMacros.Actions.ForEach(a => textToPrint.AppendLine(printText(a)));

            textBoxDisplayInfo.Text = textToPrint.ToString();
        }

        private string printText(MouseAction action)
        {
            var textResult = new StringBuilder();
            textResult.AppendLine($"        {action.Name}");
            textResult.AppendLine($"     {action.Coordinates.ToString()}");
            textResult.AppendLine($"     {action.ActionType.ToString()}");
            textResult.AppendLine($"     {action.DelayBefore.ToString()}");
            textResult.AppendLine($"     {action.DelayAfter.ToString()}");
            textResult.AppendLine($"     {action.ReturnToOriginal.ToString()}");
            textResult.AppendLine($"     {action.Frequency.ToString()}");
            textResult.AppendLine($"     {action.Duration.ToString()}");
            textResult.AppendLine($"     {action.RepeatCount.ToString()}");

            return textResult.ToString();
        }

        private void lstActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            var test = currentMacro.Actions[lstActions.SelectedIndex];
         
            labelTest.Text = $"{lstActions.SelectedIndex}\nИме: {test.Name}\nДеиствия: " +
                $"\n    Кординати: {test.Coordinates.X} : {test.Coordinates.Y}" +
                $"\n    Действие: {test.ActionType}" +
                $"\n    Забавяне преди: {test.DelayBefore}" +
                $"\n    Забавяне след: {test.DelayAfter}" +
                $"\n    Честота: {test.Frequency}" +
                $"\n    Продължителност: {test.Duration}" +
                $"\n    Повторения: {test.RepeatCount}" +
                $"\n    Оригинална позиция: {test.ReturnToOriginal}";
        }

        private void btnExecuteMacro_Click(object sender, EventArgs e)
        {
            Macro test = macros[lstMacros.SelectedIndex] ?? macros[0];
            test.RepeatCount = (int)countMacroRepeat.Value;
            currentMacro = test;

            StartClickingButton.Enabled = false;
            StatusLabel.Text = "Автоматично кликане в прогрес...";

            endTime = DateTime.Now.AddMinutes(currentMacro.Actions[currentActionIndex].Duration);
            countActionRepeat = currentMacro.Actions[currentActionIndex].RepeatCount;

            autoClickTimer = new Timer();
            autoClickTimer.Interval = currentMacro.Actions[currentActionIndex].Frequency * 1000; // Convert to milliseconds
            autoClickTimer.Tick += AutoClickTimer_Tick;
            autoClickTimer.Start();
        }
    }
}
