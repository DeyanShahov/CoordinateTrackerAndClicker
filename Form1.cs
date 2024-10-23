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
        private Rectangle formBounds;

        // Нови променливи за автоматично кликане
        private Timer autoClickTimer;
        private DateTime endTime;
        private int countRepeat;

        private bool isSingleClick = true;
        private bool isDoubleClick = false;
        private bool isMacroCommand = false;

        public Form1()
        {
            InitializeComponent();
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
            this.Shown += MainForm_Shown;
            SetupGlobalMouseHook();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            formBounds = new Rectangle(this.Location, this.Size);
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
                POINT point;
                if (GetCursorPos(out point))
                {
                    currentCoordinate = new Point(point.X, point.Y);
                    CurrentPositionLabel.Text = $"Текуща позиция: X={currentCoordinate.X}, Y={currentCoordinate.Y}";
                }
            }
        }

        private void OnGlobalMouseClick(Point clickPoint)
        {
            if (isRecording && !IsClickInFormBounds(clickPoint))
            {
                clickHistory.Add(clickPoint);
                currentCoordinate = clickPoint;
                UpdateCurrentPositionLabel(clickPoint);
            }
        }

        private bool IsClickInFormBounds(Point clickPoint)
        {
            return formBounds.Contains(clickPoint);
        }

        private void SaveLastValidCoordinate()
        {
            if (clickHistory.Count > 0)
            {
                Point lastClick = clickHistory[clickHistory.Count - 2];

                if (!isFirstCoordinateSet)
                {
                    firstSavedCoordinate = lastClick;
                    isFirstCoordinateSet = true;
                }
                else
                {
                    secondSavedCoordinate = lastClick;
                }

                UpdateCoordinatesLabel();
            }
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
            UpdateCoordinatesLabel();
            CurrentPositionLabel.Text = "Текуща позиция: ";
            StatusLabel.Text = "";
        }

        private void UpdateCoordinatesLabel()
        {
            string firstCoord = firstSavedCoordinate.IsEmpty ?
                "Няма" : $"X={firstSavedCoordinate.X}, Y={firstSavedCoordinate.Y}";
            string secondCoord = secondSavedCoordinate.IsEmpty ?
                "Няма" : $"X={secondSavedCoordinate.X}, Y={secondSavedCoordinate.Y}";

            CoordinatesLabel.Text = $"Запазени координати:\nПърви: {firstCoord}\nВтори: {secondCoord}";
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
            countRepeat = count;

            autoClickTimer = new Timer();
            autoClickTimer.Interval = frequency * 1000; // Convert to milliseconds
            autoClickTimer.Tick += AutoClickTimer_Tick;
            autoClickTimer.Start();
        }

        private void AutoClickTimer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now >= endTime || countRepeat <= 0)
            {
                autoClickTimer.Stop();
                StartClickingButton.Enabled = true;
                StatusLabel.Text = "Автоматичното кликане приключи.";
                return;
            }

            // Избор на крайно дейстрие
            if(isSingleClick) SimulateClick(firstSavedCoordinate.X, firstSavedCoordinate.Y);
            else if(isDoubleClick) SimulateDoubleClick(firstSavedCoordinate.X, firstSavedCoordinate.Y);
            else if(isMacroCommand) SimulateTwoActionsClick();

            // Намаля максималния брои на повторения
            countRepeat--;
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

        

        private void radioButtonSingleClick_CheckedChanged(object sender, EventArgs e)
        {
            isSingleClick = !isSingleClick;
            setTestText();
        }

        private void radioButtonDoubleClick_CheckedChanged(object sender, EventArgs e)
        {
            isDoubleClick = !isDoubleClick;
            setTestText();
        }

        private void radioButtonMacro_CheckedChanged(object sender, EventArgs e)
        {
            isMacroCommand = !isMacroCommand;
            setTestText();
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
    }
}
