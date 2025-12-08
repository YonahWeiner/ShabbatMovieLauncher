
using System;
using System.Runtime.InteropServices;

namespace ShabbatMovieLauncher.Services
{

    public class PCDisplayWaker
    {
        [StructLayout(LayoutKind.Sequential)]
        struct INPUT
        {
            public uint type;
            public MOUSEINPUT mi;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        const uint INPUT_MOUSE = 0;
        const uint MOUSEEVENTF_MOVE = 0x0001;
        const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        const uint MOUSEEVENTF_LEFTUP = 0x0004;

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        public static void WakeDisplay()
        {
            INPUT[] input = new INPUT[1];
            input[0].type = INPUT_MOUSE;

            // Fake a 1-pixel mouse move (Windows treats this as real input)
            input[0].mi.dx = 1;
            input[0].mi.dy = 1;
            input[0].mi.dwFlags = MOUSEEVENTF_MOVE;

            SendInput(1, input, Marshal.SizeOf(typeof(INPUT)));

            // Move back so user doesn’t see jump
            input[0].mi.dx = -1;
            input[0].mi.dy = -1;
            SendInput(1, input, Marshal.SizeOf(typeof(INPUT)));
        }
        public static void Click()
        {
            INPUT[] inputs = new INPUT[2];

            // Mouse down
            inputs[0].type = INPUT_MOUSE;
            inputs[0].mi.dwFlags = MOUSEEVENTF_LEFTDOWN;

            // Mouse up
            inputs[1].type = INPUT_MOUSE;
            inputs[1].mi.dwFlags = MOUSEEVENTF_LEFTUP;

            SendInput(2, inputs, Marshal.SizeOf(typeof(INPUT)));
        }

        public static void WakeAndClick()
        {
            WakeDisplay();
            System.Threading.Thread.Sleep(1000); // brief pause
            Click();
        }
    }

}
