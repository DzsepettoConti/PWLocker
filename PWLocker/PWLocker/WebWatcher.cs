using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PWLocker
{
    public class WebWatcher
    {
        string filePath = "c:\\temp\\test.txt";

        // Import necessary Windows API functions
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        // Delegate to handle the callback from EnumWindows
        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        private readonly int _monitoringInterval;

        public WebWatcher(int monitoringInterval = 5000)
        {
            _monitoringInterval = monitoringInterval; // Interval in milliseconds
        }

        public async Task StartMonitoring()
        {
            while (true)
            {
                MonitorChromeWindows();
                Thread.Sleep(_monitoringInterval); // Wait for the specified interval before checking again
                
            }
        }

        private void MonitorChromeWindows()
        {
            // Enumerate all open windows
            EnumWindows((hWnd, lParam) =>
            {
                StringBuilder className = new StringBuilder(256);
                GetClassName(hWnd, className, className.Capacity);

                // Check if the window belongs to Chrome
                if (className.ToString().Contains("Chrome_WidgetWin_1"))
                {
                    StringBuilder windowTitle = new StringBuilder(256);
                    GetWindowText(hWnd, windowTitle, windowTitle.Capacity);
                    
                    // Display the window title in the console
                    string content = $"Chrome window found: {windowTitle}";
                    File.AppendAllText(filePath, content);
                }
                return true; // Continue enumerating windows
            }, IntPtr.Zero);
        }


    }
}
