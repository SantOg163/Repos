using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartAndKillProcess();
            Console.ReadKey();
        }
        static void StartAndKillProcess()
        {
            Process process = new Process();
            try
            {
                process = Process.Start("MicrosoftEdge.exe", "www.youtube.com");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message); 
            }
            Console.Write("--> Hit enter to kill {0}...", process.ProcessName);
            Console.ReadLine();
            // Уничтожить процесс 
            try
            {
                process.Kill();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void ListAllRunningProcesses()
        {
            // Получить все процессы на локальной машине, упорядоченные по PID.
            var runningProcs = from proc in Process.GetProcesses(".") orderby proc.Id select proc;
            // Вывести для каждого процесса идентификатор PID и имя.
            foreach (var p in runningProcs)
            {
                string info = $"-> PID: {p.Id}\tName: {p.ProcessName}";
                Console.WriteLine(info);
            }
        }
        static void EnumThreadsForPid(int pID)
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(pID);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;

            }
            // Вывести статистические сведения по каждому потоку в указанном процессе.
            Console.WriteLine("Here are the threads used by: {0}",
            theProc.ProcessName);
            ProcessThreadCollection theThreads = theProc.Threads;
            foreach (ProcessThread pt in theThreads)
                Console.WriteLine($"-> Thread ID: {pt.Id}\tStart Time: { pt.StartTime.ToShortTimeString()}\tPriority: { pt.PriorityLevel}");
        }

    }
}
