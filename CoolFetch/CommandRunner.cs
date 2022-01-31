using System;
using System.Diagnostics;
using System.IO;

namespace CoolFetch
{
    public static class CommandRunner
    {
        private static string shell;
        
        public static string runCommand(string programExecutable, string command)
        {
            if(shell == null) getShell();
            
            var psi = new ProcessStartInfo();
            psi.FileName = programExecutable;
            psi.Arguments = command;
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;

            using var process = Process.Start(psi);

            process.WaitForExit();

            var output = process.StandardOutput.ReadToEnd();

            return output;
        }
        
        private static void getShell()
        {
            Debug.throwInfo("Looking for bash...");
            
            if (File.Exists("/bin/bash"))
            {
                Debug.throwInfo("Bash found.");
                shell = "/bin/bash";
            }
            else
            {
                Debug.throwWarning("Bash not found. Searching for other shells.");
                findOtherShell();
            }
        }
        
        private static void findOtherShell()
        {
            Debug.throwInfo("Looking for any other shell...");
            
            if (!File.Exists("/etc/shells"))
            {
                Debug.throwCriticalError(
                    "Could not find a valid shell.\n" +
                    "Both /bin/bash and /etc/shells are unavailable.\n"
                );
            }
            
            string[] lines = FileReader.getFileLines("/etc/shells");
        
            foreach (var line in lines)
            {
                if(line[0] == '#') continue;
        
                shell = line;
                Debug.throwInfo("Found " + shell + " shell.");
                
                break;
            }
        }

    }
}