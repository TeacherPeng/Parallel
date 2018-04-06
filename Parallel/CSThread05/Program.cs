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
    private delegate void ActionDelegate();
    private static void WorkThread(object aAction)
    {
        for (int i = 0; i < 5; i++)
        {
            (aAction as ActionDelegate)();
        }
    }
    private static void Tick()
    {
        lock (lockOn)
        {
            Console.WriteLine("Tick");
            Monitor.Pulse(lockOn);
            Monitor.Wait(lockOn);
        }
    }
    private static void Tock()
    {
        lock (lockOn)
        {
            Console.WriteLine("Tock");
            Monitor.Pulse(lockOn);
            Monitor.Wait(lockOn);
        }
    }
}