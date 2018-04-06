using System;
using System.Threading;

class Program
{
    private static object lockOn = new object();
    public static void Main()
    {
        Console.WriteLine("Main thread starting...");
        Thread aThread1 = new Thread(new ParameterizedThreadStart(WorkThread));
        Thread aThread2 = new Thread(new ParameterizedThreadStart(WorkThread));
        aThread1.Start(new ActionDelegate(Tick));
        aThread2.Start(new ActionDelegate(Tock));
        aThread1.Join();
        aThread2.Join();
        Console.WriteLine("Main thread ending.");
    }
    private delegate void ActionDelegate(bool isRunning);
    private static void WorkThread(object aAction)
    {
        for (int i = 0; i < 5; i++)
        {
            (aAction as ActionDelegate)(true);
        }
        (aAction as ActionDelegate)(false);
    }
    private static void Tick(bool isRunning)
    {
        lock (lockOn)
        {
            if (isRunning)
            {
                Console.WriteLine("Tick"); Monitor.Pulse(lockOn); Monitor.Wait(lockOn);
            }
            else Monitor.Pulse(lockOn);
        }
    }
    private static void Tock(bool isRunning)
    {
        lock (lockOn)
        {
            if (isRunning)
            {
                Console.WriteLine("Tock"); Monitor.Pulse(lockOn); Monitor.Wait(lockOn);
            }
            else Monitor.Pulse(lockOn);
        }
    }
}

