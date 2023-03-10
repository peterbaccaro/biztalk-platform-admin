using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace BTSPlatformAdmin
{
    static class Program
    {
        [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern int SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            const int SW_RESTORE = 9;

            Process pThis = Process.GetCurrentProcess();
            foreach (Process p in Process.GetProcesses())
            {
                if (p.Id != pThis.Id && p.ProcessName == pThis.ProcessName)
                {
                    MessageBox.Show("BizTalk Server Platform Administration is already running.", "BizTalk Server Platform Administration", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    IntPtr hWnd = p.MainWindowHandle;
                    ShowWindow(hWnd, SW_RESTORE);
                    SetForegroundWindow(hWnd);

                    return;
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BTSPlatformAdmin());
        }
    }
}
