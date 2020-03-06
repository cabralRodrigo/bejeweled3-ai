using System;
using System.Runtime.InteropServices;

namespace Bejeweled3AI.Common.Native
{
    internal static class Gdi32
    {
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);
    }
}