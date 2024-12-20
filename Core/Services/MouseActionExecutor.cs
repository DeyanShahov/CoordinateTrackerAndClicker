using CoordinateTrackerAndClicker.Core.Models;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoordinateTrackerAndClicker.Core.Services
{
    internal class MouseActionExecutor : IMouseActionExecutor
    {
        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out Point lpPoint);

        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const int MOUSEEVENTF_RIGHTUP = 0x0010;
        private const int MOUSEEVENTF_WHEEL = 0x0800;

        //public async Task Execute(MouseAction action, CancellationToken cancellationToken, ManualResetEvent _pauseEvent)
        public async Task Execute(MouseAction action, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            // Запазваме текущата позиция на курсора
            var originalPos = Cursor.Position;

            // Чакаме, докато не се възобнови от пауза
            //_pauseEvent.WaitOne();

            Cursor.Position = action.Coordinates;

            await Task.Delay(action.DelayBefore, cancellationToken);
            //await WaitWithPause(action.DelayBefore, cancellationToken, _pauseEvent);

            switch (action.ActionType)
            {
                case MouseActionType.SingleClick:
                    SimulateSingleClick();
                    break;
                case MouseActionType.DoubleClick:
                    SimulateDoubleClick();
                    break;
                case MouseActionType.Scroll:
                    SimulateScroll();
                    break;
                case MouseActionType.RightClick:
                    SimulateRightClick();
                    break;
            }

            //if(_pauseEvent.WaitOne(0))
            //{
            //    await WaitWithPause(action.DelayAfter, cancellationToken, _pauseEvent);
            //}
            await Task.Delay(action.DelayAfter, cancellationToken);
           

            // Връщаме курсора на първоначалната позиция ако е отбелязано
            if (action.ReturnToOriginal)
            {
                //_pauseEvent.WaitOne();
                Cursor.Position = originalPos;
            }
        }

        public void SimulateSingleClick()
        {
            // Симулираме клик (натискане и освобождаване на левия бутон)
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }
        public void SimulateDoubleClick()
        {
            // Симулираме първия клик (натискане и освобождаване на левия бутон)
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

            // Изчакваме малко, за да симулираме нормалната пауза между кликванията
            Thread.Sleep(300);

            // Симулираме втория клик за двойния клик
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }
        public void SimulateScroll(int dwData = 520)
        {
            // Симулираме завъртане на колелото на мишката (нагоре или надолу)
            // dwData: положителна стойност за завъртане нагоре, отрицателна за надолу
            mouse_event(MOUSEEVENTF_WHEEL, 0, 0, dwData, 0); // Завъртане нагоре (120 е една стъпка)
            Thread.Sleep(500); // Изчакване за ефекта
            //mouse_event(MOUSEEVENTF_WHEEL, 0, 0, -720, 0); // Завъртане надолу
        }

        public void SimulateRightClick()
        {
            // Симулираме клик (натискане и освобождаване на десния бутон)
            mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
        }

        //private async Task WaitWithPause(int milliseconds, CancellationToken cancellationToken, ManualResetEvent _pauseEvent)
        //{
        //    int interval = 100; // Проверка за пауза на всеки 100мс
        //    int elapsed = 0;

        //    while (elapsed < milliseconds)
        //    {
        //        // Чакаме за пауза и проверяваме за отмяна
        //        _pauseEvent.WaitOne();
        //        cancellationToken.ThrowIfCancellationRequested();

        //        // Изчакваме малък интервал
        //        int delay = Math.Min(interval, milliseconds - elapsed);
        //        await Task.Delay(delay, cancellationToken);
        //        elapsed += delay;
        //    }
        //}
    }
}
