namespace VolumeControllerService.Utility
{
    using System;
    using System.Runtime.InteropServices;
    public class Shutdown
    {
        public Shutdown(Action disposeAction)
        {
            handler = new ConsoleEventDelegate((a) => ConsoleEventCallback(a, disposeAction));
            SetConsoleCtrlHandler(handler, true);
        }

        static bool ConsoleEventCallback(int eventType, Action disposeAction)
        {
            if (eventType == 2)
                disposeAction();
            return false;
        }
        static ConsoleEventDelegate handler;

        private delegate bool ConsoleEventDelegate(int eventType);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleCtrlHandler(ConsoleEventDelegate callback, bool add);
    }
}
