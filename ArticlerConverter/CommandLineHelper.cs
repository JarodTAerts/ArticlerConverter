using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlerConverter
{
    public static class CommandLineHelper
    {
        public static void RunCmdHidden(string commandString)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = commandString;
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }
    }
}
