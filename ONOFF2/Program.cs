using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONOFF2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choice :");
            Console.WriteLine("1. Wait for ending child process");
            Console.WriteLine("2. Kill child process");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Incorrect! Type 1 or 2.");
                return;
            }

            Process process = new Process();
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = @"C:\\Windows\\System32\\notepad.exe",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                };

                process.StartInfo = startInfo;
                process.Start();

                if (choice == 1)
                {
                    process.WaitForExit();
                    int exitCode = process.ExitCode;
                    Console.WriteLine($"Child process ending with code: {exitCode}");
                }
                else if (choice == 2)
                {
                    if (!process.HasExited)
                    {
                        process.Kill();
                        Console.WriteLine("Child process has been killed.");
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect! Type 1 or 2.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                if (process != null)
                {
                    process.Close();
                    process.Dispose();
                }
            }
        }
    }
}
