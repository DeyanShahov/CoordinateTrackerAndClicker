using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;
//using System.Threading;

namespace CoordinateTrackerAndClicker
{
    public partial class MainForm : Form1
    {
        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out POINT lpPoint);

        // Импортираме функцията от user32.dll
        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const uint MOUSEEVENTF_LEFTUP = 0x0004;

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
        private Rectangle formBounds;

        // Нови променливи за автоматично кликане
        private Timer autoClickTimer;
        private DateTime endTime;

        public MainForm()
        {
            InitializeComponent();
            SetupForm();
            SetupMouseTracking();
        }

        private void InitializeComponent()
        {
            this.StartButton = new Button();
            this.StopButton = new Button();
            this.ResetButton = new Button();
            this.CoordinatesLabel = new Label();
            this.CurrentPositionLabel = new Label();
            this.FrequencyLabel = new Label();
            this.FrequencyInput = new NumericUpDown();
            this.DurationLabel = new Label();
            this.DurationInput = new NumericUpDown();
            this.StartClickingButton = new Button();
            this.StatusLabel = new Label();

            // Form
            this.ClientSize = new Size(400, 300);
            this.Text = "Координатен тракер и кликер";
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width - 20, 20);

            // Start Button
            this.StartButton.Location = new Point(10, 10);
            this.StartButton.Size = new Size(100, 30);
            this.StartButton.Text = "Старт запис";
            this.StartButton.Click += StartButton_Click;

            // Stop Button
            this.StopButton.Location = new Point(120, 10);
            this.StopButton.Size = new Size(100, 30);
            this.StopButton.Text = "Стоп запис";
            this.StopButton.Enabled = false;
            this.StopButton.Click += StopButton_Click;

            // Reset Button
            this.ResetButton.Location = new Point(230, 10);
            this.ResetButton.Size = new Size(100, 30);
            this.ResetButton.Text = "Ресет";
            this.ResetButton.Click += ResetButton_Click;

            // Coordinates Label
            this.CoordinatesLabel.Location = new Point(10, 50);
            this.CoordinatesLabel.Size = new Size(380, 60);
            this.CoordinatesLabel.Text = "Запазени координати:\nПърви: Няма\nВтори: Няма";

            // Current Position Label
            this.CurrentPositionLabel.Location = new Point(10, 120);
            this.CurrentPositionLabel.Size = new Size(380, 20);
            this.CurrentPositionLabel.Text = "Текуща позиция: ";

            // Frequency Label
            this.FrequencyLabel.Location = new Point(10, 150);
            this.FrequencyLabel.Size = new Size(120, 20);
            this.FrequencyLabel.Text = "Честота (секунди):";

            // Frequency Input
            this.FrequencyInput.Location = new Point(140, 150);
            this.FrequencyInput.Size = new Size(60, 20);
            this.FrequencyInput.Minimum = 1;
            this.FrequencyInput.Maximum = 3600;
            this.FrequencyInput.Value = 10;

            // Duration Label
            this.DurationLabel.Location = new Point(10, 180);
            this.DurationLabel.Size = new Size(120, 20);
            this.DurationLabel.Text = "Продължителност (мин):";

            // Duration Input
            this.DurationInput.Location = new Point(140, 180);
            this.DurationInput.Size = new Size(60, 20);
            this.DurationInput.Minimum = 1;
            this.DurationInput.Maximum = 1440;
            this.DurationInput.Value = 1;

            // Start Clicking Button
            this.StartClickingButton.Location = new Point(10, 210);
            this.StartClickingButton.Size = new Size(150, 30);
            this.StartClickingButton.Text = "Започни автоматично кликане";
            this.StartClickingButton.Click += StartClickingButton_Click;

            // Status Label
            this.StatusLabel.Location = new Point(10, 250);
            this.StatusLabel.Size = new Size(380, 20);
            this.StatusLabel.Text = "";

            this.Controls.AddRange(new Control[] {
                this.StartButton, this.StopButton, this.ResetButton,
                this.CoordinatesLabel, this.CurrentPositionLabel,
                this.FrequencyLabel, this.FrequencyInput,
                this.DurationLabel, this.DurationInput,
                this.StartClickingButton, this.StatusLabel
            });
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

            StartClickingButton.Enabled = false;
            StatusLabel.Text = "Автоматично кликане в прогрес...";

            endTime = DateTime.Now.AddMinutes(duration);

            autoClickTimer = new Timer();
            autoClickTimer.Interval = frequency * 1000; // Convert to milliseconds
            autoClickTimer.Tick += AutoClickTimer_Tick;
            autoClickTimer.Start();
        }

        private void AutoClickTimer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now >= endTime)
            {
                autoClickTimer.Stop();
                StartClickingButton.Enabled = true;
                StatusLabel.Text = "Автоматичното кликане приключи.";
                return;
            }

            SimulateClick(firstSavedCoordinate.X, firstSavedCoordinate.Y);
            //SimulateDoubleClick(firstSavedCoordinate.X, firstSavedCoordinate.Y);
        }

        private void SimulateClick(int x, int y)
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
            System.Threading.Thread.Sleep(10);  

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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (mouseTrackTimer != null)
                {
                    mouseTrackTimer.Stop();
                    mouseTrackTimer.Dispose();
                }
                if (autoClickTimer != null)
                {
                    autoClickTimer.Stop();
                    autoClickTimer.Dispose();
                }
                if (hookHandle != IntPtr.Zero)
                {
                    UnhookWindowsHookEx(hookHandle);
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        private Button StartButton;
        private Button StopButton;
        private Button ResetButton;
        private Label CoordinatesLabel;
        private Label CurrentPositionLabel;
        private Label FrequencyLabel;
        private NumericUpDown FrequencyInput;
        private Label DurationLabel;
        private NumericUpDown DurationInput;
        private Button StartClickingButton;
        private Label StatusLabel;
    }
}