using Bejeweled3AI.Common.Native;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;

namespace Bejeweled3AI.Common
{
    public class ApplicationTracker
    {
        private static readonly Brush ErrorBrush = new SolidBrush(Color.Pink);

        private readonly string processName;
        private Process processo;

        public ApplicationTracker() : this("Bejeweled3") { }

        public ApplicationTracker(string processName)
        {
            this.processName = processName;
        }

        public bool Init()
        {
            var processos = Process.GetProcessesByName(this.processName);
            if (processos.Any())
            {
                this.processo = processos[0];
                return true;
            }
            else
                return false;
        }

        public Bitmap GetScreenshot()
        {
            var c = 0;
            Bitmap output = null;
            do
            {
                output = GetScreenshotInternal();
            } while (output == null && c < 10);

            if (output == null)
                throw new Exception("");

            return output;
        }

        private Bitmap GetScreenshotInternal()
        {
            if (this.processo == null)
                throw new Exception("Não inicializado.");

            var handleWindow = this.processo.MainWindowHandle;

            User32.GetWindowRect(handleWindow, out var recWindow);

            var bmp = new Bitmap(recWindow.Right - recWindow.Left, recWindow.Bottom - recWindow.Top, PixelFormat.Format24bppRgb);
            using (var g = Graphics.FromImage(bmp))
            {
                var handleBitmap = g.GetHdc();

                try
                {
                    if (!User32.PrintWindow(handleWindow, handleBitmap, 0))
                    {
                        var error = Marshal.GetLastWin32Error();
                        throw new Exception($"Win32 error code {error}");
                    }
                }
                finally
                {
                    g.ReleaseHdc(handleBitmap);
                }

                //var handleRegion = Gdi32.CreateRectRgn(0, 0, 0, 0);
                //User32.GetWindowRgn(handleWindow, handleRegion);

                //using (var region = Region.FromHrgn(handleRegion))
                //    if (!region.IsEmpty(g))
                //    {
                //        g.ExcludeClip(region);
                //        g.Clear(Color.Transparent);
                //    }
            }

            return bmp;
        }

        public Rectangle GetWindowRect()
        {
            User32.GetWindowRect(this.processo.MainWindowHandle, out var rect);
            return rect;
        }

        public void SetActive()
        {
            SetWindowActive(this.processo.Handle, this.processo.MainWindowHandle);
        }

        public static void SetWindowActive(IntPtr processHandle, IntPtr windowHandle)
        {
            //check if the window is hidden / minimized
            if (windowHandle == IntPtr.Zero)
                //the window is hidden so try to restore it before setting focus.
                User32.ShowWindow(processHandle, User32.ShowWindowEnum.Restore);

            //set user the focus to the window
            User32.SetForegroundWindow(windowHandle);
        }
    }
}